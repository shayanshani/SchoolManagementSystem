<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ViewBranches.aspx.cs" Inherits="SchoolManagementSystem.BranchMaster.ViewBranches" %>

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
                        Branches
                    </div>
                    <div class="panel-body table-responsive">
                        <table id="table1" class="table table-striped table-hover table-fw-widget">
                            <thead>
                                <tr>
                                    <td style="vertical-align: middle!important">Filter by status:
                                    </td>
                                    <td colspan="2">
                                        <asp:DropDownList ID="DDLFilter" runat="server" CssClass="form-control" Style="width: 100%!important" AutoPostBack="true" OnSelectedIndexChanged="DDLFilter_SelectedIndexChanged">
                                            <asp:ListItem Value="">All</asp:ListItem>
                                            <asp:ListItem Value="1" Selected="True">Active</asp:ListItem>
                                            <asp:ListItem Value="0">InActive</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>

                                <tr>
                                    <th>Branch Name</th>
                                    <th>Branch PhoneNo</th>
                                    <th>Branch Address</th>
                                    <th>Current Principal
                                    </th>
                                    <th>Action(s)</th>
                                </tr>
                            </thead>
                            <tbody>

                                <asp:Repeater ID="rptBranches" runat="server" DataSourceID="obsBranches">
                                    <ItemTemplate>
                                        <tr class="even gradeX">
                                            <td><%# Eval("[BranchName]") %></td>

                                            <td><%# Eval("[BPhoneNo]") %></td>
                                            <td><%# Eval("[BAddress]") %></td>
                                            <td>
                                                <a href='AddPrinciples.aspx?BranchID=<%# Eval("BranchID") %>'><%# String.IsNullOrEmpty(Eval("PrincipalName").ToString()) ? "Add principal" : Eval("PrincipalName") %></a>
                                            </td>
                                            <td class="center">
                                                <asp:LinkButton ID="btnEdit" runat="server" OnClick="btnEdit_Click" CommandArgument='<%# Eval("BranchID") %>'><span class="mdi mdi-edit" style="font-size: 22px!important;"></span></asp:LinkButton>
                                                <%--    <asp:LinkButton ID="btnDelete" runat="server" OnClick="btnDelete_Click" CommandArgument='<%# Eval("BranchID") %>' OnClientClick='return confirm("Are you sure you want to delete this branch?")'><span class="mdi mdi-delete" style="font-size: 22px!important;"></span></asp:LinkButton>
                                                --%>   </td>
                                        </tr>

                                    </ItemTemplate>
                                </asp:Repeater>

                                 <asp:ObjectDataSource ID="obsBranches" runat="server" TypeName="SchoolManagementSystem.BL.TblBranch" SelectMethod="Filter">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="DDLFilter" PropertyName="SelectedValue" Name="isActive"
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
