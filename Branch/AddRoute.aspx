<%@ Page Language="C#"  MasterPageFile="~/Branch/Master.Master" AutoEventWireup="true" CodeBehind="AddRoute.aspx.cs" Inherits="SchoolManagementSystem.Branch.AddRoute" %>

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


                    <div class="panel-heading panel-heading-divider">Route Information</div>
                    <div class="panel-body table-responsive">
                        <div class="row">
                            <div class="col-sm-12">
                                <a href="#" data-modal="form-success" class="btn btn-space btn-success md-trigger">Add Route</a>
                            </div>
                        </div>
                        <table id="table1" class="table table-striped table-hover table-fw-widget">
                            <thead>
                                <tr>
                                    <th>From</th>
                                    <th>To</th>
                                    <th>Fare</th>
                                    <th>Status</th>
                                    <th>Action(s)</th>
                                </tr>
                            </thead>
                            <tbody>

                                <asp:Repeater ID="rptRoutes" runat="server">
                                    <ItemTemplate>
                                        <tr class="even gradeX">
                                            <td><%# Eval("RFrom") %></td>
                                             <td><%# Eval("RTo") %></td>
                                             <td><%# Eval("RFare") %></td>
                                            <td><%# Convert.ToInt32(Eval("IsActive")) == 0 ? "Inactive" : "Active" %></td>
                                            <td class="center">
                                                <asp:LinkButton ID="btnEdit" ClientIDMode="Static" runat="server" OnClick="btnEdit_Click" CommandArgument='<%# Eval("RouteID") %>'><span class="mdi mdi-edit" style="font-size: 22px!important;"></span></asp:LinkButton>
                                      
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
    <asp:HiddenField ID="hdnRouteID" runat="server" />
            <div id="form-success" class="modal-container colored-header colored-header-success custom-width modal-effect-9">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" data-dismiss="modal" aria-hidden="true" class="close modal-close" id="cls"><span class="mdi mdi-close"></span></button>
                        <h3 class="modal-title"><asp:Label runat="server" ID="PopupHeading" Text="Add Route"></asp:Label></h3>
                    </div>
                    <div class="modal-body form">
                        <div class="form-group">
                            <label>
                                From
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtRForm" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator> 
                                           </label>
                           <asp:TextBox ID="txtRForm" runat="server" CssClass="form-control"></asp:TextBox>
                                  
                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Insert Letters" ValidationExpression="^[a-zA-z0-9 ]+$" ControlToValidate="txtRForm" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>
                           
                        </div>
                         <div class="form-group">
                            <label>
                               To
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtRTo" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>                        </label>
                               <asp:TextBox ID="txtRTo" runat="server" CssClass="form-control"></asp:TextBox>
                                          
                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Insert Letters" ValidationExpression="^[a-zA-z0-9 ]+$" ControlToValidate="txtRTo" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>
                                  
                        </div>
                         <div class="form-group">
                            <label>
                             Route Fee<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtRFee" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>
                </label>
                                
                                              <asp:TextBox ID="txtRFee" runat="server" CssClass="form-control"></asp:TextBox>
                                          
                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Insert Digits" ValidationExpression="^[0-9]+$" ControlToValidate="txtRFee" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>
                                         
                        </div>
                          <div class="form-group">
                            <label>
                             Status<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="ddlstatus" InitialValue="-1" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>
                </label>
                                
                                             <asp:DropDownList runat="server" ID="ddlstatus" CssClass="form-control">
                                                 <asp:ListItem Value="-1">Select Status</asp:ListItem>
                                                   <asp:ListItem Value="1">Active</asp:ListItem>
                                                   <asp:ListItem Value="0">Inactive</asp:ListItem>
                                             </asp:DropDownList>
                                          
                                
                                       
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" data-dismiss="modal" class="btn btn-default modal-close" id="cls1">Cancel</button>
                        <asp:Button ID="btnSave" runat="server" class="btn btn-success" OnClick="btnSave_Click" Text="Save" ValidationGroup="validation" />
                    </div>
                </div>
                </div>
     


    <div class="modal-overlay"></div>

    <script src="assets/lib/jquery/jquery.min.js" type="text/javascript"></script>
    <script src="assets/lib/perfect-scrollbar/js/perfect-scrollbar.jquery.min.js" type="text/javascript"></script>
    <script src="assets/js/main.js" type="text/javascript"></script>


    <script type="text/javascript">
        function openModal() {
            $('#form-success').addClass('modal-container colored-header colored-header-success custom-width modal-effect-9 modal-show');
        }

        var b, a;

        b = document.getElementById('cls');
        a = document.getElementById('cls1');
        

        b.onclick = function () {
            document.getElementById('ContentPlaceHolder1_txtRForm').value = "";
            document.getElementById('ContentPlaceHolder1_txtRTo').value = "";
            document.getElementById('ContentPlaceHolder1_txtRFee').value = "";
            document.getElementById('ContentPlaceHolder1_ddlstatus').value = "-1";

            document.getElementById('ContentPlaceHolder1_hdnRouteID').value = "";

            var frm = document.getElementById('form-success');
            
            frm.setAttribute('class', 'modal-container colored-header colored-header-success custom-width modal-effect-9 modal-close');
            
        }

        a.onclick = function () {
            document.getElementById('ContentPlaceHolder1_txtRForm').value = "";
            document.getElementById('ContentPlaceHolder1_txtRTo').value = "";
            document.getElementById('ContentPlaceHolder1_txtRFee').value = "";
            document.getElementById('ContentPlaceHolder1_ddlstatus').value = "-1";

            document.getElementById('ContentPlaceHolder1_hdnRouteID').value = "";

            var frm = document.getElementById('form-success');
           
            frm.setAttribute('class', 'modal-container colored-header colored-header-success custom-width modal-effect-9 modal-close');
            
        }

    </script>


</asp:Content>

