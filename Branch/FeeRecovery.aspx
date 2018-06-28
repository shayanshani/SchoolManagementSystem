<%@ Page Title="" Language="C#" MasterPageFile="~/Branch/Master.Master" AutoEventWireup="true" CodeBehind="FeeRecovery.aspx.cs" Inherits="SchoolManagementSystem.Branch.FeeRecovery" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .clndr {
            height: 34px !important;
            border: 1px solid #CCC !important;
        }

        .lblRDsch {
            font-size: 15px !important;
        }

        .lblfee {
            padding-top: 12px !important;
            color: #000 !important;
        }
    </style>

    <div class="main-content container-fluid">
        <asp:HiddenField runat="server" ID="hdnCEID" />
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


                    <div class="panel-heading panel-heading-divider">
                        <center>
                                                Fee Recovery (<%= Session["BranchName"] %>) <br />
                                  <span style="font-size:13px">Pak Pearl School and Cologe (Session 2016-17)</span>  
                            </center>

                    </div>

                    <div class="panel-body">

                        <div class="row">
                            <div class="form-group">
                                <div class="col-sm-4">
                                    <table>
                                        <tr>
                                            <td>
                                                <label>Admission no:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtAdmissionNO" ErrorMessage="*" ForeColor="Red" ValidationGroup="validationSearch"></asp:RequiredFieldValidator></label>
                                                <asp:TextBox ID="txtAdmissionNO" runat="server" CssClass="form-control"></asp:TextBox>

                                            </td>
                                            <td>&nbsp&nbsp&nbsp&nbsp
                                            </td>
                                            <td>
                                                <label style="visibility: hidden!important">Admission no:&nbsp&nbsp<asp:RequiredFieldValidator Enabled="false" ID="RequiredFieldValidator6" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtAdmissionNO" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                                <asp:Button ID="btnSearch" runat="server" Text="Go" class="btn btn-space btn-primary" OnClick="btnSearch_Click" ValidationGroup="validationSearch" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="col-md-12">
                                    <div class="panel panel-border-color panel-border-color-primary">
                                        <div class="panel-heading">
                                            <div class="row">
                                                <div class="col-sm-4">
                                                    <b>Student Name:</b>&nbsp<asp:Label ID="lblStudentName" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-sm-4">
                                                    <b>Class:</b>&nbsp<asp:Label ID="lblClass" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                        </div>


                                        <div class="panel-body">
                                            <p>
                                                <table border="1" style="width: 100%" class="table table-condensed table-bordered table-striped">
                                                    <tr>
                                                        <th>Scholarship
                                                        </th>
                                                        <th>Admission fee(Once)
                                                        </th>
                                                        <th>Monthly fee
                                                        </th>
                                                        <th>Discount 
                                                        </th>
                                                    </tr>

                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblscholarship" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblAdmissionFee" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblMonthlyFee" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lbldiscount" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>

                                                </table>
                                            </p>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>


                        <div class="row">
                            <div class="col-lg-12">
                            </div>
                            <div class="form-group">

                                <div class="col-lg-6">
                                    <label>
                                        Fee Type:&nbsp
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="ddlFeeType" InitialValue="-1" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:DropDownList ID="ddlFeeType" runat="server" OnSelectedIndexChanged="ddlFeeType_SelectedIndexChanged" CssClass="form-control" AutoPostBack="true">
                                        <asp:ListItem Text="--Select Type--" Value="-1" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Admission Fee" Value="Admission Fee"></asp:ListItem>
                                        <asp:ListItem Text="Re-Admission Fee" Value="Re-Admission Fee"></asp:ListItem>
                                        <asp:ListItem Text="Monthly Fee" Value="Monthly Fee"></asp:ListItem>


                                    </asp:DropDownList>
                                </div>

                            </div>
                        </div>

                        <div class="row">
                            <div class="form-group">

                                <div class="col-lg-6">
                                    <label>
                                        Date:&nbsp&nbsp
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtDate" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>
                                    </label>
                                    <telerik:RadDatePicker RenderMode="Lightweight" ID="txtDate" Width="100%" runat="server" DateInput-CssClass="form-control clndr">
                                        <DateInput runat="server" DateFormat="dd/MM/yyyy">
                                        </DateInput>
                                    </telerik:RadDatePicker>
                                    <%--<asp:CompareValidator ID="cmptodayDate" runat="server" Display="Dynamic" ControlToValidate="txtDate" Type="Date" Operator="LessThanEqual" ErrorMessage="Date of birth must be less then today's date" ForeColor="Red" ValidationGroup="validation"></asp:CompareValidator>--%>
                                </div>

                            </div>
                        </div>



                        <div class="row">
                            <div class="form-group">

                                <div class="col-lg-6">
                                    <label>
                                        Fee Amount:&nbsp&nbsp
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtDate" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtFeePayable" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>

                            </div>
                        </div>


                        <div class="row">
                            <div class="form-group">
                                <div class="col-lg-6">
                                    <label>
                                        Fee Payable:&nbsp&nbsp
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtDate" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtAmountRecieve" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>

                            </div>
                        </div>

                        <div class="row xs-pt-15">
                            <div class="col-xs-6">
                                <p class="text-right">
                                    <asp:Button ID="btnSave" runat="server" Text="Submit" ValidationGroup="validation" class="btn btn-space btn-primary" OnClick="btnSave_Click" />
                                </p>
                            </div>
                        </div>

                    </div>


                    <div class="row">
                        <div class="col-sm-12">

                            <div class="panel-heading panel-heading-divider">Previous Fee(s) Details</div>
                            <div class="panel-body table-responsive">

                                <table id="table1" class="table table-striped table-hover table-fw-widget">
                                    <thead>
                                        <tr>
                                            <th>Fee Type</th>
                                            <th>Amount</th>
                                            <th>Date</th>
                                            <th>Action</th>
                                        </tr>
                                    </thead>
                                    <tbody>

                                        <asp:Repeater ID="rptFeeRecovery" runat="server">
                                            <ItemTemplate>
                                                <tr class="even gradeX">
                                                    <td><%# Eval("FeeType") %></td>
                                                    <td class="center"><%# Eval("Amount") %></td>
                                                    <td class="center">
                                                        <%# Eval("Date") %>  </td>
                                                    <td class="center">
                                                          <asp:LinkButton ID="btnDelete" runat="server" OnClick="btnDelete_Click" CommandArgument='<%# Eval("FeeID") %>' OnClientClick='return confirm("Are you sure you want to delete this?")'><span class="mdi mdi-delete" style="font-size: 22px!important;"></span></asp:LinkButton>
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
        </div>



    </div>
</asp:Content>
