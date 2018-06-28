<%@ Page Title="" Language="C#" MasterPageFile="~/Branch/Master.Master" AutoEventWireup="true" CodeBehind="ViewEditHostel.aspx.cs" Inherits="SchoolManagementSystem.Branch.ViewEditHostel" %>

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
                        Hostel detail
                    </div>
                    <div class="panel-body table-responsive">
                        <table id="table1" class="table table-striped table-hover table-fw-widget">
                            <thead>
                                <tr>
                                    <td colspan="1">
                                        <label>Filter by status:</label>
                                        <asp:DropDownList ID="DDLFilter" runat="server" CssClass="form-control" Style="width: 100%!important" AutoPostBack="true" OnSelectedIndexChanged="DDLFilter_SelectedIndexChanged">
                                            <asp:ListItem Value="-1">All</asp:ListItem>
                                            <asp:ListItem Value="1" Selected="True">Active</asp:ListItem>
                                            <asp:ListItem Value="0">Inactive</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <th>Hostel Name</th>
                                    <th>Contact</th>
                                    <th>Fee</th>
                                    <th>Location</th>
                                    <th>Wardan</th>
                                    <th>Status</th>
                                    <th>Action(s)</th>
                                </tr>
                            </thead>
                            <tbody>
                                  <asp:HiddenField ID="hfGetBranchID" runat="server" />


                                <asp:ObjectDataSource ID="obsHostels" runat="server" TypeName="SchoolManagementSystem.BL.TblHostelinformation" SelectMethod="Filter">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="DDLFilter" PropertyName="SelectedValue" Name="isActive"
                                            ConvertEmptyStringToNull="true" />
                                        <asp:ControlParameter ControlID="hfGetBranchID" PropertyName="Value" Name="BranchID" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>

                                <asp:Repeater ID="rptHostels" runat="server" DataSourceID="obsHostels">
                                    <ItemTemplate>
                                        <tr class="even gradeX">
                                            <td><%# Eval("[HostelName]") %></td>
                                            <td><%# Eval("[HostelContact]") %></td>
                                            <td><%# Eval("[HostelFee]") %></td>
                                            <td><%# Eval("[HostelLocation]") %></td>
                                            <td>
                                                <%# Eval("[EmployeeName]") %>
                                            </td>
                                            <td>
                                                <%# Convert.ToInt32(Eval("isActive"))==1 ? "Active" : "InActive" %>
                                            </td>
                                            <td class="center">
                                                <asp:LinkButton ID="btnEdit" runat="server" OnClick="btnEdit_Click" CommandArgument='<%# Eval("[HostelID]") %>'><span class="mdi mdi-edit" style="font-size: 22px!important;"></span></asp:LinkButton>
                                            </td>
                                        </tr>

                                    </ItemTemplate>
                                </asp:Repeater>


                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>



    </div>


</asp:Content>
