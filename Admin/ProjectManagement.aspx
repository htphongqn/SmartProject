<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site_Admin.master" AutoEventWireup="true" CodeFile="ProjectManagement.aspx.cs" Inherits="Admin_Dahboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="admin_head" Runat="Server">
    <style type="text/css">
        .style2
        {
            width: 180px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_admin_main" Runat="Server">
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
    <div class="table">
    <table style="width: 29%;">
        <tr>
            <td class="style2">
                <asp:TextBox ID="txtUserlist" runat="server" Width="220px" 
                    CssClass="txtTable" onblur="if(this.value==''){this.value='Enter project name';}" 
                                onfocus="if (this.value=='Enter project name') {this.value = '';}" value="Enter project name"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnFilter" runat="server" Text="Search" CssClass="btnBlue" 
                    onclick="btnFilter_Click" />
            </td>
        </tr>
        <tr>
            <td style="width: 611px" colspan="2">
               
                <asp:Button ID="btnAddnew" runat="server" Text="Add new project" 
                    CssClass="btnBlue" PostBackUrl="~/Admin/Add_Project.aspx"/>
            </td>
        </tr>
        </table>
    </div><!-- table -->
    <h3>Project List</h3>
    <div class="gridview">
        <asp:GridView ID="grvProject" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" Width="100%" EmptyDataText=" No data" 
            ShowHeaderWhenEmpty="True" 
            onpageindexchanging="grvProject_PageIndexChanging" >
            <Columns>
             <asp:TemplateField>
                    <HeaderTemplate>
                        <%--<asp:CheckBox ID="chkAll" onclick = "checkAll(this);" runat="server" />--%>
                    </HeaderTemplate>
                    <ItemTemplate>
                       <asp:CheckBox ID="chkSelected" Checked="false" runat="server" 
                            CssClass='<%# Eval("ProjectID") %>'/>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10px" />
                    <FooterTemplate>
                        
                    </FooterTemplate>
            </asp:TemplateField>
                <asp:BoundField HeaderText="ID" DataField="ID"/>
                <asp:BoundField DataField="ProjectID" HeaderText="ProjectID" >
                <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="ProjectName" HeaderText="Project Name">
                <ItemStyle Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="MemberList" HeaderText="Member List">
                </asp:BoundField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="Label1" runat="server" Text="Action"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:HyperLink ID="link" runat="server" 
                            NavigateUrl='<%#"~/Admin/Add_Project.aspx?ProjectID=" + Eval("ProjectID") %>'>Edit</asp:HyperLink>
                        
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
                    <FooterTemplate>
                        
                    </FooterTemplate>
            </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div><!-- gridview -->
    <div class="bottom">
        <asp:Button ID="btnReMove" runat="server" Text="Remove" CssClass="btnBlue" 
            onclick="btnReMove_Click" />
    </div><!-- bottom -->
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

