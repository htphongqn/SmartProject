using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Admin_Dahboard : System.Web.UI.Page
{
    DBClass _db = new DBClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadUser();
        }
    }
    private void LoadUser()
    {
        DataTable dt = _db.GetList_Employee_Admin();
        grvUser.DataSource = dt;
        grvUser.DataBind();
    }
    protected void btnActive_Click(object sender, EventArgs e)
    {
        int id = 0;

        for (int i = 0; i < grvUser.Rows.Count; i++)
        {
            CheckBox checkbox = (CheckBox)grvUser.Rows[i].FindControl("chkSelected");
            if (checkbox.Checked)
            {
                id = Convert.ToInt32(checkbox.CssClass);
                int a = _db.Active_DeActive_Employees(id, true);
            }
        }
        LoadUser();
    }
    protected void btnDeActive_Click(object sender, EventArgs e)
    {
        int id = 0;
        for (int i = 0; i < grvUser.Rows.Count; i++)
        {
            CheckBox checkbox = (CheckBox)grvUser.Rows[i].FindControl("chkSelected");
            if (checkbox.Checked)
            {
                id = Convert.ToInt32(checkbox.CssClass);
                 string empID ="";
                if (Session["Admin"] != null)
                {
                    DataRow row = (DataRow)Session["Admin"];
                     empID = "Employee ID: " + BaseView.GetStringFieldValue(row, "EmpId");
                }
                if (id != Convert.ToInt32(empID))
                {
                    int a = _db.Active_DeActive_Employees(id, false);
                }
                else
                {
                    lbError.Text = "Not deactive" ;
                }
            }
        }
        LoadUser();
    }
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        string ids = "";
        for (int i = 0; i < grvUser.Rows.Count; i++)
        {
            CheckBox checkbox = (CheckBox)grvUser.Rows[i].FindControl("chkSelected");
            if (checkbox.Checked)
            {
                ids += checkbox.CssClass + ",";

            }
            int a = _db.Delete_ProjectEmps_ByEmpIds(ids);
        }
        LoadUser();
    }
    protected void btnFilter_Click(object sender, EventArgs e)
    {
        string empName = txtUserlist.Text;
        if (empName  == "Enter employee name")
        {
            empName = "";
        }
        DataView dataView = new DataView(_db.GetList_Employee_Admin());
        dataView.RowFilter = "EmpName like '%" + empName + "%'";
        grvUser.DataSource = dataView;
        grvUser.DataBind();
    }
}