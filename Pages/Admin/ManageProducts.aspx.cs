using System;
using System.Collections;

public partial class Pages_Admin_ManageProducts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            GetImages();

        if (!String.IsNullOrWhiteSpace(Request.QueryString["id"]))
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            FillPage(id);
        }
    }

    private void FillPage(int id)
    {
        ProductModel productModel = new ProductModel();
        Product product = productModel.GetProduct(id);

        txtDescription.Text = product.Description;
        txtName.Text = product.Name;
        txtPrice.Text = product.Price.ToString();

        ddlImage.SelectedValue = product.Image;
        ddlType.SelectedValue = product.TypeID.ToString();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ProductModel productModel = new ProductModel();
        Product product = CreateProduct();

        if (!String.IsNullOrWhiteSpace(Request.QueryString["id"]))
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            lblResult.Text = productModel.UpdateProduct(id, product);
        }
        else
        {
            lblResult.Text = productModel.InsertProduct(product);
        }

    }

    private void GetImages()
    {
        try
        {
            string[] images = System.IO.Directory.GetFiles(Server.MapPath("~/Images/Products/"));

            ArrayList imageList = new ArrayList();
            foreach (string image in images)
            {
                string imageName = image.Substring(image.LastIndexOf(@"\", StringComparison.Ordinal) + 1);
                imageList.Add(imageName);

            }
            ddlImage.DataSource = imageList;
            ddlImage.AppendDataBoundItems = true;
            ddlImage.DataBind();
        }
        catch (Exception e)
        {
            lblResult.Text = e.ToString();
        }

    }
    private Product CreateProduct()
    {
        Product product = new Product();
        product.Name = txtName.Text;

        double strTxt = Convert.ToDouble(txtPrice.Text);
        product.Price = strTxt;
        product.TypeID = Convert.ToInt32(ddlType.SelectedValue);
        product.Description = txtDescription.Text;
        product.Image = ddlImage.SelectedValue;

        return product;

    }


}