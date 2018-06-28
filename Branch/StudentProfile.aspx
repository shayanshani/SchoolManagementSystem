<%@ Page Title="" Language="C#" MasterPageFile="~/Branch/Master.Master" AutoEventWireup="true" CodeBehind="StudentProfile.aspx.cs" Inherits="SchoolManagementSystem.Branch.StudentProfile" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .user-display-bg {
            max-height: 100px !important;
        }

        .clndr {
            height: 34px !important;
            border: 1px solid #CCC !important;
        }
    </style>
    <div class="main-content container-fluid">
        <div class="user-profile">
            <div class="row">
                <asp:Repeater runat="server" ID="rptStudentProfile" OnItemDataBound="rptStudentProfile_ItemDataBound">
                    <ItemTemplate>
                        <div class="col-md-12">
                            <div class="user-display">
                                <div class="user-display-bg">
                                    <img src="assets/img/user-profile-display.png" alt="Profile Background">
                                </div>
                                <div class="user-display-bottom">
                                    <div class="user-display-avatar">
                                        <img src="/Admin/assets/CustomImages/<%# Eval("Pic")  %>" alt="Avatar">
                                    </div>
                                    <div class="user-display-info">
                                        <div class="name"><span class="mdi mdi-account"></span>&nbsp;<%# Eval("StudentName") %> </div>
                                        <div class="nick"><%# Eval("Class") %></div>
                                    </div>

                                </div>
                            </div>
                        </div>

                        <div class="col-sm-12">
                            <div class="panel panel-default">
                                <div class="tab-container">
                                    <ul class="nav nav-tabs">

                                        <li class="active"><a href="#profile5" data-toggle="tab"><span class="icon mdi mdi-face"></span>Profile</a></li>
                                        <li><a href="#home5" data-toggle="tab"><span class="icon mdi mdi-format-list-bulleted"></span>Attendance</a></li>
                                        <li><a href="#messages5" data-toggle="tab"><span class="icon mdi mdi-graduation-cap"></span>Previous Results</a></li>

                                    </ul>
                                    <div class="tab-content">

                                        <div id="profile5" class="tab-pane active cont">
                                            <div class="user-info-list panel panel-default">
                                                <div class="panel-heading panel-heading-divider">About <%# Eval("StudentName") %> :<span class="panel-subtitle">Student addmitted in <%# Eval("ClassName") %> on <%#Convert.ToDateTime( Eval("DateofAdmission")).ToString("dd/MM/yyyy")%><%# Convert.ToBoolean(Eval("IsActive").ToString())==true ? " stil our active Student": "is now inactive" %> </span></div>
                                                <div class="panel-body">
                                                    <table class="no-border no-strip skills">
                                                        <tbody class="no-border-x no-border-y">
                                                            <tr>
                                                                <td class="icon"><span class="mdi mdi-case"></span></td>
                                                                <td class="item">Father Name<span class="icon s7-portfolio"></span></td>
                                                                <td><%# Eval("FatherName") %> </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="icon"><span class="mdi mdi-calendar"></span></td>
                                                                <td class="item">Date Of Admision<span class="icon s7-portfolio"></span></td>
                                                                <td><%#Convert.ToDateTime( Eval("DateofAdmission")).ToString("dd/MM/yyyy")%></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="icon"><span class="mdi mdi-cake"></span></td>
                                                                <td class="item">Birthday<span class="icon s7-gift"></span></td>
                                                                <td><%#Convert.ToDateTime( Eval("DOB")).ToString("dd/MM/yyyy")%></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="icon"><span class="mdi mdi-smartphone-android"></span></td>
                                                                <td class="item">Mobile<span class="icon s7-phone"></span></td>
                                                                <td><%# Eval("SCellNo") %> </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="icon"><span class="mdi mdi-pin"></span></td>
                                                                <td class="item">Location<span class="icon s7-map-marker"></span></td>
                                                                <td><%# Eval("SAddress") %></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="icon"><span class="mdi mdi-arrow-missed"></span></td>
                                                                <td class="item">Student Status<span class="icon s7-ps-active-x"></span></td>
                                                                <td><%# Convert.ToBoolean(Eval("IsActive").ToString())==true ? "Active": " Inactive" %> </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>




                                        <div id="home5" class="tab-pane cont">
                                            <h4>
                                                <asp:Label ID="lblStudentName" runat="server"></asp:Label>
                                                Attendance</h4>

                                            <asp:HiddenField ID="hfStudentName" runat="server" Value='<%# Eval("[StudentName]") %>' />
                                            <asp:UpdatePanel ID="pnl" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <div class="panel-body table-responsive">
                                                        <table id="table1" class="table table-striped table-hover table-fw-widget" style="width: 100%!important">
                                                            <thead>
                                                                <tr>
                                                                    <td colspan="1">
                                                                        <label>Select Date:</label>
                                                                        <telerik:RadDatePicker RenderMode="Lightweight" ID="txtDate" Width="100%" runat="server" DateInput-CssClass="form-control clndr" AutoPostBack="true" OnSelectedDateChanged="txtDate_SelectedDateChanged">
                                                                            <DateInput runat="server" DateFormat="dd/MM/yyyy">
                                                                            </DateInput>
                                                                        </telerik:RadDatePicker>
                                                                    </td>

                                                                    <td style="vertical-align: middle; font-size: 18px; float: right;">
                                                                        <br />
                                                                        <asp:Label ID="lblAbsenties" runat="server"></asp:Label> Absenties=<asp:Label ID="lblTotalAbsenties" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <th>Date
                                                                    </th>
                                                                    <th>Present/Absent
                                                                    </th>

                                                                </tr>
                                                            </thead>
                                                            <tbody>

                                                                <asp:Repeater ID="rptStudentAttendance" runat="server" DataSourceID="obsStudentAttendance">
                                                                    <ItemTemplate>
                                                                        <tr class="even gradeX">
                                                                            <td>
                                                                                <%# Eval("[AttendanceDate]","{0:dd/MMM/yyyy}") %>
                                                                            </td>
                                                                            <td>
                                                                                <%# Convert.ToBoolean(Eval("isPresent"))==true ? "Present" : "Absent" %>
                                                                            </td>
                                                                        </tr>

                                                                    </ItemTemplate>
                                                                </asp:Repeater>



                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>


                                            <asp:HiddenField ID="hfGetBranchID" runat="server" />
                                            <asp:HiddenField ID="HfStudentLevel" runat="server" Value='<%# Eval("LevelID") %>' />
                                            <asp:HiddenField ID="HfStudentID" runat="server" Value='<%# Eval("StudentID") %>' />

                                            <asp:ObjectDataSource ID="obsStudentAttendance" runat="server" TypeName="SchoolManagementSystem.BL.TblAttendance" SelectMethod="FilterProfileList">
                                                <SelectParameters>

                                                    <asp:ControlParameter ControlID="txtDate" PropertyName="SelectedDate" Name="Date"
                                                        ConvertEmptyStringToNull="true" />
                                                    <asp:ControlParameter ControlID="HfStudentLevel" PropertyName="Value" Name="LevelID" />

                                                    <asp:ControlParameter ControlID="hfGetBranchID" PropertyName="Value" Name="BranchID" />

                                                    <asp:ControlParameter ControlID="HfStudentID" PropertyName="Value" Name="StudentID" />

                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </div>






                                        <div id="messages5" class="tab-pane">
                                            <p>Consectetur adipisicing elit. Ipsam ut praesentium, voluptate quidem necessitatibus quam nam officia soluta aperiam, recusandae.</p>
                                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Quos facilis laboriosam, vitae ipsum tenetur atque vel repellendus culpa reiciendis velit quas, unde soluta quidem voluptas ipsam, rerum fuga placeat rem error voluptate eligendi modi. Delectus, iure sit impedit? Facere provident expedita itaque, magni, quas assumenda numquam eum! Sequi deserunt, rerum.</p>
                                            <a href="#">Read more</a>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>


            </div>

        </div>
    </div>

</asp:Content>
