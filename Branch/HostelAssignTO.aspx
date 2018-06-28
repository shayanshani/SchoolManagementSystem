<%@ Page Title="" Language="C#" MasterPageFile="~/Branch/Master.Master" AutoEventWireup="true" CodeBehind="HostelAssignTO.aspx.cs" Inherits="SchoolManagementSystem.Branch.HostelAssignTO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="main-content container-fluid">

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


                    <div class="panel-heading">
                        Stock Detail
                    </div>
                    <div class="panel-body table-responsive">
                        <table id="table1" class="table table-striped table-hover table-fw-widget">
                            <thead>
                                <tr>
                                    <td colspan="1">
                                        <label>Select member type:</label>
                                        <asp:DropDownList ID="ddlMemberType" runat="server" CssClass="form-control" Style="width: 100%!important" AutoPostBack="true" OnSelectedIndexChanged="ddlMemberType_SelectedIndexChanged">
                                            <asp:ListItem Text="Student" Selected="True" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Employee" Value="1"></asp:ListItem>

                                        </asp:DropDownList>
                                    </td>
                                </tr>

                                <tr>
                                    <th>Hostel</th>
                                    <th><asp:Label ID="lblEnrolledTo" runat="server"></asp:Label></th>
                                    <th>Contact</th>
                                    <th>Class</th>
                                     <th>Date of joining</th>
                                   <%-- <th>Action(s)</th>--%>
                                </tr>
                            </thead>
                            <tbody>



                                <asp:Repeater ID="rptHostelEnrollement" runat="server" DataSourceID="obsHostelEnrollement">
                                    <ItemTemplate>
                                        <tr class="even gradeX">
                                            <td><%# Eval("[HostelName]") %></td>
                                            <td><%# Eval("[StudentName]") %></td>
                                            <td><%# Eval("[SCellno]") %></td>
                                            <td><%# Eval("[ClassName]") %> - <%# Eval("[GroupName]") %></td>
                                            <td><%# Convert.ToDateTime(Eval("[HAdmissionDate]")).ToString("dd-MM-yyyy") %></td>
                                        </tr>

                                    </ItemTemplate>
                                </asp:Repeater>

                                <asp:HiddenField ID="hfGetBranchID" runat="server" />

                                <asp:ObjectDataSource ID="obsHostelEnrollement" runat="server" TypeName="SchoolManagementSystem.BL.TblHostelinformation" SelectMethod="FilterMember">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlMemberType" PropertyName="SelectedValue" Name="MemberTypePrm"
                                            ConvertEmptyStringToNull="true" />
                                        <asp:ControlParameter ControlID="hfGetBranchID" PropertyName="Value" Name="BranchID" />

                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
