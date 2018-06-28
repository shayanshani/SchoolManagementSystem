<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddBuses.aspx.cs" MasterPageFile="~/Branch/Master.Master" Inherits="SchoolManagementSystem.Branch.AddBuses" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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


                    <div class="panel-heading panel-heading-divider">Bus Information</div>
                    <div class="panel-body table-responsive">
                        <div class="row">
                            <div class="col-sm-12">
                                <a href="#" data-modal="form-success" class="btn btn-space btn-success md-trigger">Add Bus</a>
                            </div>
                        </div>
                        <table id="table1" class="table table-striped table-hover table-fw-widget">
                            <thead>
                                <tr>
                                    <th>Route</th>
                                    <th>Bus No</th>
                                    <th>Total Seat</th>

                                    <th>Driver</th>
                                    <th>Status</th>
                                    <th>Action(s)</th>
                                </tr>
                            </thead>
                            <tbody>

                                <asp:Repeater ID="rptBus" runat="server">
                                    <ItemTemplate>
                                        <tr class="even gradeX">
                                            <td><%# Eval("Route") %></td>
                                            <td><%# Eval("BusNo") %></td>
                                            <td><%# Eval("Seats") %></td>
                                            <td>
                                                <asp:LinkButton ID="btnDriver" ClientIDMode="Static" runat="server" OnClick="btnDriver_Click" CommandArgument='<%# Eval("DID") %>' CommandName='<%# Eval("BusID") %>'><span class="mdi mdi-account"><%# Eval("DName") %></span></asp:LinkButton>

                                            </td>
                                            <td><%# Convert.ToInt32(Eval("IsActive")) == 0 ? "Inactive" : "Active" %></td>

                                            <td class="center">
                                                <asp:LinkButton ID="btnEdit" ClientIDMode="Static" runat="server" OnClick="btnEdit_Click" CommandArgument='<%# Eval("BusID") %>'><span class="mdi mdi-edit" style="font-size: 22px!important;"></span></asp:LinkButton>

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
    <asp:HiddenField ID="hdnBusID" runat="server" />
    <div id="form-success" class="modal-container colored-header colored-header-success custom-width modal-effect-9">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" data-dismiss="modal" aria-hidden="true" class="close modal-close" id="cls"><span class="mdi mdi-close"></span></button>
                <h3 class="modal-title">
                    <asp:Label runat="server" ID="BusPopupHeading" Text="Add New Bus"></asp:Label></h3>
            </div>
            <div class="modal-body form">
                <div class="form-group">
                    <label>
                        Select Route
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="ddlRoute" InitialValue="-1" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>
                    </label>

                    <asp:DropDownList runat="server" ID="ddlRoute" CssClass="form-control">
                    </asp:DropDownList>



                </div>
                <div class="form-group">
                    <label>
                        Bus No
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtBusNo" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>
                    </label>
                    <asp:TextBox ID="txtBusNo" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Insert Letters" ValidationExpression="^[a-zA-z0-9 ]+$" ControlToValidate="txtBusNo" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>

                </div>

                <div class="form-group">
                    <label>
                        Total Seats<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtTotalSeats" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>
                    </label>

                    <asp:TextBox ID="txtTotalSeats" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Insert Digits" ValidationExpression="^[0-9]+$" ControlToValidate="txtTotalSeats" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>

                </div>
                <div class="form-group">
                    <label>
                        Status<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="ddlstatus" InitialValue="-1" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>
                    </label>

                    <asp:DropDownList runat="server" ID="ddlstatus" CssClass="form-control">
                        <asp:ListItem Value="-1">Select Status</asp:ListItem>
                        <asp:ListItem Value="1">Active</asp:ListItem>
                        <asp:ListItem Value="0">Inactive</asp:ListItem>
                    </asp:DropDownList>



                </div>
            </div>
            <div class="modal-footer">
                <button type="button" data-dismiss="modal" class="btn btn-default modal-close" id="cls1">Cancel</button>
                <asp:Button ID="btnSave" runat="server" class="btn btn-success" OnClick="btnSave_Click" Text="Save" ValidationGroup="validation" />
            </div>
        </div>
    </div>

    <div id="form-success1" class="modal-container colored-header colored-header-success custom-width modal-effect-9">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" data-dismiss="modal" aria-hidden="true" class="close modal-close" id="clsdriver"><span class="mdi mdi-close"></span></button>
                <h3 class="modal-title">
                    <asp:Label runat="server" ID="lblDriverPopupHeader" Text="Add Driver Information"></asp:Label></h3>
            </div>
            <div class="modal-body form">
                <div class="form-group">
                    <label>
                        <asp:HiddenField runat="server" ID="hdndriverID" />
                        Bus No 
                    </label>

                    <asp:TextBox ID="txtBusNo1" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>




                </div>
                <div class="form-group">
                    <label>
                        Name<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtDName" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation1"></asp:RequiredFieldValidator>
                    </label>
                    <asp:TextBox ID="txtDName" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Insert Letters" ValidationExpression="^[a-zA-z ]+$" ControlToValidate="txtDName" Display="Dynamic" CssClass="error" ValidationGroup="validation1"></asp:RegularExpressionValidator>



                </div>
                <div class="form-group">
                    <label>
                        CNIC<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtDCnic" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation1"></asp:RequiredFieldValidator>
                    </label>


                    <asp:TextBox ID="txtDCnic" runat="server" CssClass="form-control"></asp:TextBox>

                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtDCnic" Mask="99999-9999999-9"
                        MessageValidatorTip="true"
                        InputDirection="LeftToRight" AcceptNegative="None" DisplayMoney="None"
                        ErrorTooltipEnabled="True" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Insert Digits" ValidationExpression="^[0-9]+$" ControlToValidate="txtDCnic" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>



                </div>
                <div class="form-group">
                    <label>
                        Address<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtDAddress" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation1"></asp:RequiredFieldValidator>
                    </label>

                    <asp:TextBox ID="txtDAddress" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>




                </div>
                <div class="form-group">
                    <label>
                        Mobile<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtDMobile" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation1"></asp:RequiredFieldValidator>
                    </label>

                    <asp:TextBox ID="txtDMobile" runat="server" CssClass="form-control" MaxLength="11"></asp:TextBox>
                    <ajaxToolkit:MaskedEditExtender ViewStateMode="Enabled" ID="MaskedEditExtender2" runat="server" TargetControlID="txtDMobile" Mask="(9999)-9999999"
                        MessageValidatorTip="true"
                        InputDirection="LeftToRight" AcceptNegative="None" DisplayMoney="None"
                        ErrorTooltipEnabled="True" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Insert Digits" ValidationExpression="^[0-9]+$" ControlToValidate="txtDMobile" Display="Dynamic" CssClass="error" ValidationGroup="validation1"></asp:RegularExpressionValidator>




                </div>

            </div>
            <div class="modal-footer">
                <button type="button" data-dismiss="modal" class="btn btn-default modal-close" id="clsdriver2">Cancel</button>
                <asp:Button ID="btnSaveDriver" runat="server" class="btn btn-success" OnClick="btnSaveDriver_Click" Text="Save" ValidationGroup="validation1" />
            </div>
        </div>
    </div>


    <div class="modal-overlay"></div>

    <script src="assets/lib/jquery/jquery.min.js" type="text/javascript"></script>
    <script src="assets/lib/perfect-scrollbar/js/perfect-scrollbar.jquery.min.js" type="text/javascript"></script>
    <script src="assets/js/main.js" type="text/javascript"></script>
    <script src="assets/lib/bootstrap/dist/js/bootstrap.min.js" type="text/javascript"></script>

    <script type="text/javascript">

        function openModalDriver() {
            $('#form-success1').addClass('modal-container colored-header colored-header-success custom-width modal-effect-9 modal-show');
        }
        var c, d;

        c = document.getElementById('clsdriver');
        d = document.getElementById('clsdriver2');


        d.onclick = function () {

            document.getElementById('ContentPlaceHolder1_txtBusNo1').value = "";
            document.getElementById('ContentPlaceHolder1_txtDName').value = "";
            document.getElementById('ContentPlaceHolder1_txtDCnic').value = "";
            document.getElementById('ContentPlaceHolder1_txtDAddress').value = "";
            document.getElementById('ContentPlaceHolder1_txtDMobile').value = "";

            document.getElementById('ContentPlaceHolder1_hdndriverID').value = "";

            var frm = document.getElementById('form-success1');

            frm.setAttribute('class', 'modal-container colored-header colored-header-success custom-width modal-effect-9 modal-close');

        }

        c.onclick = function () {
            document.getElementById('ContentPlaceHolder1_txtBusNo1').value = "";
            document.getElementById('ContentPlaceHolder1_txtDName').value = "";
            document.getElementById('ContentPlaceHolder1_txtDCnic').value = "";
            document.getElementById('ContentPlaceHolder1_txtDAddress').value = "";
            document.getElementById('ContentPlaceHolder1_txtDMobile').value = "";

            document.getElementById('ContentPlaceHolder1_hdndriverID').value = "";

            var frm = document.getElementById('form-success1');

            frm.setAttribute('class', 'modal-container colored-header colored-header-success custom-width modal-effect-9 modal-close');

        }

        function openModal() {
            $('#form-success').addClass('modal-container colored-header colored-header-success custom-width modal-effect-9 modal-show');
        }

        var b, a;

        b = document.getElementById('cls');
        a = document.getElementById('cls1');


        b.onclick = function () {
            document.getElementById('ContentPlaceHolder1_txtBusNo').value = "";
            document.getElementById('ContentPlaceHolder1_ddlRoute').value = "";
            document.getElementById('ContentPlaceHolder1_txtTotalSeats').value = "";
            document.getElementById('ContentPlaceHolder1_ddlstatus').value = "-1";

            document.getElementById('ContentPlaceHolder1_hdnBusID').value = "";

            var frm = document.getElementById('form-success');

            frm.setAttribute('class', 'modal-container colored-header colored-header-success custom-width modal-effect-9 modal-close');

        }

        a.onclick = function () {
            document.getElementById('ContentPlaceHolder1_txtBusNo').value = "";
            document.getElementById('ContentPlaceHolder1_ddlRoute').value = "";
            document.getElementById('ContentPlaceHolder1_txtTotalSeats').value = "";
            document.getElementById('ContentPlaceHolder1_ddlstatus').value = "-1";

            document.getElementById('ContentPlaceHolder1_hdnBusID').value = "";
            var frm = document.getElementById('form-success');

            frm.setAttribute('class', 'modal-container colored-header colored-header-success custom-width modal-effect-9 modal-close');

        }

    </script>


</asp:Content>

