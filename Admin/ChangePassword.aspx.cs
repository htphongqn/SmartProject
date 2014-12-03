using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChangePassword : System.Web.UI.Page
{
    DBClass _db = new DBClass();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(Request.QueryString["EmpID"]))
        {
            int i = _db.ChangePassword(Convert.ToInt32(Request.QueryString["EmpID"]), txtCurrent.Text, txtConfirm.Text);
            if (i == 0)
            {
                lbchanges.Text = "Error!";
            }
            else
            {
                //MessagesBox.Show("Successfull");
                Response.Redirect("~/Admin/User_Management.aspx");
            }
        }
        if (!String.IsNullOrEmpty(Request.QueryString["UserId"]))
        {
            int i = _db.ChangePassword_Admin(Convert.ToInt32(Request.QueryString["UserId"]), txtCurrent.Text, txtConfirm.Text);
            if (i == 0)
            {
                lbchanges.Text = "Error!";
            }
            else
            {
                Response.Redirect("~/Admin/User_Management.aspx");
            }
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/User_Management.aspx");
    }
}