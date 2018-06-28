<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentAdmission.aspx.cs" MasterPageFile="~/Branch/Master.Master" Inherits="SchoolManagementSystem.Branch.StudentAdmission" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .panel-default > .panel-heading {
            color: white !important;
            background-color: rgb(66, 133, 244) !important;
            border-color: #5f99f5 !important;
            padding: 10px !important;
            margin: 5px !important;
            margin-top: 10px !important;
        }

        .panel-body {
            padding: 0px 0px 0px !important;
        }

        .panel-heading-divider {
            color: white !important;
            background-color: rgb(66, 133, 244) !important;
            border-color: #5f99f5 !important;
            margin: 5px !important;
            padding: 10px !important;
        }

        .row {
            margin: 7px !important;
        }

        label {
            padding-top: 10px !important;
            color: black !important;
        }

        panel-border-color-primary {
            border-top-color: #ffffff !important;
            padding-top: 10px !important;
        }

        .be-checkbox, .be-radio {
            padding: 0px 0 !important;
        }
    </style>
</asp:Content>

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
                    <div class="panel-heading panel-heading-divider">Student Admission Form</div>
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

                    <asp:UpdatePanel ID="mainpnl" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>



                            <div class="panel-body">

                                <div class="form-group xs-pt-12">
                                    <div class="row">

                                        <div class="col-lg-2">
                                            <label>Registration No:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtRegNo" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                        </div>
                                        <div class="col-lg-4">
                                            <asp:TextBox ID="txtRegNo" runat="server" CssClass="form-control input-sm"></asp:TextBox>

                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid Input" ForeColor="Red" ValidationExpression="^[a-zA-z0-9-]+$" ControlToValidate="txtRegNo" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>
                                        </div>
                                        <div class="col-lg-2">
                                            <label>
                                                Session
                                            </label>
                                        </div>
                                        <div class="col-lg-4">


                                            <div class="be-radio inline">

                                                <asp:RadioButton ID="radioSpring" runat="server" GroupName="session" />
                                                <label for="ContentPlaceHolder1_radioSpring">Spring </label>


                                                <asp:RadioButton ID="radioFall" runat="server" GroupName="session" />&nbsp;
                                     <label for="ContentPlaceHolder1_radioFall">Autumn</label>
                                            </div>

                                        </div>
                                    </div>


                                    <div class="row">

                                        <div class="col-lg-2">
                                            <label>
                                                ACADEMIC LEVEL:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="ddlLevel" InitialValue="-1" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>
                                            </label>
                                        </div>
                                        <div class="col-lg-4">
                                            <asp:DropDownList ID="ddlLevel" runat="server" CssClass="form-control input-sm" OnSelectedIndexChanged="ddlLevel_SelectedIndexChanged" AutoPostBack="true">
                                                <asp:ListItem Text="--Select Level--" Value="-1"></asp:ListItem>
                                                <asp:ListItem Text="School" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="College" Value="2"></asp:ListItem>

                                            </asp:DropDownList>
                                        </div>

                                        <div class="col-lg-2">
                                            <label>Select Class:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="ddlClass" InitialValue="-1" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                        </div>
                                        <div class="col-lg-4">
                                            <asp:DropDownList ID="ddlClass" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged" CssClass="form-control input-sm"></asp:DropDownList>
                                        </div>

                                    </div>
                                    <div class="row" runat="server" id="divProgram" visible="false">

                                        <div class="col-lg-2">
                                            <label>Select Group:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="ddlGroup" InitialValue="-1" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                        </div>
                                        <div class="col-lg-4">
                                            <asp:DropDownList ID="ddlGroup" runat="server" CssClass="form-control input-sm"></asp:DropDownList>
                                        </div>

                                        <div class="col-lg-2">
                                            <label>
                                                Select Program
                                            </label>
                                        </div>
                                        <div class="col-lg-4">
                                            <asp:DropDownList ID="DDProgName" runat="server" CssClass="form-control input-sm">
                                                <asp:ListItem Text="--Select Program--" Value="-1"></asp:ListItem>
                                                <asp:ListItem Text="Pre-Eng" Value="PreEng"></asp:ListItem>
                                                <asp:ListItem Text="Pre-Med" Value="PreMed"></asp:ListItem>
                                                <asp:ListItem Text="ICS" Value="ICS"></asp:ListItem>
                                                <asp:ListItem Text="FA" Value="FA"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <%-- <div class="be-radio">
                         
                                   
                            </div> --%>
                                    </div>



                                </div>
                                <div class="panel-heading panel-heading-divider">PERSONAL DETAIL</div>
                                <div class="panel-body">

                                    <div class="form-group xs-pt-12">
                                        <div class="row">

                                            <div class="col-lg-2">
                                                <label>Student Name:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtStudentName" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                            </div>
                                            <div class="col-lg-4">
                                                <asp:TextBox ID="txtStudentName" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="(Insert Letters)" ControlToValidate="txtStudentName" ValidationExpression="[a-zA-Z ]*$" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>
                                            </div>
                                            <div class="col-lg-2">
                                                <label>Father Name:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtFatherName" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                            </div>
                                            <div class="col-lg-4">
                                                <asp:TextBox ID="txtFatherName" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="(Insert Letters)" ControlToValidate="txtFatherName" ValidationExpression="[a-zA-Z ]*$" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>
                                            </div>


                                        </div>

                                        <div class="row">

                                            <div class="col-lg-2">
                                                <label>Religion:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" InitialValue="-1" ControlToValidate="ddlReligion" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                            </div>
                                            <div class="col-lg-4">

                                                <asp:DropDownList ID="ddlReligion" runat="server" CssClass="form-control input-sm">
                                                    <asp:ListItem Text="--Select Religion--" Value="-1"></asp:ListItem>
                                                    <asp:ListItem Text="Muslim" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Non Muslim" Value="2"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-lg-2">
                                                <label>Gender:</label>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="be-radio inline">

                                                    <asp:RadioButton ID="radioMale" runat="server" GroupName="Gender" />
                                                    <label for="ContentPlaceHolder1_radioMale">Male </label>


                                                    <asp:RadioButton ID="radioFemale" runat="server" GroupName="Gender" />&nbsp;
                                     <label for="ContentPlaceHolder1_radioFemale">Female</label>
                                                </div>
                                            </div>

                                        </div>


                                        <div class="row">

                                            <div class="col-lg-2">
                                                <label>Date Of Birth:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtDOB" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                                <asp:CompareValidator ID="cmpDOB" runat="server" Display="Dynamic" ControlToValidate="txtDOB" Type="Date" Operator="LessThan" ErrorMessage="Birth date must be less then todays date" ForeColor="Red" ValidationGroup="validation"></asp:CompareValidator>
                                            </div>
                                            <div class="col-lg-4">
                                                <telerik:RadDatePicker RenderMode="Lightweight" ID="txtDOB" Width="100%" runat="server" DateInput-CssClass="form-control clndr">
                                                    <DateInput runat="server" DateFormat="dd/MM/yyyy">
                                                    </DateInput>
                                                </telerik:RadDatePicker>
                                            </div>
                                            <div class="col-lg-2">
                                                <label>Place Of Birth:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtPlaceOfBirth" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                            </div>
                                            <div class="col-lg-4">
                                                <asp:TextBox ID="txtPlaceOfBirth" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="(Insert Letters)" ControlToValidate="txtPlaceOfBirth" ValidationExpression="[a-zA-Z ]*$" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>
                                            </div>


                                        </div>

                                        <div class="row">

                                            <div class="col-lg-2">
                                                <label>Date Of Admision:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtDOA" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                                <asp:CompareValidator ID="cmpDOA" runat="server" Display="Dynamic" ControlToValidate="txtDOA" Type="Date" Operator="LessThanEqual" ErrorMessage="Admision date must be less then or equal to todays date" ForeColor="Red" ValidationGroup="validation"></asp:CompareValidator>
                                            </div>
                                            <div class="col-lg-4">
                                                <telerik:RadDatePicker RenderMode="Lightweight" ID="txtDOA" Width="100%" runat="server" DateInput-CssClass="form-control clndr">
                                                    <DateInput runat="server" DateFormat="dd/MM/yyyy">
                                                    </DateInput>
                                                </telerik:RadDatePicker>

                                            </div>

                                            <div class="col-lg-2">
                                                <label>Nationality:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtNationality" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                            </div>
                                            <div class="col-lg-4">
                                                <asp:TextBox ID="txtNationality" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="(Insert Letters)" ControlToValidate="txtNationality" ValidationExpression="[a-zA-Z ]*$" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>
                                            </div>

                                        </div>

                                        <div class="row">

                                            <div class="col-lg-2">
                                                <label>CNIC/B.Form:&nbsp&nbsp<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtCNIC" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>--%></label>
                                            </div>
                                            <div class="col-lg-4">

                                                <asp:TextBox ID="txtCNIC" runat="server" MaxLength="15" CssClass="form-control input-sm"></asp:TextBox>

                                                <%--  <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtCNIC" Mask="99999-9999999-9"
                                            MessageValidatorTip="true"
                                            InputDirection="LeftToRight" AcceptNegative="None" DisplayMoney="None"
                                            ErrorTooltipEnabled="True" />--%>
                                            </div>


                                            <div class="col-lg-2">
                                                <label>Domicile:&nbsp&nbsp<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtDomicile" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>--%></label>
                                            </div>
                                            <div class="col-lg-4">
                                                <asp:TextBox ID="txtDomicile" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ErrorMessage="(Insert Letters)" ControlToValidate="txtDomicile" ValidationExpression="[a-zA-Z ]*$" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>
                                            </div>


                                        </div>

                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-lg-2">
                                                    <label>Upload Picture&nbsp&nbsp<asp:RequiredFieldValidator ID="reqFpic" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtPic" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>

                                                </div>
                                                <div class="col-lg-4">
                                                    <asp:FileUpload ID="txtPic" runat="server" /><asp:Label ID="lblimgName" runat="server" Visible="false"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                </div>

                                <div runat="server" id="devAcademic" visible="false">
                                    <div class="panel-heading panel-heading-divider">ACADEMIC RECORD</div>

                                    <div class="panel-body">

                                        <div class="form-group xs-pt-12">
                                            <div class="row">

                                                <div class="col-lg-12" style="overflow-x: auto">
                                                    <div class="panel panel-default">

                                                        <div class="panel-body">
                                                            <table class="table table-condensed table-hover table-bordered table-striped">
                                                                <thead>

                                                                    <tr>
                                                                        <th>Degree</th>
                                                                        <th>Board/University</th>
                                                                        <th>Year</th>
                                                                        <th>Roll No</th>
                                                                        <th>Total Marks</th>
                                                                        <th>Obtained Marks</th>
                                                                        <th>Grade</th>
                                                                        <th>Major Subjects</th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:DropDownList ID="DropDownMatric" runat="server" CssClass="form-control input-sm">
                                                                                <asp:ListItem Text="Select Matric" Value="-1"></asp:ListItem>
                                                                                <asp:ListItem Text="SSC" Value="SSC"></asp:ListItem>
                                                                                <asp:ListItem Text="O-Level" Value="O-Level"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator runat="server" ErrorMessage="*" ControlToValidate="DropDownMatric" InitialValue="-1" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtSCCInstitue" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator runat="server" ErrorMessage="*" ControlToValidate="txtSCCInstitue" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator100" runat="server" ErrorMessage="(Insert Letters)" ControlToValidate="txtSCCInstitue" ValidationExpression="[a-zA-Z0-9 ]*$" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>

                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtSSCYear" runat="server" CssClass="form-control input-sm" MaxLength="4"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator runat="server" ErrorMessage="*" ControlToValidate="txtSSCYear" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator111" runat="server" ErrorMessage="(Insert Digits)" ControlToValidate="txtSSCYear" ValidationExpression="[0-9]*$" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>
                                                                        </td>
                                                                        <td>

                                                                            <asp:TextBox ID="txtSSCRNo" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator runat="server" ErrorMessage="*" ControlToValidate="txtSSCRNo" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator120" runat="server" ErrorMessage="(Insert Digits)" ControlToValidate="txtSSCRNo" ValidationExpression="[0-9]*$" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>

                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtSSCTMarks" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator runat="server" ErrorMessage="*" ControlToValidate="txtSSCTMarks" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator33" runat="server" ErrorMessage="(Insert Digits)" ControlToValidate="txtSSCTMarks" ValidationExpression="[0-9]*$" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>


                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtSSCOMarks" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator runat="server" ErrorMessage="*" ControlToValidate="txtSSCOMarks" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ErrorMessage="(Insert Digits)" ControlToValidate="txtSSCOMarks" ValidationExpression="[0-9]*$" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtSSCGrade" runat="server" CssClass="form-control input-sm" MaxLength="1"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator runat="server" ErrorMessage="*" ControlToValidate="txtSSCGrade" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" ErrorMessage="(Insert A-D Grade)" ControlToValidate="txtSSCGrade" ValidationExpression="[ABCD]*$" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtSSCDestinction" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator runat="server" ErrorMessage="*" ControlToValidate="txtSSCDestinction" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server" ErrorMessage="(Insert Letters)" ControlToValidate="txtSSCDestinction" ValidationExpression="[a-zA-Z, ]*$" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:DropDownList ID="DropDownInter" runat="server" CssClass="form-control input-sm">

                                                                                <asp:ListItem Text="Select Intermidiate" Value="-1"></asp:ListItem>
                                                                                <asp:ListItem Text="A-Level" Value="A-level"></asp:ListItem>
                                                                                <asp:ListItem Text="FA" Value="FA"></asp:ListItem>
                                                                                <asp:ListItem Text="FSc(Pre-Eng)" Value="FSc(Pre-Eng)"></asp:ListItem>
                                                                                <asp:ListItem Text="FSc(Pre-Med)" Value="FSc(Pre-Med)"></asp:ListItem>
                                                                                <asp:ListItem Text="ICS" Value="ICS"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator runat="server" ErrorMessage="*" InitialValue="-1" ControlToValidate="DropDownInter" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtInterInstitue" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator runat="server" ErrorMessage="*" ControlToValidate="txtInterInstitue" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server" ErrorMessage="(Insert Letters)" ControlToValidate="txtInterInstitue" ValidationExpression="[a-zA-Z0-9 ]*$" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtInterYear" runat="server" CssClass="form-control input-sm" MaxLength="4"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator runat="server" ErrorMessage="*" ControlToValidate="txtInterYear" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server" ErrorMessage="(Insert Digits)" ControlToValidate="txtInterYear" ValidationExpression="[0-9]*$" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtInterRNo" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator runat="server" ErrorMessage="*" ControlToValidate="txtInterRNo" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator22" runat="server" ErrorMessage="(Insert Digits)" ControlToValidate="txtInterRNo" ValidationExpression="[0-9]*$" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtInterTMarks" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator runat="server" ErrorMessage="*" ControlToValidate="txtInterTMarks" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator34" runat="server" ErrorMessage="(Insert Digits)" ControlToValidate="txtInterTMarks" ValidationExpression="[0-9]*$" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtInterOMarks" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator runat="server" ErrorMessage="*" ControlToValidate="txtInterOMarks" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator23" runat="server" ErrorMessage="(Insert Digits)" ControlToValidate="txtInterOMarks" ValidationExpression="[0-9]*$" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtInterGrade" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator runat="server" ErrorMessage="*" ControlToValidate="txtInterGrade" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator24" runat="server" ErrorMessage="(Insert Letters)" ControlToValidate="txtInterGrade" ValidationExpression="[A-D]*$" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtInterDestinction" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator runat="server" ErrorMessage="*" ControlToValidate="txtInterDestinction" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator26" runat="server" ErrorMessage="(Insert Letters)" ControlToValidate="txtInterDestinction" ValidationExpression="[a-zA-Z, ]*$" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>
                                                                        </td>
                                                                    </tr>

                                                                </tbody>
                                                            </table>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                </div>

                                <div class="panel-heading panel-heading-divider">CONTACT DETAILS</div>
                                <div class="panel-body">

                                    <div class="form-group xs-pt-12">
                                        <div class="row">

                                            <div class="col-lg-2">
                                                <label>Address:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtHomeAddress" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                            </div>
                                            <div class="col-lg-4">
                                                <asp:TextBox ID="txtHomeAddress" runat="server" CssClass="form-control input-sm" TextMode="MultiLine"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ErrorMessage="(Insert Letters)" ControlToValidate="txtHomeAddress" ValidationExpression="[^$]+" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>
                                            </div>
                                            <div class="col-lg-2">
                                                <label>Student Cell No:&nbsp&nbsp<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtStdCell" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>--%></label>
                                            </div>
                                            <div class="col-lg-4">
                                                <asp:TextBox ID="txtStdCell" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                <ajaxToolkit:MaskedEditExtender ViewStateMode="Enabled" ID="MaskedEditExtender2" runat="server" TargetControlID="txtStdCell" Mask="(9999)-9999999"
                                                    MessageValidatorTip="true"
                                                    InputDirection="LeftToRight" AcceptNegative="None" DisplayMoney="None"
                                                    ErrorTooltipEnabled="True" />
                                            </div>


                                        </div>

                                        <div class="row">

                                            <div class="col-lg-2">
                                                <label>Home Phone No:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtPhoneNo" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                            </div>
                                            <div class="col-lg-4">

                                                <asp:TextBox ID="txtPhoneNo" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                <ajaxToolkit:MaskedEditExtender ViewStateMode="Enabled" ID="MaskedEditExtender3" runat="server" TargetControlID="txtPhoneNo" Mask="(9999)-999999"
                                                    MessageValidatorTip="true"
                                                    InputDirection="LeftToRight" AcceptNegative="None" DisplayMoney="None"
                                                    ErrorTooltipEnabled="True" />

                                            </div>
                                            <div class="col-lg-2">
                                                <label>Student Email:</label>
                                            </div>
                                            <div class="col-lg-4">
                                                <asp:TextBox ID="txtStdEmail" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator42" runat="server" ErrorMessage="(Insert Valid Pattern)" ControlToValidate="txtStdEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>


                                            </div>

                                        </div>


                                    </div>

                                </div>
                                <div class="panel-heading panel-heading-divider">GUARDIAN INFORAMTION (if Applicable)</div>
                                <div class="panel-body">

                                    <div class="form-group xs-pt-12">

                                        <div class="row">

                                            <div class="col-lg-2">
                                                <label>Name:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtGardianName" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                            </div>
                                            <div class="col-lg-4">
                                                <asp:TextBox ID="txtGardianName" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                            </div>
                                            <div class="col-lg-2">
                                                <label>Relationship:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtRegNo" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                            </div>
                                            <div class="col-lg-4">
                                                <asp:TextBox ID="txtRelationship" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator19" runat="server" ErrorMessage="(Insert Letters)" ControlToValidate="txtRelationship" ValidationExpression="[a-zA-Z ]*$" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>
                                            </div>


                                        </div>

                                        <div class="row">

                                            <div class="col-lg-2">
                                                <label>Office Address:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtOfficeAddress" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                            </div>
                                            <div class="col-lg-4">

                                                <asp:TextBox ID="txtOfficeAddress" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator20" runat="server" ErrorMessage="(Invalid Input)" ControlToValidate="txtOfficeAddress" ValidationExpression="[^$]+" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>

                                            </div>
                                            <div class="col-lg-2">
                                                <label>Email:</label>
                                            </div>
                                            <div class="col-lg-4">
                                                <asp:TextBox ID="txtGEmail" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator21" runat="server" ErrorMessage="(Insert Valid Pattern)" ControlToValidate="txtGEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>


                                            </div>

                                        </div>

                                        <div class="row">

                                            <div class="col-lg-2">
                                                <label>Occupation:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtGOccupation" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                            </div>
                                            <div class="col-lg-4">

                                                <asp:TextBox ID="txtGOccupation" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator25" runat="server" ErrorMessage="(Insert Letters)" ControlToValidate="txtGOccupation" ValidationExpression="[a-zA-Z ]*$" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>

                                            </div>
                                            <div class="col-lg-2">
                                                <label>Monthly Income:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtMonthlyIncome" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                            </div>
                                            <div class="col-lg-4">
                                                <asp:TextBox ID="txtMonthlyIncome" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator27" runat="server" ErrorMessage="(Insert Valid Pattern)" ControlToValidate="txtMonthlyIncome" ValidationExpression="^[0-9.]+$" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>


                                            </div>

                                        </div>

                                        <div class="row">

                                            <div class="col-lg-2">
                                                <label>Cell No:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtGCell" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                            </div>
                                            <div class="col-lg-4">

                                                <asp:TextBox ID="txtGCell" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                <ajaxToolkit:MaskedEditExtender ViewStateMode="Enabled" ID="MaskedEditExtender4" runat="server" TargetControlID="txtGCell" Mask="(9999)-9999999"
                                                    MessageValidatorTip="true"
                                                    InputDirection="LeftToRight" AcceptNegative="None" DisplayMoney="None"
                                                    ErrorTooltipEnabled="True" />

                                            </div>


                                        </div>

                                    </div>

                                </div>
                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <asp:UpdatePanel ID="pnl" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>

                            <div class="row">
                                <div class="form-group">

                                    <%--   <asp:UpdatePanel ID="pnl" runat="server">
                                            <ContentTemplate>--%>
                                    <div class="col-lg-4 col-lg-offset-2">
                                        <div class="be-checkbox inline">
                                            <asp:CheckBox runat="server" ID="chkTransport" AutoPostBack="true" OnCheckedChanged="chkTransport_CheckedChanged" />

                                            <label for="ContentPlaceHolder1_chkTransport">Transport</label>
                                        </div>
                                        <div class="be-checkbox inline">
                                            <asp:CheckBox runat="server" ID="chkHostel" AutoPostBack="true" OnCheckedChanged="chkHostel_CheckedChanged" />
                                            <label for="ContentPlaceHolder1_chkHostel">Hostel</label>
                                        </div>
                                    </div>
                                    <%--     </ContentTemplate>
                                        </asp:UpdatePanel>--%>
                                </div>
                            </div>

                            <div id="divTransport" runat="server" visible="false">
                                <div class="panel-heading panel-heading-divider">TRANSPORT INFORMATION</div>
                                <div class="panel-body">

                                    <div class="form-group">
                                        <div class="row">

                                            <div class="col-lg-2">
                                                <label>Select Route:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="ddlRoute" InitialValue="-1" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                            </div>
                                            <div class="col-lg-4">
                                                <asp:DropDownList ID="ddlRoute" AutoPostBack="true" OnSelectedIndexChanged="ddlRoute_SelectedIndexChanged" runat="server" CssClass="form-control"></asp:DropDownList>
                                            </div>
                                            <div class="col-lg-2">
                                                <label>Select Bus:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="ddlBus" InitialValue="-1" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                            </div>
                                            <div class="col-lg-4">
                                                <asp:DropDownList ID="ddlBus" runat="server" CssClass="form-control"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <div class="row">

                                            <div class="col-lg-2">
                                                <label>Discount:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtDiscount" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                            </div>
                                            <div class="col-lg-4">
                                                <asp:TextBox ID="txtDiscount" runat="server" CssClass="form-control"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator29" runat="server" ErrorMessage="Insert Letters" ForeColor="Red" ValidationExpression="^[0-9]+$" ControlToValidate="txtDiscount" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>

                                            </div>
                                            <div class="col-lg-2">
                                                <label>Seat#:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtSeatNo" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                            </div>
                                            <div class="col-lg-4">
                                                <asp:TextBox ID="txtSeatNo" runat="server" CssClass="form-control"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator30" runat="server" ErrorMessage="Insert Letters" ForeColor="Red" ValidationExpression="^[0-9]+$" ControlToValidate="txtSeatNo" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>

                                            </div>
                                        </div>
                                    </div>


                                    <div class="form-group">
                                        <div class="row">

                                            <div class="col-lg-2">
                                                <label>Joining Date:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtTJoinDate" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                            </div>
                                            <div class="col-lg-4">
                                                <telerik:RadDatePicker RenderMode="Lightweight" ID="txtTJoinDate" CssClass="form-control" Width="100%" runat="server" DateInput-CssClass="form-control clndr">
                                                    <DateInput runat="server" DateFormat="dd/MM/yyyy">
                                                    </DateInput>
                                                </telerik:RadDatePicker>
                                            </div>
                                            <div class="col-lg-2">
                                                <label>Bus Stop:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtBusStop" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                            </div>
                                            <div class="col-lg-4">
                                                <asp:TextBox ID="txtBusStop" runat="server" CssClass="form-control"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator31" runat="server" ErrorMessage="Insert Letters" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9 ]+$" ControlToValidate="txtBusStop" Display="Dynamic" CssClass="error" ValidationGroup="validation"></asp:RegularExpressionValidator>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div id="divHostel" runat="server" visible="false">
                                <div class="panel-heading panel-heading-divider">Hostel INFORAMTION</div>
                                <div class="panel-body">

                                    <div class="form-group xs-pt-12">

                                        <div class="row">

                                            <div class="col-lg-2">
                                                <label>Select Hostel:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" InitialValue="-1" ControlToValidate="ddlHostel" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                            </div>
                                            <div class="col-lg-4">
                                                <asp:DropDownList ID="ddlHostel" runat="server" CssClass="form-control"></asp:DropDownList>
                                            </div>
                                            <div class="col-lg-2">
                                                <label>Enrollment Date:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtEnrollDate" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                            </div>
                                            <div class="col-lg-4">
                                                <telerik:RadDatePicker RenderMode="Lightweight" ID="txtEnrollDate" CssClass="form-control" Width="100%" runat="server" DateInput-CssClass="form-control clndr"></telerik:RadDatePicker>
                                                <asp:CompareValidator ID="cmptodayDate" runat="server" Display="Dynamic" ControlToValidate="txtEnrollDate" Type="Date" Operator="LessThanEqual" ErrorMessage="Enrollment date must be less then or equal to todays date" ForeColor="Red" ValidationGroup="validation"></asp:CompareValidator>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>





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
                            <asp:HiddenField ID="hdnID" runat="server" />
                            <asp:HiddenField ID="hdnpic" runat="server" />
                        </div>
                    </div>

                </div>

            </div>

        </div>

    </div>

</asp:Content>
