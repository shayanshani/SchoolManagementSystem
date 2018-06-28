<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ManageUserAccount.aspx.cs" Inherits="SchoolManagementSystem.BranchMaster.ManageUserAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    
    <div class="main-content container-fluid">
        <div class="row">
            <div class="col-sm-12">
                <div class="panel panel-default panel-table" style="padding-top: 15px!important;">

                    <asp:UpdatePanel ID="pnlMsg" runat="server">
                        <ContentTemplate>
                            <asp:Timer runat="server" ID="timerNews" Interval="10000" OnTick="timerNews_Tick"></asp:Timer>

                            <div id="msgDiv" runat="server" visible="false" style="width: 50%; margin: auto; margin-top: 10px;">
                                <div class="icon"><span id="icon" runat="server"></span></div>
                                <div class="message">
                                    <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>


                    <div class="panel-heading">
                        User Accounts
                    </div>
                    <div class="panel-body table-responsive">
                        <table id="table1" class="table table-striped table-hover table-fw-widget">


                            <thead>
                                <tr>
                                    <td style="vertical-align: middle!important">Filter by branch:
                                    </td>
                                    <td colspan="2">
                                        <asp:DropDownList ID="ddlBranches" runat="server" CssClass="form-control" Style="width: 100%!important" AutoPostBack="true" OnSelectedIndexChanged="ddlBranches_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>

                                    <td style="vertical-align: middle!important">Filter by status:
                                    </td>
                                    <td colspan="2">
                                        <asp:DropDownList ID="DDLFilter" runat="server" CssClass="form-control" Style="width: 100%!important" AutoPostBack="true" OnSelectedIndexChanged="DDLFilter_SelectedIndexChanged">
                                            <asp:ListItem Value="">All</asp:ListItem>
                                            <asp:ListItem Value="true" Selected="True">Active</asp:ListItem>
                                            <asp:ListItem Value="false" Selected="false">InActive</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <th>User</th>
                                    <th>Current branch
                                    </th>
                                    <th>Contact</th>
                                    <th>Email</th>
                                    <th>UserName</th>
                                    <th>Password</th>
                                    <th>Address</th>

                                    <th>Status</th> 
                                   
                                    <th>Action(s)</th>
                                </tr>
                            </thead>
                            <tbody>

                                <asp:Repeater ID="rptUsers" runat="server" DataSourceID="obsUsers">
                                    <ItemTemplate>
                                        <tr class="even gradeX">
                                            <td class="user-avatar cell-detail user-info"><img src="assets/img/avatar.png" alt="Avatar"><span><%# Eval("UserName") %></span></td>
                                            <td><%# Eval("BranchName") %></td>
                                            <td><%# Eval("[Contact]") %></td>
                                            <td><%# Eval("[Email]") %></td>
                                             <td><%# Eval("[UserName]") %></td>
                                            <td><%# Eval("[Password]") %></td>
                                            <td>
                                                <%# Eval("[Address]") %>
                                            </td>
                                            <td>
                                               <%# Convert.ToBoolean(Eval("isActive"))==true ? "<span class='label label-success'>Active</span>" : "<span class='label label-default'>Inactive</span>" %> 
                                            </td>
                                           
                                            <td class="center">
                                                   <%-- <asp:LinkButton ID="btnEdit" runat="server" OnClick="btnEdit_Click" ToolTip="Click to change user settings" CommandArgument='<%# Eval("[UserID]") %>'><span class="mdi mdi-edit" style="font-size: 22px!important;"></span></asp:LinkButton>
                                                --%>
                                                     <a href='AddBranchUser.aspx?BranchID=<%# Eval("BranchID") %>'><span class="mdi mdi-edit" style="font-size: 22px!important;"></span></a>
                                          
                                                <asp:LinkButton ID="btnDelete" runat="server" OnClick="btnDelete_Click" CommandArgument='<%# Eval("[UserID]") %>' OnClientClick='return confirm("Are you sure you want to delete this user?")'><span class="mdi mdi-delete" style="font-size: 22px!important;"></span></asp:LinkButton>
                                            </td>
                                        </tr>

                                    </ItemTemplate>
                                </asp:Repeater>

                                <asp:ObjectDataSource ID="obsUsers" runat="server" TypeName="SchoolManagementSystem.BL.TblBranchUser" SelectMethod="Filter">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="DDLFilter" PropertyName="SelectedValue" Name="isActive"
                                            ConvertEmptyStringToNull="true" />
                                        <asp:ControlParameter ControlID="ddlBranches" PropertyName="SelectedValue" Name="branchID"
                                            ConvertEmptyStringToNull="true" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>

                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>



    </div>



</asp:Content>
