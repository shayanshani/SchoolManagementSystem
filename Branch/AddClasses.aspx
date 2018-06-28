<%@ Page Title="" Language="C#" MasterPageFile="~/Branch/Master.Master" AutoEventWireup="true" CodeBehind="AddClasses.aspx.cs" Inherits="SchoolManagementSystem.Branch.AddClasses" %>

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
                            <asp:Timer runat="server" ID="timerNews" Interval="10000" OnTick="timerNews_Tick1"></asp:Timer>
                            <div id="msgDiv" runat="server" visible="false" style="width: 50%; margin: auto; margin-top: 10px;">
                                <div class="icon"><span id="icon" runat="server"></span></div>
                                <div class="message">
                                    <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>


                    <div class="panel-heading panel-heading-divider">Classes</div>
                    <div class="panel-body table-responsive">
                        <div class="row">
                            <div class="col-sm-12">
                                <a href="#" data-modal="form-success" class="btn btn-space btn-success md-trigger">Add Class</a>
                            </div>
                        </div>
                        <table id="table1" class="table table-striped table-hover table-fw-widget">
                            <thead>
                                <tr>
                                    <th>Academic level</th>
                                    <th>Class</th>

                                    <th>Action(s)</th>
                                </tr>
                            </thead>
                            <tbody>

                                <asp:Repeater ID="rptClasses" runat="server">
                                    <ItemTemplate>
                                        <tr class="even gradeX">
                                            <td><%# Convert.ToInt16(Eval("LevelID"))==1 ? "School" : "College" %></td>
                                            <td><%# Eval("ClassName") %></td>
                                            <td class="center">
                                                <asp:LinkButton ID="btnEdit" runat="server" OnClick="btnEdit_Click" CommandArgument='<%# Eval("[ClassNo]") %>'><span class="mdi mdi-edit" style="font-size: 22px!important;"></span></asp:LinkButton>
                                                <%--            <asp:LinkButton ID="btnDelete" runat="server" OnClick="btnDelete_Click" CommandArgument='<%# Eval("[ClassNo]") %>' CommandName='<%# Eval("[ClassName]") %>' OnClientClick='return confirm("Are you sure you want to delete this class?")'><span class="mdi mdi-delete" style="font-size: 22px!important;"></span></asp:LinkButton>
                                                --%>         </td>
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
    <asp:HiddenField ID="hfClassID" runat="server" />
    <div id="form-success" class="modal-container colored-header colored-header-success custom-width modal-effect-9">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" data-dismiss="modal" aria-hidden="true" class="close modal-close" id="cls"><span class="mdi mdi-close"></span></button>
                <h3 class="modal-title">
                    <asp:Label ID="lblPopUpHeading" runat="server" Text="Add Class"></asp:Label>
                </h3>
            </div>
            <asp:UpdatePanel ID="pnl" runat="server">
                <ContentTemplate>
                    <div class="modal-body form">
                        <div class="form-group">
                            <label>
                                Acedemic Level:&nbsp&nbsp
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="ddlLevel" InitialValue="-1" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>

                            </label>
                            <asp:DropDownList ID="ddlLevel" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlLevel_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Text="--Select Level--" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="School" Value="1"></asp:ListItem>
                                <asp:ListItem Text="College" Value="2"></asp:ListItem>

                            </asp:DropDownList>
                        </div>

                        <div class="form-group">
                            <label>
                                Enter Class:&nbsp&nbsp
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtClass" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>
                            </label>
                            <asp:TextBox ID="txtClass" runat="server" CssClass="form-control" placeholder="Enter Class"></asp:TextBox>

                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Insert Letters" ForeColor="Red" ValidationExpression="^[a-zA-z0-9 ]+$" ControlToValidate="txtClass" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>

                        </div>
                        <div id="admissionmonth" runat="server">
                            <div class="form-group">
                                <label>
                                    Admission Fee:&nbsp&nbsp
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtAdmissionFee" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>
                                </label>
                                <asp:TextBox ID="txtAdmissionFee" runat="server" CssClass="form-control" placeholder="Enter Admission Fee"></asp:TextBox>

                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Insert numbers" ForeColor="Red" ValidationExpression="^[0-9,]+$" ControlToValidate="txtAdmissionFee" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>

                            </div>
                            <div class="form-group">
                                <label>
                                    Monthly Fee:&nbsp&nbsp
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtMOnthlyFee" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>
                                </label>
                                <asp:TextBox ID="txtMOnthlyFee" runat="server" CssClass="form-control" placeholder="Enter Monthly Fee"></asp:TextBox>

                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Insert Numbers" ForeColor="Red" ValidationExpression="^[0-9,]+$" ControlToValidate="txtMOnthlyFee" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>

                            </div>
                        </div>

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>


            <div class="modal-footer">
                <button type="button" data-dismiss="modal" class="btn btn-default modal-close" id="cls1">Cancel</button>
                <asp:Button ID="btnSave" runat="server" class="btn btn-success" OnClick="btnSave_Click" Text="Save" ValidationGroup="validation" />
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
            document.getElementById('ContentPlaceHolder1_ddlLevel').value = "-1";
            document.getElementById('ContentPlaceHolder1_txtClass').value = "";
            document.getElementById('ContentPlaceHolder1_hfClassID').value = "";

            var frm = document.getElementById('form-success');

            frm.setAttribute('class', 'modal-container colored-header colored-header-success custom-width modal-effect-9 modal-close');

        }

        a.onclick = function () {
            document.getElementById('ContentPlaceHolder1_ddlLevel').value = "-1";
            document.getElementById('ContentPlaceHolder1_txtClass').value = "";
            document.getElementById('ContentPlaceHolder1_hfClassID').value = "";

            var frm = document.getElementById('form-success');

            frm.setAttribute('class', 'modal-container colored-header colored-header-success custom-width modal-effect-9 modal-close');

        }

    </script>


</asp:Content>
