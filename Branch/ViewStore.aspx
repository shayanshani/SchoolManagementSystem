<%@ Page Title="" Language="C#" MasterPageFile="~/Branch/Master.Master" AutoEventWireup="true" CodeBehind="ViewStore.aspx.cs" Inherits="SchoolManagementSystem.Branch.ViewStore" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="main-content container-fluid">

          <div class="row">
            <div class="col-sm-12">
              <div class="panel panel-default panel-border-color panel-border-color-primary">

                <div class="panel-heading">Store Items Detail
                </div>
                <div class="panel-body table-responsive">
                  <table id="table1" class="table table-striped table-hover table-fw-widget">
                    <thead>
                      <tr>
                        <th>Items</th>
                          <th>Quantity</th>
                          <th>Scrap</th>
                      </tr>
                    </thead>
                    <tbody>
                   
                      <asp:Repeater ID="rptStore" runat="server">
                          <ItemTemplate>
                              <tr class="even gradeX">
                              <td><%# Eval("[Item]") %></td>
                                   <td><%# Eval("[Quantity]") %></td>
                                  <td><%# Eval("Scrap") %></td>
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
