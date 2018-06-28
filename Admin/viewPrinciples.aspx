<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewPrinciples.aspx.cs" Inherits="SchoolManagementSystem.Admin.viewPrinciples" MasterPageFile="~/Admin/Admin.Master"%>
  <asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
   


      <div class="main-content container-fluid">

        <div class="row">
            <div class="col-sm-12">
                <div class="panel panel-default panel-border-color panel-border-color-primary" style="padding-top: 15px!important;">

                   

                    <div class="panel-heading">
                        Branch Principles
                    </div>
                    <div class="panel-body table-responsive">
                        <div class="row">
                            <div class="col-sm-4">
                                Select Branch
                            </div>
                             <div class="col-sm-4">
                                <asp:DropDownList runat="server" ID="ddlBranches" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlBranches_SelectedIndexChanged">

                                </asp:DropDownList>
                            </div>
                        </div>
                        <table id="table1" class="table table-striped table-hover table-fw-widget">
                            <thead>
                                <tr>
                                    <th>Branch</th>
                                    <th>Name</th>
                                   
                                    <th>Contact</th>
                                    <th>Email</th>
                                    
                                </tr>
                            </thead>
                            <tbody>
       
                                <asp:Repeater ID="rptEmployee" runat="server">
                                    <ItemTemplate>
                                        <tr class="even gradeX">
                                            <td><%# Eval("[BranchName]") %></td>
                                            <td><%# Eval("[PrincipalName]") %></td>
                                           
                                           
                                            <td><%# Eval("[PrincipalMobile]") %>
                                            </td>
                                            <td><%# Eval("[PrincipalEmail]") %></td>
                                           
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

 