using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Site_Employee : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Employee"] != null)
        {
            DataRow row = (DataRow)Session["Employee"];
            lbId.Text ="Employee ID: "+ BaseView.GetStringFieldValue(row, "EmpId");
            lbName.Text = "Employee Name: " + BaseView.GetStringFieldValue(row, "EmpName");
        }
        else
        {
            Response.Redirect("~/login.aspx");
        }
    }
    protected void lbLogOut_Click(object sender, EventArgs e)
    {
        Session["Employee"] = null;
        Response.Redirect("~/login.aspx");
    }
    protected void lbChangePass_Click(object sender, EventArgs e)
    {
        if (Session["Employee"] != null)
        {
            DataRow row = (DataRow)Session["Employee"];
            string empID = BaseView.GetStringFieldValue(row, "EmpId");
            Response.Redirect("~/ChangePass_Employee.aspx?EmpID="+empID);
        }
    }
}
