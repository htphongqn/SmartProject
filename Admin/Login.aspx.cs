using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class home : System.Web.UI.Page
{
    DBClass _db = new DBClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            Session["Admin"] = null;
            Session["Employee"] = null;
        }
    }
   
    protected void btnLogAdmin_Click(object sender, EventArgs e)
    {
            DataRow row;
            row = _db.Login_Admin(txtUserAdmin.Text, txtPassAdmin.Text);

            if (row != null && BaseView.GetStringFieldValue(row, "IsOk") == "1")
            {
                Session["Admin"] = row;
                Session["UserId"] = BaseView.GetStringFieldValue(row, "UserId");
                Response.Redirect("~/Admin/User_Management.aspx");
            }
            else
            {
                lberorr.Text = "Username or password is correct.";
                lberorr.Visible = true;
            }

        
    }

}