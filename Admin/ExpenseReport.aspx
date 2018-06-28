<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExpenseReport.aspx.cs" MasterPageFile="~/Admin/Admin.Master" Inherits="SchoolManagementSystem.Admin.ExpenseReport" %>
 <%@ Register Src="~/Reports/frmExpenseReport.ascx" TagPrefix="FRC" TagName="ReportForm" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <FRC:ReportForm id="rptShow" runat="server" ></FRC:ReportForm>
 </asp:Content>