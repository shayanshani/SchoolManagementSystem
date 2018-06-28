<%@ Page Title="" Language="C#" MasterPageFile="~/Branch/Master.Master" AutoEventWireup="true" CodeBehind="AddExpenses.aspx.cs" Inherits="SchoolManagementSystem.Branch.AddExpenses" %>

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
                    <asp:UpdatePanel ID="pnlMsg" runat="server">
                        <ContentTemplate>
                             <asp:Timer runat="server" id="timerNews" Interval="10000" OnTick="timerNews_Tick"></asp:Timer>
                            <div id="msgDiv" runat="server" visible="false" style="width: 50%; margin: auto; margin-top: 10px;">
                                <div class="icon"><span id="icon" runat="server"></span></div>
                                <div class="message">
                                    <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    

                    <div class="panel-heading panel-heading-divider">Add Expenses</div>
                    <div class="panel-body">

                         <div class="form-group xs-pt-10">
                           <label>Expense Head:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="ddlExpenseHead" InitialValue="-1" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                            <asp:DropDownList ID="ddlExpenseHead" runat="server" CssClass="form-control"></asp:DropDownList>
                      
                        </div>


                        <div class="form-group xs-pt-10">
                            <label>Title:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtTitle" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                            <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox>

                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Insert Letters" ForeColor="Red" ValidationExpression="^[a-zA-z0-9 ]+$" ControlToValidate="txtTitle" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>

                        </div>

                      
                        <div class="form-group">
                            <label>
                                Amount:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtAmount" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>
                            </label>
                            <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Insert Only Digits" ForeColor="Red" ValidationExpression="^[0-9]+$" ControlToValidate="txtAmount" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>
                        </div>

                        <div class="form-group">
                            <label>
                                Description:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtDescription" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>
                            </label>
                            <asp:TextBox ID="txtDescription" runat="server" cols="29" Rows="5" TextMode="MultiLine" CssClass="form-control" Style="resize: none"></asp:TextBox>
                        </div>

                         <div class="form-group">
                                            <label>Expense Date: &nbsp&nbsp  <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtExpenseDate" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>
                                        </label>
                                       
                                          <telerik:RadDatePicker RenderMode="Lightweight" ID="txtExpenseDate" DateInput-ReadOnly="true" Width="100%" runat="server" DateInput-CssClass="form-control clndr"></telerik:RadDatePicker>
                                     <asp:CompareValidator ID="cmptodayDate" runat="server" Display="Dynamic" ControlToValidate="txtExpenseDate" type="Date" Operator="LessThanEqual" ErrorMessage="Date must be less then todays date" ForeColor="Red" ValidationGroup="validation"></asp:CompareValidator>

                                          
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



</asp:Content>
