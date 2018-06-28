<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExpenseReport.aspx.cs" Inherits="SchoolManagementSystem.Reports.ExpenseReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     
      <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="shortcut icon" href="../Admin/assets/img/logo-fav.png">
    <title>Expanse Report</title>
    <link rel="stylesheet" type="text/css" href="../Admin/assets/lib/perfect-scrollbar/css/perfect-scrollbar.min.css"/>
    <link rel="stylesheet" type="text/css" href="../Admin/assets/lib/material-design-icons/css/material-design-iconic-font.min.css"/><!--[if lt IE 9]>
    <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
    <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
    <link rel="stylesheet" href="../Admin/assets/css/style.css" type="text/css"/>
</head>
<body>
    <style >
        .invoice-data {
    margin-bottom: 40px !important;
}
        .invoice-header {
    margin-bottom: 30px !important;
}
        .invoice-details th{
            text-align:left !important;
        }
    </style>
    <form id="form1" runat="server">
     <div class="row">
            <div class="col-md-12">
              <div class="invoice">
                <div class="row invoice-header">
                  <div class="col-xs-7">
                    <div  class="logo"><img src="../assets/images/logocopy.png" alt="Logo-symbol"></div>
                  </div>
                  <div class="col-xs-5 invoice-order"><span class="invoice-id"></span><span class="incoice-date"><asp:Label runat="server" ID="lblDate"></asp:Label></span></div>
                </div>
                <div class="row invoice-data">
                  <div class="col-xs-5 invoice-person"><span class="name">Expense Report</span><span><asp:Label runat="server" ID="lblrptType"></asp:Label></span><span></span><span></span><span><asp:Label runat="server" ID="lblHeads"></asp:Label></span></div>
                  <div class="col-xs-2 invoice-payment-direction"><i class=""></i></div>
                  <div class="col-xs-5 invoice-person"><span class="name"></span><span></span><span></span><span></span><span></span></div>
                </div>
                <div class="row">
                  <div class="col-md-12">
                    <table class="invoice-details">
                      <tr>
                           <th style="width:17%">Title</th>
                           
                        <th style="width:50%" class="description">Description</th>
                         
                        <th style="width:17%" >Date</th>
                        <th style="width:16%" class="amount">Amount</th>
                      </tr>
                     <asp:Repeater runat="server" ID="rptExpenseDetails">
                         <ItemTemplate>
                                 <tr>
                                      <td class="description"><%# Eval("Title") %></td>
                        <td class="description"><%# Eval("Description") %></td>
                       
                          <td class="description"><%# Convert.ToDateTime( Eval("ExpenseDate")).ToString("dd-MM-yyyy") %></td>
                        <td class="description"><%# Eval("Amount") %></td>
                      </tr>
                         </ItemTemplate>
                     </asp:Repeater>
                     
                      
                     
                      <tr>
                        <td></td>
                          <td></td>
                        <td class="summary total">Total</td>
                        <td class="amount total-value">PKR 5,920</td>
                      </tr>
                    </table>
                  </div>
                </div>
               
                <div class="row invoice-company-info">
                  <div class="col-sm-6 col-md-2 logo"><img src="../Admin/assets/img/logo-symbol.png" alt="Logo-symbol"></div>
                  <div class="col-sm-6 col-md-4 summary"><span class="title">
                      <asp:Label runat="server" ID="lblBranchName"></asp:Label>



                                                         </span>
                    <p><asp:Label runat="server" ID="lblBranchLocation"></asp:Label>
</p>
                  </div>
                  <div class="col-sm-6 col-md-3 phone">
                    <ul class="list-unstyled">
                      <li><asp:Label runat="server" ID="lblBranchContact"></asp:Label></li>
                       
                    </ul>
                  </div>
                  <div class="col-sm-6 col-md-3 email">
                    <ul class="list-unstyled">
                      <li><asp:Label runat="server" ID="lblBranchEmail"></asp:Label></li>
                      
                    </ul>
                  </div>
                </div>
                <div class="row invoice-footer">
                  <div class="col-md-12">
                     
                  </div>
                </div>
              </div>
            </div>
          </div>
    </form>
</body>
</html>
