using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.Services;

/**
* \brief select, insert, update, delete database sql server
*/
public class DBClass : BaseServ
{
    private int result;
	public DBClass()
	{
        this.result = 0;
    }

    #region sqlHelp
    /**
     * execute procedure insert, update, delete
     * @see ExecuteScalar()
     * @return object
     */
    public virtual object ExecuteScalar(string ProcedureName, params object[] Parameters)
    {
        return SqlHelper.ExecuteScalar(dbConnString, ProcedureName, Parameters);
    }
    /**
     * execute procedure insert, update, delete
     * @see ExecuteNonQuery()
     * @return int
     */
    public virtual int ExecuteNonQuery(string ProcedureName, params object[] Parameters)
    {
        return SqlHelper.ExecuteNonQuery(dbConnString, ProcedureName, Parameters);
    }
    /**
     * get data by procedure
     * @see GetDataRow()
     * @return DataRow
     */
    public virtual DataRow GetDataRow(string ProcedureName, params object[] Parameters)
    {
        return GetDataRow(0, ProcedureName, Parameters);
    }
    /**
     * get datarow in datatable by rowindex
     * @see GetDataRow()
     * @return DataRow
     */
    public virtual DataRow GetDataRow(int RowIndex, string ProcedureName, params object[] Parameters)
    {
        DataTable dt = GetDataTable(0, ProcedureName, Parameters);
        DataRow dr = null;

        if (dt != null)
        {
            if (RowIndex >= 0 && RowIndex < dt.Rows.Count)
            {
                dr = dt.Rows[RowIndex];
            }
            dt.Dispose();
        }
        return dr;
    }
    /**
     * get datatable in dataset by tableindex
     * @see GetDataTable()
     * @return DataTable
     */
    public static DataTable GetDataTable(int TableIndex, string ProcedureName, params object[] Parameters)
    {
        DataSet ds = GetDataSet(ProcedureName, Parameters);
        DataTable dt = null;
        if (ds != null && ds.Tables.Count > 0)
        {
            if (TableIndex >= 0 && TableIndex < ds.Tables.Count)
                dt = ds.Tables[TableIndex];

            ds.Dispose();
        }
        return dt;
    }
    /**
     * get datatable by procedure
     * @see GetDataTable()
     * @return DataTable
     */
    public static DataTable GetDataTable(string ProcedureName, params object[] Parameters)
    {
        DataSet ds = GetDataSet(ProcedureName, Parameters);
        DataTable dt = null;
        if (ds != null && ds.Tables.Count > 0)
        {
            dt = ds.Tables[0];
            ds.Dispose();
        }
        return dt;
    }
    /**
     * get dataset by procedure
     * @see GetDataSet()
     * @return DataSet
     */
    public static DataSet GetDataSet(string ProcedureName, params object[] Parameters)
    {
       return SqlHelper.ExecuteDataset(dbConnString, ProcedureName, Parameters);
    }
    public object GetValueFromDB(string sql)
    {
        return SqlHelper.ExecuteScalar(dbConnString, CommandType.Text, sql);
    }

    #endregion
    #region Load_Data
    public DataRow Login_Employee(int empID,string passWord,string projectID)
    {
        return GetDataRow("spLogin_Employee", empID, passWord,projectID);
    }
    public DataRow Login_Admin(string userName, string passWord)
    {
        return GetDataRow("spLogin_Admin", userName, passWord);
    }
    #endregion
    #region ListProject
    public DataTable GetList_Projects()
    {
        return GetDataTable("spGetList_Projects");
    }
    public DataTable GetList_Projects_ByEmpId(int empID)
    {
        return GetDataTable("spGetList_Projects_ByEmpId",empID);
    }
    public DataTable GetList_TaskStatus()
    {
        return GetDataTable("spGetList_TaskStatus");
    }
   
    public string Get_ProjectName_ById(string projectID)
    {
        object a = ExecuteScalar("spGet_ProjectName_ById", projectID);

        return Convert.ToString(a);
    }
    public DataTable GetList_Tasks(int empID,string projectID)
    {
        return GetDataTable("spGetList_Tasks", empID, projectID);
    }
    public DataTable GetList_Projects_Admin()
    {
        return GetDataTable("spGetList_Projects_Admin");
    }
    

