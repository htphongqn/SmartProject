<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site_Admin.master" AutoEventWireup="true" CodeFile="Add_Project.aspx.cs" Inherits="Add_User" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="admin_head" Runat="Server">
    <style type="text/css">
        .txtTable
        {}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_admin_main" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
    <div class="table">
    <table>
        <tr>
            <td colspan="3">
               <h3><asp:Label ID="lbTitle" runat="server" Text="Add new Project"></asp:Label></h3> 
            </td>
        </tr>
         <tr>
            <td>
                Project ID</td>
            <td>
                <asp:TextBox ID="txtProjectID" runat="server" CssClass="txtTable" Width="220px"></asp:TextBox>
            </td>
            <td>
                
                &nbsp;</td>
        </tr>
         <tr>
             <td>
                 <asp:Label ID="lbFirst" runat="server" Text="Project name"></asp:Label>
             </td>
             <td>
                 <asp:TextBox ID="txtName" runat="server" CssClass="txtTable" Width="220px"></asp:TextBox>
             </td>
             <td>
             </td>
        </tr>
         <tr>
            <td>
                Create Time</td>
            <td>
                <asp:TextBox ID="txtDate" runat="server" CssClass="txtTable" Width="220px"></asp:TextBox>
                <asp:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                    CssClass="orange" Enabled="True" TargetControlID="txtDate">
                </asp:CalendarExtender>
            </td>
            <td>
                
                &nbsp;</td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="lbStatus" runat="server" Text="Assign members"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlAssign" runat="server" Width="227px">
                </asp:DropDownList>
            </td>
            <td>
                
                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btnBlue" 
                    onclick="btnAdd_Click"/>
                
            </td>
        </tr>
         <tr>
            <td valign="top">
                <asp:Label ID="lbProject" runat="server" Text="Member list"></asp:Label>
            </td>
            <td>
                <asp:ListBox ID="lstMember" runat="server" CssClass="txtTable" Height="106px" 
                    Width="227px"></asp:ListBox>
            </td>
            <td valign="top">
                
                <asp:Button ID="btnRemove" runat="server" Text="Remove" CssClass="btnBlue" 
                    onclick="btnRemove_Click"/>
                
            </td>
        </tr> 
        <tr>
            <td colspan="3" style="text-align:center">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btnBlue" 
                    onclick="btnSave_Click"/>
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btnBlue" 
                    onclick="btnCancel_Click" CausesValidation="False"/>
            </td>
        </tr>
         </table>
</div>
</ContentTemplate>
</asp:UpdatePanel>
<div class="process">
        <asp:UpdateProgress ID="upProcess" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
        <ProgressTemplate>
            <div class="loading">
                <img src="../Resource/Images/loading.gif" />
            </div>
        </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
</asp:Content>

