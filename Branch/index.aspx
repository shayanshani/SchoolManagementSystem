<%@ Page Title="" Language="C#" MasterPageFile="~/Branch/Master.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SchoolManagementSystem.Branch.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style type="text/css">
        .chart-pie-counter {
            font-size: 24px !important;
        }

        a {
            color: black !important;
        }

        }
    </style>
    <div class="main-content container-fluid">
        <div class="row">
            <div class="col-md-12">
                <div class="widget widget-fullwidth be-loading">
                    <div class="widget-head">
                        <div class="tools">
                            <div class="dropdown">
                                <span data-toggle="dropdown" class="icon mdi mdi-more-vert visible-xs-inline-block dropdown-toggle"></span>
                                <ul role="menu" class="dropdown-menu">
                                    <li><a href="#">Week</a></li>
                                    <li><a href="#">Month</a></li>
                                    <li><a href="#">Year</a></li>
                                    <li class="divider"></li>
                                    <li><a href="#">Today</a></li>
                                </ul>
                            </div>
                            <span class="icon mdi mdi-chevron-down"></span><span class="icon toggle-loading mdi mdi-refresh-sync"></span><span class="icon mdi mdi-close"></span>
                        </div>
                        <div class="button-toolbar hidden-xs">
                            <div class="btn-group">
                                <button type="button" class="btn btn-default">Week</button>
                                <button type="button" class="btn btn-default active">Month</button>
                                <button type="button" class="btn btn-default">Year</button>
                            </div>
                            <div class="btn-group">
                                <button type="button" class="btn btn-default">Today</button>
                            </div>
                        </div>
                        <span class="title">Recent Movement</span>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">

            <asp:Repeater runat="server" ID="rptBranchInfo">
                <ItemTemplate>

                    <div class="col-xs-12 col-md-6 col-lg-4">
                        <div class="widget widget-tile">
                            <div id="spark2" class="chart sparkline"></div>
                            <div class="data-info">
                                <div class="desc"><a href="ViewStudents.aspx">New Admissions</a></div>
                                <%--data-suffix="%"--%>
                                <div class="value">
                                    <span class="indicator indicator-positive mdi mdi-chevron-up"></span><span data-toggle="counter" data-end='<%# Eval("NewAdmissions") %>' class="number">0</span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12 col-md-6 col-lg-4">
                        <div class="widget widget-tile">
                            <div id="spark3" class="chart sparkline"></div>
                            <div class="data-info">
                                <div class="desc"><a href="ViewEmployee.aspx">Employees</a></div>
                                <div class="value">
                                    <span class="indicator indicator-positive mdi mdi-chevron-up"></span><span data-toggle="counter" data-end='<%# Eval("ActiveEmployees") %>' class="number">0</span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12 col-md-6 col-lg-4">
                        <div class="widget widget-tile">
                            <div id="spark4" class="chart sparkline"></div>
                            <div class="data-info">
                                <div class="desc"><a href="EnrolledStudents.aspx">Students</a></div>
                                <div class="value">
                                    <span class="indicator indicator-negative mdi mdi-chevron-down"></span><span data-toggle="counter" data-end='<%# Eval("EnrolledStudents") %>' class="number">0</span>
                                </div>
                            </div>
                        </div>
                    </div>

                    </div>

           
                </ItemTemplate>
            </asp:Repeater>

            <div class="row">
                <div class="col-xs-12 col-md-4">
                    <div class="widget be-loading">
                        <div class="widget-head">
                            <div class="tools"><span class="icon mdi mdi-chevron-down"></span><span class="icon mdi mdi-refresh-sync toggle-loading"></span><span class="icon mdi mdi-close"></span></div>
                            <div class="title">Account Details</div>
                        </div>
                        <div class="widget-chart-container">
                            <div id="top-sales" style="height: 178px;"></div>
                            <div class="chart-pie-counter"><a href="ViewAccountDetail.aspx">CR/DR</a></div>
                        </div>

                        <asp:Repeater ID="rptAccountDetails" runat="server">
                            <ItemTemplate>
                                <div class="chart-legend">
                                    <table>
                                        <tr>
                                            <td class="chart-legend-color"><span data-color="top-sales-color1"></span></td>
                                            <td>Current Month Income</td>
                                            <td class="chart-legend-value"><%# Eval("IncomeForCurrentMonth") %></td>
                                        </tr>
                                        <tr>
                                            <td class="chart-legend-color"><span data-color="top-sales-color2"></span></td>
                                            <td>Expenses Current Month</td>
                                            <td class="chart-legend-value"><%# Eval("totalExpensecurrentmonth") %></td>
                                        </tr>
                                        <tr>
                                            <td class="chart-legend-color"><span data-color="top-sales-color3"></span></td>
                                            <td>Remaining For Current Month</td>
                                            <td class="chart-legend-value"><%# (Convert.ToInt32(Eval("IncomeForCurrentMonth"))-Convert.ToInt32(Eval("totalExpensecurrentmonth"))) %></td>
                                        </tr>
                                    </table>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>


                        <div class="be-spinner">
                            <svg width="40px" height="40px" viewBox="0 0 66 66" xmlns="http://www.w3.org/2000/svg">
                                <circle fill="none" stroke-width="4" stroke-linecap="round" cx="33" cy="33" r="30" class="circle"></circle>
                            </svg>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12 col-md-4">
                    <div class="widget be-loading">
                        <div class="widget-head">
                            <div class="tools"><span class="icon mdi mdi-chevron-down"></span><span class="icon mdi mdi-refresh-sync toggle-loading"></span><span class="icon mdi mdi-close"></span></div>
                            <div class="title">Store Details</div>
                        </div>
                        <div class="widget-chart-container">
                            <div id="top-sales1" style="height: 178px;"></div>
                            <div class="chart-pie-counter"><a href="ViewStore.aspx">Assets</a></div>
                        </div>
                        <asp:Repeater ID="rptStoreDetail" runat="server">
                            <ItemTemplate>

                                <div class="chart-legend">
                                    <table>
                                        <tr>
                                            <td class="chart-legend-color"><span data-color="top-sales-color1"></span></td>
                                            <td>New Items Purchase</td>
                                            <td class="chart-legend-value"><%# Eval("ItemPurchaseCurrentMonth") %></td>
                                        </tr>
                                        <tr>
                                            <td class="chart-legend-color"><span data-color="top-sales-color2"></span></td>
                                            <td>Current Store</td>
                                            <td class="chart-legend-value"><%# Eval("totalItemInStore") %></td>
                                        </tr>
                                        <tr>
                                            <td class="chart-legend-color"><span data-color="top-sales-color3"></span></td>
                                            <td>Scarp Items</td>
                                            <td class="chart-legend-value"><%# Eval("totalItemInScarp") %></td>
                                        </tr>
                                    </table>
                                </div>

                            </ItemTemplate>
                        </asp:Repeater>
                        <div class="be-spinner">
                            <svg width="40px" height="40px" viewBox="0 0 66 66" xmlns="http://www.w3.org/2000/svg">
                                <circle fill="none" stroke-width="4" stroke-linecap="round" cx="33" cy="33" r="30" class="circle"></circle>
                            </svg>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12 col-md-4">
                    <div class="widget be-loading">
                        <div class="widget-head">
                            <div class="tools"><span class="icon mdi mdi-chevron-down"></span><span class="icon mdi mdi-refresh-sync toggle-loading"></span><span class="icon mdi mdi-close"></span></div>
                            <div class="title">Expense Details</div>
                        </div>
                        <div class="widget-chart-container">
                            <div id="top-sales2" style="height: 178px;"></div>
                            <div class="chart-pie-counter"><a href="ViewEditExpenses.aspx">Expenses</a></div>
                        </div>

                        <asp:Repeater ID="rptExpenses" runat="server">
                            <ItemTemplate>
                                <div class="chart-legend">
                                    <table>
                                        <tr>
                                            <td class="chart-legend-color"><span data-color="top-sales-color1"></span></td>
                                            <td>Current Month Expenses</td>
                                            <td class="chart-legend-value"><%# Eval("totalExpensecurrentmonth") %></td>
                                        </tr>
                                        <tr>
                                            <td class="chart-legend-color"><span data-color="top-sales-color2"></span></td>
                                            <td>Last Month Expenses</td>
                                            <td class="chart-legend-value"><%# Eval("totalExpensePrevmonth") %></td>
                                        </tr>
                                        <tr>
                                            <td class="chart-legend-color"><span data-color="top-sales-color3"></span></td>
                                            <td>Current Year Expenses</td>
                                            <td class="chart-legend-value"><%# Eval("totalcurrentYear") %></td>
                                        </tr>
                                    </table>

                                </div>
                            </ItemTemplate>
                        </asp:Repeater>

                        <div class="be-spinner">
                            <svg width="40px" height="40px" viewBox="0 0 66 66" xmlns="http://www.w3.org/2000/svg">
                                <circle fill="none" stroke-width="4" stroke-linecap="round" cx="33" cy="33" r="30" class="circle"></circle>
                            </svg>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-default panel-table">
                        <div class="panel-heading">
                            <div class="title">Notification Details</div>
                        </div>
                        <div class="panel-body table-responsive">
                            <asp:UpdatePanel ID="pnlnotifications" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>

                                    <asp:Timer runat="server" ID="timerNews" Interval="15000" OnTick="timerNews_Tick"></asp:Timer>

                                    <table class="table table-striped table-hover">
                                        <thead>
                                            <tr>
                                                <th style="width: 37%;">Subject</th>
                                                <th style="width: 36%;">Message</th>
                                                <th>Date</th>

                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater runat="server" ID="rptNotifications">
                                                <ItemTemplate>

                                                    <tr>
                                                        <td><%# Eval("NotificationSubject") %></td>
                                                        <td><%# Eval("ShortMessage") %>...<a href='ReadNotification.aspx?val=<%# Eval("NotificationID") %>' style="color: #4285f4!important;">Read More</a></td>
                                                        <td><%# Eval("NotificationDate") %></td>
                                                    </tr>

                                                </ItemTemplate>
                                            </asp:Repeater>


                                        </tbody>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                           
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">

                <div id="main-chart" style="height: 260px;"></div>
            </div>
            <div class="be-spinner">
            </div>

        </div>

    </div>
</asp:Content>
