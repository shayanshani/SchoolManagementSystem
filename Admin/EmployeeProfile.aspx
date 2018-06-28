<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeProfile.aspx.cs" Inherits="SchoolManagementSystem.Admin.EmployeeProfile" MasterPageFile="~/Admin/Admin.Master" %>
<%@ Register Src="~/Controls/EmployeeProfile.ascx" TagPrefix="FRC" TagName="ReportForm" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <style>
        .user-display-bg {
    max-height: 100px !important;
    
}
    </style>
       <FRC:ReportForm id="rptShow" runat="server" ></FRC:ReportForm>
</asp:Content>