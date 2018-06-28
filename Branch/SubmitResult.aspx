<%@ Page Title="" Language="C#" MasterPageFile="~/Branch/Master.Master" AutoEventWireup="true" CodeBehind="SubmitResult.aspx.cs" Inherits="SchoolManagementSystem.Branch.SubmitResult" %>

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


                    <div class="panel-heading panel-heading-divider">Groups</div>
                    <div class="panel-body table-responsive">

                        <table id="table1" class="table table-striped table-hover table-fw-widget">
                            <thead>


                                <tr>
                                    <td colspan="1">
                                        <label>Select Level:</label>
                                        <asp:DropDownList ID="ddlLevel" runat="server" CssClass="form-control" Style="width: 100%!important" AutoPostBack="true" OnSelectedIndexChanged="ddlLevel_SelectedIndexChanged">
                                            <asp:ListItem Text="Select Level" Selected="True" Value="-1"></asp:ListItem>
                                            <asp:ListItem Text="School" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="College" Value="2"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>


                                    <td colspan="1">
                                        <label>Select Class:</label>
                                        <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control" Style="width: 100%!important" AutoPostBack="true" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </thead>
                            <asp:Repeater ID="rptSubmitResult" runat="server" OnItemDataBound="rptSubmitResult_ItemDataBound">

                                <HeaderTemplate>
                                    <thead>
                                        <tr>
                                            <th id="thStudentName" runat="server" visible="false">Student Name</th>
                                            <asp:Repeater ID="rptHeadings" runat="server">
                                                <ItemTemplate>
                                                    <th><%# Eval("SubjectName") %></th>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </tr>
                                    </thead>
                                </HeaderTemplate>

                                <ItemTemplate>
                                    <tr class="even gradeX">
                                        <td>
                                            <%# Eval("StudentName") %>
                                        </td>
                                        <asp:HiddenField ID="hfStudentID" runat="server" Value='<%# Eval("StudentID") %>' />
                                        <%-- <% for (int i = 1; i <= getVal(); i++)
                                           { %>--%>
                                        <asp:Repeater ID="rptMarks" runat="server">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hfSubjectID" runat="server" Value='<%# Eval("SubjectID") %>' />
                                                <td>
                                                    <asp:TextBox ID="txtMarks" runat="server" CssClass="form-control"></asp:TextBox>
                                                </td>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                        <%--  <% } %>--%>
                                    </tr>
                                </ItemTemplate>

                                <FooterTemplate>
                                    <tr>
                                        <td colspan="5" align="right">
                                            <asp:Button ID="btnSubmit" runat="server" class="btn btn-success" OnClick="btnSubmit_Click" Text="Submit" />
                                        </td>
                                    </tr>
                                </FooterTemplate>
                            </asp:Repeater>

                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
