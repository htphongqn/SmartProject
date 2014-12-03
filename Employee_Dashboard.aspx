<%@ Page Title="" Language="C#" MasterPageFile="~/Site_Employee.master" AutoEventWireup="true" CodeFile="Employee_Dashboard.aspx.cs" Inherits="Employee_Dashboard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content_employee" Runat="Server">
    <asp:UpdatePanel ID="pContent" runat="server">
    <ContentTemplate>
    <div class="table">
    <table style="width: 100%;">
        <tr>
            <td style="width: 611px">
                <asp:Label ID="lbProjectName" runat="server" Text="Project Name"></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 611px">
                <asp:Label ID="lbToDay" runat="server" Text="ToDay"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Select other project"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlProject" runat="server" Width="220px" 
                    AutoPostBack="True" DataTextField="ProjectName" DataValueField="ProjectID" 
                    onselectedindexchanged="ddlProject_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        </table>
    </div><!-- table -->
    <h3>To do List</h3>
    <div class="gridview">
        <asp:GridView ID="grvToDoList" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" Width="100%" EmptyDataText="No data" 
            ShowHeaderWhenEmpty="True" 
            onpageindexchanged="grvToDoList_PageIndexChanged" 
            onpageindexchanging="grvToDoList_PageIndexChanging" >
            <Columns>
            <asp:TemplateField>
                    <HeaderTemplate>
                        <%--<asp:CheckBox ID="chkAll" onclick = "checkAll(this);" runat="server" />--%>
                    </HeaderTemplate>
                    <ItemTemplate>
                       <asp:CheckBox ID="chkSelected" Checked="false" runat="server" CssClass='<%# Eval("TaskID") %>'/>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10px" />
                    <FooterTemplate>
                        
                    </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                    <HeaderTemplate>
                        Task Description
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbDiscription" runat="server" Text='<%# Eval("Description")  %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="300px" />
                    <FooterTemplate>
                        
                    </FooterTemplate>
            </asp:TemplateField>
            
                <asp:BoundField DataField="StatusName" HeaderText="Status">
                <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="Start" HeaderText="Issue Start" DataFormatString="{0:MM/dd/yyyy HH:mm:ss}">
                <ItemStyle Width="120px" />
                </asp:BoundField>
                <asp:BoundField DataField="End" HeaderText="Issue End" DataFormatString="{0:MM/dd/yyyy HH:mm:ss}">
                <ItemStyle Width="120px" />
                </asp:BoundField>
                <asp:BoundField DataField="Notes" HeaderText="Note" >
                <ItemStyle Width="285px" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
   
    </div><!-- gridview -->
    <br />

        <asp:Panel ID="pntable" runat="server" Visible="false" CssClass="add_new">
         <table width="100%" style="margin-top:10px;">
            <tr>
                <td style="width:10px"></td>
                <td >
                    <asp:TextBox ID="txtDescription" runat="server" Width="220px" CssClass="txtTable" onblur="if(this.value==''){this.value='Description';}" 
                                onfocus="if (this.value=='Description') {this.value = '';}" value="Description" ></asp:TextBox>
                </td>
                <td>
                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="txtTable" 
                        DataTextField="Name" DataValueField="AutoId">
                    </asp:DropDownList>
                </td>
                <td style="width: 70px" >
                    <asp:TextBox ID="txtStart" runat="server" Width="70px" CssClass="txtTable"  onblur="if(this.value==''){this.value='Start';}" 
                                onfocus="if (this.value=='Start') {this.value = '';}" 
                        value="Start"></asp:TextBox>
                    <asp:CalendarExtender ID="txtStart_CalendarExtender" runat="server" 
                        Enabled="True" TargetControlID="txtStart" CssClass="orange">
                    </asp:CalendarExtender>
                </td>
                <td style="width: 120px">
                    <asp:DropDownList ID="ddlHstart" runat="server" CssClass="txtTable" Width="50px">
                    </asp:DropDownList>
                    :<asp:DropDownList ID="ddMstart" runat="server" CssClass="txtTable" 
                        Width="50px">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
                <td style="width:90px">
                    <asp:TextBox ID="txtEnd" runat="server" Width="70px" CssClass="txtTable" onblur="if(this.value==''){this.value='End';}" 
                                onfocus="if (this.value=='End') {this.value = '';}" value="End"></asp:TextBox>
                    <asp:CalendarExtender ID="txtEnd_CalendarExtender" runat="server" 
                        Enabled="True" TargetControlID="txtEnd" CssClass="orange">
                    </asp:CalendarExtender>
                </td>
                <td>
                    <asp:DropDownList ID="ddlHend" runat="server" CssClass="txtTable" Width="50px">
                    </asp:DropDownList>
                    :<asp:DropDownList ID="ddlMend" runat="server" CssClass="txtTable" Width="50px">
                    </asp:DropDownList>
                </td>
                <td>
                </td>
                <td style="width:150px">
                    <asp:TextBox ID="txtNote" runat="server" Width="200px" CssClass="txtTable" onblur="if(this.value==''){this.value='Notes';}" 
                                onfocus="if (this.value=='Notes') {this.value = '';}" 
                        value="Notes"></asp:TextBox></td>
            </tr>
        </table>
        </asp:Panel>
        <h3></h3>
    <div class="bottom">
        <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btnOrange" 
            onclick="btnAdd_Click" />
        <asp:Button ID="btnReMove" runat="server" Text="Remove" CssClass="btnOrange" 
            onclick="btnReMove_Click" />
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btnOrange" 
            onclick="btnSave_Click" Visible="False" />
        <asp:Button ID="btncancel" runat="server" Text="Cancel" CssClass="btnBlue" 
            onclick="btncancel_Click" Visible="False" />
    </div><!-- bottom -->
    
    
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

