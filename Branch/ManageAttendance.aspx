<%@ Page Title="" Language="C#" MasterPageFile="~/Branch/Master.Master" AutoEventWireup="true" CodeBehind="ManageAttendance.aspx.cs" Inherits="SchoolManagementSystem.Branch.ManageAttendance" %>
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
                        Student Attendance
                    </div>
                    <div class="panel-body table-responsive">
                        <table id="table1" class="table table-striped table-hover table-fw-widget">
                            <thead>
                                <tr>
                                    <td colspan="1">
                                        <label>Select Level:</label>
                                        <asp:DropDownList ID="ddlLevel" runat="server" CssClass="form-control" AutoPostBack="true" Style="width: 100%!important" OnSelectedIndexChanged="ddlLevel_SelectedIndexChanged">
                                            <asp:ListItem Text="Select level" Value="" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="School" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="College" Value="2"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>

                                    <td colspan="1">
                                        <label>Select Class:</label>
                                        <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control" Style="width: 100%!important" AutoPostBack="true" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>

                                    <td colspan="1">
                                        <label>Select Group:</label>
                                        <asp:DropDownList ID="ddlGroups" runat="server" CssClass="form-control" Style="width: 100%!important" AutoPostBack="true" OnSelectedIndexChanged="ddlGroups_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>

                                </tr>

                                <tr>
                                    <th>Present/Absent</th>
                                    <th>Student Name</th>
                                    <th>Registration No</th>
                                    <th>Level</th>
                                    <th>Class</th>
                                    <th>Student Contact</th>
                                    <th>Gender</th>
                                </tr>

                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptStudents" runat="server" OnItemDataBound="rptStudents_ItemDataBound" DataSourceID="obsAttendace">
                                    <ItemTemplate>

                                        <asp:HiddenField ID="HfAttendaceID" runat="server" />

                                        <asp:HiddenField ID="hfStudentID" runat="server" Value='<%# Eval("StudentID") %>' />
                                        <asp:HiddenField ID="hfClassNo" runat="server" Value='<%# Eval("ClassNo") %>' />

                                        <tr class="even gradeX">
                                            <td>
                                                <div class="be-checkbox">
                                                    <asp:CheckBox ID="chkAll" runat="server" Checked="true" />
                                                    <label for='<%# getCheckBoxID() %>'></label>
                                                </div>
                                            </td>
                                            <td>
                                               <%# Eval("[StudentName]") %>
                                            </td>
                                            <th><%# Eval("RegistrationNo") %></th>
                                            <td>
                                                <%# Convert.ToInt32(Eval("[LevelID]"))==1 ? "School" : "College" %>
                                            </td>
                                            <td>
                                                <%# Eval("[ClassName]") %>-<%# Eval("[GroupName]") %>
                                            </td>
                                            <td><%# Eval("[SCellNo]") %></td>
                                            <td><%# Eval("[Gender]") %></td>

                                        </tr>

                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <tr>
                                            <td colspan="7" align="right">
                                                <asp:Button ID="btnSubmit" runat="server" class="btn btn-success" OnClick="btnSubmit_Click" Text="Submit" />
                                            </td>
                                        </tr>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>

                        <asp:HiddenField ID="hfGetBranchID" runat="server" />

                        <asp:ObjectDataSource ID="obsAttendace" runat="server" TypeName="SchoolManagementSystem.BL.TblAttendance" SelectMethod="Filter">
                            <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlLevel" PropertyName="SelectedValue" Name="LevelID"
                                    ConvertEmptyStringToNull="true" />

                                <asp:ControlParameter ControlID="ddlClass" PropertyName="SelectedValue" Name="ClassID"
                                    ConvertEmptyStringToNull="true" />

                                <asp:ControlParameter ControlID="ddlGroups" PropertyName="SelectedValue" Name="GroupID"
                                    ConvertEmptyStringToNull="true" />

                                <asp:ControlParameter ControlID="hfGetBranchID" PropertyName="Value" Name="BranchID" />

                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </div>
                </div>
            </div>
        </div>
    </div>




</asp:Content>
