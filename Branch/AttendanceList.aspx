<%@ Page Title="" Language="C#" MasterPageFile="~/Branch/Master.Master" AutoEventWireup="true" CodeBehind="AttendanceList.aspx.cs" Inherits="SchoolManagementSystem.Branch.AttendanceList" %>

<%@ Register Src="~/Controls/StudentAttendace.ascx" TagPrefix="ATL" TagName="AttList" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ATL:AttList ID="List" runat="server"></ATL:AttList>
</asp:Content>
