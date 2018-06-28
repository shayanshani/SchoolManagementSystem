<%@ Page Title="" Language="C#" MasterPageFile="~/Branch/Master.Master" AutoEventWireup="true" CodeBehind="AddClassGroups.aspx.cs" Inherits="SchoolManagementSystem.Branch.AddClassGroups" %>

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


                    <div class="panel-heading panel-heading-divider">Groups</div>
                    <div class="panel-body table-responsive">
                        <div class="row">
                            <div class="col-sm-12">
                                <a href="#" data-modal="form-success" class="btn btn-space btn-success md-trigger">Add Group</a>
                            </div>
                        </div>
                        <table id="table1" class="table table-striped table-hover table-fw-widget">
                            <thead>
                                <tr>
                                    <th>Class</th>
                                    <th>Group</th>
                                    <th>Class incharge</th>
                                    <th>Action(s)</th>
                                </tr>
                            </thead>
                            <tbody>

                                <asp:Repeater ID="rptGroups" runat="server">
                           
                                    <ItemTemplate>
                                        <tr class="even gradeX">
                                            <td><%# Eval("ClassName") %></td>
                                            <td>
                                                <%# Eval("GroupName") %>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="btnAssignTo" runat="server" CommandArgument='<%# Eval("GroupID") %>' OnClick="btnAssignTo_Click">
                                                       <%# Convert.ToInt16(Eval("AssignTo"))==-1 ? "Unassigned" : Eval("EmployeeName") %>  
                                                </asp:LinkButton>
                                            </td>
                                            <td class="center">
                                                <asp:LinkButton ID="btnEdit" runat="server" OnClick="btnEdit_Click" CommandArgument='<%# Eval("[GroupID]") %>'><span class="mdi mdi-edit" style="font-size: 22px!important;"></span></asp:LinkButton>
                                                <%--            <asp:LinkButton ID="btnDelete" runat="server" OnClick="btnDelete_Click" CommandArgument='<%# Eval("[GroupID]") %>' CommandName='<%# Eval("[GroupName]") %>' OnClientClick='return confirm("Are you sure you want to delete this group?")'><span class="mdi mdi-delete" style="font-size: 22px!important;"></span></asp:LinkButton>
                                                --%>          </td>
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
    <asp:HiddenField ID="hfGroupID" runat="server" />

    <div id="form-success" class="modal-container colored-header colored-header-success custom-width modal-effect-9">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" data-dismiss="modal" aria-hidden="true" class="close modal-close" id="cls"><span class="mdi mdi-close"></span></button>
                <h3 class="modal-title">Add Group</h3>
            </div>
            <div class="modal-body form">

                <asp:UpdatePanel ID="pnlDrp" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="form-group">
                            <label>
                                Acedemic Level:&nbsp&nbsp
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="ddlLevel" InitialValue="-1" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>
                            </label>

                            <asp:DropDownList ID="ddlLevel" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlLevel_SelectedIndexChanged">
                                <asp:ListItem Text="--Select Level--" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="School" Value="1"></asp:ListItem>
                                <asp:ListItem Text="College" Value="2"></asp:ListItem>

                            </asp:DropDownList>
                        </div>

                        <div class="form-group">
                            <label>
                                Class:&nbsp&nbsp
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="ddlclass" InitialValue="-1" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>

                            </label>
                            <asp:DropDownList ID="ddlclass" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>


                <div class="form-group">
                    <label>
                        Enter group:&nbsp&nbsp
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtGroup" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>
                    </label>
                    <asp:TextBox ID="txtGroup" runat="server" CssClass="form-control" placeholder="Enter group"></asp:TextBox>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Insert Letters" ForeColor="Red" ValidationExpression="^[a-zA-z0-9 ]+$" ControlToValidate="txtGroup" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>

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
                <button type="button" data-dismiss="modal" aria-hidden="true" class="close modal-close" id="clsAssign"><span class="mdi mdi-close"></span></button>
                <h3 class="modal-title">Assign Group:</h3>
            </div>
            <div class="modal-body form">

                <asp:UpdatePanel ID="pnlAssign" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="form-group">
                            <label>
                                Select Designation:&nbsp&nbsp
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="ddlDesignation" InitialValue="-1" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation1"></asp:RequiredFieldValidator>

                            </label>
                            <asp:DropDownList ID="ddlDesignation" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlDesignation_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>


                        <div class="form-group">
                            <label>
                                Select Emlpoyee:&nbsp&nbsp
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="ddlEmployees" InitialValue="-1" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation1"></asp:RequiredFieldValidator>
                            </label>
                            <asp:DropDownList ID="ddlEmployees" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>


                <%--     <div class="form-group">
                    <label>
                        Select Group:&nbsp&nbsp
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="ddlGroups" InitialValue="-1" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation1"></asp:RequiredFieldValidator>

                    </label>
                    <asp:DropDownList ID="ddlGroups" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>--%>
            </div>

            <div class="modal-footer">
                <button type="button" data-dismiss="modal" class="btn btn-default modal-close" id="clsAssign1">Cancel</button>
                <asp:Button ID="btnAssign" runat="server" class="btn btn-success" OnClick="btnAssign_Click" Text="Assign" ValidationGroup="validation1" />
            </div>
        </div>
    </div>

    <div class="modal-overlay"></div>

    <script src="assets/lib/jquery/jquery.min.js" type="text/javascript"></script>
    <script src="assets/lib/perfect-scrollbar/js/perfect-scrollbar.jquery.min.js" type="text/javascript"></script>
    <script src="assets/js/main.js" type="text/javascript"></script>

    <script type="text/javascript">
        function openModal() {
            $('#form-success').addClass('modal-container colored-header colored-header-success custom-width modal-effect-9 modal-show');
        }

        function openModalAssignTo() {
            $('#form-success1').addClass('modal-container colored-header colored-header-success custom-width modal-effect-9 modal-show');
        }

        var b, a, c, d;

        b = document.getElementById('cls');
        a = document.getElementById('cls1');

        c = document.getElementById('clsAssign1');
        d = document.getElementById('clsAssign');

        c.onclick = function () {
            document.getElementById('ContentPlaceHolder1_ddlLevel').value = "-1";
            document.getElementById('ContentPlaceHolder1_ddlclass').value = "-1";
            document.getElementById('ContentPlaceHolder1_ddlDesignation').value = "-1";
            document.getElementById('ContentPlaceHolder1_ddlEmployees').value = "-1";
            document.getElementById('ContentPlaceHolder1_txtGroup').value = "";
            document.getElementById('ContentPlaceHolder1_hfGroupID').value = "";

            var frm = document.getElementById('form-success1');

            frm.setAttribute('class', 'modal-container colored-header colored-header-success custom-width modal-effect-9 modal-close');

        }

        d.onclick = function () {
            document.getElementById('ContentPlaceHolder1_ddlLevel').value = "-1";
            document.getElementById('ContentPlaceHolder1_ddlclass').value = "-1";
            document.getElementById('ContentPlaceHolder1_ddlDesignation').value = "-1";
            document.getElementById('ContentPlaceHolder1_ddlEmployees').value = "-1";
            document.getElementById('ContentPlaceHolder1_txtGroup').value = "";
            document.getElementById('ContentPlaceHolder1_hfGroupID').value = "";

            var frm = document.getElementById('form-success1');

            frm.setAttribute('class', 'modal-container colored-header colored-header-success custom-width modal-effect-9 modal-close');

        }

        b.onclick = function () {
            document.getElementById('ContentPlaceHolder1_ddlLevel').value = "-1";
            document.getElementById('ContentPlaceHolder1_ddlclass').value = "-1";
            document.getElementById('ContentPlaceHolder1_ddlDesignation').value = "-1";
            document.getElementById('ContentPlaceHolder1_ddlEmployees').value = "-1";
            document.getElementById('ContentPlaceHolder1_txtGroup').value = "";
            document.getElementById('ContentPlaceHolder1_hfGroupID').value = "";

            var frm = document.getElementById('form-success');

            frm.setAttribute('class', 'modal-container colored-header colored-header-success custom-width modal-effect-9 modal-close');

        }

        a.onclick = function () {
            document.getElementById('ContentPlaceHolder1_ddlLevel').value = "-1";
            document.getElementById('ContentPlaceHolder1_ddlclass').value = "-1";
            document.getElementById('ContentPlaceHolder1_ddlDesignation').value = "-1";
            document.getElementById('ContentPlaceHolder1_ddlEmployees').value = "-1";
            document.getElementById('ContentPlaceHolder1_txtGroup').value = "";
            document.getElementById('ContentPlaceHolder1_hfGroupID').value = "";

            var frm = document.getElementById('form-success');

            frm.setAttribute('class', 'modal-container colored-header colored-header-success custom-width modal-effect-9 modal-close');

        }

    </script>

</asp:Content>
