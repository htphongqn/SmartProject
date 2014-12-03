<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site_Admin.master" AutoEventWireup="true" CodeFile="ReportDailyAllEmployee.aspx.cs" Inherits="Report" %>

<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="asp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="admin_head" Runat="Server">
    <link href="../Css/Scroll.css" rel="stylesheet" type="text/css" />
    
    <script src="../Js/Scroll.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_admin_main" Runat="Server">    
    <div class="table2">
    <table cellspacing="10" align="center" style="margin:0 auto" >
        <tr>
            <td>
                From
                <asp:TextBox ID="txtFrom" runat="server" CssClass="txtTable" Width="150px"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="orange"
                    Enabled="True" TargetControlID="txtFrom"></asp:CalendarExtender></td>
            <td valign="bottom">
                To
                <asp:TextBox ID="txtTo" runat="server" CssClass="txtTable" Width="150px"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True"  CssClass="orange"
                    TargetControlID="txtTo"></asp:CalendarExtender></td>  
            <td><asp:DropDownCheckBoxes ID="chkEmployee" runat="server" DataTextField="EmpName" 
                        DataValueField="EmpId" UseButtons="True" UseSelectAllNode="true"
                 AddJQueryReference="True">
                <Style SelectBoxWidth="150" DropDownBoxBoxWidth="" DropDownBoxBoxHeight="" SelectBoxCssClass="txtTable"></Style>
                <Texts OkButton="Apply" CancelButton="Cancel" SelectAllNode="ALL" SelectBoxCaption="Select Employee" />
            </asp:DropDownCheckBoxes>                
            </td>      
            <td><asp:DropDownCheckBoxes ID="chkProject" runat="server" DataTextField="ProjectName"
                        DataValueField="ProjectId" UseButtons="True" UseSelectAllNode="true"
                 AddJQueryReference="True">
                <Style SelectBoxWidth="150" DropDownBoxBoxWidth="" DropDownBoxBoxHeight="" SelectBoxCssClass="txtTable"></Style>
                <Texts OkButton="Apply" CancelButton="Cancel" SelectAllNode="ALL" SelectBoxCaption="Select Project" />
            </asp:DropDownCheckBoxes>                
            </td>
            <td>
                <asp:Button ID="btnCreate" runat="server" CssClass="btnOrange" 
                    onclick="btnCreate_Click" Text="Create Report" Width="107px" />
            </td>
        </tr>       
    </table>
</div>
    <asp:TabContainer ID="tabReport" runat="server" ActiveTabIndex="1" 
        CssClass="mytab" Width="100%"> &nbsp;&nbsp;&nbsp;<asp:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
        <HeaderTemplate>
                Chart
            </HeaderTemplate>
            <ContentTemplate>
                <div class="chart_data">
                   <asp:Chart ID="Chart1" runat="server" Palette="Excel" Width="524px">
	                   <ChartAreas>
		               <asp:ChartArea Name="ChartArea1">
                         </asp:ChartArea>
	                      </ChartAreas>
                     <BorderSkin BackColor="Maroon" BorderColor="Maroon" /></asp:Chart>
             </div><!-- chart -->
          </ContentTemplate>
        </asp:TabPanel>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate>
                Table
            </HeaderTemplate>
            <ContentTemplate>               
                <div class="table_data">
               <div class="scroll">
                <div class="content_scroll">
                    <asp:Label ID="lbTable" runat="server" Text=""></asp:Label>
                       </div><!-- content -->
                       </div><!-- scroll -->
                </div><!-- table -->                
            </ContentTemplate>
        </asp:TabPanel>
&nbsp;&nbsp; </asp:TabContainer>

<div class="bottom">
    <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btnOrange"/>
    <asp:Button ID="btnExport" runat="server" Text="Export" CssClass="btnBlue"/>
</div>
 <div class="process">
        <asp:UpdateProgress ID="upProcess" runat="server">
        <ProgressTemplate>
            <div class="loading">
                <img src="../Resource/Images/loading.gif" /><%--
                <img  src="<%= ResolveUrl("~/Resource/Images/loading.gif.png") %>" alt=""/>--%>
            </div>
        </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
</asp:Content>

