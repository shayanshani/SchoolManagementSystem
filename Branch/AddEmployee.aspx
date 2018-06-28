<%@ Page Title="" Language="C#" MasterPageFile="~/Branch/Master.Master" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="SchoolManagementSystem.Branch.AddEmployee" %>

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

        .be-checkbox, .be-radio {
            padding: 0px 0 !important;
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


                    <div class="panel-heading panel-heading-divider">Add/Edit Employee</div>
                    <div class="panel-body">

                        <div class="row">
                            <div class="form-group">
                                <div class="col-sm-6">
                                    <label>Employee Name:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtName" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control" MaxLength="20"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator40" runat="server" ErrorMessage="Alphabets,special characters or space not allowed" ForeColor="Red" ValidationExpression="^[a-zA-Z ]+$" ControlToValidate="txtName" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>
                                </div>
                                <div class="col-sm-6">
                                    <label>Father Name:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtFName" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                    <asp:TextBox ID="txtFName" runat="server" MaxLength="20" CssClass="form-control"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Alphabets,special characters or space not allowed" ForeColor="Red" ValidationExpression="^[a-zA-Z ]+$" ControlToValidate="txtFName" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="form-group">
                                <div class="col-sm-6">
                                    <label>CNIC&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtCNIC" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                    <asp:TextBox ID="txtCNIC" runat="server" CssClass="form-control"></asp:TextBox>
                                    <%--        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter CNIC like 12101-1234567-1" ForeColor="Red" ValidationExpression="^[0-9]{5}[-][0-9]{7}[-][0-9]$" ControlToValidate="txtCNIC" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>

                                    --%>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtCNIC" Mask="99999-9999999-9"
                                        MessageValidatorTip="true"
                                        InputDirection="LeftToRight" AcceptNegative="None" DisplayMoney="None"
                                        ErrorTooltipEnabled="True" />


                                </div>
                                <div class="col-sm-6">
                                    <label>Contact&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtContact" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                    <asp:TextBox ID="txtContact" runat="server" CssClass="form-control"></asp:TextBox>

                                    <ajaxToolkit:MaskedEditExtender ViewStateMode="Enabled" ID="MaskedEditExtender2" runat="server" TargetControlID="txtContact" Mask="(9999)-9999999"
                                        MessageValidatorTip="true"
                                        InputDirection="LeftToRight" AcceptNegative="None" DisplayMoney="None"
                                        ErrorTooltipEnabled="True" />

                                    <%--         <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="Enter number like +92-300-1234567" ForeColor="Red" ValidationExpression="^[+][0-9]{2}[-][0-9]{3}[-][0-9]{7}$" ControlToValidate="txtContact" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>
                                    --%>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="form-group">
                                <div class="col-sm-6">
                                    <label>
                                        Date of Birth:&nbsp&nbsp 
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtDOB" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                    <telerik:RadDatePicker RenderMode="Lightweight" ID="txtDOB" Width="100%" runat="server" DateInput-CssClass="form-control clndr">
                                        <DateInput runat="server" DateFormat="dd/MM/yyyy">
                                        </DateInput>
                                    </telerik:RadDatePicker>
                                    <asp:CompareValidator ID="cmptodayDate" runat="server" Display="Dynamic" ControlToValidate="txtDOB" Type="Date" Operator="LessThanEqual" ErrorMessage="Date of birth must be less then today's date" ForeColor="Red" ValidationGroup="validation"></asp:CompareValidator>
                                </div>
                                <div class="col-sm-6">

                                    <label>
                                        Date of Joining:&nbsp&nbsp 
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtDOJ" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                    <telerik:RadDatePicker RenderMode="Lightweight" ID="txtDOJ" Width="100%" runat="server" DateInput-CssClass="form-control clndr">
                                        <DateInput runat="server" DateFormat="dd/MM/yyyy">
                                        </DateInput>
                                    </telerik:RadDatePicker>
                                    <%-- <asp:CompareValidator ID="cmpDOJ" runat="server" Display="Dynamic" ControlToValidate="txtDOJ" Type="Date" Operator="GreaterThanEqual" ErrorMessage="Date pf joining must be Greater then or equal to todays date" ForeColor="Red" ValidationGroup="validation"></asp:CompareValidator>--%>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="form-group">
                                <div class="col-sm-6">
                                    <label>Qualification&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtQualification" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                    <asp:TextBox ID="txtQualification" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Number or special characters not allowed" ForeColor="Red" ValidationExpression="^[a-zA-Z()0-9 -,]+$" ControlToValidate="txtQualification" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>
                                </div>
                                <div class="col-sm-6">
                                    <label>Select Designation:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="ddlDesignation" InitialValue="-1" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                    <asp:DropDownList ID="ddlDesignation" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="form-group">
                                <div class="col-sm-12">
                                    <label>
                                        Address:&nbsp&nbsp 
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator200" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtAddress" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                    <asp:TextBox ID="txtAddress" runat="server" cols="29" Rows="5" TextMode="MultiLine" CssClass="form-control" Style="resize: none"></asp:TextBox>

                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group">
                                <div class="col-sm-6">
                                    <label>Gender</label>
                                    <div class="be-radio inline">

                                        <asp:RadioButton ID="rdoMale" runat="server" GroupName="gender" />
                                        <label for="ContentPlaceHolder1_rdoMale">Male </label>


                                        <asp:RadioButton ID="rdoFemale" runat="server" GroupName="gender" />&nbsp;
                                     <label for="ContentPlaceHolder1_rdoFemale">Female</label>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="be-checkbox inline">
                                        <asp:CheckBox runat="server" ID="chkTransport" />

                                        <label for="ContentPlaceHolder1_chkTransport">Transport</label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group">
                                <div class="col-sm-6">
                                    <label>Status</label>
                                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                                        <asp:ListItem Selected="True" Value="True">Active</asp:ListItem>
                                        <asp:ListItem Value="False">InActive</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>


                        <div class="row xs-pt-15">
                            <div class="col-xs-6">
                                <p class="text-right">
                                    <asp:Button ID="btnSave" runat="server" Text="Submit" ValidationGroup="validation" class="btn btn-space btn-primary" OnClick="btnSave_Click" />
                                    <asp:HiddenField ID="hdnID" runat="server" />
                                    <asp:HiddenField ID="hdnpic" runat="server" />
                                </p>
                            </div>
                        </div>

                    </div>
                </div>
            </div>

        </div>

    </div>
    <div id="form-success" class="modal-container colored-header colored-header-success custom-width modal-effect-9">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" id="cls" data-dismiss="modal" aria-hidden="true" class="close modal-close"><span class="mdi mdi-close"></span></button>
                <h3 class="modal-title">Transport Information</h3>
            </div>
            <div class="modal-body form">
                <div class="row">
                    <div class="form-group">
                        <asp:UpdatePanel ID="updatepanel1" runat="server">
                            <ContentTemplate>
                                <div class="col-sm-6">
                                    <label>Select Route:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="ddlRoute" InitialValue="-1" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation2"></asp:RequiredFieldValidator></label>
                                    <asp:DropDownList ID="ddlRoute" AutoPostBack="true" OnSelectedIndexChanged="ddlRoute_SelectedIndexChanged" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                                <div class="col-sm-6">
                                    <label>Select Bus:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="ddlBus" InitialValue="-1" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation2"></asp:RequiredFieldValidator></label>
                                    <asp:DropDownList ID="ddlBus" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>

                <div class="row">
                    <div class="form-group">
                        <div class="col-sm-6">
                            <label>Discount:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtDiscount" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation2"></asp:RequiredFieldValidator></label>
                            <asp:TextBox ID="txtDiscount" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Insert Letters" ForeColor="Red" ValidationExpression="^[0-9]+$" ControlToValidate="txtDiscount" Display="Dynamic" CssClass="error" ValidationGroup="validation2"></asp:RegularExpressionValidator>
                        </div>
                        <div class="col-sm-6">
                            <label>Seat#:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtSeatNo" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation2"></asp:RequiredFieldValidator></label>
                            <asp:TextBox ID="txtSeatNo" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Insert Letters" ForeColor="Red" ValidationExpression="^[0-9]+$" ControlToValidate="txtSeatNo" Display="Dynamic" CssClass="error" ValidationGroup="validation2"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="form-group">
                        <div class="col-sm-6">
                            <label>Joining Date:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtTJoinDate" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation2"></asp:RequiredFieldValidator></label>
                            <telerik:RadDatePicker RenderMode="Lightweight" ID="txtTJoinDate" Width="100%" runat="server" DateInput-CssClass="form-control clndr">
                                <DateInput runat="server" DateFormat="dd/MM/yyyy">
                                </DateInput>
                            </telerik:RadDatePicker>
                        </div>
                        <div class="col-sm-6">
                            <label>Bus Stop:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtBusStop" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation2"></asp:RequiredFieldValidator></label>
                            <asp:TextBox ID="txtBusStop" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="Insert Letters" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9 ]+$" ControlToValidate="txtBusStop" Display="Dynamic" CssClass="error" ValidationGroup="validation2"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <button type="button" id="cls1" data-dismiss="modal" class="btn btn-default modal-close">Cancel</button>
                <asp:Button ID="btnSubmit" runat="server" class="btn btn-success" OnClick="btnSubmit_Click" ValidationGroup="validation2" Text="Submit" />
            </div>
        </div>
    </div>
    <div class="modal-overlay"></div>
    <script src="assets/lib/jquery/jquery.min.js" type="text/javascript"></script>
    <script src="assets/lib/perfect-scrollbar/js/perfect-scrollbar.jquery.min.js" type="text/javascript"></script>
    <script src="assets/js/main.js" type="text/javascript"></script>
    <%--  <script src="assets/lib/bootstrap/dist/js/bootstrap.min.js" type="text/javascript"></script>--%>

    <script type="text/javascript">

        function openModal() {
            $('#form-success').addClass('modal-container colored-header colored-header-success custom-width modal-effect-9 modal-show');
        }

        var b, a;

        b = document.getElementById('cls');
        a = document.getElementById('cls1');

        b.onclick = function () {
            document.getElementById('ContentPlaceHolder1_hdnID').value = "";
            var frm = document.getElementById('form-success');
            frm.setAttribute('class', 'modal-container colored-header colored-header-success custom-width modal-effect-9 modal-close');

        }

        a.onclick = function () {
            document.getElementById('ContentPlaceHolder1_hdnID').value = "";
            var frm = document.getElementById('form-success');
            frm.setAttribute('class', 'modal-container colored-header colored-header-success custom-width modal-effect-9 modal-close');
        }

    </script>

</asp:Content>

