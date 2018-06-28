<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StudentAttendace.ascx.cs" Inherits="SchoolManagementSystem.Controls.StudentAttendace" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


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


                <div class="panel-heading">
                    Student Attendance
                </div>
                <%--  <asp:UpdatePanel ID="pnl" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                        <ContentTemplate>--%>

                <div class="panel-body table-responsive">
                    <table id="table1" class="table table-striped table-hover table-fw-widget">
                        <thead>
                            <tr>
                                <td colspan="2">
                                    <label>Select Level:</label>
                                    <asp:DropDownList ID="ddlLevel" runat="server" CssClass="form-control input-sm" AutoPostBack="true" Style="width: 100%!important" OnSelectedIndexChanged="ddlLevel_SelectedIndexChanged">
                                        <asp:ListItem Text="Select level" Value="" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="School" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="College" Value="2"></asp:ListItem>

                                    </asp:DropDownList>
                                </td>

                                <td colspan="2">
                                    <label>Select Class:</label>
                                    <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control input-sm" Style="width: 100%!important" AutoPostBack="true" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>

                                <td colspan="2">
                                    <label>Select Group:</label>
                                    <asp:DropDownList ID="ddlGroups" runat="server" CssClass="form-control input-sm" Style="width: 100%!important" AutoPostBack="true" OnSelectedIndexChanged="ddlGroups_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>

                                <td colspan="2">
                                    <label>Select Date:</label>
                                    <telerik:RadDatePicker RenderMode="Lightweight" ID="txtDate" Width="100%" runat="server" DateInput-CssClass="form-control clndr" AutoPostBack="true" OnSelectedDateChanged="txtDate_SelectedDateChanged">
                                        <DateInput runat="server" DateFormat="dd/MM/yyyy">
                                        </DateInput>
                                    </telerik:RadDatePicker>
                                </td>
                            </tr>

                            <tr>
                                <th>Name</th>
                                <th>Father Name</th>
                                <th>Registration#</th>
                                 <th>Level
                                </th>
                                <th>Program
                                </th>
                                <th>Class
                                </th>
                               <th>
                                   Date
                               </th> 
                                <th>
                                    Present/Absent
                                </th>
                                <th>
                                    <asp:Label ID="lblAbsenties" runat="server"></asp:Label>-Absenties
                                </th>
                            </tr>
                        </thead>
                        <tbody>

                            <asp:Repeater ID="rptStudentAttendance" runat="server" DataSourceID="obsStudentAttendance">
                                <ItemTemplate>
                                    <tr class="even gradeX">
                                        <td>
                                            <asp:LinkButton ID="lnkViewProfile" runat="server" OnClick="lnkViewProfile_Click" CommandArgument='<%# Eval("StudentID") %>'><%# Eval("[StudentName]") %></asp:LinkButton>
                                        </td>
                                        <td><%# Eval("[FatherName]") %></td>
                                        <td><%# Eval("[RegistrationNo]") %></td>
                      <%--                  <td><%# Eval("[SCellNo]") %></td>
                                        <td><%# Eval("[Gender]") %></td>--%>
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
                                            <%# Eval("[AttendanceDate]") %>
                                        </td>
                                        <td>
                                            <%# Convert.ToBoolean(Eval("isPresent"))==true ? "Present" : "Absent" %>
                                        </td>
                                        <td>
                                            <%# Eval("Absenties") %>
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

                <asp:ObjectDataSource ID="obsStudentAttendance" runat="server" TypeName="SchoolManagementSystem.BL.TblAttendance" SelectMethod="FilterList">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlLevel" PropertyName="SelectedValue" Name="LevelID"
                            ConvertEmptyStringToNull="true" />

                        <asp:ControlParameter ControlID="ddlClass" PropertyName="SelectedValue" Name="ClassID"
                            ConvertEmptyStringToNull="true" />

                        <asp:ControlParameter ControlID="ddlGroups" PropertyName="SelectedValue" Name="GroupID"
                            ConvertEmptyStringToNull="true" />

                        <asp:ControlParameter ControlID="txtDate" PropertyName="SelectedDate" Name="Date"
                            ConvertEmptyStringToNull="true" />

                        <asp:ControlParameter ControlID="hfGetBranchID" PropertyName="Value" Name="BranchID" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
        </div>
    </div>
</div>
