<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewEmployees.aspx.cs" Inherits="SchoolManagementSystem.Admin.viewEmployees" MasterPageFile="~/Admin/Admin.Master" %>
 <%@ Register Src="~/Controls/ViewEmployees.ascx" TagPrefix="FRC" TagName="ReportForm" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <style>
        .user-display-bg {
    max-height: 100px !important;
    
}
    </style>
       <FRC:ReportForm id="rptShow" runat="server" ></FRC:ReportForm>
</asp:Content>
 