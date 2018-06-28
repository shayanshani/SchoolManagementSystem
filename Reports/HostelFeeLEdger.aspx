<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HostelFeeLEdger.aspx.cs" Inherits="SchoolManagementSystem.Reports.HostelFeeLEdger" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="shortcut icon" href="../Admin/assets/img/logo-fav.png">
    <title>Hostel Fee Ledger</title>
    <link rel="stylesheet" type="text/css" href="../Admin/assets/lib/perfect-scrollbar/css/perfect-scrollbar.min.css" />
    <link rel="stylesheet" type="text/css" href="../Admin/assets/lib/material-design-icons/css/material-design-iconic-font.min.css" />
    <!--[if lt IE 9]>
    <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
    <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
    <link rel="stylesheet" href="../Admin/assets/css/style.css" type="text/css" />
    <style>
        .panel-heading {
            text-align: center !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="row">
                <div class="col-sm-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            HOSTEL/MESS FEE COLLECTION DETAIL LEDGER PAK PEARL GROUP OF SCHOOL & COLLEGE D.I.KHAN CAMPUS
                 
                            <div class="tools"><span class="icon mdi mdi-download"></span><span class="icon mdi mdi-more-vert"></span></div>
                        </div>
                          <div class="row container">
                            <div class="form-group">
                                 <div class="col-sm-1">
                                    Branch
                                </div>
                                <div class="col-sm-2">
                                    <asp:DropDownList ID="ddlBranch" AutoPostBack="true" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged" runat="server" CssClass="form-control input-sm"></asp:DropDownList>
                                </div>
                              <%--  <div class="col-sm-1">
                                    Class
                                </div>
                                <div class="col-sm-2">
                                    <asp:DropDownList ID="ddlClass" AutoPostBack="true" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged" runat="server" CssClass="form-control input-sm"></asp:DropDownList>
                                </div>
                                <div class="col-sm-1">
                                    Session
                                </div>
                                <div class="col-sm-2">
                                    <asp:DropDownList ID="ddlSession" AutoPostBack="true" OnSelectedIndexChanged="ddlSession_SelectedIndexChanged" runat="server" CssClass="form-control input-sm"></asp:DropDownList>
                                </div>--%>
                            </div>
                        </div>
                        <div class="panel-body">
                            <table class="table table-condensed table-hover table-bordered table-striped">
                                <thead>
                                    <tr>
                                        <th class="number">Sr#</th>
                                        <th>Name of Student</th>
                                        <th>Father Name</th>
                                        <th>Class</th>
                                        <th>Home Address</th>
                                        <th>Contact#</th>
                                        <th>Entry Date</th>
                                        <th>Security</th>
                                        <th>April</th>
                                        <th>May</th>
                                        <th>June</th>
                                        <th>July</th>
                                        <th>Aug</th>
                                        <th>Sep</th>
                                        <th>Oct</th>
                                        <th>Nov</th>
                                        <th>Dec</th>
                                        <th>Jan</th>
                                        <th>Feb</th>
                                        <th>March</th>
                                    </tr>
                                </thead>
                                <tbody>
                                     <asp:Repeater ID="rptHostelFeeLedger" runat="server">
                                        <ItemTemplate>
                                       <tr>
                                            <td><%# Eval("SrNo") %></td>
                                            <td><%# Eval("StudentName") %></td>
                                            <td><%# Eval("FatherName") %></td>
                                            <td><%# Eval("ClassName") %></td>
                                            <td><%# Eval("SAddress") %></td>
                                            <td><%# Eval("SCellNo") %></td>
                                            <td><%# Eval("HEntryDate") %></td>
                                            <td><%# Eval("HostelSecurity") %></td>
                                            <td><%# Eval("Apr") %></td>
                                            <td><%# Eval("May") %></td>
                                            <td><%# Eval("June") %></td>
                                            <td><%# Eval("July") %></td>
                                            <td><%# Eval("August") %></td>
                                            <td><%# Eval("September") %></td>
                                            <td><%# Eval("October") %></td>
                                            <td><%# Eval("November") %></td>
                                            <td><%# Eval("December") %></td>
                                            <td><%# Eval("January") %></td>
                                            <td><%# Eval("Fabruary") %></td>
                                            <td><%# Eval("March") %></td>
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
    </form>
</body>
</html>
