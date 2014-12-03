﻿using System;
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
        if (!IsPostBack)
        {
            LoadProject();
        }
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
    private void LoadProject()
    {
        DataTable dtProject = _db.GetList_Projects();
        chkProject.DataSource = dtProject;
        chkProject.DataBind();
      
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
        DataTable dataTime = _db.GetList2Date(fromDate(txtFrom.Text), toDate(txtTo.Text));
        string empTitle = "", projectTitle = "", datetime = "", duration = "";
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
    
}