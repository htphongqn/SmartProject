<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link href="Css/Control_Log.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_right" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_main" Runat="Server">
    <asp:UpdatePanel ID="pContent" runat="server">
    <ContentTemplate>
    <div class="login">
<%--<div class="text_center title_login">  
    <asp:Label ID="lnLogin" runat="server"  Text="LOGIN"></asp:Label>
</div>--%>
<div style="margin-top:15px;text-align:left;width:100%;">
<h3>Employee Management WebApp</h3>
</div>

<div class="center">
    
   
    <asp:Panel ID="pnEmploy" runat="server" CssClass="pnMargin">
   
    <table style="width:100%;">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Employee ID"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtEmpID" runat="server" onblur="IsNumeric(this.value)" AutoPostBack="True" 
                    ontextchanged="txtEmpID_TextChanged" onunload="txtEmpID_Unload"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="txtEmpID" ErrorMessage="*" Font-Size="Smaller" 
                    ForeColor="#FF3300" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Select project"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="ddlProject" runat="server" DataTextField="ProjectName" 
                    DataValueField="ProjectId" 
                    onselectedindexchanged="ddlProject_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Password"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtPassEmp" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
       
    </table>
    </asp:Panel>
     <div class="btnLog"> 
     <asp:Button ID="btnLogAdmin" runat="server" Text="LogIn" CssClass="btnBlue" 
             onclick="btnLogAdmin_Click"/>
     </div>
 <div style="margin:10px">
     <asp:Label ID="lberorr" runat="server" 
         ForeColor="Red" Visible="False" Font-Size="Smaller"></asp:Label>
 </div>
 </div><!-- center -->
</div><!-- login -->

    </ContentTemplate>
    </asp:UpdatePanel>
      <div class="process">
        <asp:UpdateProgress ID="upProcess" AssociatedUpdatePanelID="pContent" runat="server">
        <ProgressTemplate>
            <div class="loading">
                <img src="Resource/Images/loading.gif" alt=""/>
            </div>
        </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
</asp:Content>

