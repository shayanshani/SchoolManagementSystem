<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddEvents.aspx.cs" Inherits="SchoolManagementSystem.BranchMaster.AddEvents" %>

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
    </style>
    
    <div class="main-content container-fluid">

        <!--Basic forms-->
        <div class="row">
            <div class="col-sm-12">

                <div class="panel panel-default panel-border-color panel-border-color-primary">

                    <div class="panel panel-default panel-border-color panel-border-color-primary">

                        <asp:UpdatePanel ID="pnlMsg" runat="server">
                            <ContentTemplate>
                                <asp:Timer runat="server" ID="timerNews" Interval="10000" OnTick="timerEvent_Tick"></asp:Timer>
                                <div id="msgDiv" runat="server" visible="false" style="width: 50%; margin: auto; margin-top: 10px;">
                                    <div class="icon"><span id="icon" runat="server"></span></div>
                                    <div class="message">
                                        <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <div class="panel-heading panel-heading-divider">Add Events</div>
                        <div class="panel-body">

                            <div class="form-group xs-pt-4">
                                <label>Heading:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtHeading" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                <asp:TextBox ID="txtHeading" runat="server" CssClass="form-control"></asp:TextBox>

                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Insert Letters" ForeColor="Red" ValidationExpression="^[a-zA-z0-9 ]+$" ControlToValidate="txtHeading" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>

                            </div>

                            <div class="form-group xs-pt-10">
                                
                                <table>
                                    <tr>
                                        <td>
                                            <label>
                                                From time:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtFromTime" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>
                                            </label>
                                            <telerik:RadTimePicker ID="txtFromTime" RenderMode="Lightweight" runat="server" DateInput-CssClass="form-control clndr"></telerik:RadTimePicker>
                                        </td>
                                        <td>
                                            <label>
                                                To:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtTimeTo" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>

                                            </label>

                                            <telerik:RadTimePicker ID="txtTimeTo" RenderMode="Lightweight" runat="server" DateInput-CssClass="form-control clndr"></telerik:RadTimePicker>

                                        </td>
                                    </tr>
                                </table>

                            </div>

                            <div class="form-group">
                                            <label>Event Date: &nbsp&nbsp  <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtEventDate" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>
                                        </label>
                                       
                                          <telerik:RadDatePicker RenderMode="Lightweight" ID="txtEventDate" Width="100%" runat="server" DateInput-CssClass="form-control clndr">
                                               <DateInput runat="server" DateFormat="dd/MM/yyyy"> 
                                                </DateInput>                                          
                                          </telerik:RadDatePicker>
                                     <asp:CompareValidator ID="cmptodayDate" runat="server" Display="Dynamic" ControlToValidate="txtEventDate" type="Date" Operator="GreaterThan" ErrorMessage="Date must be greater then todays date" ForeColor="Red" ValidationGroup="validation"></asp:CompareValidator>

                                          
                                        </div>
                               <div class="form-group xs-pt-4">
                                <label>Venue:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtVenue" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                <asp:TextBox ID="txtVenue" runat="server" CssClass="form-control"></asp:TextBox>

                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Insert Letters" ForeColor="Red" ValidationExpression="^[a-zA-z0-9 ]+$" ControlToValidate="txtVenue" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>

                            </div>

                            <div class="form-group">
                                <label>
                                    Detail:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtDetail" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>
                                </label>
                                <asp:TextBox ID="txtDetail" runat="server" cols="29" Rows="5" TextMode="MultiLine" CssClass="form-control" Style="resize: none"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Some special characters not allowed" ForeColor="Red" ValidationExpression="[^$]+" ControlToValidate="txtDetail" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>

                            </div>

                            <div class="row xs-pt-15">
                                <div class="col-xs-6">
                                    <div class="be-checkbox">
                                    </div>
                                </div>
                                <div class="col-xs-6">
                                    <p class="text-right">
                                        <asp:Button ID="btnSave" runat="server" Text="Submit" class="btn btn-space btn-primary" OnClick="btnSave_Click" ValidationGroup="validation" />
                                        <%--<button class="btn btn-space btn-default">Cancel</button>--%>
                                    </p>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>

            </div>

        </div>
    </div>



</asp:Content>
