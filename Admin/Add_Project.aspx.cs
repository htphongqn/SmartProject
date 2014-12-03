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
            LoadMember();
            LoadInfoProject();
        }
        txtDate.Text = DateTime.Now.ToString();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (ddlAssign.SelectedIndex > 0)
        {
            for (int i = 0; i < lstMember.Items.Count; i++)
            {
                if (lstMember.SelectedValue == lstMember.Items[i].Value)
                {
                    return;
                }
            }
            ListItem item = new ListItem(ddlAssign.SelectedItem.Text, ddlAssign.SelectedValue);
            lstMember.Items.Add(item);
            ListItem item2 = new ListItem(ddlAssign.SelectedItem.Text, ddlAssign.SelectedValue);
            ddlAssign.Items.Remove(item2);
        }
    }
    private void LoadMember()
    {
        DataTable dt;
        dt = _db.GetList_Employees();
        foreach (DataRow rows in dt.Rows)
        {
            ListItem item = new ListItem(BaseView.GetStringFieldValue(rows, "FirstName")+" "+BaseView.GetStringFieldValue(rows, "LastName"), BaseView.GetStringFieldValue(rows, "EmpId"));
            ddlAssign.Items.Add(item);
        }
        ListItem items = new ListItem("(Select)", "");
        ddlAssign.Items.Insert(0, items);

    }
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        if (lstMember.SelectedIndex >= 0)
        {
            ListItem item2 = new ListItem(lstMember.SelectedItem.Text, lstMember.SelectedValue);
            ddlAssign.Items.Add(item2);

            ListItem item = new ListItem(lstMember.SelectedItem.Text, lstMember.SelectedValue);
            lstMember.Items.Remove(item);

        }
    }
    private DateTime Date(string fromTime)
    {
        DateTime fromT = DateTime.MinValue;
        DateTime.TryParse(fromTime, out fromT);
        if (fromT == DateTime.MinValue)
            fromT = DateTime.Now;
        return fromT;
    }
    
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string IdOld = "";
        if (!String.IsNullOrEmpty(Request.QueryString["ProjectID"]))
        {
            IdOld = Request.QueryString["ProjectID"];
        }
        string id = _db.InsertUpdate_Projects(txtProjectID.Text,txtName.Text, null, Date(txtDate.Text),IdOld);
        string projectID =id.ToString();
        string idEmps ="";
        if (id != "-1")
        {
            if (lstMember.Items.Count > 0)
            {
                for (int i = 0; i < lstMember.Items.Count; i++)
                {
                    idEmps += lstMember.Items[i].Value + ",";
                }
                int autoid = _db.Insert_ProjectEmps_ByEmpIds(projectID, idEmps);
            }

            Response.Redirect("~/Admin/ProjectManagement.aspx");
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/ProjectManagement.aspx");
    }
    private void LoadInfoProject()
    {
        if (!String.IsNullOrEmpty(Request.QueryString["ProjectID"]))
        {
            lbTitle.Text = "Edit Project Info";
            string projectID = Request.QueryString["ProjectID"];
            txtProjectID.Text = projectID;
            DataRow row = _db.GetInfo_Projects_ByprojectID(projectID);
            txtName.Text = BaseView.GetStringFieldValue(row, "ProjectName");
            txtDate.Text = BaseView.GetStringFieldValue(row, "CreatedDate");
            DataTable dt = _db.GetList_Employees_ByprojectID(projectID);
            foreach (DataRow rows in dt.Rows)
            {
                ListItem item = new ListItem(BaseView.GetStringFieldValue(rows, "EmpName"), BaseView.GetStringFieldValue(rows, "EmpID"));
                lstMember.Items.Add(item);
                ddlAssign.Items.Remove(item);
            }

        }
    }
}