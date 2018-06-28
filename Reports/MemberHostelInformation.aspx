<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberHostelInformation.aspx.cs" Inherits="SchoolManagementSystem.Reports.MemberHostelInformation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="shortcut icon" href="../Admin/assets/img/logo-fav.png">
    <title>Hostel Enrolled</title>
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
                            MEMBERS ENROLLED IN HOSTEL PAK PEARL GROUP OF SCHOOL & COLLEGE D.I.KHAN CAMPUS
                 
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
                                <div class="col-sm-2">
                                    Select Type
                                </div>
                                <div class="col-sm-2">
                                    <asp:DropDownList ID="ddlType" AutoPostBack="true" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" runat="server" CssClass="form-control input-sm">
                                        <asp:ListItem Text="Student" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Employee" Value="1"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div id="divStudent" runat="server">
                        <div class="panel-body">
                            <table class="table table-condensed table-hover table-bordered table-striped">
                                <thead>
                                    <tr>
                                        <th class="number">Sr#</th>
                                        <th>Name of Student</th>
                                        <th>Father Name</th>
                                        <th>Home Address</th>
                                        <th>Contact#</th>
                                        <th>Class</th>
                                        <th>Admision Date</th>
                                        <th>Hostel Name</th>
                                        <th>Hostel Contact#</th>
                                        <th>Hostel Fee</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rptStudent" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%# Eval("SrNo") %></td>
                                                <td><%# Eval("StudentName") %></td>
                                                <td><%# Eval("FatherName") %></td>
                                                <td><%# Eval("SAddress") %></td>
                                                <td><%# Eval("SCellNo") %></td>
                                                <td><%# Eval("ClassName") %></td>
                                                <td><%# Eval("HAdmissionDate") %></td>
                                                <td><%# Eval("HostelName") %></td>
                                                <td><%# Eval("HostelContact") %></td>
                                                <td><%# Eval("HostelFee") %></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                            </div>

                          <div id="divEmployee" runat="server">
                        <div class="panel-body">
                            <table class="table table-condensed table-hover table-bordered table-striped">
                                <thead>
                                    <tr>
                                        <th class="number">Sr#</th>
                                        <th>Employee Name</th>
                                        <th>Father Name</th>
                                        <th>Designation</th>
                                        <th>CNIC</th>
                                        <th>Contact#</th>
                                        <th>Address</th>
                                        <th>Admision Date</th>
                                        <th>Hostel Name</th>
                                        <th>Hostel Contact#</th>
                                        <th>Hostel Fee</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rptEmployee" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%# Eval("SrNo") %></td>
                                                <td><%# Eval("EmployeeName") %></td>
                                                <td><%# Eval("FatherName") %></td>
                                                <td><%# Eval("Designation") %></td>
                                                <td><%# Eval("CNIC") %></td>
                                                <td><%# Eval("ContactNo") %></td>
                                                <td><%# Eval("Address") %></td>
                                                <td><%# Eval("HAdmissionDate") %></td>
                                                <td><%# Eval("HostelName") %></td>
                                                <td><%# Eval("HostelContact") %></td>
                                                <td><%# Eval("HostelFee") %></td>
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
        </div>
    </form>
</body>
</html>
