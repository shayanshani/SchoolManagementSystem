<%@ Page Title="" Language="C#" MasterPageFile="~/Branch/Master.Master" AutoEventWireup="true" CodeBehind="SubjectAssignment.aspx.cs" Inherits="SchoolManagementSystem.Branch.SubjectAssignment" %>

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


                    <div class="panel-heading panel-heading-divider">Assign Subjects</div>
                    <div class="panel-body table-responsive">
                        <div class="row">
                            <div class="col-sm-12">
                                <a href="#" data-modal="form-success" class="btn btn-space btn-success md-trigger">Assign Subject</a>
                            </div>
                        </div>
                        <table id="table1" class="table table-striped table-hover table-fw-widget">
                            <thead>
                                <tr>
                                    <td colspan="1">
                                        <label>Select academic level:</label>
                                        <asp:DropDownList ID="ddlLevel" runat="server" CssClass="form-control" Style="width: 100%!important" AutoPostBack="true" OnSelectedIndexChanged="ddlLevel_SelectedIndexChanged">
                                            <asp:ListItem Text="--Select Level--" Value="-1"></asp:ListItem>
                                            <asp:ListItem Text="School" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="College" Value="2"></asp:ListItem>

                                        </asp:DropDownList>
                                    </td>

                                    <td colspan="1">
                                        <label>Select Class:</label>
                                        <asp:DropDownList ID="DDLClass" runat="server" CssClass="form-control" Style="width: 100%!important" AutoPostBack="true" OnSelectedIndexChanged="DDLClass_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>

                                <tr>
                                    <th>Academic Level
                                    </th>
                                    <th>Class</th>

                                    <th>Subject</th>
                                    <th>AssignTo</th>
                                    <th>Subject Marks</th>
                                    <th>Status</th>
                                    <th>Action(s)</th>
                                </tr>
                            </thead>
                            <tbody>

                                <asp:Repeater ID="rptAssignSubjects" runat="server" DataSourceID="obsAssignSubjects">
                                    <ItemTemplate>
                                        <tr class="even gradeX">
                                            <td><%# Convert.ToInt16(Eval("LvlID"))==1 ? "School" : "College" %></td>
                                            <td><%# Eval("ClassName") %></td>
                                            <td><%# Eval("SubjectName") %></td>
                                            <td>
                                                <asp:LinkButton ID="btnAssignTO" runat="server" CommandArgument='<%# Eval("[AssignID]") %>' CommandName='<%# Eval("DesignationID") %>' OnClick="btnAssignTO_Click">
                                                    <%# Convert.ToInt32(Eval("AssignTo"))==-1 ? "Unassigned" : Eval("EmployeeName") %>
                                                </asp:LinkButton>
                                            </td>
                                            <td><%# Eval("TotalMarks") %></td>
                                            <td><%# Convert.ToInt16(Eval("isActive"))==1 ? "Active" : "Inactive" %></td>

                                            <td class="center">
                                                <asp:LinkButton ID="btnEdit" runat="server" OnClick="btnEdit_Click" CommandArgument='<%# Eval("[AssignID]") %>'><span class="mdi mdi-edit" style="font-size: 22px!important;"></span></asp:LinkButton>
                                            </td>
                                        </tr>

                                    </ItemTemplate>
                                </asp:Repeater>
                                <asp:HiddenField ID="hfGetBranchID" runat="server" />

                                <asp:ObjectDataSource ID="obsAssignSubjects" runat="server" TypeName="SchoolManagementSystem.BL.TblSubject" SelectMethod="FilterAssignSubjects">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlLevel" PropertyName="SelectedValue" Name="LevelID"
                                            ConvertEmptyStringToNull="true" />
                                        <asp:ControlParameter ControlID="DDLClass" PropertyName="SelectedValue" Name="ClassID"
                                            ConvertEmptyStringToNull="true" />
                                        <asp:ControlParameter ControlID="hfGetBranchID" PropertyName="Value" Name="BranchID" />

                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hfAssignID" runat="server" />
    <div id="form-success" class="modal-container colored-header colored-header-success custom-width modal-effect-9">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" data-dismiss="modal" aria-hidden="true" class="close modal-close" id="cls"><span class="mdi mdi-close"></span></button>
                <h3 class="modal-title">Assign Subjects</h3>
            </div>
            <div class="modal-body form">
                <asp:UpdatePanel ID="pnlAssignSubject" runat="server">
                    <ContentTemplate>
                        <div class="form-group">
                            <label>
                                Select academic level:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="ddlAcLevel" InitialValue="-1" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>
                            </label>
                            <asp:DropDownList ID="ddlAcLevel" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlAcLevel_SelectedIndexChanged">

                                <asp:ListItem Text="--Select Level--" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="School" Value="1"></asp:ListItem>
                                <asp:ListItem Text="College" Value="2"></asp:ListItem>

                            </asp:DropDownList>
                        </div>

                        <div class="form-group">
                            <label>
                                Select class:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="ddlAsClass" InitialValue="-1" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>

                            </label>
                            <asp:DropDownList ID="ddlAsClass" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </div>


                        <div class="form-group">
                            <label>
                                Select subject:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="ddlSubjects" InitialValue="-1" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>

                            </label>
                            <asp:DropDownList ID="ddlSubjects" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </div>

                        <div class="form-group">
                            <label>
                                Enter Marks:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtMarks" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>

                            </label>
                            <asp:TextBox ID="txtMarks" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>


                    </ContentTemplate>
                </asp:UpdatePanel>



            </div>

            <div class="modal-footer">
                <button type="button" data-dismiss="modal" class="btn btn-default modal-close" id="cls1">Cancel</button>
                <asp:Button ID="btnSave" runat="server" class="btn btn-success" OnClick="btnSave_Click" Text="Assign" ValidationGroup="validation" />
            </div>
        </div>
    </div>


    <div id="form-success1" class="modal-container colored-header colored-header-success custom-width modal-effect-9">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" data-dismiss="modal" aria-hidden="true" class="close modal-close" id="clscros"><span class="mdi mdi-close"></span></button>
                <h3 class="modal-title">Assign Subjects to employee</h3>
            </div>
            <div class="modal-body form">
                <asp:UpdatePanel ID="pnlAssignEmploye" runat="server">
                    <ContentTemplate>

                        <div class="form-group">
                            <label>
                                Select Employee Designation:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="ddlDesignation" InitialValue="-1" ErrorMessage="*" ForeColor="Red" ValidationGroup="validationEmp"></asp:RequiredFieldValidator>
                            </label>
                            <asp:DropDownList ID="ddlDesignation" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlDesignation_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>

                        </div>

                        <div class="form-group">
                            <label>
                                Select Employee:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="ddlSubjects" InitialValue="-1" ErrorMessage="*" ForeColor="Red" ValidationGroup="validationEmp"></asp:RequiredFieldValidator>
                            </label>
                            <asp:DropDownList ID="ddlEmployees" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>



            </div>

            <div class="modal-footer">
                <button type="button" data-dismiss="modal" class="btn btn-default modal-close" id="cls2">Cancel</button>
                <asp:Button ID="btnAssigntoEmployee" runat="server" class="btn btn-success" OnClick="btnAssigntoEmployee_Click" Text="Assign" ValidationGroup="validationEmp" />
            </div>
        </div>
    </div>



    <div class="modal-overlay"></div>

    <script src="assets/lib/jquery/jquery.min.js" type="text/javascript"></script>
    <script src="assets/lib/perfect-scrollbar/js/perfect-scrollbar.jquery.min.js" type="text/javascript"></script>
    <script src="assets/js/main.js" type="text/javascript"></script>
    <script src="assets/lib/bootstrap/dist/js/bootstrap.min.js" type="text/javascript"></script>

    <script type="text/javascript">
        function openModal() {
            $('#form-success').addClass('modal-container colored-header colored-header-success custom-width modal-effect-9 modal-show');
        }

        function openEmployeeModal() {
            $('#form-success1').addClass('modal-container colored-header colored-header-success custom-width modal-effect-9 modal-show');
        }

        var b, a,d,e;

        b = document.getElementById('cls');
        a = document.getElementById('cls1');

        d = document.getElementById('clscros');
        e = document.getElementById('cls2');


        d.onclick = function () {
            document.getElementById('ContentPlaceHolder1_ddlDesignation').value = "-1";
            document.getElementById('ContentPlaceHolder1_ddlAsClass').value = "-1";
            document.getElementById('ContentPlaceHolder1_hfAssignID').value = "";

            var frm = document.getElementById('form-success1');

            frm.setAttribute('class', 'modal-container colored-header colored-header-success custom-width modal-effect-9 modal-close');

        }
        

        e.onclick = function () {
            document.getElementById('ContentPlaceHolder1_ddlAcLevel').value = "-1";
            document.getElementById('ContentPlaceHolder1_ddlEmployees').value = "-1";
            document.getElementById('ContentPlaceHolder1_hfAssignID').value = "";
            var frm = document.getElementById('form-success1');
            frm.setAttribute('class', 'modal-container colored-header colored-header-success custom-width modal-effect-9 modal-close');
        }

        b.onclick = function () {
            document.getElementById('ContentPlaceHolder1_ddlAcLevel').value = "-1";
            document.getElementById('ContentPlaceHolder1_ddlEmployees').value = "-1";
            document.getElementById('ContentPlaceHolder1_hfAssignID').value = "";

            var frm = document.getElementById('form-success1');

            frm.setAttribute('class', 'modal-container colored-header colored-header-success custom-width modal-effect-9 modal-close');

        }

        a.onclick = function () {
            document.getElementById('ContentPlaceHolder1_ddlAcLevel').value = "-1";
            document.getElementById('ContentPlaceHolder1_ddlAsClass').value = "-1";
            document.getElementById('ContentPlaceHolder1_ddlSubjects').value = "-1";
            document.getElementById('ContentPlaceHolder1_txtMarks').value = "";
            document.getElementById('ContentPlaceHolder1_hfAssignID').value = "";

            var frm = document.getElementById('form-success');

            frm.setAttribute('class', 'modal-container colored-header colored-header-success custom-width modal-effect-9 modal-close');

        }

    </script>


</asp:Content>
