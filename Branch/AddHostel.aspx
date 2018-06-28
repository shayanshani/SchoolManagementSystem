<%@ Page Title="" Language="C#" MasterPageFile="~/Branch/Master.Master" AutoEventWireup="true" CodeBehind="AddHostel.aspx.cs" Inherits="SchoolManagementSystem.Branch.AddHostel" %>


<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .clndr {
            height: 34px !important;
            border: 1px solid #CCC !important;
        }
    </style>
   
    <div class="main-content container-fluid">

        <!--Basic forms-->
        <div class="row">
            <div class="col-sm-12">

                <div class="panel panel-default panel-border-color panel-border-color-primary">
                    <asp:UpdatePanel ID="pnlMsg" runat="server">
                        <ContentTemplate>
                            <asp:Timer runat="server" ID="timerNews" Interval="10000" OnTick="timerNews_Tick"></asp:Timer>
                            <div id="msgDiv" runat="server" visible="false" style="width: 50%; margin: auto; margin-top: 10px;">
                                <div class="icon"><span id="icon" runat="server"></span></div>
                                <div class="message">
                                    <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>


                    <div class="panel-heading panel-heading-divider">Add Hostel Information</div>
                    <div class="panel-body">

                        <div class="row">
                            <div class="form-group">
                                <div class="col-sm-6">
                                    <label>Select Employee Designation:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="ddlDesignation" InitialValue="-1" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                    <asp:DropDownList ID="ddlDesignation" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlDesignation_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>
                                <div class="col-sm-6">
                                    <label>Select Employee:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="ddlEmployees" ErrorMessage="*" InitialValue="-1" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                    <asp:DropDownList ID="ddlEmployees" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="form-group xs-pt-10">
                            <label>Hostel Name:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtHostelName" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                            <asp:TextBox ID="txtHostelName" runat="server" CssClass="form-control"></asp:TextBox>

                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Insert Letters" ForeColor="Red" ValidationExpression="^[a-zA-z0-9 ]+$" ControlToValidate="txtHostelName" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>

                        </div>


                        <div class="form-group">
                            <label>
                                Contact:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtHostelContact" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>
                            </label>
                            <asp:TextBox ID="txtHostelContact" runat="server" CssClass="form-control"></asp:TextBox>

                            <ajaxToolkit:MaskedEditExtender ViewStateMode="Enabled" ID="MaskedEditExtender2" runat="server" TargetControlID="txtHostelContact" Mask="(9999)-9999999"
                                MessageValidatorTip="true"
                                InputDirection="LeftToRight" AcceptNegative="None" DisplayMoney="None"
                                ErrorTooltipEnabled="True" />
                        </div>

                        <div class="form-group xs-pt-10">

                            <label>Hostel fee:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtHostelFee" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                            <asp:TextBox ID="txtHostelFee" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Insert Digits" ForeColor="Red" ValidationExpression="^[0-9 ,]+$" ControlToValidate="txtHostelFee" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>

                        </div>

                        <div class="form-group">
                            <label>
                                Location:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtHostelLocation" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>
                            </label>
                            <asp:TextBox ID="txtHostelLocation" runat="server" Rows="4" TextMode="MultiLine" CssClass="form-control" Style="resize: none"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Some Special characters are not allowed!" ForeColor="Red" ValidationExpression="[^$]+" ControlToValidate="txtHostelLocation" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>

                        </div>

                          <div class="form-group">
                            <label>
                                Select Status:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="ddlStatus" InitialValue="-1" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>
                            </label>
                         <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                             <asp:ListItem Selected="True" Value="-1">Select Status</asp:ListItem>
                             <asp:ListItem  Value="1">Active</asp:ListItem>
                             <asp:ListItem Value="0">InActive</asp:ListItem>
                         </asp:DropDownList>
                        </div>

                      

                        <div class="row xs-pt-15">
                            <div class="col-xs-6">
                                <div class="be-checkbox">
                                </div>
                            </div>
                            <div class="col-xs-6">
                                <p class="text-right">
                                    <asp:Button ID="btnSave" runat="server" Text="Submit" class="btn btn-space btn-primary" OnClick="btnSave_Click" ValidationGroup="validation" />
                                    <%--<button class="btn btn-space btn-default">Cancel</button>--%>
                                    <asp:HiddenField ID="hfHostelID" runat="server" />
                                </p>
                            </div>
                        </div>

                    </div>
                </div>
            </div>

        </div>

    </div>


</asp:Content>
