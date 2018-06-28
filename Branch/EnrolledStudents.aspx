<%@ Page Title="" Language="C#" MasterPageFile="~/Branch/Master.Master" AutoEventWireup="true" CodeBehind="EnrolledStudents.aspx.cs" Inherits="SchoolManagementSystem.Branch.EnrolledStudents" %>

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
                        Enrolled Students
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
                                            <asp:ListItem Text="Select level" Value="" Selected="True"></asp:ListItem>
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
                                        <%--<telerik:RadDatePicker RenderMode="Lightweight" ID="txtYear" Width="100%" runat="server" DateInput-CssClass="form-control clndr"  AutoPostBack="true" OnSelectedDateChanged="txtYear_SelectedDateChanged">
                                            <DateInput runat="server" DateFormat="dd/MM/yyyy" >
                                            </DateInput>
                                        </telerik:RadDatePicker>--%>
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
                                    <th>Class
                                    </th>
                                    <th>Session
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





</asp:Content>
