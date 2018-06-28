<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewEmployees.ascx.cs" Inherits="SchoolManagementSystem.Controls.ViewEmployees" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
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
                        Employees
                    </div>
                    <div class="panel-body table-responsive">
                        <div class="row">
                            <div class="col-sm-4">
                                Select Branch
                            </div>
                             <div class="col-sm-4">
                                <asp:DropDownList runat="server" ID="ddlBranches" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlBranches_SelectedIndexChanged">

                                </asp:DropDownList>
                            </div>
                        </div>
                        <table id="table1" class="table table-striped table-hover table-fw-widget">
                            <thead>
                                <tr>
                                    <th>Designation</th>
                                    <th>Name</th>
                                    <th>CNIC</th>
                                    <th>Contact</th>
                                    <th>Qualification</th>
                                    <th>Action(s)</th>
                                </tr>
                            </thead>
                            <tbody>

                                <asp:Repeater ID="rptEmployee" runat="server">
                                    <ItemTemplate>
                                        <tr class="even gradeX">
                                            <td><%# Eval("[Designation]") %></td>
                                            <td>
                                                <asp:LinkButton ID="lnkViewProfile" runat="server" OnClick="lnkViewProfile_Click" CommandArgument='<%# Eval("EmployeeID") %>'><%# Eval("[EmployeeName]") %></asp:LinkButton>
                                            </td>
                                            <td>
                                                    <asp:Literal ID="litCNIC"  runat="server" Text='<%# string.Format("{0:#####-#######-#}", Int64.Parse(Eval("CNIC").ToString())) %>' /> 
                                            </td>
                                            <td><%# Eval("[ContactNo]") %>
                                            </td>
                                            <td><%# Eval("[Qualification]") %></td>
                                            <td class="center">
                                                <asp:LinkButton ID="btnEdit" runat="server"  OnClick="btnEdit_Click" CommandArgument='<%# Eval("EmployeeID") %>'><span class="mdi mdi-edit" style="font-size: 22px!important;"></span></asp:LinkButton>
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