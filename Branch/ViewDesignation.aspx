<%@ Page Title="" Language="C#" MasterPageFile="~/Branch/Master.Master" AutoEventWireup="true" CodeBehind="ViewDesignation.aspx.cs" CodeFile="~/Branch/ViewDesignation.aspx.cs" Inherits="SchoolManagementSystem.Branch.ViewDesignation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-content container-fluid">

        <div class="row">
            <div class="col-sm-12">
                <div class="panel panel-default panel-border-color panel-border-color-primary" style="padding-top: 15px!important;">

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


                    <div class="panel-heading">
                        Designation
                    </div>
                    <div class="panel-body table-responsive">
                        <div class="row">
                            <div class="col-sm-12">
                                <a href="#" data-modal="form-success" class="btn btn-space btn-success md-trigger">Add New Designation</a>
                            </div>
                        </div>

                        <table id="table1" class="table table-striped table-hover table-fw-widget">
                            <thead>
                                <tr>
                                    <th>Designation</th>
                                    <th>Action(s)</th>
                                </tr>
                            </thead>
                            <tbody>

                                <asp:Repeater ID="rptDesignation" runat="server">
                                    <ItemTemplate>
                                        <tr class="even gradeX">
                                            <td><%# Eval("[Designation]") %></td>
                                            <td class="center">
                                                <asp:LinkButton ID="btnEdit" runat="server" OnClick="btnEdit_Click" CommandArgument='<%# Eval("DesignationID") %>'><span class="mdi mdi-edit" style="font-size: 22px!important;"></span></asp:LinkButton>
                                                <%-- <asp:LinkButton ID="btnDelete" runat="server" OnClick="btnDelete_Click" CommandArgument='<%# Eval("DesignationID") %>' OnClientClick='return confirm("Are you sure you want to delete this item?")'><span class="mdi mdi-delete" style="font-size: 22px!important;"></span></asp:LinkButton>--%>
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

    <div id="form-success" class="modal-container colored-header colored-header-success custom-width modal-effect-9">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" id="cls" data-dismiss="modal" aria-hidden="true" class="close modal-close"><span class="mdi mdi-close"></span></button>
                <h3 class="modal-title">Add New Designation</h3>
            </div>
            <div class="modal-body form">
                <div class="form-group">
                    <label>Enter Designation:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtDesignation" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                    <asp:TextBox ID="txtDesignation" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Insert Letters" ForeColor="Red" ValidationExpression="^[a-zA-Z ]+$" ControlToValidate="txtDesignation" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="modal-footer">
                <button type="button" id="cls1" data-dismiss="modal" class="btn btn-default modal-close">Cancel</button>
                <asp:Button ID="btnSave" runat="server" class="btn btn-success" OnClick="btnSave_Click" ValidationGroup="validation" Text="Save" />
            </div>
        </div>
    </div>
    <div class="modal-overlay"></div>
    <asp:HiddenField ID="hdnid" runat="server" />
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
            document.getElementById('ContentPlaceHolder1_txtDesignation').value = "";
            document.getElementById('ContentPlaceHolder1_hdnid').value = "";
            var frm = document.getElementById('form-success');
            frm.setAttribute('class', 'modal-container colored-header colored-header-success custom-width modal-effect-9 modal-close');

        }

        a.onclick = function () {
            document.getElementById('ContentPlaceHolder1_txtDesignation').value = "";
            document.getElementById('ContentPlaceHolder1_hdnid').value = "";
            var frm = document.getElementById('form-success');
            frm.setAttribute('class', 'modal-container colored-header colored-header-success custom-width modal-effect-9 modal-close');
        }

    </script>
</asp:Content>
