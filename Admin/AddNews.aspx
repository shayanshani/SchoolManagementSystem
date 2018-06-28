<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddNews.aspx.cs" Inherits="SchoolManagementSystem.BranchMaster.AddNews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="main-content container-fluid">

        <!--Basic forms-->
        <div class="row">
            <div class="col-sm-12">

                <div class="panel panel-default panel-border-color panel-border-color-primary">

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

                        <div class="panel-heading panel-heading-divider">Add News</div>
                        <div class="panel-body">

                            <div class="form-group xs-pt-10">
                                <label>Heading:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtHeading" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                <asp:TextBox ID="txtHeading" runat="server" CssClass="form-control"></asp:TextBox>

                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Insert Letters" ForeColor="Red" ValidationExpression="^[a-zA-z0-9 ]+$" ControlToValidate="txtHeading" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>

                            </div>


                            <div class="form-group">
                                <label>
                                    Description:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtDescription" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>
                                </label>
                                <asp:TextBox ID="txtDescription" runat="server" cols="29" Rows="5" TextMode="MultiLine" CssClass="form-control" Style="resize: none"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Some special characters not allowed" ForeColor="Red" ValidationExpression="[^$]+" ControlToValidate="txtDescription" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>

                            </div>

                            <div class="form-group" id="file" runat="server">
                                <label>
                                    News Image:&nbsp&nbsp<asp:RequiredFieldValidator ID="reqFile" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="FileUpload1" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>
                                </label>
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator21" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.jpeg|.jpg|.png)$"
                                    ControlToValidate="FileUpload1" runat="server" ForeColor="Red" ErrorMessage="Select (.jpeg|.jpg|.png|.JPEG|.JPG|.PNG) Image" Display="Dynamic" />
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
    </div>

</asp:Content>
