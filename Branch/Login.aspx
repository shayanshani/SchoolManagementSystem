<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SchoolManagementSystem.Branch.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="shortcut icon" href="assets/img/logo-fav.png">
    <title>PAK PEARL branch login</title>
    <link rel="stylesheet" type="text/css" href="assets/lib/perfect-scrollbar/css/perfect-scrollbar.min.css"/>
    <link rel="stylesheet" type="text/css" href="assets/lib/material-design-icons/css/material-design-iconic-font.min.css"/><!--[if lt IE 9]>
    <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
    <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
    <link rel="stylesheet" href="assets/css/style.css" type="text/css"/>
</head>
    <body class="be-splash-screen">
    <form id="form1" runat="server">
    <div>
     <div class="be-wrapper be-login">
      <div class="be-content">
        <div class="main-content container-fluid">
          <div class="splash-container">
            <div class="panel panel-default panel-border-color panel-border-color-primary">
              <div class="panel-heading">
                  <img src="../assets/images/logocopy.png" alt="logo" width="180" height="60" class="logo-img">
                  <h1>Branch Login</h1>
                  <span class="splash-description">
                      <asp:Label ID="lblmsg" runat="server" Text="Please enter your branch user information."></asp:Label>
                  </span></div>
              <div class="panel-body" id="divLogin" runat="server">
               
                  <div class="form-group">
                    <asp:TextBox ID="txtBranchName" runat="server" placeholder="Username" autocomplete="off" class="form-control"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtBranchName" ErrorMessage="Enter UserName" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>
                  </div>
                  <div class="form-group">
                    <asp:TextBox ID="txtBranchPassword" runat="server" TextMode="Password" placeholder="Password" class="form-control"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtBranchPassword" ErrorMessage="Enter Password" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>
                  </div>
                  <div class="form-group row login-tools">
                    <div class="col-xs-6 login-remember">
                      <div class="be-checkbox">
                        <asp:CheckBox ID="chkremember" runat="server" />
                        <label for="chkremember">Remember Me</label>
                      </div>
                    </div>
                    <div class="col-xs-6 login-forgot-password"><asp:LinkButton ID="btnFPass" runat="server" OnClick="btnFPass_Click">Forgot Password?</asp:LinkButton></div>
                  </div>
                  <div class="form-group login-submit">
                    <asp:Button ID="btnSignIN" runat="server" class="btn btn-primary btn-xl" Text="Sign in" OnClick="btnSignIN_Click" ValidationGroup="validation"></asp:Button>
                  </div>
              </div>


              <div class="panel-body" id="divReset" visible="false" runat="server">
               
                  <div class="form-group">
                    <asp:TextBox ID="txtContact" runat="server" placeholder="Enter Contact" autocomplete="off" class="form-control"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtContact" ErrorMessage="Enter Contact" ForeColor="Red" ValidationGroup="validation1"></asp:RequiredFieldValidator>
                  </div>
                  <div class="form-group login-submit">
                    <asp:Button ID="btnSendCode" runat="server" class="btn btn-primary btn-xl" Text="Send" OnClick="btnSendCode_Click" ValidationGroup="validation1"></asp:Button>
                  </div>
              </div>


              <div class="panel-body" id="divPasswordUpdate" visible="false" runat="server">
               
                  <div class="form-group">
                    <asp:TextBox ID="txtCode" runat="server" placeholder="Enter Code" autocomplete="off" class="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtCode" ErrorMessage="Enter Code" ForeColor="Red" ValidationGroup="validation2"></asp:RequiredFieldValidator>
                  </div>
                 
                   <div class="form-group">
                    <asp:TextBox ID="txtNewPassword" runat="server" placeholder="Enter New Password" autocomplete="off" TextMode="Password" class="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtNewPassword" ErrorMessage="Enter New Password" ForeColor="Red" ValidationGroup="validation2"></asp:RequiredFieldValidator>
                  </div>

                   <div class="form-group">
                    <asp:TextBox ID="txtRetypePaswword" runat="server" placeholder="Confirm Paswword" autocomplete="off" TextMode="Password" class="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtRetypePaswword" ErrorMessage="Enter Confirm Password" ForeColor="Red" ValidationGroup="validation2"></asp:RequiredFieldValidator>
                       <asp:CompareValidator ID="cmpPass" runat="server" ControlToValidate="txtNewPassword" ControlToCompare="txtRetypePaswword" Operator="Equal" ErrorMessage="Passwords mismatched" ValidationGroup="validation2" ForeColor="Red" SetFocusOnError="true"></asp:CompareValidator>
                  </div>
                  
                  <div class="form-group login-submit">
                    <asp:Button ID="btnChange" runat="server" class="btn btn-primary btn-xl" Text="Update" OnClick="btnChange_Click" ValidationGroup="validation2"></asp:Button>
                  </div>

              </div>

                <div class="panel-body" id="divFirstLogin" visible="false" runat="server">
               
                    <div class="form-group">
                    <asp:TextBox ID="txtCurrentPassword" runat="server" TextMode="Password" placeholder="Enter Current Password" class="form-control"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtCurrentPassword" ErrorMessage="Enter Password" ForeColor="Red" ValidationGroup="validationF"></asp:RequiredFieldValidator>
                  </div>
                    
                    <div class="form-group">
                    <asp:TextBox ID="txtfNewPassword" runat="server" TextMode="Password" placeholder="New Password" class="form-control"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtfNewPassword" ErrorMessage="Enter Password" ForeColor="Red" ValidationGroup="validationF"></asp:RequiredFieldValidator>
                  </div>
                  <div class="form-group">
                    <asp:TextBox ID="txtRetypePassword" runat="server" TextMode="Password" placeholder="Confirm Password" class="form-control"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtRetypePassword" ErrorMessage="Enter Password" ForeColor="Red" ValidationGroup="validationF"></asp:RequiredFieldValidator>
                      <asp:CompareValidator ID="cmpFpass" runat="server" ControlToValidate="txtfNewPassword" ControlToCompare="txtRetypePassword" Operator="Equal" ErrorMessage="Passwords mismatched" ValidationGroup="validation2" ForeColor="Red" SetFocusOnError="true"></asp:CompareValidator>
                  </div>
               
                  <div class="form-group login-submit">
                    <asp:Button ID="btnChangePassword" runat="server" class="btn btn-primary btn-xl" Text="Update" OnClick="btnChangePassword_Click" ValidationGroup="validationF"></asp:Button>
                  </div>
              </div>

            </div>
          </div>
        </div>
      </div>
    </div>
   
    </div>
    </form>
     <script src="assets/lib/jquery/jquery.min.js" type="text/javascript"></script>
    <script src="assets/lib/perfect-scrollbar/js/perfect-scrollbar.jquery.min.js" type="text/javascript"></script>
    <script src="assets/js/main.js" type="text/javascript"></script>
    <script src="assets/lib/bootstrap/dist/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            //initialize the javascript
            App.init();
        });

    </script>
</body>
</html>
