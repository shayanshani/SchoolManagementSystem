<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPanel.aspx.cs" Inherits="SchoolManagementSystem.Administration.LoginPanel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>Administration Login Panel</title>
    <link rel="stylesheet" type="text/css" href="/Admin/assets/lib/perfect-scrollbar/css/perfect-scrollbar.min.css" />
    <link rel="stylesheet" type="text/css" href="/Admin/assets/lib/material-design-icons/css/material-design-iconic-font.min.css" />
    <!--[if lt IE 9]>
    <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
    <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
    <link rel="stylesheet" type="text/css" href="/Admin/assets/lib/jquery.vectormap/jquery-jvectormap-1.2.2.css" />
    <link rel="stylesheet" href="/Admin/assets/css/style.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">


        <div class="container">

            <div class="main-content container-fluid">
            <%--    <div class="row" style="background-color: #fff!important; margin-bottom: 20px">
                    <div class="col-md-12">
                        <div class="row col-md-offset-4" style="margin-bottom: 30px!important; background-color: transparent!important">
                            <div class="col-md-12">

                                <h2>
                                    <img src="../assets/images/Newlogo.png" />

                                </h2>

                            </div>
                        </div>
                    </div>
                </div>--%>


                <div class="row">

                    <div class="col-lg-6">
                        <div class="panel panel-border-color panel-border-color-success">
                            <div class="panel-heading">Admin Login</div>
                            <div class="panel-body">
                                <p>
                                    
                                    <a href="../Admin/Login.aspx" class="btn btn-space"><img src="../assets/images/AdminLink.png" style="width:255px!important" /></a>
                                </p>
                                <p>
                                    Aliquam posuere volutpat turpis, ut euimod diam pellentesque at. Sed sit amet nulla a dui dignisim euismod. Morbi luctus elementum dictum. Donec convallis mattis elit id varius. Quisque facilisis sapien quis mauris,, erat condimentum.
                                </p>
                            </div>
                        </div>
                    </div>
                    
                    <div class="col-lg-6">
                        <div class="panel panel-border-color panel-border-color-success">
                            <div class="panel-heading">Branch Login</div>
                            <div class="panel-body">
                                <p>
                                    <a href="../Branch/Login.aspx" class="btn btn-space"><img src="../assets/images/branchLink.png" style="width:255px!important" /></a>
                                </p>
                                <p>
                                    Aliquam posuere volutpat turpis, ut euimod diam pellentesque at. Sed sit amet nulla a dui dignisim euismod. Morbi luctus elementum dictum. Donec convallis mattis elit id varius. Quisque facilisis sapien quis mauris,, erat condimentum.

                                </p>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>



    </form>

</body>
</html>
