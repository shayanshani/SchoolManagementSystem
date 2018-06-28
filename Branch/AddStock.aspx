<%@ Page Title="" Language="C#" MasterPageFile="~/Branch/Master.Master" AutoEventWireup="true" CodeBehind="AddStock.aspx.cs" Inherits="SchoolManagementSystem.Branch.AddStock" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .clndr {
            height: 34px !important;
            border: 1px solid #CCC !important;
        }

        .row {
            margin-top: 10px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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


                    <div class="panel-heading panel-heading-divider">Add Stock</div>
                    <div class="panel-body">

                        <div class="row">
                            <div class="form-group">
                                <div class="col-sm-6">
                                    <label>Select Item:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="ddlItems" InitialValue="-1" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                    <asp:DropDownList ID="ddlItems" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                                <div class="col-sm-6">
                                    <label>Enter Quantity:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtQuantity" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                    <asp:TextBox ID="txtQuantity" MaxLength="10" runat="server" onkeyup="multiply();" CssClass="form-control"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Alphabets,special characters or space not allowed" ForeColor="Red" ValidationExpression="^[0-9]+$" ControlToValidate="txtQuantity" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="form-group">
                                <div class="col-sm-6">
                                    <label>Enter Price (per item):&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtPP" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                    <asp:TextBox ID="txtPP" MaxLength="10" runat="server" onkeyup="multiply();" CssClass="form-control"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Alphabets,special characters or space not allowed" ForeColor="Red" ValidationExpression="^[0-9.]+$" ControlToValidate="txtPP" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>
                                </div>
                                <div class="col-sm-6">
                                    <label>Total Price</label>
                                    <asp:TextBox ID="txtTotalPrice" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="form-group">
                                <div class="col-sm-6">
                                    <label>Purchase Date:&nbsp&nbsp 
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtPurchaseDate" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                    <telerik:RadDatePicker RenderMode="Lightweight" ID="txtPurchaseDate" Width="100%" runat="server" DateInput-CssClass="form-control clndr">
                                        <DateInput runat="server" DateFormat="dd/MM/yyyy">
                                        </DateInput>
                                    </telerik:RadDatePicker>
                                    <asp:CompareValidator ID="cmptodayDate" runat="server" Display="Dynamic" ControlToValidate="txtPurchaseDate" Type="Date" Operator="LessThanEqual" ErrorMessage="Purchase date must be less then or equal to todays date" ForeColor="Red" ValidationGroup="validation"></asp:CompareValidator>
                                </div>
                                <div class="col-sm-6">
                                    <label>Description:&nbsp&nbsp 
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtDescription" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                    <asp:TextBox ID="txtDescription" runat="server" cols="29" Rows="5" TextMode="MultiLine" CssClass="form-control" Style="resize: none"></asp:TextBox>
                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Alphabets,special characters or space not allowed" ForeColor="Red" ValidationExpression="^[0-9.a-zA-Z,_ ()]+$" ControlToValidate="txtDescription" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>


                        <div class="row xs-pt-15">
                            <div class="col-xs-6">
                                <p class="text-right">
                                    <asp:Button ID="btnSave" runat="server" Text="Submit" ValidationGroup="validation" class="btn btn-space btn-primary" OnClick="btnSave_Click" />
                                    <asp:HiddenField ID="hdnID" runat="server" />
                                    <asp:HiddenField ID="hdnQuantity" runat="server" />
                                </p>
                            </div>
                        </div>

                    </div>
                </div>
            </div>

        </div>

    </div>
    <script type="text/javascript">
        function multiply() {
            var txt1 = document.getElementById('<%= txtPP.ClientID %>');
            var txt2 = document.getElementById('<%= txtQuantity.ClientID %>');
            var result = txt1.value * txt2.value; //Here changes!

            var rstTxtbox = document.getElementById('<%= txtTotalPrice.ClientID %>');


            rstTxtbox.value = result;
        }
    </script>
</asp:Content>
