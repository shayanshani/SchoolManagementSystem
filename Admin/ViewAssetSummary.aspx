<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ViewAssetSummary.aspx.cs" Inherits="SchoolManagementSystem.Admin.ViewAssetSummary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="main-content container-fluid">
        <div class="row">
            <div class="col-sm-12">
                <div class="panel panel-default panel-table" style="padding-top: 15px!important;">


                    <div class="panel-heading">
                        Store Details
                    </div>
                    <div class="panel-body table-responsive">
                        <table id="table1" class="table table-striped table-hover table-fw-widget">
                            <thead>
                                <tr>
                                    <th>Branch Name</th>
                                    <th>Branch Status</th>
                                    <th>Current Month Purchased items</th>
                                    <th>Total items in store</th>
                                    <th>Total items in Scrap</th>
                                </tr>
                            </thead>
                            <tbody>

                                <asp:Repeater ID="rptAssetSummary" runat="server">
                                    <ItemTemplate>
                                        <tr class="even gradeX">

                                            <td><%# Eval("[BranchName]") %></td>
                                            <td><%# Convert.ToInt32(Eval("[isActive]"))==1 ? "Active" :"inActive" %></td>
                                            <td><%# Eval("[ItemPurchaseCurrentMonth]") %></td>
                                            <td>
                                               <%# Eval("totalItemInStore") %>
                                            </td>
                                             <td>
                                               <%# Eval("totalItemInScarp") %>
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
