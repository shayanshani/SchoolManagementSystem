<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Admin.Master" CodeBehind="ScholarshipDetails.aspx.cs" Inherits="SchoolManagementSystem.Admin.ScholarshipDetails" %>
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
                            <asp:Timer runat="server" ID="timerNews" Interval="10000" OnTick="timerNews_Tick"></asp:Timer>
                            <div id="msgDiv" runat="server" visible="false" style="width: 50%; margin: auto; margin-top: 10px;">
                                <div class="icon"><span id="icon" runat="server"></span></div>
                                <div class="message">
                                    <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <asp:HiddenField runat="server" ID="hdnScholarshipID" Value="" />
                    <div class="panel-heading panel-heading-divider">Add Scholarship/Fee Structure</div>
                    <div class="panel-body">

                          <div class="form-group xs-pt-10">
                             
                                    <asp:DropDownList ID="DDProgName" runat="server" CssClass="form-control input-sm">
                                        <asp:ListItem Text="--Select Program--" Value="-1"></asp:ListItem>
                                        <asp:ListItem Text="Pre-Eng" Value="FSC"></asp:ListItem>
                                        <asp:ListItem Text="Pre-Med" Value="FSC"></asp:ListItem>
                                        <asp:ListItem Text="ICS" Value="ICS"></asp:ListItem>
                                        <asp:ListItem Text="FA" Value="FA"></asp:ListItem>
                                    </asp:DropDownList>
                                 
                        </div>
                          <div class="form-group xs-pt-10">
                            <label>Total Fee:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtTotalFee" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                            <asp:TextBox ID="txtTotalFee" runat="server" CssClass="form-control"></asp:TextBox>

                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Numbers only" ForeColor="Red" ValidationExpression="^[0-9]+$" ControlToValidate="txtTotalFee" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>

                        </div>
                        <div class="form-group xs-pt-10">
                            <label>Admission Fee:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtAdmissionFee" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                            <asp:TextBox ID="txtAdmissionFee" runat="server" CssClass="form-control input-sm"></asp:TextBox>

                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Numbers only" ForeColor="Red" ValidationExpression="^[0-9]+$" ControlToValidate="txtAdmissionFee" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>

                        </div>
                        
                          <div class="form-group xs-pt-10">
                            <label>Misc :&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtAdmissionFee" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                            <asp:TextBox ID="txtMisc" runat="server" CssClass="form-control input-sm"></asp:TextBox>

                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Numbers only" ForeColor="Red" ValidationExpression="^[0-9]+$" ControlToValidate="txtAdmissionFee" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>

                        </div>
                          <div class="form-group xs-pt-10">
                            <label>Tuition Fee:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtTuitionFee" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                            <asp:TextBox ID="txtTuitionFee" runat="server" CssClass="form-control input-sm"></asp:TextBox>

                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Numbers only" ForeColor="Red" ValidationExpression="^[0-9]+$" ControlToValidate="txtTuitionFee" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>

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
                       <div class="panel-body table-responsive">
                  <table id="table1" class="table table-striped table-hover table-fw-widget">
                    <thead>
                      <tr>
                        <th>Program</th>
                  
                        <th>Admission Fee</th>
                                <th>Misc</th>
                                <th>Tuition Fee</th>
                                <th>Total Fee</th>
                          <th>Action(s)</th>
                      </tr>
                    </thead>
                    <tbody>
                   
                      <asp:Repeater ID="rptScholarship" runat="server">
                          <ItemTemplate>
                              <tr class="even gradeX">
                              <td><%# Eval("[Program]") %></td>
                                 <td>
                                      <%# Eval("[AdmissionFee]") %>
                                  </td>
                                  
                                    <td>
                                      <%# Eval("[Mise]") %>
                                  </td>
                                
                                     <td>
                                      <%# Eval("[TuitionFee]") %>
                                  </td>
                                  <td>
                                      <%# Eval("[TotalFee]") %>
                                  </td>
                              
                              

                                <td class="center">
                                  <asp:LinkButton ID="btnEdit" runat="server" OnClick="btnEdit_Click" CommandArgument='<%# Eval("[SSID]") %>'><span class="mdi mdi-edit" style="font-size: 22px!important;"></span></asp:LinkButton>
                                  <asp:LinkButton ID="btnDelete" runat="server" OnClick="btnDelete_Click" CommandArgument='<%# Eval("[SSID]") %>' OnClientClick='return confirm("Are you sure you want to delete ?")'><span class="mdi mdi-delete" style="font-size: 22px!important;"></span></asp:LinkButton>
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