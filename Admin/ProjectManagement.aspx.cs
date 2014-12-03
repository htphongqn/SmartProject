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
            LoadProject();
        }
    }
    private void LoadProject()
    {
        DataTable dt = _db.GetList_Projects_Admin();
        grvProject.DataSource = dt;
        grvProject.DataBind();
    }
    protected void btnReMove_Click(object sender, EventArgs e)
    {
        string ids = "";
        for (int i = 0; i < grvProject.Rows.Count; i++)
        {
            CheckBox checkbox = (CheckBox)grvProject.Rows[i].FindControl("chkSelected");
            if (checkbox.Checked)
            {
                ids += checkbox.CssClass+",";

            }
           
        }
        if (ids != "")
        {
            int a = _db.Delete_ProjectEmps_ByprojectIDs(ids);
            LoadProject();
        }
        
    }
    protected void grvProject_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvProject.PageIndex = e.NewPageIndex;
        LoadProject();
    }
    protected void btnFilter_Click(object sender, EventArgs e)
    {
        string proName = txtUserlist.Text;
        if (proName == "Enter project name")
        {
            proName = "";
        }
        DataView dataView = new DataView(_db.GetList_Projects_Admin());

        dataView.RowFilter = "ProjectName like '%" + proName+ "%'";
        grvProject.DataSource = dataView;
        grvProject.DataBind();
       

    }
}