<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeProfile.ascx.cs" Inherits="SchoolManagementSystem.Controls.EmployeeProfile" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<div class="main-content container-fluid">
    <div class="user-profile">
        <div class="row">
            <asp:Repeater runat="server" ID="rptEmployeeProfile">
                <ItemTemplate>
                    <div class="col-md-12">
                        <div class="user-display">
                            <div class="user-display-bg">
                                <img src="assets/img/user-profile-display.png" alt="Profile Background"></div>
                            <div class="user-display-bottom">
                                <div class="user-display-avatar">
                                    <img src="assets/img/avatar-150.png" alt="Avatar"></div>
                                <div class="user-display-info">
                                    <div class="name"><%# Eval("EmployeeName") %> </div>
                                    <div class="nick"><span class="mdi mdi-account"></span><%# Eval("Designation") %> at <%# Eval("BranchName") %></div>
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="col-md-5">
                        <div class="user-info-list panel panel-default">
                            <div class="panel-heading panel-heading-divider">About <%# Eval("EmployeeName") %> :<span class="panel-subtitle">Employee appointed as <%# Eval("Designation") %> on <%#Convert.ToDateTime( Eval("DOJ")).ToString("dd/MM/yyyy")%><%# Convert.ToBoolean(Eval("IsActive").ToString())==true ? "stil our active Employee": "is now inactive" %> </span></div>
                            <div class="panel-body">
                                <table class="no-border no-strip skills">
                                    <tbody class="no-border-x no-border-y">
                                        <tr>
                                            <td class="icon"><span class="mdi mdi-case"></span></td>
                                            <td class="item">Designation<span class="icon s7-portfolio"></span></td>
                                            <td><%# Eval("Designation") %> </td>
                                        </tr>
                                        <tr>
                                            <td class="icon"><span class="mdi mdi-calendar"></span></td>
                                            <td class="item">Date Of Joining<span class="icon s7-portfolio"></span></td>
                                            <td><%#Convert.ToDateTime( Eval("DOJ")).ToString("dd/MM/yyyy")%></td>
                                        </tr>
                                        <tr>
                                            <td class="icon"><span class="mdi mdi-cake"></span></td>
                                            <td class="item">Birthday<span class="icon s7-gift"></span></td>
                                            <td><%#Convert.ToDateTime( Eval("DOB")).ToString("dd/MM/yyyy")%></td>
                                        </tr>
                                        <tr>
                                            <td class="icon"><span class="mdi mdi-smartphone-android"></span></td>
                                            <td class="item">Mobile<span class="icon s7-phone"></span></td>
                                            <td><%# Eval("ContactNo") %> </td>
                                        </tr>
                                        <tr>
                                            <td class="icon"><span class="mdi mdi-pin"></span></td>
                                            <td class="item">Location<span class="icon s7-map-marker"></span></td>
                                            <td><%# Eval("Address") %></td>
                                        </tr>
                                        <tr>
                                            <td class="icon"><span class="mdi mdi-arrow-missed"></span></td>
                                            <td class="item">Employee Status<span class="icon s7-ps-active-x"></span></td>
                                            <td><%# Convert.ToBoolean(Eval("IsActive").ToString())==true ? "Active": " Inactive" %> </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

            <div class="col-md-7">
                <div class="widget widget-fullwidth widget-small">
                    <div class="widget-head xs-pb-30">
                        <div class="tools"><span class="icon mdi mdi-chevron-down"></span><span class="icon mdi mdi-refresh-sync"></span><span class="icon mdi mdi-close"></span></div>
                        <div class="title">Class And Subject Information</div>
                    </div>
                    <div class="widget-chart-container">

                        <table class="table table-striped table-hover">
                            <thead>
                                <tr>
                                    <th style="width: 37%;">Class</th>
                                    <th style="width: 36%;">Subject Name</th>

                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="rptAssignSubjects">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Eval("ClassName") %></td>
                                            <td><%# Eval("SubjectName") %></td>


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
</div>
