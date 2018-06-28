<%@ Page Title="" Language="C#" MasterPageFile="~/Branch/Master.Master" AutoEventWireup="true" CodeBehind="StudentPromotion.aspx.cs" Inherits="SchoolManagementSystem.Branch.StudentPromotion" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
                        Promote Students
                    </div>
                    <%--  <asp:UpdatePanel ID="pnl" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                        <ContentTemplate>--%>

                    <div class="panel-body table-responsive">
                        <table id="table1" class="table table-striped table-hover table-fw-widget">
                            <thead>
                                <tr>
                                    <td colspan="2">
                                        <label>Select Level:</label>
                                        <asp:DropDownList ID="ddlLevel" runat="server" CssClass="form-control" AutoPostBack="true" Style="width: 100%!important" OnSelectedIndexChanged="ddlLevel_SelectedIndexChanged">
                                            <asp:ListItem Text="Select level" Value="-1" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="School" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="College" Value="2"></asp:ListItem>

                                        </asp:DropDownList>
                                    </td>

                                    <td colspan="2">
                                        <label>Select Class:</label>
                                        <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control" Style="width: 100%!important" AutoPostBack="true" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>

                                    <td colspan="2">
                                        <label>Select Group:</label>
                                        <asp:DropDownList ID="ddlGroups" runat="server" CssClass="form-control" Style="width: 100%!important" AutoPostBack="true" OnSelectedIndexChanged="ddlGroups_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>

                                    <td colspan="2">
                                        <label>Select Year:</label>
                                        <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control" Style="width: 100%!important" AutoPostBack="true" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>

                                <tr>
                                    <th>Name</th>
                                    <th>Father Name</th>
                                    <th>Registration#</th>
                                    <th>Contact</th>
                                    <th>Gender</th>
                                    <th>Level
                                    </th>
                                    <th>Program
                                    </th>
                                    <th>Previous Class
                                    </th>
                                    <th>Previous
                                        Session
                                    </th>
                                    <th>Promotion Setup
                                    </th>
                                </tr>
                            </thead>
                            <tbody>

                                <asp:Repeater ID="rptEnrolledStudents" runat="server" DataSourceID="obsEnrolledStudents">
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
                                                <%# String.IsNullOrEmpty(Convert.ToString(Eval("[Program]"))) ? "N/A" : Eval("[Program]")  %>
                                            </td>
                                            <td>
                                                <%# Eval("[ClassName]") %>-<%# Eval("[GroupName]") %>
                                            </td>
                                            <td>
                                                <%# Eval("[SessionYear]") %> &nbsp <%# Eval("[Session]") %>
                                            </td>

                                            <td>
                                                <!-- School -->
                                                <asp:LinkButton ID="btnSchPromotion" runat="server" OnClick="btnSchPromotion_Click" Visible='<%# Convert.ToInt32(Eval("LevelID"))==1 %>' CommandArgument='<%# Eval("StudentID") %>' CommandName='<%# Eval("CEID") %>'>
                                                   <%-- <%# Convert.ToInt32(Eval("EnrollemntStatus"))>0 ? "Enrolled" : "Not Enrolled" %>--%>
                                                    Promote
                                                </asp:LinkButton>

                                                <!-- College -->
                                                <asp:LinkButton ID="btnClgPromotion" runat="server" OnClick="btnClgPromotion_Click" Visible='<%# Convert.ToInt32(Eval("LevelID"))==2 %>' CommandArgument='<%# Eval("StudentID") %>' CommandName='<%# Eval("CEID") %>'>
                                                    <%--<%# Convert.ToInt32(Eval("EnrollemntStatus"))>0 ? "Enrolled" : "Not Enrolled" %>--%>
                                                     Promote
                                                </asp:LinkButton>

                                            </td>

                                        </tr>

                                    </ItemTemplate>
                                </asp:Repeater>



                            </tbody>
                        </table>
                    </div>

                    <%-- </ContentTemplate>
                    </asp:UpdatePanel>--%>
                    <asp:HiddenField ID="hfGetBranchID" runat="server" />

                    <asp:ObjectDataSource ID="obsEnrolledStudents" runat="server" TypeName="SchoolManagementSystem.BL.TblStudent" SelectMethod="Filter">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlLevel" PropertyName="SelectedValue" Name="LevelID"
                                ConvertEmptyStringToNull="true" />

                            <asp:ControlParameter ControlID="ddlClass" PropertyName="SelectedValue" Name="ClassID"
                                ConvertEmptyStringToNull="true" />

                            <asp:ControlParameter ControlID="ddlGroups" PropertyName="SelectedValue" Name="GroupID"
                                ConvertEmptyStringToNull="true" />

                            <asp:ControlParameter ControlID="ddlYear" PropertyName="Text" Name="Session"
                                ConvertEmptyStringToNull="true" />

                            <asp:ControlParameter ControlID="hfGetBranchID" PropertyName="Value" Name="BranchID" />


                        </SelectParameters>
                    </asp:ObjectDataSource>
                </div>
            </div>
        </div>
    </div>

    <div id="form-success" class="modal-container colored-header colored-header-success custom-width modal-effect-9">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" id="cls" data-dismiss="modal" aria-hidden="true" class="close modal-close"><span class="mdi mdi-close"></span></button>
                <h3 class="modal-title">Student Promotion</h3>
            </div>
            <asp:UpdatePanel ID="pnlDrop" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-body form">

                        <div class="form-group">
                            <label>Select Level:</label>
                            <asp:DropDownList ID="ddlLevelP" runat="server" CssClass="form-control" AutoPostBack="true" Style="width: 100%!important" OnSelectedIndexChanged="ddlLevelP_SelectedIndexChanged">
                                <asp:ListItem Text="Select level" Value="-1" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="School" Value="1"></asp:ListItem>
                                <asp:ListItem Text="College" Value="2"></asp:ListItem>

                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>Select Class:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="ddlClass" InitialValue="-1" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                            <asp:DropDownList ID="ddlClassP" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlClassP_SelectedIndexChanged" CssClass="form-control input-sm"></asp:DropDownList>
                        </div>

                        <div class="form-group" id="divGroup" runat="server">
                            <label>Select Group:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="ddlGroup" InitialValue="-1" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                            <asp:DropDownList ID="ddlGroup" runat="server" CssClass="form-control input-sm"></asp:DropDownList>
                        </div>

                        <div class="form-group">
                            <label>
                                Promotion Date:&nbsp&nbsp 
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtEnrollmentDate" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                            <telerik:RadDatePicker RenderMode="Lightweight" ID="txtEnrollmentDate" Width="100%" runat="server" DateInput-CssClass="form-control clndr">
                                <DateInput runat="server" DateFormat="dd/MM/yyyy">
                                </DateInput>
                            </telerik:RadDatePicker>

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
    <asp:HiddenField ID="hfEnrollementIDToUpdate" runat="server" />
    <asp:HiddenField ID="hfschFeeID" runat="server" />


    <script src="assets/lib/jquery/jquery.min.js" type="text/javascript"></script>
    <script src="assets/lib/perfect-scrollbar/js/perfect-scrollbar.jquery.min.js" type="text/javascript"></script>
    <script src="assets/js/main.js" type="text/javascript"></script>


    <script type="text/javascript">
        function openModal() {
            $('#form-success').addClass('modal-container colored-header colored-header-success custom-width modal-effect-9 modal-show');
        }

        var b, a;

        b = document.getElementById('cls');
        a = document.getElementById('cls1');

        b.onclick = function () {
            document.getElementById('ContentPlaceHolder1_hfstudentID').value = "";
            document.getElementById('ContentPlaceHolder1_ddlClassP').value = "-1";
            document.getElementById('ContentPlaceHolder1_hfLevel').value = "";
            document.getElementById('ContentPlaceHolder1_hfEnrollementID').value = "";

            //if (document.getElementById('ContentPlaceHolder1_txtEnrollmentDate').value != null) {
            //    document.getElementById('ContentPlaceHolder1_txtEnrollmentDate').value = null;
            //}

            var frm = document.getElementById('form-success');
            frm.setAttribute('class', 'modal-container colored-header colored-header-success custom-width modal-effect-9 modal-close');

        }

        a.onclick = function () {
            document.getElementById('ContentPlaceHolder1_hfstudentID').value = "";
            document.getElementById('ContentPlaceHolder1_ddlClassP').value = "-1";
            document.getElementById('ContentPlaceHolder1_hfLevel').value = "";
            document.getElementById('ContentPlaceHolder1_hfEnrollementID').value = "";

            //if (document.getElementById('ContentPlaceHolder1_txtEnrollmentDate').value != null) {
            //    document.getElementById('ContentPlaceHolder1_txtEnrollmentDate').value = null;
            //}

            var frm = document.getElementById('form-success');
            frm.setAttribute('class', 'modal-container colored-header colored-header-success custom-width modal-effect-9 modal-close');
        }

    </script>

</asp:Content>

