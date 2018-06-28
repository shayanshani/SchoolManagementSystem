<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddBranches.aspx.cs" Inherits="SchoolManagementSystem.BranchMaster.AddBranches" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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


                    <div class="panel-heading panel-heading-divider">Add Branches</div>
                    <div class="panel-body">

                        <div class="form-group xs-pt-10">
                            <label>Branch Name:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtBranchName" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                            <asp:TextBox ID="txtBranchName" runat="server" CssClass="form-control"></asp:TextBox>

                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Insert Letters" ForeColor="Red" ValidationExpression="^[a-zA-z0-9 ]+$" ControlToValidate="txtBranchName" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>

                        </div>


                        <div class="form-group">
                            <label>
                                Branch Phone No:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtPhoneNo" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>
                            </label>
                            <asp:TextBox ID="txtPhoneNo" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Insert Only Digits" ForeColor="Red" ValidationExpression="^[0-9]+$" ControlToValidate="txtPhoneNo" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>
                        </div>

                        <div class="form-group">
                            <label>
                                Branch Address:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtAddress" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>
                            </label>
                            <asp:TextBox ID="txtAddress" runat="server" cols="29" Rows="5" TextMode="MultiLine" CssClass="form-control" Style="resize: none"></asp:TextBox>
                        </div>


                        <div class="form-group">
                            <label>
                                Select Status:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="ddlStatus" ErrorMessage="*" InitialValue="-1" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>
                            </label>
                            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                                <asp:ListItem Selected="True" Value="-1">Select</asp:ListItem>
                                <asp:ListItem  Value="1">Active</asp:ListItem>
                                <asp:ListItem  Value="0">Inactive</asp:ListItem>
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
                                </p>
                            </div>
                        </div>

                    </div>
                </div>
            </div>

        </div>

    </div>




</asp:Content>
