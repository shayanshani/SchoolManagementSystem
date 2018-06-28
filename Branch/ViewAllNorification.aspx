<%@ Page Title="" Language="C#" MasterPageFile="~/Branch/Master.Master" AutoEventWireup="true" CodeBehind="ViewAllNorification.aspx.cs" Inherits="SchoolManagementSystem.Branch.ViewAllNorification" %>
 <%@ Register Src="~/Controls/ViewAllNotification.ascx" TagPrefix="VAN" TagName="Notify" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <VAN:Notify id="rptShow" runat="server" ></VAN:Notify>

</asp:Content>
