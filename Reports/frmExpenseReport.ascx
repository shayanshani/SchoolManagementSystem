<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="frmExpenseReport.ascx.cs" Inherits="SchoolManagementSystem.Reports.frmExpenseReport" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<style>
    .clndr {
        height: 34px !important;
        border: 1px solid #CCC !important;
    }
</style>


<div class="main-content container-fluid">

    <!--Basic forms-->
    <div class="row">
        <div class="col-sm-12">

            <div class="panel panel-default panel-border-color panel-border-color-primary">
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


                <div class="panel-heading panel-heading-divider">Genrate Report</div>
                <div class="panel-body">

                    <asp:UpdatePanel ID="pnl" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>

                            <div class="row">


                                <div class="col-sm-4">
                                    <div class="form-group">

                                        <label>Select Report Type:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="ddlReportType" InitialValue="-1" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                        <asp:DropDownList ID="ddlReportType" runat="server" OnSelectedIndexChanged="ddlReportType_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control input-sm">
                                            <asp:ListItem Value="-1">Select Report</asp:ListItem>
                                            <asp:ListItem Value="1">Daily Expense Report</asp:ListItem>
                                            <asp:ListItem Value="2">Monthly Expense Report</asp:ListItem>
                                            <asp:ListItem Value="3">Date Range Expense Report</asp:ListItem>
                                            <asp:ListItem Value="4">Yearly Expense Report</asp:ListItem>

                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-sm-4">
                                    <div class="form-group">

                                        <label>Select Branch:<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="ddBranches" InitialValue="-1" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                        <asp:DropDownList ID="ddBranches" runat="server" OnSelectedIndexChanged="ddBranches_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control input-sm"></asp:DropDownList>

                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="form-group">

                                        <label>Expense Head:<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="ddlExpenseHead" InitialValue="-1" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                        <asp:DropDownList ID="ddlExpenseHead" runat="server" CssClass="form-control input-sm"></asp:DropDownList>

                                    </div>
                                </div>

                            </div>




                            <div class="row" runat="server" id="devRptSelectedDate" visible="false">
                                <div class="panel-heading panel-heading-divider">Selected Day Report</div>
                                <div class="col-sm-2">

                                    <label>
                                        Select Date: &nbsp&nbsp 
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtselectDailyDate" ErrorMessage="*" ForeColor="Red" ValidationGroup="validationD"></asp:RequiredFieldValidator>
                                    </label>
                                </div>
                                <div class="col-sm-4">
                                    <div class="form-group">

                                        <telerik:RadDatePicker RenderMode="Lightweight" ID="txtselectDailyDate" DateInput-ReadOnly="true" Width="100%" runat="server" DateInput-DisplayDateFormat="dd-MM-yyyy" DateInput-CssClass="form-control clndr"></telerik:RadDatePicker>
                                    </div>

                                </div>

                                <div class="col-sm-4">
                                    <asp:Button runat="server" ID="btnShowSelectedReport" OnClick="btnShowSelectedReport_Click" CssClass="btn btn-primary" Text="Show Report" ValidationGroup="validationD" />
                                </div>
                            </div>



                            <div class="row" runat="server" id="devMonthly" visible="false">
                                <div class="panel-heading panel-heading-divider">Monthly Report</div>

                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <label>
                                            Select from Month: &nbsp&nbsp 
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="ddlFromMonth" ErrorMessage="*" InitialValue="-1" ForeColor="Red" ValidationGroup="validationM"></asp:RequiredFieldValidator>
                                        </label>



                                        <asp:DropDownList ID="ddlFromMonth" runat="server" CssClass="form-control input-sm">
                                            <asp:ListItem Value="-1">Select Year</asp:ListItem>
                                            <asp:ListItem Value="1">January</asp:ListItem>
                                            <asp:ListItem Value="2">February</asp:ListItem>
                                            <asp:ListItem Value="3">March</asp:ListItem>
                                            <asp:ListItem Value="4">April</asp:ListItem>
                                            <asp:ListItem Value="5">May</asp:ListItem>
                                            <asp:ListItem Value="6">June</asp:ListItem>
                                            <asp:ListItem Value="7">July</asp:ListItem>
                                            <asp:ListItem Value="8">August</asp:ListItem>
                                            <asp:ListItem Value="9">September</asp:ListItem>
                                            <asp:ListItem Value="10">October</asp:ListItem>
                                            <asp:ListItem Value="11">November</asp:ListItem>
                                            <asp:ListItem Value="12">December</asp:ListItem>

                                        </asp:DropDownList>

                                    </div>

                                </div>

                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <label>
                                            Select from Year: &nbsp&nbsp 
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="ddlFromYear" ErrorMessage="*" InitialValue="-1" ForeColor="Red" ValidationGroup="validationM"></asp:RequiredFieldValidator>
                                        </label>

                                        <asp:DropDownList ID="ddlFromYear" runat="server" CssClass="form-control input-sm">
                                            <asp:ListItem Value="-1">Select Year</asp:ListItem>
                                            <asp:ListItem>2017</asp:ListItem>
                                            <asp:ListItem>2018</asp:ListItem>
                                            <asp:ListItem>2019</asp:ListItem>
                                            <asp:ListItem>2020</asp:ListItem>
                                            <asp:ListItem>2021</asp:ListItem>
                                            <asp:ListItem>2022</asp:ListItem>
                                            <asp:ListItem>2023</asp:ListItem>
                                            <asp:ListItem>2024</asp:ListItem>
                                            <asp:ListItem>2025</asp:ListItem>
                                            <asp:ListItem>2026</asp:ListItem>
                                            <asp:ListItem>2027</asp:ListItem>
                                            <asp:ListItem>2028</asp:ListItem>
                                            <asp:ListItem>2029</asp:ListItem>
                                            <asp:ListItem>2030</asp:ListItem>
                                        </asp:DropDownList>

                                    </div>

                                </div>


                                <div class="col-sm-4">
                                    <asp:Button runat="server" ID="btnShowMonthlyReport" OnClick="btnShowMonthlyReport_Click" CssClass="btn btn-primary" Text="Show Report" ValidationGroup="validationM" />
                                </div>





                            </div>

                            <div class="row" runat="server" id="devRange" visible="false">
                                <div class="panel-heading panel-heading-divider">Date Range Reports</div>

                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <label>
                                            Select From Date: &nbsp&nbsp 
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtRangeFromDate" ErrorMessage="*" ForeColor="Red" ValidationGroup="validationR"></asp:RequiredFieldValidator>
                                        </label>

                                        <telerik:RadDatePicker RenderMode="Lightweight" ID="txtRangeFromDate" DateInput-ReadOnly="true" Width="100%" runat="server" DateInput-DisplayDateFormat="dd-MM-yyyy" DateInput-CssClass="form-control clndr"></telerik:RadDatePicker>
                                    </div>

                                </div>
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <label>
                                            Select To Date: &nbsp&nbsp 
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtToRangeDate" ErrorMessage="*" ForeColor="Red" ValidationGroup="validationR"></asp:RequiredFieldValidator>
                                        </label>

                                        <telerik:RadDatePicker RenderMode="Lightweight" ID="txtToRangeDate" DateInput-ReadOnly="true" Width="100%" runat="server" DateInput-DisplayDateFormat="dd-MM-yyyy" DateInput-CssClass="form-control clndr"></telerik:RadDatePicker>
                                    </div>

                                </div>

                                <div class="col-sm-4">
                                    <div class="form-group">

                                        <asp:Button runat="server" ID="btnShowRangeReport" OnClick="btnShowRangeReport_Click" CssClass="btn btn-primary" Text="Show Report" ValidationGroup="validationR" />
                                    </div>

                                </div>


                            </div>


                            <div class="row" runat="server" id="DivYearlyReport" visible="false">
                                <div class="panel-heading panel-heading-divider">Yearly Reports</div>

                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <label>
                                            Select Year: &nbsp&nbsp 
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="ddlYear" ErrorMessage="*" InitialValue="-1" ForeColor="Red" ValidationGroup="validationY"></asp:RequiredFieldValidator>
                                        </label>

                                        <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control input-sm">
                                            <asp:ListItem Value="-1">Select Year</asp:ListItem>
                                            <asp:ListItem>2017</asp:ListItem>
                                            <asp:ListItem>2018</asp:ListItem>
                                            <asp:ListItem>2019</asp:ListItem>
                                            <asp:ListItem>2020</asp:ListItem>
                                            <asp:ListItem>2021</asp:ListItem>
                                            <asp:ListItem>2022</asp:ListItem>
                                            <asp:ListItem>2023</asp:ListItem>
                                            <asp:ListItem>2024</asp:ListItem>
                                            <asp:ListItem>2025</asp:ListItem>
                                            <asp:ListItem>2026</asp:ListItem>
                                            <asp:ListItem>2027</asp:ListItem>
                                            <asp:ListItem>2028</asp:ListItem>
                                            <asp:ListItem>2029</asp:ListItem>
                                            <asp:ListItem>2030</asp:ListItem>
                                        </asp:DropDownList>

                                    </div>

                                </div>

                                <div class="col-sm-4">
                                    <div class="form-group">

                                        <asp:Button runat="server" ID="btnShowYearlyReport" OnClick="btnShowYearlyReport_Click" CssClass="btn btn-primary" Text="Show Report" ValidationGroup="validationR" />
                                    </div>

                                </div>


                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>

    </div>

    </div>