﻿using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Models;
using System.Data.Entity.Core.EntityClient;

public partial class Pages_Account_Register : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        // Default UserStore constructor uses the default connection string named: DefaultConnection
        var userStore = new UserStore<IdentityUser>();

        //Set ConnectionString to GarageConnectionString
        string entityConnectionString = System.Configuration.ConfigurationManager.
            ConnectionStrings["GarageDBEntities6"].ConnectionString;

        string providerConnectionString = new EntityConnectionStringBuilder(entityConnectionString).ProviderConnectionString;
        userStore.Context.Database.Connection.ConnectionString = providerConnectionString;

        
        var manager = new UserManager<IdentityUser>(userStore);



        //Create new user and try to store in DB.
        var user = new IdentityUser { UserName = txtUserName.Text };

        if (txtPassword.Text == txtConfirmPassword.Text)
        {
            try
            {
                IdentityResult result = manager.Create(user, txtPassword.Text);
                if (result.Succeeded)
                {
                    UserInformation userDetail = new UserInformation
                    {
                        Address = txtAddress.Text,
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        GUID = user.Id,
                        PostalCode = Convert.ToInt32(txtPostalCode.Text)
                    };

                    UserDetailModel model = new UserDetailModel();
                    model.InsertUserDetail(userDetail);

                    //Store user in DB
                    var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                    var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                    //If succeedeed, log in the new user and set a cookie and redirect to homepage
                    authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);
                    Response.Redirect("~/Index.aspx");
                }
                else
                {
                    litStatusMessage.Text = result.Errors.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                litStatusMessage.Text = "Try Logging in";
            }
        }
        else
        {
            litStatusMessage.Text = "Passwords must match!";
        }
    }
}