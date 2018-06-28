<%@ Page Title="" Language="C#" MasterPageFile="~/Branch/Master.Master" AutoEventWireup="true" CodeBehind="AddScrap.aspx.cs" Inherits="SchoolManagementSystem.Branch.AddScrap" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
         <style>
        .clndr {
            height: 34px !important;
            border: 1px solid #CCC !important;
        }
        .row{
            margin-top:10px!important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="main-content container-fluid">

        <!--Basic forms-->
        <div class="row">
            <div class="col-sm-12">

                <div class="panel panel-default panel-border-color panel-border-color-primary">
                    <asp:UpdatePanel ID="pnlMsg" runat="server">
                        <ContentTemplate>
                             <asp:Timer runat="server" id="timerNews" Interval="10000" OnTick="timerNews_Tick"></asp:Timer>
                            <div id="msgDiv" runat="server" visible="false" style="width: 50%; margin: auto; margin-top: 10px;">
                                <div class="icon"><span id="icon" runat="server"></span></div>
                                <div class="message">
                                    <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    

                    <div class="panel-heading panel-heading-divider">Add Scrap</div>
                    <div class="panel-body">

                        <div class="row">
                            <div class="form-group">
                                <div class="col-sm-6">
                                    <label>Select Item:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="ddlItems" ErrorMessage="*" ForeColor="Red" InitialValue="-1" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                    <asp:DropDownList ID="ddlItems" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                                 <div class="col-sm-6">
                                     <label>Enter Quantity:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtQuantity" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                     <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control"></asp:TextBox>
                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Alphabets, spaces or special characters not allowed" ForeColor="Red" ValidationExpression="^[0-9]+$" ControlToValidate="txtQuantity" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>

                                                <div class="row">
                            <div class="form-group">
                                 <div class="col-sm-12">
                                     <label>Description:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtDescription" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                      <asp:TextBox ID="txtDescription" runat="server" cols="29" Rows="5" TextMode="MultiLine" CssClass="form-control" Style="resize: none"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <div class="row xs-pt-15">
                            <div class="col-xs-6">
                                <p class="text-right">
                                    <asp:Button ID="btnSave" runat="server" Text="Submit" ValidationGroup="validation" class="btn btn-space btn-primary" OnClick="btnSave_Click" />
                                    <asp:HiddenField ID="hdnid" runat="server" />
                                    <asp:HiddenField ID="hdnQuantity" runat="server" />
                                </p>
                            </div>
                        </div>

                    </div>
                </div>
            </div>

        </div>

    </div>
</asp:Content>
