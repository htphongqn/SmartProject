using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace TimeSheetDemo
{
    public class DataManager
    {
        public static DataTable GetEmployeeData()
        {
            DataTable employee = new DataTable();
            employee.Columns.Add("EMPLOYEEID");
            employee.Columns.Add("EMPLOYEENAME");

            AddEmployeeRecords(employee, "1235", "Vinod.T.V");
            AddEmployeeRecords(employee, "1236", "Anuraj");
            AddEmployeeRecords(employee, "1237", "SivaPrasad");
            AddEmployeeRecords(employee, "1238", "Rengaraj");
            AddEmployeeRecords(employee, "1239", "Sarath");
            return employee;
        }       

        public static DataTable GetTimeSheetData()
        {
            DataTable timeSheet = new DataTable();
            timeSheet.Columns.Add("EMPLOYEEID");
            timeSheet.Columns.Add("DENTRY");
            timeSheet.Columns.Add("INTIME");
            timeSheet.Columns.Add("OUTTIME");
            timeSheet.Columns.Add("STATUS");

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
            AddTimeSheetRecords(timeSheet, "1238", "5/22/2012", "11:00 am","06:00", "WDAY");
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
}