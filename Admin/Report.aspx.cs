using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Report : System.Web.UI.Page
{
    DBClass _db = new DBClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        //ChartItem();
        if (!IsPostBack)
        {
            LoadEmployee();
            LoadProject();
        }
        //Trasnform();
    }
    #region ConvertDate
    private DateTime fromDate(string fromTime)
    {
        DateTime fromT = DateTime.MinValue;
        if (fromTime == "")
            fromT = DateTime.Now;
        else
        {
            DateTime.TryParse(fromTime, out fromT);
            if (fromT == DateTime.MinValue)
                fromT = DateTime.Parse("1/1/1753 12:00:00 AM");
        }
        return fromT;
    }
    /**
    * [Get TO Date] get to date.
    * */
    private DateTime toDate(string toTime)
    {
        DateTime toT;
        if (toTime == "")
            toT = DateTime.Now;
        else
        {
            DateTime.TryParse(toTime, out toT);
            if (toT == DateTime.MinValue)
                toT = DateTime.MaxValue;
        }
        return toT;
    }
    private void LoadEmployee()
    {
        DataTable dtEmployee = _db.GetList_Employees();

        chkEmployee.DataSource = dtEmployee;
        chkEmployee.DataBind();
       
    }
    private void LoadProject()
    {
        DataTable dtProject = _db.GetList_Projects();
        chkProject.DataSource = dtProject;
        chkProject.DataBind();
      
    }
    private string GetEmpIds()
    {
        string EmpIds = "";
        for (int i = 0; i < chkEmployee.Items.Count; i++)
        {
            if (chkEmployee.Items[i].Selected)
                EmpIds += chkEmployee.Items[i].Value + ",";
        }
        return EmpIds;
    }
    private string GetProIds()
    {
        string ProIds = "";
        for (int i = 0; i < chkProject.Items.Count; i++)
        {
            if (chkProject.Items[i].Selected)
                ProIds += chkProject.Items[i].Value + ",";
        }
        return ProIds;
    }
    #endregion
    #region Table
    private void DailyEmployees()
    {
        string empIds = GetEmpIds();
        DataTable dataEmployee = _db.GetList_Employee_Report(fromDate("02/01/2014"), toDate("02/20/2014"), empIds);
       
        DataRow rowEmp = dataEmployee.Rows[0];
        int idEmp = Convert.ToInt32(BaseView.GetStringFieldValue(rowEmp, "EmpID"));
        string Name = BaseView.GetStringFieldValue(rowEmp, "EmpName");
        //lbTable.Text += DailyAllEmployees(9, Name);
        //}
    }
    //report 1
    private void CombinedReport()
    {

    }
    //report 2
    private void DailyEmployeeReport()
    {
        DataTable dataTime = _db.GetList2Date(fromDate(txtFrom.Text), toDate(txtTo.Text));
        string empTitle = "", projectTitle = "", datetime = "", duration="";
        DateTime fromdate = fromDate(txtFrom.Text);
        DateTime todate = toDate(txtTo.Text);
        int col = 0;
        string proIds = GetProIds();
        DataTable dataProject = _db.GetList_Projects_Report(fromdate, todate, proIds);
        col = 0;
        datetime += "<tr><td><ul>";
        foreach (DataRow row in dataTime.Rows)
        {
            DateTime date = BaseView.GetDateTimeFieldValue(row, "AtDate");
            datetime += "<li>" + date.Month + "/" + date.Day + "/" + date.Year + "</li>";
        }
        datetime += "<li style='font-weight:bold;background:#fff'>Total: </li>";
        datetime += "</ul></td>";

        foreach (DataRow rowPros in dataProject.Rows)
        {
            string idProject = BaseView.GetStringFieldValue(rowPros, "ProjectID");
            projectTitle += "<th>" + BaseView.GetStringFieldValue(rowPros, "ProjectName") + "</th>";

            DataTable tableDuration = _db.GetList_DurationOfEmployee_Report(null, idProject, fromdate, todate);
            duration += "<td><ul>";
            foreach (DataRow rowDur in tableDuration.Rows)
            {
                duration += "<li>" + BaseView.GetStringFieldValue(rowDur, "DurationHours") + "</li>";
            }
            DataRow dr = _db.GetDurationHours_ByFromDateToDate(null, idProject, fromdate, todate);
            if (dr != null)
            {
                duration += "<li style='font-weight:bold'>" + dr[0].ToString() + "</li>";
            }
            duration += "</ul></td>";
            col++;
        }
        projectTitle += "<th>" + "All Project" + "</th>";
        DataTable allProjectDuration = _db.GetList_DurationOfEmployee_Report(null, null, fromdate, todate);
       
        duration += "<td><ul>";
        col++;
        foreach (DataRow rowDur in allProjectDuration.Rows)
        {
            duration += "<li style='font-weight:bold'>" + BaseView.GetStringFieldValue(rowDur, "DurationHours") + "</li>";
        }
        DataRow drs = _db.GetDurationHours_ByFromDateToDate(null, null, fromdate, todate);
        if (drs != null)
        {
            duration += "<li style='font-weight:bold;background:#fff'>" + drs[0].ToString() + "</li>";
        }
        datetime += duration;
        datetime += "</tr>";
        empTitle += "<th colspan='" + col + "' class='ac'> " + "Work Duration" + "</th>";


        string table = "<table ><thead>";
        table += "<tr><th rowspan='2' > Date</th>" + empTitle + "</tr>";
        table += "<tr>" + projectTitle + "</tr>";
        table += "</thead>";
        table += "<tbody>";
        table += datetime;
        table += "</tbody>";
        table += "</table>";
        lbTable.Text = table;
    }
    //report 3
    private void MonthEmployeeReport()
    {

    }
    //report 4
    private void DailyAllEmployees_Report()
    {
        DateTime fromdate = fromDate(txtFrom.Text);
        DateTime todate = toDate(txtTo.Text);
        string empIds = GetEmpIds();
        DataTable dataEmp = _db.GetList_Employee_Report(fromdate, todate, empIds);
        DataTable dataTime = _db.GetList2Date(fromdate, todate);
        string empTitle = "", projectTitle = "", datetime = "", duration = "";
        int col = 0;

        foreach (DataRow rowEmp in dataEmp.Rows)
        {
            int EmpID = Convert.ToInt32(BaseView.GetStringFieldValue(rowEmp, "EmpID"));
            string Name = BaseView.GetStringFieldValue(rowEmp, "EmpName");
            string proIds = GetProIds();
            DataTable dataProject = _db.GetList_Projects_ByEmpId_Report(EmpID, fromdate, todate, proIds);// lay ten project 
            col = 0;
            datetime = "";
            datetime += "<tr><td><ul>";
            foreach (DataRow row in dataTime.Rows)// lay du lieu cot datetime
            {
                DateTime date = BaseView.GetDateTimeFieldValue(row, "AtDate");
                datetime += "<li>" + date.Month + "/" + date.Day + "/" + date.Year + "</li>";
            }
            datetime += "<li style='font-weight:bold;background:#fff'>Total: </li>";
            datetime += "</ul></td>";

            foreach (DataRow rowPros in dataProject.Rows)// lay du lieu theo Project ID
            {
                string idProject = BaseView.GetStringFieldValue(rowPros, "ProjectID");
                projectTitle += "<th>" + BaseView.GetStringFieldValue(rowPros, "ProjectName") + "</th>";

                DataTable tableDuration = _db.GetList_DurationOfEmployee_Report(EmpID, idProject, fromdate, todate);
                duration += "<td><ul>";
                foreach (DataRow rowDur in tableDuration.Rows)//do du lieu vao tung cot theo tung emp & project
                {
                    duration += "<li>" + BaseView.GetStringFieldValue(rowDur, "DurationHours") + "</li>";
                }
                DataRow dr = _db.GetDurationHours_ByFromDateToDate(EmpID, idProject, fromdate, todate);//cong du lieu theo tung cot
                if (dr != null)
                {
                    duration += "<li style='font-weight:bold;background:#fff'>" + dr[0].ToString() + "</li>";
                }
                duration += "</ul></td>";
                col++;
            }
            projectTitle += "<th>" + "All Project" + "</th>";
            DataTable allProjectDuration = _db.GetList_DurationOfEmployee_Report(EmpID, null, fromdate, todate);//cong tat ca du lieu theo project (all project)
            duration += "<td><ul>";
            col++;
            foreach (DataRow rowDur in allProjectDuration.Rows)
            {
                duration += "<li style='font-weight:bold;'>" + BaseView.GetStringFieldValue(rowDur, "DurationHours") + "</li>";
            }
            DataRow drs = _db.GetDurationHours_ByFromDateToDate(EmpID, null, fromdate, todate);////cong du lieu cot All project
            
            if (drs != null)
            {
                duration += "<li  style='font-weight:bold;background:#fff'>" + drs[0].ToString() + "</li>";
            }
            datetime += duration;
            datetime += "</tr>";
            empTitle += "<th colspan='" + col + "' class='ac'> " + Name + "</th>";
        }
        string table = "<table style='float:left'><thead>";
        table += "<tr><th rowspan='2' > Date</th>" + empTitle + "</tr>";
        table += "<tr>" + projectTitle + "</tr>";
        table += "</thead>";
        table += "<tbody>";
        table += datetime;
        table += "</tbody>";
        table += "</table>";
        lbTable.Text = table;

    }
    //report 5
    private void DailyProjectReport()
    {
        DateTime fromdate = fromDate(txtFrom.Text);
        DateTime todate = toDate(txtTo.Text);
        string empIds = GetEmpIds();
        DataTable dataEmp = _db.GetList_Employee_Report(fromdate, todate, empIds);
        DataTable dataTime = _db.GetList2Date(fromdate, todate);
        string empTitle = "", projectTitle = "", datetime = "", duration = "";
        int col = 0;
        datetime += "<td><ul>";
        foreach (DataRow row in dataTime.Rows)// lay du lieu cot datetime
        {
            DateTime date = BaseView.GetDateTimeFieldValue(row, "AtDate");
            datetime += "<li>" + date.Month + "/" + date.Day + "/" + date.Year + "</li>";
        }
        datetime += "<li style='font-weight:bold;background:#fff'>Total: </li>";
        datetime += "</ul></td>";

        foreach (DataRow rowEmp in dataEmp.Rows)//lay du lieu tung cot theo employee id
        {
            int EmpID = Convert.ToInt32(BaseView.GetStringFieldValue(rowEmp, "EmpID"));
            string Name = BaseView.GetStringFieldValue(rowEmp, "EmpName");
            projectTitle += "<th>" + Name + "</th>";

            DataTable allProjectDuration = _db.GetList_DurationOfEmployee_Report(EmpID, null, fromdate, todate);
            duration = "<td><ul>";
            col++;
            foreach (DataRow rowDur in allProjectDuration.Rows)//lay du lieu tung cot emp
            {
                duration += "<li >" + BaseView.GetStringFieldValue(rowDur, "DurationHours") + "</li>";
            }
            DataRow dr = _db.GetDurationHours_ByFromDateToDate(EmpID, null, fromdate, todate);//cong du lieu cot emp
            if (dr != null)
            {
                duration += "<li style='font-weight:bold'>" + dr[0].ToString() + "</li>";
            }
            duration += "</ul></td>";
            
            datetime += duration;
            
        }
        DataTable allEmployeeDuration = _db.GetList_DurationOfEmployee_Report(null, null, fromdate, todate);////lay du lieu cot All
        duration = "<td><ul>";
        foreach (DataRow rowEm in allEmployeeDuration.Rows)
        {
            duration += "<li style='font-weight:bold;'>" + BaseView.GetStringFieldValue(rowEm, "DurationHours") + "</li>";
        }
        DataRow drs = _db.GetDurationHours_ByFromDateToDate(null, null, fromdate, todate);////cong du lieu cot All 
        if (drs != null)
        {
            duration += "<li style='font-weight:bold;background:#fff'>" + drs[0].ToString() + "</li>";
        }
        duration += "</ul></td>";
        datetime += duration;

        projectTitle += "<th>" + "All employee" + "</th>";
        
        empTitle += "<th colspan='" + (col+1) + "' class='ac'> " + "Working duration" + "</th>";
        string table = "<table style='float:left'><thead>";
        table += "<tr><th rowspan='2' > Date</th>" + empTitle + "</tr>";
        table += "<tr>" + projectTitle + "</tr>";
        table += "</thead>";
        table += "<tbody>";
        table += "<tr>"+datetime+"</tr>";
        table += "</tbody>";
        table += "</table>";
        lbTable.Text = table;
    }
    // report 6
    private void MonthProjectReport()
    {

    }
    //report 7
    private void DailyAllProject_Reort()
    {
        DateTime fromdate = fromDate(txtFrom.Text);
        DateTime todate = toDate(txtTo.Text);
        string proIds = GetProIds(); string empIds = GetEmpIds();
        DataTable dataPro = _db.GetList_Projects_Report(fromdate, todate, proIds);
        DataTable dataTime = _db.GetList2Date(fromdate, todate);
        string empTitle = "", projectTitle = "", datetime = "", duration = "";
        int col = 0;

        foreach (DataRow rowPro in dataPro.Rows)
        {
            string ProID = BaseView.GetStringFieldValue(rowPro, "ProjectID");
            string ProName = BaseView.GetStringFieldValue(rowPro, "ProjectName");
            DataTable dataEmployee = _db.GetList_Employees_ByprojectID_Report(ProID, fromdate, todate, empIds);
            col = 0;
            datetime = "";
            datetime += "<tr><td><ul>";
            foreach (DataRow row in dataTime.Rows)
            {
                DateTime date = BaseView.GetDateTimeFieldValue(row, "AtDate");
                datetime += "<li>" + date.Month + "/" + date.Day + "/" + date.Year + "</li>";
            }
            datetime += "<li style='font-weight:bold;background:#fff'>Total: </li>";
            datetime += "</ul></td>";

            foreach (DataRow rowEmp in dataEmployee.Rows)
            {
                int idEmp = Convert.ToInt32(BaseView.GetStringFieldValue(rowEmp, "EmpID"));
                empTitle += "<th>" + BaseView.GetStringFieldValue(rowEmp, "EmpName") + "</th>";

                DataTable tableDuration = _db.GetList_DurationOfEmployee_Report(idEmp, ProID, fromdate, todate);
                duration += "<td><ul>";
                foreach (DataRow rowDur in tableDuration.Rows)
                {
                    duration += "<li>" + BaseView.GetStringFieldValue(rowDur, "DurationHours") + "</li>";
                }
                DataRow dr = _db.GetDurationHours_ByFromDateToDate(idEmp, ProID, fromdate, todate);
                if (dr != null)
                {
                    duration += "<li style='font-weight:bold;background:#fff'>" + dr[0].ToString() + "</li>";
                }
                duration += "</ul></td>";
                col++;
            }
            empTitle += "<th>" + "All Employees" + "</th>";
            //DataTable allProjectDuration = _db.GetList_DurationOfEmployee_Report(EmpID, null, fromdate, todate);
            DataTable alltableDuration = _db.GetList_DurationOfEmployee_Report(null, ProID, fromdate, todate);
            duration += "<td><ul>";
            col++;
            foreach (DataRow rowDur in alltableDuration.Rows)
            {
                duration += "<li style='font-weight:bold'>" + BaseView.GetStringFieldValue(rowDur, "DurationHours") + "</li>";
            }
            DataRow drs = _db.GetDurationHours_ByFromDateToDate(null, ProID, fromdate, todate);
            if (drs != null)
            {
                duration += "<li  style='font-weight:bold;background:#fff'>" + drs[0].ToString() + "</li>";
            }
            datetime += duration;
            datetime += "</tr>";
            projectTitle += "<th colspan='" + col + "' class='ac'> " + ProName + "</th>";
        }
        string table = "<table style='float:left'><thead>";
        table += "<tr><th rowspan='2' > Date</th>" +  projectTitle+ "</tr>";
        table += "<tr>" + empTitle + "</tr>";
        table += "</thead>";
        table += "<tbody>";
        table += datetime;
        table += "</tbody>";
        table += "</table>";
        lbTable.Text = table;
    }
    
    #endregion
    #region Chart

    private DataTable Tb()
    {
        DataTable myTbl = new DataTable();
        myTbl.Columns.Add("ID", typeof(int));
        myTbl.Columns.Add("Name", typeof(string));
        myTbl.Columns.Add("Data", typeof(string));

        DataRow empployee1 = myTbl.NewRow();
        empployee1["ID"] = "1";
        empployee1["Name"] = "HomeCare";
        empployee1["Data"] = "2,5,3,1";
        myTbl.Rows.Add(empployee1);

        empployee1 = myTbl.NewRow();
        empployee1["ID"] = "2";
        empployee1["Name"] = "TryOn";
        empployee1["Data"] = "2,3,6";
        myTbl.Rows.Add(empployee1);

        empployee1 = myTbl.NewRow();
        empployee1["ID"] = "2";
        empployee1["Name"] = "TryOns";
        empployee1["Data"] = "4,3,4,1,2,4";
        myTbl.Rows.Add(empployee1);

        empployee1 = myTbl.NewRow();
        empployee1["ID"] = "2";
        empployee1["Name"] = "TryOnsa";
        empployee1["Data"] = "4,3,4,1,2,4,3,4,1";
        myTbl.Rows.Add(empployee1);

        empployee1 = myTbl.NewRow();
        empployee1["ID"] = "2";
        empployee1["Name"] = "TryOn";
        empployee1["Data"] = "4,3,4,1,2,4,3,9";
        myTbl.Rows.Add(empployee1);

        empployee1 = myTbl.NewRow();
        empployee1["ID"] = "2";
        empployee1["Name"] = "TryOns";
        empployee1["Data"] = "6,3,9,8,9,8";
        myTbl.Rows.Add(empployee1);

        empployee1 = myTbl.NewRow();
        empployee1["ID"] = "2";
        empployee1["Name"] = "TryOnsa";
        empployee1["Data"] = "6,3,4,1";
        myTbl.Rows.Add(empployee1);

        empployee1 = myTbl.NewRow();
        empployee1["ID"] = "2";
        empployee1["Name"] = "TryOn";
        empployee1["Data"] = "6,3,9";
        myTbl.Rows.Add(empployee1);

        empployee1 = myTbl.NewRow();
        empployee1["ID"] = "2";
        empployee1["Name"] = "TryOns";
        empployee1["Data"] = "6,3,9,8,9,8";
        myTbl.Rows.Add(empployee1);

        empployee1 = myTbl.NewRow();
        empployee1["ID"] = "2";
        empployee1["Name"] = "TryOnsa";
        empployee1["Data"] = "6,3,4,1";
        myTbl.Rows.Add(empployee1);
        return myTbl;
    }

    private void ChartItem()
    {
        AddItem();
        AddDataItem();
    }
    private int CountI()
    {
        int k = 0;
        int[] ass = new int[100];
        string[] arrS = new string[100];

        for (int i = 0; i < Tb().Rows.Count; i++)
        {
            string st = Tb().Rows[i]["Data"].ToString();
            arrS = st.Split(',');
            for (int j = 0; j < arrS.Length; j++)
            {
                if (j >= k)
                {
                    k++;
                }
            }
        }
        return k;
    }
    private void AddItem()
    {
        int k = CountI();
        for (int j = 0; j < k; j++)
        {
            string item = "Series" + j.ToString();
            Chart1.Series.Add(item);
        }

    }
    private void AddDataItem()
    {

        string st = "";
        int[] ass = new int[100];
        string[] arrS = new string[100];
        string item = "";
        for (int i = 0; i < Tb().Rows.Count; i++)
        {
            st = Tb().Rows[i]["Data"].ToString();
            arrS = st.Split(',');
            for (int j = 0; j < CountI(); j++)
            {
                if (j < arrS.Length)
                {

                    string ss = arrS[j].ToString();
                    ass[j] = Convert.ToInt32(ss);
                }
                else
                {
                    ass[j] = 0;
                }
                item = "Series" + j.ToString();
                Chart1.Series[item].Points.AddXY(Tb().Rows[i]["Name"].ToString(), ass[j]);
            }
        }
    }
    #endregion
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        //string EmpIds = GetEmpIds();
        //string ProIds = GetProIds();
            string function = ddlType.SelectedValue;
            switch (function)
            {
                case "0":
                    CombinedReport();
                    break;
                case "1":
                    DailyEmployeeReport();
                    break;
                case "2":
                    MonthEmployeeReport();
                    break;
                case "3":
                    DailyAllEmployees_Report();
                    break;
                case "4":
                    DailyProjectReport();
                    break;
                case "5":
                    MonthProjectReport();
                    break;
                case "6":
                    DailyAllProject_Reort();
                    break;
                default:
                    CombinedReport();
                    break;
            }
    }
    protected void ddlEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        //lbTable.Text = ddlEmployee.SelectedValue;
    }
    protected void btnApplyEmployee_Click(object sender, EventArgs e)
    {
        System.Collections.ArrayList arr = new System.Collections.ArrayList();
        for (int i = 0; i < chkEmployee.Items.Count; i++)
        {
            if (chkEmployee.Items[i].Selected)
            {
                arr.Add(chkEmployee.Items[i].Text);
            }
        }
        if (arr.Count <= 0)
        {
            txtEmployee.Text = "Select Employee";
        }
        else if (arr.Count == 1)
        {
            txtEmployee.Text = arr[0].ToString();
        }
        else if (arr.Count > 1)
        {
            txtEmployee.Text = arr[0].ToString() + ", etc...";
        }
    }
    protected void btnCancelEmployee_Click(object sender, EventArgs e)
    {
        txtEmployee.Text = "Select Employee";
        for (int i = 0; i < chkEmployee.Items.Count; i++)
        {
            if (chkEmployee.Items[i].Selected)
                chkEmployee.Items[i].Selected = false;
        }
    }
    protected void btnApplyProject_Click(object sender, EventArgs e)
    {
        System.Collections.ArrayList arr = new System.Collections.ArrayList();
        for (int i = 0; i < chkProject.Items.Count; i++)
        {
            if (chkProject.Items[i].Selected)
            {
                arr.Add(chkProject.Items[i].Text);
            }
        }
        if (arr.Count <= 0)
        {
            txtProject.Text = "Select Project";
        }
        else if (arr.Count == 1)
        {
            txtProject.Text = arr[0].ToString();
        }
        else if (arr.Count > 1)
        {
            txtProject.Text = arr[0].ToString() + ", etc...";
        }
    }
    protected void btnCancelProject_Click(object sender, EventArgs e)
    {
        txtProject.Text = "Select Project";
        for (int i = 0; i < chkProject.Items.Count; i++)
        {
            if (chkProject.Items[i].Selected)
                chkProject.Items[i].Selected = false;
        }
    }
}