<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddPrinciples.aspx.cs" Inherits="SchoolManagementSystem.BranchMaster.AddPrinciples" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <%--  <div class="page-head">
          <ol class="breadcrumb page-head-nav">
            <li><a href="#">Admin</a></li>
            <li><a href="#">Add</a></li>
            <li class="active">Branches</li>
          </ol>
        </div>--%>

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
                    

                    <div class="panel-heading panel-heading-divider">Add Principal</div>
                    <div class="panel-body">
                        <asp:HiddenField ID="hfPricipalID" runat="server" />
                         <div class="form-group xs-pt-10">
                      <label>Select Branch:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="ddlBranches" InitialValue="-1" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                            <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="ddlBranches_SelectedIndexChanged" ID="ddlBranches" runat="server" CssClass="form-control"></asp:DropDownList>
                         </div>

                      
                        <div class="form-group">
                            <label>Principal Name:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtPrincipalName" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                            <asp:TextBox ID="txtPrincipalName" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Alphabets only" ForeColor="Red" ValidationExpression="^[a-zA-z ]+$" ControlToValidate="txtPrincipalName" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>
                        </div>

                        <div class="form-group">
                            <label>
                                Principle Mobile:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtPrincipalMobile" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>
                            </label>
                            <asp:TextBox ID="txtPrincipalMobile" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Insert Digits" ForeColor="Red" ValidationExpression="^[0-9]+$" ControlToValidate="txtPrincipalMobile" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>
                        </div>

                        <div class="form-group">
                            <label>
                                Principle Email:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtPrincipalEmail" ForeColor="Red" ErrorMessage="*" ValidationGroup="validation"></asp:RequiredFieldValidator>
                            </label>
                            <asp:TextBox ID="txtPrincipalEmail" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="Invalid Email" ForeColor="Red" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" CssClass="error" ControlToValidate="txtPrincipalEmail" Display="Dynamic" ValidationGroup="validation"></asp:RegularExpressionValidator>
                        </div>

                      

                        <div class="form-group">
                            <label>
                                Principle Image:&nbsp&nbsp<asp:RequiredFieldValidator ID="reqFile" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="FileUpload1" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>
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


</asp:Content>
