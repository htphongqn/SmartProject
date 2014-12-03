<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site_Admin.master" AutoEventWireup="true" CodeFile="Report.aspx.cs" Inherits="Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="admin_head" Runat="Server">
    <link href="../Css/Scroll.css" rel="stylesheet" type="text/css" />
    
    <script src="../Js/Scroll.js" type="text/javascript"></script>
    <style type="text/css">
        .PnlDesign
        {
            /*border: solid 1px;
            height: 150px;*/
            min-width: 156px;
            max-height:150px;
            overflow-y:scroll;          
            background-color: #ffffff;
        }
        .txtbox
        {
            min-width: 150px;
            background-image: url(../Resource/Images/drpdwn.png);
            background-position: right center;
            background-repeat: no-repeat;
            cursor: pointer;
            cursor: hand;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_admin_main" Runat="Server">    
    <div class="table2">
    <table cellpadding="5" cellspacing="5">
        <tr>
            <td>Report type</td>
            <td>
                <asp:DropDownList ID="ddlType" runat="server"
                    CssClass="txtTable" Width="160px">
                    <asp:ListItem Value="0">Combined Report</asp:ListItem>
                    <asp:ListItem Value="1">Daily Employee</asp:ListItem>
                    <asp:ListItem Value="2">Monthly Employee</asp:ListItem>
                    <asp:ListItem Value="3">Daily All Employees</asp:ListItem>
                    <asp:ListItem Value="4">Daily Project</asp:ListItem>
                    <asp:ListItem Value="5">Monthly Project</asp:ListItem>
                    <asp:ListItem Value="6">Daily All Project</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="txtEmployee" Text="Select Employee" runat="server" CssClass="txtbox txtTable"></asp:TextBox>
                <asp:Panel ID="pnlEmployee" runat="server" CssClass="PnlDesign txtTable">
                    <asp:CheckBoxList ID="chkEmployee" runat="server" DataTextField="EmpName" 
                        DataValueField="EmpId">
                    </asp:CheckBoxList>
                    <div>
                    <asp:Button ID="btnApplyEmployee" runat="server" Text="Apply" onclick="btnApplyEmployee_Click" />
                    <asp:Button ID="btnCancelEmployee" runat="server" Text="Cancel" onclick="btnCancelEmployee_Click" /></div>
                </asp:Panel>
                <asp:PopupControlExtender ID="txtEmployee_PopupControlExtender" 
                    runat="server" PopupControlID="pnlEmployee" Position="Bottom" 
                    TargetControlID="txtEmployee"></asp:PopupControlExtender>                
            </td>
            <td>
                <asp:TextBox ID="txtProject" Text="Select Project" runat="server" CssClass="txtbox txtTable"></asp:TextBox>
                <asp:Panel ID="pnlProject" runat="server" CssClass="PnlDesign txtTable">
                    <asp:CheckBoxList ID="chkProject" runat="server" DataTextField="ProjectName" 
                        DataValueField="ProjectId">
                    </asp:CheckBoxList>
                    <div>
                    <asp:Button ID="btnApplyProject" runat="server" Text="Apply" onclick="btnApplyProject_Click" />
                    <asp:Button ID="btnCancelProject" runat="server" Text="Cancel" onclick="btnCancelProject_Click" /></div>
                </asp:Panel>
                <asp:PopupControlExtender ID="PopupControlExtender_txtProject" 
                    runat="server" PopupControlID="pnlProject" Position="Bottom" 
                    TargetControlID="txtProject"></asp:PopupControlExtender>                
            </td>
        </tr>
        <tr>
            <td>
                Report duration: </td>
            <td>
                From<br />
                <asp:TextBox ID="txtFrom" runat="server" CssClass="txtTable" Width="150px"></asp:TextBox>
                <asp:CalendarExtender ID="txtFrom_CalendarExtender" runat="server" CssClass="orange"
                    Enabled="True" TargetControlID="txtFrom"></asp:CalendarExtender>
            </td>
            <td>
                To<br />
                <asp:TextBox ID="txtTo" runat="server" CssClass="txtTable" Width="150px"></asp:TextBox>
                <asp:CalendarExtender ID="txtTo_CalendarExtender" runat="server" Enabled="True"  CssClass="orange"
                    TargetControlID="txtTo"></asp:CalendarExtender>
            </td>
            <td align="right">
                <asp:Button ID="btnCreate" runat="server" CssClass="btnOrange" 
                    onclick="btnCreate_Click" Text="Create Report" Width="107px" />
            </td>
        </tr>
       
    </table>
</div>
    <asp:TabContainer ID="tabReport" runat="server" ActiveTabIndex="1" 
        CssClass="mytab" Width="100%"> &nbsp;&nbsp;<asp:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
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
        &nbsp;</asp:TabContainer>

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

