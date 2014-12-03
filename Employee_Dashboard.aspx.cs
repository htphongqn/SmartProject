using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Employee_Dashboard : System.Web.UI.Page
{
    DBClass _db = new DBClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadName();
            LoadTask();
            Load_Status();
            LoadProject();
            LoadTime();
        }
    }
    private void LoadName()
    {
        if (Session["ProjectId"] != null)
        {
            string projectID = (string)Session["ProjectId"];
            lbProjectName.Text = "Project name: " + _db.Get_ProjectName_ById(projectID);
            lbProjectName.CssClass = projectID.ToString();
        }
        DateTime now = DateTime.Now;
        lbToDay.Text = "To Day: " + now.Month + "/" + now.Day + "/" + now.Year;
    }
    private void Load_Status()
    {
        DataTable dt = new DataTable();
        dt = _db.GetList_TaskStatus();
        ddlStatus.DataSource = dt;
        ddlStatus.DataBind();
        //ListItem item = new ListItem("-------------- select ----------------", "");
        //ddlStatus.Items.Insert(0, item);
    }
    private void LoadTask()
    {
        if (Session["Employee"] != null && Session["ProjectId"] != null)
        {
            DataRow row = (DataRow)Session["Employee"];
            int empID = BaseView.GetIntFieldValue(row, "EmpId");
            string ID = (string)Session["ProjectId"];
            string projectID = lbProjectName.CssClass;
            DataTable dt = _db.GetList_Tasks(empID, projectID);
            grvToDoList.DataSource = dt;
            grvToDoList.DataBind();
        }
    }
    protected void btnReMove_Click(object sender, EventArgs e)
    {
        if (Session["Employee"] != null && Session["ProjectId"] != null)
        {
            DataRow row = (DataRow)Session["Employee"];
            int empID = BaseView.GetIntFieldValue(row, "EmpId");
            string ids = "";
            for (int i = 0; i < grvToDoList.Rows.Count; i++)
            {
                CheckBox checkbox = (CheckBox)grvToDoList.Rows[i].FindControl("chkSelected");
                if (checkbox.Checked)
                {
                    ids += checkbox.CssClass + ",";
                }
            }

            int a = _db.Delete_Tasks_ByTaskIds(empID,ids);
            LoadTask();
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        pntable.Visible = true;
        IsAdd(true);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Session["Employee"] != null)
        {
            DataRow row = (DataRow)Session["Employee"];
            int empID = BaseView.GetIntFieldValue(row, "EmpId");

            int projectID = Convert.ToInt32(lbProjectName.CssClass);
            int status = Convert.ToInt32(ddlStatus.SelectedValue);

            string desc="", note="";

            if (txtDescription.Text != "Description")
            {
                desc = txtDescription.Text;
            }

            if (txtNote.Text != "Notes")
            {
                note = txtNote.Text;
            }

            int i = _db.InsertUpdate_Tasks(0, empID, projectID, desc, status, fromDate(txtStart.Text + " " + ddlHstart.SelectedItem.Text + ":" + ddMstart.SelectedItem.Text+":00"), toDate(txtEnd.Text + " " + ddlHend.SelectedItem.Text + ":" + ddlMend.SelectedItem.Text+":00"), note);
        }
        LoadTask();
        pntable.Visible = false;
        IsAdd(false);
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        pntable.Visible = false ;
        IsAdd(false);
    }
    private void IsAdd(bool q)
    {
        btnSave.Visible = q;
        btncancel.Visible = q;
        btnAdd.Visible = !q;
        btnReMove.Visible = !q;
    }
    private DateTime fromDate(string fromTime)
    {
        DateTime fromT = DateTime.MinValue;
        DateTime.TryParse(fromTime, out fromT);
        if (fromT == DateTime.MinValue)
            fromT = DateTime.Parse("1/1/1753 12:00:00 AM");
        return fromT;
    }
    /**
    * [Get TO Date] get to date.
    * */
    private DateTime toDate(string toTime)
    {
        DateTime toT;
        DateTime.TryParse(toTime, out toT);
        if (toT == DateTime.MinValue)
            toT = DateTime.MaxValue;
        return toT;
    }
    protected void ddlProject_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Session["Employee"] != null)
        {
            if (ddlProject.SelectedIndex>0)
            {
                DataRow row = (DataRow)Session["Employee"];
                int empID = BaseView.GetIntFieldValue(row, "EmpId");
                string projectID =ddlProject.SelectedValue;
                DataTable dt = _db.GetList_Tasks(empID, projectID);
                grvToDoList.DataSource = dt;
                grvToDoList.DataBind();
               // row = _db.Get_ProjectName_ById(projectID);
                lbProjectName.Text = "Project name: "+ddlProject.SelectedItem.Text;
                lbProjectName.CssClass = projectID.ToString();
            }

        }
    }
    private void LoadProject()
    {
        if (Session["Employee"] != null )
        {
            DataRow row = (DataRow)Session["Employee"];
            int empID = BaseView.GetIntFieldValue(row, "EmpId");
            DataTable dt = new DataTable();
            dt = _db.GetList_Projects_ByEmpId(empID);
            ddlProject.DataSource = dt;
            ddlProject.DataBind();
            ListItem item = new ListItem("(Select)", "");
            ddlProject.Items.Insert(0, item);
        }
    }
    protected void grvToDoList_PageIndexChanged(object sender, EventArgs e)
    {
       
    }
    protected void grvToDoList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvToDoList.PageIndex = e.NewPageIndex;
        LoadTask();
    }
    private void LoadTime()
    {   string time="";
        for (int i = 0; i < 24; i++)
        {
            time = i.ToString();
            if(time.Length <2)
            {
                time = "0"+time;
            }
            ListItem item = new ListItem(time,time);
            ddlHend.Items.Add(item);
            ddlHstart.Items.Add(item);
        }
        for (int i = 0; i < 59; i++)
        {
            time = i.ToString();
            if (time.Length < 2)
            {
                time = "0" + time;
            }
            ListItem item = new ListItem(time, time);
            ddlMend.Items.Add(item);
            ddMstart.Items.Add(item);
        }
        time = DateTime.Now.Hour.ToString();
        if (time.Length < 2)
        {
            time = "0" + time;
        }
        ddlHend.SelectedValue = time;
        ddlHstart.SelectedValue = time;
        time = DateTime.Now.Minute.ToString();
        if (time.Length < 2)
        {
            time = "0" + time;
        }
        ddlMend.SelectedValue = time;
        ddMstart.SelectedValue = time;
    }
}