using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for DataManagerS
/// </summary>
public class DataManagerS
{
	public DataManagerS()
	{
		//
		// TODO: Add constructor logic here
		//
	}
   
    public static DataTable GetEmployeeData(DateTime? fromDate,DateTime? toDate)
    {   
        DBClass _db = new DBClass();
        DataTable dataEmployee = _db.GetList_Employee_Report(fromDate, toDate, "");
        DataTable employee = new DataTable();
        employee.Columns.Add("EMPLOYEEID");
        employee.Columns.Add("EMPLOYEENAME");
        foreach (DataRow rowEmp in dataEmployee.Rows)
        {
            AddEmployeeRecords(employee, BaseView.GetStringFieldValue(rowEmp, "EmpID"), BaseView.GetStringFieldValue(rowEmp, "EmpName"));
        }
        
        return employee;
    }

    public static DataTable GetTimeSheetData(int empId,DateTime? fromDate,DateTime? toDate)
    {
        DBClass _db = new DBClass();
        DataTable dataProject = _db.GetList_Projects_ByEmpId_Report(empId, fromDate, toDate, "");
        DataTable timeSheet = new DataTable();
        foreach (DataRow rowPro in dataProject.Rows)
        {
            timeSheet.Columns.Add(BaseView.GetStringFieldValue(rowPro, "ProjectName"));
        }
        foreach (DataRow rowPro in timeSheet.Rows)
        {
            //DataRow dr = timeSheet.NewRow();
            //dr[0] = new DataTable().Rows[0];
            DataTable dt = new DataTable();// du lieu moi
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //AddTimeSheetRecords(timeSheet,  dt.Rows[i][""],dt.Rows[i][""],dt.Rows[i][""],dt.Rows[i][""],dt.Rows[i][""]);
            }
        }


        AddTimeSheetRecords(timeSheet, "1235", "5/21/2012", "09:00 am", "07:00 pm", "WDAY");
        AddTimeSheetRecords(timeSheet, "1235", "5/22/2012", "10:00 am", "06:00 pm", "WDAY");
        AddTimeSheetRecords(timeSheet, "1235", "5/23/2012", "10:00 am", "09:00 pm", "WDAY");
        AddTimeSheetRecords(timeSheet, "1235", "5/24/2012", "00:00", "00:00", "LEAVE");
        AddTimeSheetRecords(timeSheet, "1235", "5/25/2012", "11:00 am", "06:45 pm", "WDAY");
        AddTimeSheetRecords(timeSheet, "1235", "5/28/2012", "10:00 am", "07:00 pm", "WDAY");
        AddTimeSheetRecords(timeSheet, "1235", "5/29/2012", "00:00", "00:00", "LEAVE");

        AddTimeSheetRecords(timeSheet, "1236", "5/21/2012", "09:00 am", "07:00 pm", "WDAY");
        AddTimeSheetRecords(timeSheet, "1236", "5/22/2012", "10:00 am am", "06:00 pm", "WDAY");
        AddTimeSheetRecords(timeSheet, "1236", "5/23/2012", "10:00", "09:00 pm", "WDAY");
        AddTimeSheetRecords(timeSheet, "1236", "5/24/2012", "00:00", "00:00", "LEAVE");
        AddTimeSheetRecords(timeSheet, "1236", "5/25/2012", "11:00 am", "06:45 pm", "WDAY");
        AddTimeSheetRecords(timeSheet, "1236", "5/28/2012", "10:00 am", "07:00 pm", "WDAY");
        AddTimeSheetRecords(timeSheet, "1236", "5/29/2012", "10:00 am", "07:00 pm", "WDAY");

        AddTimeSheetRecords(timeSheet, "1237", "5/21/2012", "09:00 am", "07:00 pm", "WDAY");
        AddTimeSheetRecords(timeSheet, "1237", "5/22/2012", "10:00 am", "06:00 pm", "WDAY");
        AddTimeSheetRecords(timeSheet, "1237", "5/23/2012", "10:00 am", "09:00 pm", "WDAY");
        AddTimeSheetRecords(timeSheet, "1237", "5/24/2012", "00:00", "00:00", "LEAVE");
        AddTimeSheetRecords(timeSheet, "1237", "5/25/2012", "11:00 am", "06:45 pm", "WDAY");
        AddTimeSheetRecords(timeSheet, "1237", "5/28/2012", "10:00 am", "07:00 pm", "WDAY");
        AddTimeSheetRecords(timeSheet, "1237", "5/29/2012", "10:00 am", "07:00 pm", "WDAY");

        AddTimeSheetRecords(timeSheet, "1238", "5/21/2012", "09:00 am", "07:00", "WDAY");
        AddTimeSheetRecords(timeSheet, "1238", "5/22/2012", "11:00 am", "06:00", "WDAY");
        AddTimeSheetRecords(timeSheet, "1238", "5/23/2012", "11:00 am", "09:00", "WDAY");
        AddTimeSheetRecords(timeSheet, "1238", "5/24/2012", "00:00", "00:00", "LEAVE");
        AddTimeSheetRecords(timeSheet, "1238", "5/25/2012", "00:00", "00:00", "LEAVE");
        AddTimeSheetRecords(timeSheet, "1238", "5/28/2012", "10:00 am", "05:00", "WDAY");
        AddTimeSheetRecords(timeSheet, "1238", "5/29/2012", "00:00", "00:00", "LEAVE");

        AddTimeSheetRecords(timeSheet, "1239", "5/21/2012", "09:00 am", "07:00", "WDAY");
        AddTimeSheetRecords(timeSheet, "1239", "5/22/2012", "12:00 am", "06:00", "WDAY");
        AddTimeSheetRecords(timeSheet, "1239", "5/23/2012", "12:00 am", "09:00", "WDAY");
        AddTimeSheetRecords(timeSheet, "1239", "5/24/2012", "00:00", "00:00", "LEAVE");
        AddTimeSheetRecords(timeSheet, "1239", "5/25/2012", "11:00 am", "06:45", "WDAY");
        AddTimeSheetRecords(timeSheet, "1239", "5/28/2012", "10:00 am", "07:00", "WDAY");
        AddTimeSheetRecords(timeSheet, "1239", "5/29/2012", "00:00", "00:00", "LEAVE");

        return timeSheet;
    }

    private static void AddTimeSheetRecords(DataTable timeSheet, string employeeId, string date, string inTime, string outTime, string status)
    {
        DataRow timeSheetRow = timeSheet.NewRow();
        timeSheetRow[0] = employeeId;
        timeSheetRow[1] = date;
        timeSheetRow[2] = inTime;
        timeSheetRow[3] = outTime;
        timeSheetRow[4] = status;
        timeSheet.Rows.Add(timeSheetRow);
    }

    private static void AddEmployeeRecords(DataTable employee, string employeeId, string employeeName)
    {
        DataRow employeeRow = employee.NewRow();
        employeeRow[0] = employeeId;
        employeeRow[1] = employeeName;
        employee.Rows.Add(employeeRow);
    }
}