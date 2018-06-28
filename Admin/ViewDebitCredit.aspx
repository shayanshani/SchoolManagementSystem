<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ViewDebitCredit.aspx.cs" Inherits="SchoolManagementSystem.Admin.ViewDebitCredit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="main-content container-fluid">
        <div class="row">
            <div class="col-sm-12">
                <div class="panel panel-default panel-table" style="padding-top: 15px!important;">


                    <div class="panel-heading">
                        Account Details
                    </div>
                    <div class="panel-body table-responsive">
                        <table id="table1" class="table table-striped table-hover table-fw-widget">
                            <thead>
                                <tr>
                                    <th>Branch Name</th>
                                    <th>Branch Status</th>
                                    <th>Current Month Income</th>
                                    <th>Current Month total expense</th>
                                    <th>Remaining</th>
                                </tr>
                            </thead>
                            <tbody>

                                <asp:Repeater ID="rptDebitCredit" runat="server">
                                    <ItemTemplate>
                                        <tr class="even gradeX">

                                            <td><%# Eval("[BranchName]") %></td>
                                            <td><%# Convert.ToInt32(Eval("[isActive]"))==1 ? "Active" :"inActive" %></td>
                                            <td><%# Eval("[IncomeForCurrentMonth]") %></td>
                                            <td>
                                               <%# Eval("totalExpensecurrentmonth") %>
                                            </td>
                                             <td>
                                               <%# Eval("Remaining") %>
                                            </td>

                                        </tr>

                                    </ItemTemplate>
                                </asp:Repeater>

                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>



    </div>

</asp:Content>
