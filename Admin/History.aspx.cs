using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class History : System.Web.UI.Page
{
    DBClass _db = new DBClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadHistory();
        }
    }
    private void LoadHistory()
    {
        DataTable dt = _db.GetList_History();
        grvHistory.DataSource = dt;
        grvHistory.DataBind();
    }
    protected void grvHistory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvHistory.PageIndex = e.NewPageIndex;
        LoadHistory();
    }
}