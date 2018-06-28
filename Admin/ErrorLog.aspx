<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ErrorLog.aspx.cs" Inherits="SchoolManagementSystem.Admin.ErrorLog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="main-content container-fluid">
        <div class="row">
            <div class="col-sm-12">
                <div class="panel panel-default panel-table" style="padding-top: 15px!important;">

                    <div class="panel-heading">
                        Error Log
                    </div>
                    <div class="panel-body table-responsive">
                        <table id="table1" class="table table-striped table-hover table-fw-widget">
                            <thead>
                                <tr>
                                    <th>Message</th>
                                    <th>Source</th>
                                    <th>Log Time</th>
                                    <th>Target Site</th>
                                    <th>Stack Trace</th>
                                    <th>Inner Exception</th>
                                </tr>
                            </thead>
                            <tbody>

                                <asp:Repeater ID="rptErrorLog" runat="server">
                                    <ItemTemplate>
                                        <tr class="even gradeX">
                                            <td><%# Eval("Message") %></td>
                                            <td>

                                                <%# Eval("Source") %> 
                                             
                                            </td>

                                            <td>
                                                <%# Eval("LogDateTime") %>
                                            </td>

                                                    <td>
                                                <%# Eval("TargetSite") %>
                                            </td>

                                            <td>

                                                <a href="#" data-modal="nft-fullWidth" data-id='<%# Eval("StackTrace") %>' class="AddData btn btn-space btn-primary md-trigger">View Details</a>
                                                
                                                <div id="nft-fullWidth" class="modal-container full-width modal-effect-1">
                                                    <div class="modal-content">
                                                        <div class="modal-header">
                                                            <button type="button" data-dismiss="modal" aria-hidden="true" class="close modal-close"><span class="mdi mdi-close"></span></button>
                                                        </div>
                                                        <div class="modal-body">
                                                            <div class="text-center">
                                                                <div class="text-primary"><span class="modal-main-icon mdi mdi-check"></span></div>
                                                                <h3>Detail!</h3>
                                                                <p id="Detail"><!-- Regiter from Jquery -->
                                                                   
                                                                </p>
                                                                 
                                                              <%--  <div class="xs-mt-50">
                                                                    <button type="button" data-dismiss="modal" class="btn btn-default btn-space modal-close">Cancel</button>
                                                                    <button type="button" data-dismiss="modal" class="btn btn-primary btn-space modal-close">Proceed</button>
                                                                </div>--%>
                                                            </div>
                                                        </div>
                                                        <div class="modal-footer"></div>
                                                    </div>
                                                </div>
                                              
                                            </td>

                                            <td>
                                                <%# Eval("InnerException") %>
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

</asp:Content>
