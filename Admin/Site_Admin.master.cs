using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Site_Admin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Admin"] != null)
        {
            //DataRow row = (DataRow)Session["Employee"];
            //lbId.Text = "Employee ID: " + BaseView.GetStringFieldValue(row, "EmpId");
            //lbName.Text = "Employee Name: " + BaseView.GetStringFieldValue(row, "EmpName");
        }
        else
        {
            Response.Redirect("~/Admin/login.aspx");
        }
    }
    protected void lbLogOut_Click(object sender, EventArgs e)
    {
        Session["Admin"] = null;
        Response.Redirect("~/Admin/login.aspx");
        
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (Session["Admin"] != null)
        {
            DataRow row = (DataRow)Session["Admin"];
            string userID = BaseView.GetStringFieldValue(row, "UserId");
            Response.Redirect("~/Admin/ChangePassword.aspx?UserId=" + userID);
        }
    }
}
