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
           // GetListProject();
            txtEmpID.Text = "";
            Session["Admin"] = null;
            Session["Employee"] = null;
        }
    }
   
  
    protected void btnLogAdmin_Click(object sender, EventArgs e)
    {
        DataRow row;
        
            if (ddlProject.SelectedIndex > 0)
            {
                row = _db.Login_Employee(Convert.ToInt32(txtEmpID.Text), txtPassEmp.Text, ddlProject.SelectedValue);
                Session["ProjectId"] = ddlProject.SelectedValue;
                if (row != null && BaseView.GetStringFieldValue(row, "IsOk") == "1")
                {
                    Session["Employee"] = row;
                    Response.Redirect("~/Employee_Dashboard.aspx");
                }
                else
                {
                    lberorr.Text = "Username or password is correct.";
                    lberorr.Visible = true;
                }
            }
            else
            {
                lberorr.Text = "select project";
            }
           
       
    }
    private void GetListProject()
    {
        //try
        //{i
            
            DataTable dt = new DataTable();
            dt = _db.GetList_Projects_ByEmpId(ToSQL.SQLToInt(txtEmpID.Text));
            ddlProject.DataSource = dt;
            ddlProject.DataBind();
            ListItem item = new ListItem("(select)", "");
            ddlProject.Items.Insert(0, item);
        //}
        //catch (Exception)
        //{
        //}
    }
    protected void ddlProject_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlProject.SelectedIndex > 0)
        {
            Session["ProjectId"] = ddlProject.SelectedValue;
        }
       
    }
    protected void txtEmpID_TextChanged(object sender, EventArgs e)
    {
            if (IsPostBack)
            {
                if (txtEmpID.Text != "")
                    GetListProject();

            }
        
    }
    protected void txtEmpID_Unload(object sender, EventArgs e)
    {

    }
}