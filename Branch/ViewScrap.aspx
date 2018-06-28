<%@ Page Title="" Language="C#" MasterPageFile="~/Branch/Master.Master" AutoEventWireup="true" CodeBehind="ViewScrap.aspx.cs" Inherits="SchoolManagementSystem.Branch.ViewScrap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="main-content container-fluid">

          <div class="row">
            <div class="col-sm-12">
              <div class="panel panel-default panel-border-color panel-border-color-primary">

                   <asp:UpdatePanel ID="pnlMsg" runat="server">
                                    <ContentTemplate>
                                         <asp:Timer runat="server" id="timerNews" Interval="10000" OnTick="timerNews_Tick"></asp:Timer>
              
                     <div id="msgDiv" runat="server" visible="false" style="width: 50%;margin: auto;margin-top: 10px;">
                             <div class="icon"><span id="icon" runat="server"></span></div>
                          <div class="message">
                            <asp:Label ID="lblmsg" runat="server"></asp:Label>
                              </div>
                       </div>
                                        </ContentTemplate>
                                  </asp:UpdatePanel>


                <div class="panel-heading">Scrap Detail
                </div>
                <div class="panel-body table-responsive">
                  <table id="table1" class="table table-striped table-hover table-fw-widget">
                    <thead>
                      <tr>
                        <th>Items</th>
                          <th>Quantity</th>
                          <th>Date</th>
                          <th>Description</th>
                          <th>Action(s)</th>
                      </tr>
                    </thead>
                    <tbody>
                   
                      <asp:Repeater ID="rptScrap" runat="server">
                          <ItemTemplate>
                              <tr class="even gradeX">
                              <td><%# Eval("[Item]") %></td>
                                   <td><%# Eval("[Quantity]") %></td>
                                   <td><%# Convert.ToDateTime(Eval("[Date]")).ToString("dd-MM-yyyy") %></td>
                                   <td>
                                        <a href="#" data-modal="md-scale" data-id='<%# Eval("Description") %>' class="AddData btn btn-space btn-primary md-trigger">View Description</a>
                                                
                                                <div id="md-scale" class="modal-container colored-header-success modal-effect-1">
                                                    <div class="modal-content">
                                                        <div class="modal-header">
                                                            <button type="button" data-dismiss="modal" aria-hidden="true" class="close modal-close"><span class="mdi mdi-close"></span></button>
                                                        </div>
                                                        <div class="modal-body">
                                                            <div class="text-center">
                                                                <div class="text-primary"><span class="modal-main-icon mdi mdi-check"></span></div>
                                                                <h3>Description!</h3>
                                                                <p id="Detail"><!-- Regiter from Jquery -->
                                                                   
                                                                </p>
                                                            </div>
                                                        </div>
                                                        <div class="modal-footer"></div>
                                                    </div>
                                                </div>

                                   </td>
                                <td class="center">
                                  <asp:LinkButton ID="btnEdit" runat="server" OnClick="btnEdit_Click" CommandArgument='<%# Eval("ScrapID") %>'><span class="mdi mdi-edit" style="font-size: 22px!important;"></span></asp:LinkButton>
                                 <%-- <asp:LinkButton ID="btnDelete" runat="server" OnClick="btnDelete_Click" CommandArgument='<%# Eval("ScrapID") %>' OnClientClick='return confirm("Are you sure you want to delete this item?")'><span class="mdi mdi-delete" style="font-size: 22px!important;"></span></asp:LinkButton>--%>
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
