<%@ Page Title="" Language="C#" MasterPageFile="~/Branch/Master.Master" AutoEventWireup="true" CodeBehind="ViewEmployee.aspx.cs" Inherits="SchoolManagementSystem.Branch.ViewEmployee" %>

 <%@ Register Src="~/Controls/ViewEmployees.ascx" TagPrefix="FRC" TagName="ReportForm" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <style>
        .user-display-bg {
    max-height: 100px !important;
    
}
    </style>
       <FRC:ReportForm id="rptShow" runat="server" ></FRC:ReportForm>
</asp:Content>