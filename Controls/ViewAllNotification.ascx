<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewAllNotification.ascx.cs" Inherits="SchoolManagementSystem.Controls.ViewAllNotification" %>
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
</style>

<div class="main-content container-fluid">

    <div class="row">
        <!--White alert icon colored-->
        <div class="col-sm-12">
            <div class="panel panel-default">
                <div class="panel-heading panel-heading-divider">Notifications<span class="panel-subtitle"></span></div>
                <div class="panel-body">


                    <asp:Repeater ID="rptNotifications" runat="server">
                        <ItemTemplate>


                            <div role="alert" class="alert alert-success alert-icon alert-icon-colored alert-dismissible">
                                <div class="icon"><span class="mdi mdi-notifications"></span></div>
                               
                                 <div class="message">
                                    <%--    <button type="button" data-dismiss="alert" aria-label="Close" class="close"><span aria-hidden="true" class="mdi mdi-delete"></span></button>
                              --%>
                                    <a href="../Branch/ReadNotification.aspx?val=<%#  Eval("NotificationID") %>">

                                        <strong><%# Eval("NotificationSubject") %>!</strong>
                                        <br />
                                        <%# Eval("ShortMessage") %>

                                    </a>
                                </div>

                            </div>

                        </ItemTemplate>
                    </asp:Repeater>


                </div>
            </div>
        </div>

    </div>

</div>
