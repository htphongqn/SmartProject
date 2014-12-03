<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site_Admin.master" AutoEventWireup="true" CodeFile="Add_User.aspx.cs" Inherits="Add_User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="admin_head" Runat="Server">
    <style type="text/css">
        
        .style2
        {
            width: 115px;
        }
        .style3
        {
            width: 113px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_admin_main" Runat="Server">


<div class="table">
    <table>
        <tr>
            <td colspan="3">
               <h3><asp:Label ID="lbTitle" runat="server" Text="Add New Employee"></asp:Label></h3> 
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="lbFirst" runat="server" Text="First name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFirst" runat="server" CssClass="txtTable" Width="220px"></asp:TextBox>
            </td>
            <td>
                
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtFirst" ErrorMessage="*" Font-Size="Smaller" 
                    ForeColor="#FF3300"></asp:RequiredFieldValidator>
                
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="lbLast" runat="server" Text="Last name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtLast" runat="server" CssClass="txtTable" Width="220px"></asp:TextBox>
            </td>
            <td>
                
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtLast" ErrorMessage="*" Font-Size="Smaller" 
                    ForeColor="#FF3300"></asp:RequiredFieldValidator>
                
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="lbID" runat="server" Text="Employee ID" ></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtID" runat="server" CssClass="txtTable" Width="220px"></asp:TextBox>
            </td>
            <td>
                
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtID" ErrorMessage="*" Font-Size="Smaller" 
                    ForeColor="#FF3300"></asp:RequiredFieldValidator>
                
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="txtID" ErrorMessage="*" Font-Size="Smaller" 
                    ForeColor="#FF3300" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                
            </td>
        </tr>
        
         <tr>
            <td>
                <asp:Label ID="lbPass" runat="server" Text="Password"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPass" runat="server" CssClass="txtTable" 
                    TextMode="Password" Width="220px"></asp:TextBox>
            </td>
            <td>
                
                <asp:RequiredFieldValidator ID="rqPass" runat="server" 
                    ControlToValidate="txtPass" ErrorMessage="*" Font-Size="Smaller" 
                    ForeColor="#FF3300"></asp:RequiredFieldValidator>
                
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="lbConfirm" runat="server" Text="Confirm password"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtConfirm" runat="server" CssClass="txtTable" 
                    TextMode="Password" Width="220px"></asp:TextBox>
            </td>
            <td>
                
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="txtPass" ControlToValidate="txtConfirm" ErrorMessage="*" 
                    Font-Size="Smaller" ForeColor="#FF3300"></asp:CompareValidator>
                
            </td>
        </tr>
        </table>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
        <table>
         <tr>
            <td class="style3">
                <asp:Label ID="lbStatus" runat="server" Text="Status"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlStatus" runat="server" Width="227px" 
                    DataTextField="Name" DataValueField="AutoID">
                </asp:DropDownList>
            </td>
            <td>
                
                &nbsp;</td>
        </tr>
         <tr>
            <td class="style3">
                Assign project</td>
            <td>
                <asp:DropDownList ID="ddlProject" runat="server" Width="227px" 
                    DataTextField="Name" DataValueField="AutoID">
                </asp:DropDownList>
            </td>
            <td>
                
                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btnBlue" 
                    onclick="btnAdd_Click" CausesValidation="False"/>
                
            </td>
        </tr>
         <tr>
            <td valign="top" class="style3">
                <asp:Label ID="lbProject" runat="server" Text="Project list"></asp:Label>
            </td>
            <td>
                <asp:ListBox ID="lstProject" runat="server" CssClass="txtTable" Height="106px" 
                    Width="227px"></asp:ListBox>
            </td>
            <td valign="top">
                
                <asp:Button ID="btnRemove" runat="server" Text="Remove" CssClass="btnBlue" 
                    onclick="btnRemove_Click" CausesValidation="False"/>
                
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
         </ContentTemplate>
</asp:UpdatePanel>
</div>
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

