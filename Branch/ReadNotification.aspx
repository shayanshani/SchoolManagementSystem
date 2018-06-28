<%@ Page Title="" Language="C#" MasterPageFile="~/Branch/Master.Master" AutoEventWireup="true" CodeBehind="ReadNotification.aspx.cs" Inherits="SchoolManagementSystem.Branch.ReadNotification" %>
<%@ Register Src="~/Controls/ViewSingleNotification.ascx" TagPrefix="VSN" TagName="Notify" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <VSN:Notify id="rptShow" runat="server" ></VSN:Notify>


</asp:Content>
