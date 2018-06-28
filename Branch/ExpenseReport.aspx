<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExpenseReport.aspx.cs" Inherits="SchoolManagementSystem.Branch.ExpenseReport" MasterPageFile="~/Branch/Master.Master" %>
 <%@ Register Src="~/Reports/frmExpenseReport.ascx" TagPrefix="FRC" TagName="ReportForm" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <FRC:ReportForm id="rptShow" runat="server" ></FRC:ReportForm>
 </asp:Content>