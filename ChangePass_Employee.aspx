﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site_Employee.master" AutoEventWireup="true" CodeFile="ChangePass_Employee.aspx.cs" Inherits="ChangePass_Employee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content_employee" Runat="Server">
<div class="table">
    <table>
        <tr>
            <td colspan="2"><h3>Change password</h3></td>
            
            <td>&nbsp;</td>
            
        </tr>
        <tr>
            <td>
                Current password
            </td>
            <td>
                 <asp:TextBox ID="txtCurrent" runat="server" CssClass="txtTable" 
                     TextMode="Password" Width="220px"></asp:TextBox>
                 
            </td>
            
            <td>
                 <asp:RequiredFieldValidator ID="rqCurrent" runat="server" 
                     ControlToValidate="txtCurrent" ErrorMessage="Input old password" 
                     Font-Size="Smaller" ForeColor="#FF5050"></asp:RequiredFieldValidator>
                 
            </td>
            
        </tr>
        <tr>
            <td>
               New password
            </td>
            <td>
                 <asp:TextBox ID="txtNewPass" runat="server" CssClass="txtTable" 
                     TextMode="Password" Width="220px"></asp:TextBox>
            </td>
           
            <td>
                 <asp:RequiredFieldValidator ID="rqNew" runat="server" 
                     ControlToValidate="txtNewPass" ErrorMessage="Input new password" 
                     Font-Size="Smaller" ForeColor="#FF5050"></asp:RequiredFieldValidator>
            </td>
           
        </tr>
        <tr>
            <td>
                Confirm new password
            </td>
            <td>
               <asp:TextBox ID="txtConfirm" runat="server" CssClass="txtTable" 
                    TextMode="Password" Width="220px"></asp:TextBox>
            </td>
            
            <td>
                <asp:CompareValidator ID="rqCofrim" runat="server" 
                    ControlToCompare="txtNewPass" ControlToValidate="txtConfirm" ErrorMessage="*" 
                    Font-Size="Smaller" ForeColor="#FF5050"></asp:CompareValidator>
            </td>
            
        </tr>
        <tr>
            <td colspan="2" style="text-align:center">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btnOrange" 
                    onclick="btnSave_Click"/>
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btnBlue" 
                    onclick="btnCancel_Click" CausesValidation="false"/>
            </td>
            <td style="text-align:center">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center">
                <asp:Label ID="lbchanges" runat="server" ForeColor="#FF0066"></asp:Label>
            </td>
            <td style="text-align:center">
                &nbsp;</td>
        </tr>
    </table>
</div>
</asp:Content>

