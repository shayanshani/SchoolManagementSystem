<%@ Page Title="" Language="C#" MasterPageFile="~/Branch/Master.Master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="SchoolManagementSystem.Branch.Test" %>

<%@ Register Assembly="SpartansControls" Namespace="SpartansControls" TagPrefix="spartans" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <spartans:DatePicker ID="DatePicker1" runat="server" IncludeJquery="true" IconClass="icon mdi mdi-power">
    </spartans:DatePicker>
    
    <spartans:TimePicker runat="server" IncludeJquery="true" IconClass="icon mdi mdi-power"></spartans:TimePicker>

    <spartans:SearchableDropdownList  runat="server" IsSearchable="true" CssClass="form-control col-lg-4" IsCustomCss="false">
        <asp:ListItem >Shayan</asp:ListItem>
        <asp:ListItem >Irfan Kundi</asp:ListItem>
        <asp:ListItem >Durani</asp:ListItem>
        <asp:ListItem >Mubasher</asp:ListItem>
    </spartans:SearchableDropdownList>

</asp:Content>
