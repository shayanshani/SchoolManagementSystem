<%@ Page Title="" Language="C#" MasterPageFile="~/Branch/Master.Master" AutoEventWireup="true" CodeBehind="AddSubjects.aspx.cs" Inherits="SchoolManagementSystem.Branch.AddSubjects" %>
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


                    <div class="panel-heading panel-heading-divider">Subjects</div>
                    <div class="panel-body table-responsive">
                        <div class="row">
                            <div class="col-sm-12">
                                <a href="#" data-modal="form-success" class="btn btn-space btn-success md-trigger">Add Subject</a>
                            </div>
                        </div>
                        <table id="table1" class="table table-striped table-hover table-fw-widget">
                            <thead>
                                <tr>
                                    <td colspan="1">
                                    <label>Filter by status:</label>
                              <asp:DropDownList ID="DDLFilter" runat="server" CssClass="form-control"  style="width:100%!important" AutoPostBack="true" OnSelectedIndexChanged="DDLFilter_SelectedIndexChanged">
                                  <asp:ListItem  Value="-1">All</asp:ListItem>
                                  <asp:ListItem  Value="1" Selected="True">Active</asp:ListItem>
                                  <asp:ListItem  Value="0">Inactive</asp:ListItem>
                              </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <th>Subject</th>
                                    <th>Status</th>
                                    <th>Action(s)</th>
                                </tr>
                            </thead>
                            <tbody>

                                <asp:Repeater ID="rptSubjects" runat="server" DataSourceID="obsSubjects">
                                    <ItemTemplate>
                                        <tr class="even gradeX">
                                          <td><%# Eval("SubjectName") %></td>

                                            <td><%# Convert.ToInt16(Eval("isActive"))==1 ? "Active" : "Inactive" %></td>
                                           
                                            <td class="center">
                                                <asp:LinkButton ID="btnEdit" runat="server" OnClick="btnEdit_Click" CommandArgument='<%# Eval("[SubjectID]") %>'><span class="mdi mdi-edit" style="font-size: 22px!important;"></span></asp:LinkButton>
                                            </td>
                                        </tr>

                                    </ItemTemplate>
                                </asp:Repeater>
                                <asp:HiddenField ID="hfGetBranchID" runat="server" />

                                <asp:ObjectDataSource ID="obsSubjects" runat="server" TypeName="SchoolManagementSystem.BL.TblSubject" SelectMethod="Filter">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="DDLFilter" PropertyName="SelectedValue" Name="isActive"
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
    <asp:HiddenField ID="hfSubjectID" runat="server" />
            <div id="form-success" class="modal-container colored-header colored-header-success custom-width modal-effect-9">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" data-dismiss="modal" aria-hidden="true" class="close modal-close" id="cls"><span class="mdi mdi-close"></span></button>
                        <h3 class="modal-title">Add Subject</h3>
                    </div>
                    <div class="modal-body form">
                         <div class="form-group">
                            <label>
                                Select Academic Level:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="ddlLevel" InitialValue="-1" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>
                        
                            </label>
                               <asp:DropDownList ID="ddlLevel" runat="server" CssClass="form-control">

                                <asp:ListItem Text="--Select Level--" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="School" Value="1"></asp:ListItem>
                                <asp:ListItem Text="College" Value="2"></asp:ListItem>

                            </asp:DropDownList>
                        </div>

                        <div class="form-group">
                            <label>
                                Enter Subject Name:&nbsp&nbsp
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtSubject" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>
                            </label>
                            <asp:TextBox ID="txtSubject" runat="server" CssClass="form-control" placeholder="Enter subject"></asp:TextBox>

                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Insert Letters" ForeColor="Red" ValidationExpression="^[a-zA-z0-9 ]+$" ControlToValidate="txtSubject" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>

                        </div>

                        <div class="form-group">
                            <label>
                                Select Status:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="ddlStatus" InitialValue="-1" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>
                        
                            </label>
                              <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                                  <asp:ListItem Selected="True" Value="-1">Select status</asp:ListItem>
                                  <asp:ListItem  Value="1">Active</asp:ListItem>
                                  <asp:ListItem  Value="0">Inactive</asp:ListItem>
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
    <script src="assets/lib/bootstrap/dist/js/bootstrap.min.js" type="text/javascript"></script>

    <script type="text/javascript">
        function openModal() {
            $('#form-success').addClass('modal-container colored-header colored-header-success custom-width modal-effect-9 modal-show');
        }

        var b, a;

        b = document.getElementById('cls');
        a = document.getElementById('cls1');
        

        b.onclick = function () {
            document.getElementById('ContentPlaceHolder1_ddlLevel').value = "-1";
            document.getElementById('ContentPlaceHolder1_ddlStatus').value = "-1";
            document.getElementById('ContentPlaceHolder1_txtSubject').value = "";
            document.getElementById('ContentPlaceHolder1_hfSubjectID').value = "";

            var frm = document.getElementById('form-success');
            
            frm.setAttribute('class', 'modal-container colored-header colored-header-success custom-width modal-effect-9 modal-close');
            
        }

        a.onclick = function () {
            document.getElementById('ContentPlaceHolder1_ddlLevel').value = "-1";
            document.getElementById('ContentPlaceHolder1_ddlStatus').value = "-1";
            document.getElementById('ContentPlaceHolder1_txtSubject').value = "";
            document.getElementById('ContentPlaceHolder1_hfSubjectID').value = "";

            var frm = document.getElementById('form-success');
           
            frm.setAttribute('class', 'modal-container colored-header colored-header-success custom-width modal-effect-9 modal-close');
            
        }

    </script>



</asp:Content>
