<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site_Admin.master" AutoEventWireup="true" CodeFile="History.aspx.cs" Inherits="History" %>

<asp:Content ID="Content1" ContentPlaceHolderID="admin_head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_admin_main" Runat="Server">
<div class="marin_top"></div>
    <h3>History List (Track changes of employees)</h3>
<div class="gridview">
        <asp:GridView ID="grvHistory" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" Width="100%" EmptyDataText=" No data" 
            onpageindexchanging="grvHistory_PageIndexChanging" 
            ShowHeaderWhenEmpty="True" PageSize="25">
            <Columns>
                
                <asp:BoundField DataField="UserName" HeaderText="Employee">
                <ItemStyle Width="150px" />
                </asp:BoundField>
                
                <asp:BoundField DataField="CreatedDate" HeaderText="Time">
                <ItemStyle Width="150px" />
                </asp:BoundField>
                <asp:BoundField DataField="Notes" HeaderText="History description">
           
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </div><!-- gridview -->
</asp:Content>

