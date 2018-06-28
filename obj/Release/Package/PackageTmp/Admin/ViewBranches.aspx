<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ViewBranches.aspx.cs" Inherits="SchoolManagementSystem.Admin.ViewBranches" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
        <div class="main-content container-fluid">
          <div class="row">
            <div class="col-sm-12">
              <div class="panel panel-default panel-table" style="    padding-top: 15px!important;">

                     <div id="msgDiv" runat="server" visible="false" style="width: 50%;margin: auto;margin-top: 10px;">
                             <div class="icon"><span id="icon" runat="server"></span></div>
                          <div class="message">
                            <asp:Label ID="lblmsg" runat="server"></asp:Label>
                              </div>
                       </div>


                <div class="panel-heading">Branches
                </div>
                <div class="panel-body">
                  <table id="table1" class="table table-striped table-hover table-fw-widget">
                    <thead>
                      <tr>
                        <th>Branch Name</th>
                        <th>Principle Name</th>
                        <th>Principle Email</th>
                        <th>Principle Mobile</th>
                        <th>Branch PhoneNo</th>
                          <th>Branch Address</th>
                          <th>Action(s)</th>
                      </tr>
                    </thead>
                    <tbody>
                   
                      <asp:Repeater ID="rptBranches" runat="server">
                          <ItemTemplate>
                              <tr class="even gradeX">
                              <td><%# Eval("[BranchName]") %></td>
                                <td>
                                  <%# Eval("[PrincipleName]") %>
                                </td>
                                <td> <%# Eval("[PEmail]") %></td>
                                <td> <%# Eval("[PrincipleMobile]") %></td>
                                <td>  <%# Eval("[BPhoneNo]") %></td>
                                <td> <%# Eval("[BAddress]") %></td>
                                <td class="center">
                                  <asp:LinkButton ID="btnEdit" runat="server" OnClick="btnEdit_Click" CommandArgument='<%# Eval("BranchID") %>'><span class="mdi mdi-edit" style="font-size: 22px!important;"></span></asp:LinkButton>
                                  <asp:LinkButton ID="btnDelete" runat="server" OnClick="btnDelete_Click" CommandArgument='<%# Eval("BranchID") %>' OnClientClick='return confirm("Are you sure you want to delete this branch?")'><span class="mdi mdi-delete" style="font-size: 22px!important;"></span></asp:LinkButton>
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
