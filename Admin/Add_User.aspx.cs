using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Add_User : System.Web.UI.Page
{
    DBClass _db = new DBClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadEmpStatic();
            LoadProject();
            LoadInfoUser();
            
        }
    }
    private void LoadEmpStatic()
    {
        DataTable dt = new DataTable();
        dt = _db.GetList_EmpStatus();
        ddlStatus.DataSource = dt;
        ddlStatus.DataBind();
    }
    private void LoadProject()
    {
            DataTable dt;
            dt = _db.GetList_Projects();
            ddlProject.DataSource = dt;
            ddlProject.DataBind();
            ListItem item = new ListItem("(Select)", "");
            ddlProject.Items.Insert(0, item);
      
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (ddlProject.SelectedIndex > 0)
        {
            for(int i=0; i<lstProject.Items.Count;i++)
            {
                if (ddlProject.SelectedValue == lstProject.Items[i].Value)
                {
                    return;
                }
            }
            ListItem item = new ListItem(ddlProject.SelectedItem.Text, ddlProject.SelectedValue);
            lstProject.Items.Add(item);
            ListItem item2 = new ListItem(ddlProject.SelectedItem.Text, ddlProject.SelectedValue);
            ddlProject.Items.Remove(item2);
        }
    }
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        if (lstProject.SelectedIndex >= 0)
        {
            ListItem item2 = new ListItem(lstProject.SelectedItem.Text, lstProject.SelectedValue);
            ddlProject.Items.Add(item2);

            ListItem item = new ListItem(lstProject.SelectedItem.Text, lstProject.SelectedValue);
            lstProject.Items.Remove(item);
            
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int? idOld = null;
        if (!String.IsNullOrEmpty(Request.QueryString["EmpID"]))
        {
            idOld = Convert.ToInt32(Request.QueryString["EmpID"]);
        }
        int id = _db.InsertUpdate_Employees(txtFirst.Text, txtLast.Text,Convert.ToInt32(txtID.Text), txtConfirm.Text, Convert.ToInt32(ddlStatus.SelectedValue),idOld);
        string idProjects = "";
        if (lstProject.Items.Count > 0)
        {
            for (int i = 0; i < lstProject.Items.Count; i++)
            {
               idProjects +=lstProject.Items[i].Value +",";
            }
            int autoid = _db.Insert_ProjectEmps_ByprojectIDs(id, idProjects);
            Response.Redirect("~/Admin/User_Management.aspx");
        }
    }
    private void LoadInfoUser()
    {
        if (!String.IsNullOrEmpty(Request.QueryString["EmpID"]))
        {
            lbTitle.Text = "Edit Employee Info";
            int id = Convert.ToInt32(Request.QueryString["EmpID"]);
            DataRow row = _db.GetInfo_Employee_ByEmpId(id);
            txtFirst.Text = BaseView.GetStringFieldValue(row, "FirstName");
            txtLast.Text = BaseView.GetStringFieldValue(row, "LastName");
            txtID.Text = id.ToString();
            //txtID.Enabled = false;
            txtPass.Enabled = false;
            txtConfirm.Enabled = false;
            rqPass.Enabled = false;
            ddlStatus.SelectedValue = BaseView.GetStringFieldValue(row, "EmpStatusId");
            DataTable dt = _db.GetList_Projects_ByEmpId(id);
            foreach(DataRow rows in dt.Rows)
            {
                ListItem item = new ListItem(BaseView.GetStringFieldValue(rows, "ProjectName"), BaseView.GetStringFieldValue(rows, "ProjectID"));
                lstProject.Items.Add(item);
                ddlProject.Items.Remove(item);
            }
            
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/User_Management.aspx");
    }
}