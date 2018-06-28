<%@ Page Title="" Language="C#" MasterPageFile="~/Branch/Master.Master" AutoEventWireup="true" CodeBehind="ViewStudents.aspx.cs" Inherits="SchoolManagementSystem.Branch.ViewStudents" %>

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
                        Students
                    </div>
                    <div class="panel-body table-responsive">
                        <table id="table1" class="table table-striped table-hover table-fw-widget">
                            <thead>
                                <tr>
                                    <th>Name</th>
                                    <th>Father Name</th>
                                    <th>Registration#</th>
                                    <th>Contact</th>
                                    <th>Gender</th>
                                    <th>Level
                                    </th>
                                    <th>Enrollemnt Setup
                                    </th>
                                    <th>Fee Setup</th>

                                    <th>Action(s)</th>
                                </tr>
                            </thead>
                            <tbody>

                                <asp:Repeater ID="rptStudents" runat="server">
                                    <ItemTemplate>
                                        <tr class="even gradeX">
                                            <td>
                                                <asp:LinkButton ID="lnkViewProfile" runat="server" OnClick="lnkViewProfile_Click" CommandArgument='<%# Eval("StudentID") %>'><%# Eval("[StudentName]") %></asp:LinkButton>
                                            </td>
                                            <td><%# Eval("[FatherName]") %></td>
                                            <td><%# Eval("[RegistrationNo]") %></td>
                                            <td><%# Eval("[SCellNo]") %></td>
                                            <td><%# Eval("[Gender]") %></td>
                                            <td>
                                                <%# Convert.ToInt32(Eval("LevelID"))==1 ? "School" : "College" %>
                                            </td>

                                            <td>
                                                <!-- College -->
                                                <asp:LinkButton ID="btnSchoolEnroll" runat="server" OnClick="btnSchoolEnroll_Click" Visible='<%# Convert.ToInt32(Eval("LevelID"))==1 %>' CommandArgument='<%# Eval("StudentID") %>' CommandName='<%# Eval("LevelID") %>'>
                                                    <%# Convert.ToInt32(Eval("EnrollemntStatus"))>0 ? "Enrolled" : "Not Enrolled" %>
                                                </asp:LinkButton>

                                                <!-- School -->
                                                <asp:LinkButton ID="btnClgEnroll" runat="server" OnClick="btnClgEnroll_Click" Visible='<%# Convert.ToInt32(Eval("LevelID"))==2 %>' CommandArgument='<%# Eval("StudentID") %>' CommandName='<%# Eval("LevelID") %>'>
                                                    <%# Convert.ToInt32(Eval("EnrollemntStatus"))>0 ? "Enrolled" : "Not Enrolled" %>
                                                </asp:LinkButton>

                                            </td>

                                             <%# Convert.ToInt32(Eval("LevelID"))>1?"<td><a href='ClgFeeEnrolement.aspx?val="+ Eval("RegistrationNo") +"'>"+
                                                 (Convert.ToInt32(Eval("[CFeeStatus]"))>0?"Completed":"Not Set"+"</a></td>"):
                                                 "<td><a href='SchFeeEnrolement.aspx?val="+ Eval("RegistrationNo") +"'>"+
                                                 (Convert.ToInt32(Eval("[SFeeStatus]"))>0?"Completed":"Not Set")+"</a></td>"
                                                  %>



                                            <td class="center">
                                                <asp:LinkButton ID="btnEdit" runat="server" OnClick="btnEdit_Click" CommandArgument='<%# Eval("StudentID") %>'><span class="mdi mdi-edit" style="font-size: 22px!important;"></span></asp:LinkButton>
                                                <%--<asp:LinkButton ID="btnDelete" runat="server" OnClick="btnDelete_Click" CommandArgument='<%# Eval("EmployeeID") %>' OnClientClick='return confirm("Are you sure you want to delete this item?")'><span class="mdi mdi-delete" style="font-size: 22px!important;"></span></asp:LinkButton>--%>
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
    <div id="form-successClg" class="modal-container colored-header colored-header-success custom-width modal-effect-9">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" id="cls" data-dismiss="modal" aria-hidden="true" class="close modal-close"><span class="mdi mdi-close"></span></button>
                <h3 class="modal-title">Student College Enrollment</h3>
            </div>
            <asp:UpdatePanel ID="pnlDrop" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-body form">

                        <div class="form-group">
                            <label>Select Class:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="ddlClass" InitialValue="-1" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                            <asp:DropDownList ID="ddlClass" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged" CssClass="form-control input-sm"></asp:DropDownList>
                        </div>

                        <div class="form-group" id="divGroup" runat="server">
                            <label>Select Group:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="ddlGroup" InitialValue="-1" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                            <asp:DropDownList ID="ddlGroup" runat="server" CssClass="form-control input-sm"></asp:DropDownList>
                        </div>

                        <div class="form-group">
                            <label>
                                Enrollement Date:&nbsp&nbsp 
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtEnrollmentDate" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                            <telerik:RadDatePicker RenderMode="Lightweight" ID="txtEnrollmentDate" Width="100%" runat="server" DateInput-CssClass="form-control clndr">
                                <DateInput runat="server" DateFormat="dd/MM/yyyy">
                                </DateInput>
                            </telerik:RadDatePicker>
                            <%--       <asp:CompareValidator ID="cmptodayDate" runat="server" Display="Dynamic" ControlToValidate="txtEnrollmentDate" Type="Date" Operator="LessThanEqual" ErrorMessage="Date of birth must be less then today's date" ForeColor="Red" ValidationGroup="validation"></asp:CompareValidator>
                            --%>
                        </div>

                        <div class="form-group">
                            <label>Select Status:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="ddlStatus" InitialValue="-1" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control input-sm">
                                <asp:ListItem Selected="True" Value="-1">Select Status</asp:ListItem>
                                <asp:ListItem Value="1">Active</asp:ListItem>
                                <asp:ListItem Value="0">InActive</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

            <div class="modal-footer">
                <button type="button" id="cls1" data-dismiss="modal" class="btn btn-default modal-close">Cancel</button>
                <asp:Button ID="btnSave" runat="server" class="btn btn-success" OnClick="btnSave_Click" ValidationGroup="validation" Text="Save" />
            </div>
        </div>
    </div>
    <div class="modal-overlay"></div>
    <asp:HiddenField ID="hfstudentID" runat="server" />
    <asp:HiddenField ID="hfLevel" runat="server" />
    <asp:HiddenField ID="hfEnrollementID" runat="server" />

    <script src="assets/lib/jquery/jquery.min.js" type="text/javascript"></script>
    <script src="assets/lib/perfect-scrollbar/js/perfect-scrollbar.jquery.min.js" type="text/javascript"></script>
    <script src="assets/js/main.js" type="text/javascript"></script>
    <%--  <script src="assets/lib/bootstrap/dist/js/bootstrap.min.js" type="text/javascript"></script>--%>



    <script type="text/javascript">
        function openModal() {
            $('#form-successClg').addClass('modal-container colored-header colored-header-success custom-width modal-effect-9 modal-show');
        }

        var b, a;

        b = document.getElementById('cls');
        a = document.getElementById('cls1');

        b.onclick = function () {
            document.getElementById('ContentPlaceHolder1_hfstudentID').value = "";
            document.getElementById('ContentPlaceHolder1_ddlClass').value = "-1";

            document.getElementById('ContentPlaceHolder1_ddlStatus').value = "-1";
            document.getElementById('ContentPlaceHolder1_hfLevel').value = "";
            document.getElementById('ContentPlaceHolder1_hfEnrollementID').value = "";

            //if (document.getElementById('ContentPlaceHolder1_txtEnrollmentDate').value != null) {
            //    document.getElementById('ContentPlaceHolder1_txtEnrollmentDate').value = null;
            //}

            var frm = document.getElementById('form-successClg');
            frm.setAttribute('class', 'modal-container colored-header colored-header-success custom-width modal-effect-9 modal-close');

        }

        a.onclick = function () {
            document.getElementById('ContentPlaceHolder1_hfstudentID').value = "";
            document.getElementById('ContentPlaceHolder1_ddlClass').value = "-1";
            document.getElementById('ContentPlaceHolder1_ddlStatus').value = "-1";
            document.getElementById('ContentPlaceHolder1_hfLevel').value = "";
            document.getElementById('ContentPlaceHolder1_hfEnrollementID').value = "";

            //if (document.getElementById('ContentPlaceHolder1_txtEnrollmentDate').value != null) {
            //    document.getElementById('ContentPlaceHolder1_txtEnrollmentDate').value = null;
            //}

            var frm = document.getElementById('form-successClg');
            frm.setAttribute('class', 'modal-container colored-header colored-header-success custom-width modal-effect-9 modal-close');
        }

    </script>
</asp:Content>