    #endregion
    #region ListEmployee
    public DataRow Get_EmpName_ById(int empID)
    {
        return GetDataRow("spGet_EmpName_ById", empID);
    }
    public DataTable GetList_EmpStatus()
    {
        return GetDataTable("spGetList_EmpStatus");
    }
    public DataTable GetList_Employee_Admin()
    {
        return GetDataTable("spGetList_Employee_Admin");
    }
    public DataTable GetList_Employees_ByprojectID(string projectID)
    {
        return GetDataTable("spGetList_Employees_ByprojectID", projectID);
    }
    public DataTable GetList_Employees()
    {
        return GetDataTable("spGetList_Employees");
    }
    #endregion
    #region Info
    public DataRow GetInfo_Employee_ByEmpId(int empID)
    {
        return GetDataRow("spGetInfo_Employee_ByEmpId",empID);
    }
    public DataRow GetInfo_Projects_ByprojectID(string projectID)
    {
        return GetDataRow("spGetInfo_Projects_ByprojectID", projectID);
    }
    #endregion
    #region Insert_UpdateEmployee
    public int Delete_Tasks_ByTaskIds(int empID,string taskIDs)
    {
        result = ExecuteNonQuery("spDelete_Tasks_ByTaskIds",empID, taskIDs);
        return result;
    }
    public int InsertUpdate_Tasks(int taskId, int empId, int @projectID, string description, int taskStatusId, DateTime? startTime, DateTime? endTime, string notes)
    {
        result = ExecuteNonQuery("spInsertUpdate_Tasks", taskId, empId, projectID, description, taskStatusId, startTime, endTime, notes);
        return result;
    }
    public int Active_DeActive_Employees(int empID, bool empStatus)
    {
        return Convert.ToInt32(ExecuteNonQuery("spActive_DeActive_Employees", empID, empStatus));
    }
    public int InsertUpdate_Employees(string fristName, string lastName, int empId, string passWord, int empStatus,int? empOld)
    {
        return Convert.ToInt32(ExecuteScalar("spInsertUpdate_Employees", fristName, lastName, empId, passWord, empStatus,empOld));
    }
    public int Insert_ProjectEmps(int empID,string projectID)
    {
        return Convert.ToInt32(ExecuteScalar("spInsert_ProjectEmps", empID,projectID));
    }
    public int Delete_ProjectEmps_ByEmpIds(string empID)
    {
        result = ExecuteNonQuery("spDelete_ProjectEmps_ByEmpIds", empID);
        return result;
    }
    public int Delete_ProjectEmps_ByprojectIDs(string empIDs)
    {
        result = ExecuteNonQuery("spDelete_ProjectEmps_ByprojectIDs", empIDs);
        return result;
    }
    //use for project
    public int Insert_ProjectEmps_ByEmpIds(string projectID, string empID)
    {
        return Convert.ToInt32(ExecuteScalar("spInsert_ProjectEmps_ByEmpIds", projectID, empID));
    }
    //user for employee
    public int Insert_ProjectEmps_ByprojectIDs(int empID, string projectID)
    {
        return Convert.ToInt32(ExecuteScalar("spInsert_ProjectEmps_ByprojectIDs", empID,projectID));
    }
    public int ChangePassword(int empID, string passOld,string passNew)
    {
        return Convert.ToInt32(ExecuteScalar("spChangePassword", empID, passOld,passNew));
    }
    public int ChangePassword_Admin(int userID, string passOld, string passNew)
    {
        return Convert.ToInt32(ExecuteScalar("spChangePassword_Admin", userID, passOld, passNew));
    }
    #endregion 
    #region History
    public DataTable GetList_History()
    {
        return GetDataTable("spGetList_History");
    }
    public DataTable spGetList_History_ByEmpId(int empID)
    {
        return GetDataTable("spGetList_History_ByEmpId",empID);
    }
    #endregion
    #region Insert_UpdateProject
    public string InsertUpdate_Projects(string projectID, string projectName, string notes, DateTime? createdDate, string projectIdOld)
    {
        return Convert.ToString(ExecuteScalar("spInsertUpdate_Projects",projectID, projectName, notes, createdDate,projectIdOld));
    }
    #endregion
    #region Report
    //Sql1
    public DataTable GetList_Employee_Report(DateTime? fromDate, DateTime? toDate, string empIds)
    {
        return GetDataTable("spGetList_Employees_Report", fromDate, toDate, empIds);
    }
    //Sql5
    public DataTable GetList_Employees_ByprojectID_Report(string projectID, DateTime? fromDate, DateTime? toDate, string empIds)
    {
        return GetDataTable("spGetList_Employees_ByprojectID_Report",projectID,fromDate, toDate, empIds);
    }
    //Sql3 
    public DataTable GetList_DurationOfEmployee_Report(int? empID,string projectID, DateTime? fromDate, DateTime? toDate)
    {
        return GetDataTable("spGetList_DurationOfEmployee_Report",empID,projectID,fromDate, toDate);
    }
    //Sql4 []
    public DataTable GetList2Date(DateTime? fromDate, DateTime? toDate)
    {
        return GetDataTable("spGetList2Date", fromDate, toDate);
    }
    //Sql2 
    public DataTable GetList_Projects_ByEmpId_Report(int empID, DateTime? fromDate, DateTime? toDate, string proIds)
    {
        return GetDataTable("spGetList_Projects_ByEmpId_Report", empID, fromDate, toDate, proIds);
    }
    public DataRow GetDurationHours_ByFromDateToDate(int? empID,string projectID, DateTime? fromDate, DateTime? toDate)
    {
        return GetDataRow("spGetDurationHours_ByFromDateToDate", empID, projectID, fromDate, toDate);
    }
    //Sql6
    public DataTable GetList_Projects_Report(DateTime? fromDate, DateTime? toDate, string projectIds)
    {
        return GetDataTable("spGetList_Projects_Report", fromDate, toDate, projectIds);
    }
    //Sql7 
    public DataTable spGetList_DurationOfProject_Report(int? empID,string projectID, DateTime? fromDate, DateTime? toDate)
    {
        return GetDataTable("spGetList_DurationOfProject_Report", empID, projectID, fromDate, toDate);
    }
    //Sql8
    //public DataTable GetList_Employees_ByprojectID_Report(int ProjID, DateTime? fromDate, DateTime? toDate)
    //{
    //    return GetDataTable("spGetList_Employees_ByprojectID_Report", ProjID, fromDate, toDate);
    //}
    #endregion
}