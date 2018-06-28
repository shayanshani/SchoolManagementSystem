<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="SendNotification.aspx.cs" Inherits="SchoolManagementSystem.BranchMaster.SendNotification" %>

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

                    <div class="panel-heading panel-heading-divider">Send Notification</div>
                    <div class="panel-body">
                        <div class="form-group xs-pt-10">
                            <label>To:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="ddlBranches" InitialValue="-1" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                            <asp:DropDownList ID="ddlBranches" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlBranches_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <asp:UpdatePanel ID="pnlTo" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="form-group xs-pt-10">
                                    <label>To:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtNotificationTo" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                    <asp:TextBox ID="txtNotificationTo" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlBranches" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>


                        <div class="form-group">
                            <label>Subject:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtSubject" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                            <asp:TextBox ID="txtSubject" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Number or special characters not allowed" ForeColor="Red" ValidationExpression="^[a-zA-z ]+$" ControlToValidate="txtSubject" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>
                        </div>


                        <div class="form-group">
                            <label>
                                Message:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtMessage" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>
                            </label>
                            <asp:TextBox ID="txtMessage" runat="server" cols="29" Rows="5" TextMode="MultiLine" CssClass="form-control" Style="resize: none"></asp:TextBox>
                        </div>

                        <div class="row xs-pt-15">
                            <div class="col-xs-6">
                                <div class="be-checkbox">
                                </div>
                            </div>
                            <div class="col-xs-6">
                                <p class="text-right">
                                    <asp:Button ID="btnSave" runat="server" Text="Send" class="btn btn-space btn-primary" OnClick="btnSave_Click" ValidationGroup="validation" />
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
