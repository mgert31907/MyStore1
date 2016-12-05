using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Management : System.Web.UI.Page
{

    protected void grdProducts_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewRow row = grdProducts.Rows[e.NewEditIndex];
        int rowId = Convert.ToInt32(row.Cells[1].Text);
        Response.Redirect("~/Pages/Admin/ManageProducts.aspx?id=" + rowId);
    }
}