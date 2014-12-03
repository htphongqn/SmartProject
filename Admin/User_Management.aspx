<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site_Admin.master" AutoEventWireup="true" CodeFile="User_Management.aspx.cs" Inherits="Admin_Dahboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="admin_head" Runat="Server">
    <style type="text/css">
        .style1
        {
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_admin_main" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>

    <div class="table">
    <table style="width: 29%;">
        <tr>
            <td class="style1">
                <asp:TextBox ID="txtUserlist" runat="server" Width="220px" 
                    CssClass="txtTable"  onblur="if(this.value==''){this.value='Enter employee name';}" 
                                onfocus="if (this.value=='Enter employee name') {this.value = '';}" value="Enter employee name"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnFilter" runat="server" Text="Search" CssClass="btnBlue" 
                    onclick="btnFilter_Click" />
            </td>
        </tr>
        <tr>
            <td style="width: 611px" colspan="2">
               
                <asp:Button ID="btnAddNew" runat="server" Text="Add new user" 
                    CssClass="btnBlue" PostBackUrl="~/Admin/Add_User.aspx"/>
            </td>
        </tr>
        </table>
    </div><!-- table -->
    <h3>User List</h3>
    <div class="gridview">
        <asp:GridView ID="grvUser" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" Width="100%" EmptyDataText=" No data" 
            ShowHeaderWhenEmpty="True" >
            <Columns>
             <asp:TemplateField>
                    <HeaderTemplate>
                        <%--<asp:CheckBox ID="chkAll" onclick = "checkAll(this);" runat="server" />--%>
                    </HeaderTemplate>
                    <ItemTemplate>
                       <asp:CheckBox ID="chkSelected" Checked="false" runat="server" CssClass='<%# Eval("EmpID") %>'/>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10px" />
                    <FooterTemplate>
                        
                    </FooterTemplate>
            </asp:TemplateField>
                <asp:BoundField HeaderText="User ID" DataField="ID"/>
                <asp:BoundField DataField="EmpID" HeaderText="EmployeeID" >
                <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="EmpName" HeaderText="Name">
                <ItemStyle Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="ProjectList" HeaderText="Project">
                </asp:BoundField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="Label1" runat="server" Text="Action"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:HyperLink ID="link" runat="server" NavigateUrl='<%#"~/Admin/Add_User.aspx?EmpId=" + Eval("EmpID") %>'>Edit</asp:HyperLink>
                        <asp:HyperLink  ID="HyperLink2" runat="server" NavigateUrl='<%#"~/Admin/ChangePassword.aspx?EmpID=" + Eval("EmpID") %>'>Change password</asp:HyperLink>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
                    <FooterTemplate>
                        
                    </FooterTemplate>
            </asp:TemplateField>
        
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="Label1" runat="server" Text="Status"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label Id="lbel" runat="server" Text='<%# Eval("Status")%>'></asp:Label>
                    </ItemTemplate>
                    
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div><!-- gridview -->
    <div class="bottom">
        <asp:Button ID="btnActive" runat="server" Text="Active" CssClass="btnBlue" 
            onclick="btnActive_Click" />
        <asp:Button ID="btnDeActive" runat="server" Text="Deactive" 
            CssClass="btnBlue" onclick="btnDeActive_Click" />
        <asp:Button ID="btnRemove" runat="server" Text="Remove" CssClass="btnBlue" 
            onclick="btnRemove_Click" />
    </div><!-- bottom -->
    <div>
        <asp:Label ID="lbError" runat="server" Text="" ForeColor="Red"></asp:Label>
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

