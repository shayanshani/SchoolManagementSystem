<%@ Page Title="" Language="C#" MasterPageFile="~/Branch/Master.Master" AutoEventWireup="true" CodeBehind="SchFeeEnrolement.aspx.cs" Inherits="SchoolManagementSystem.Branch.SchFeeEnrolement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .clndr {
            height: 34px !important;
            border: 1px solid #CCC !important;
        }

        .lblRDsch {
            font-size: 15px !important;
        }

        .lblfee {
            padding-top: 12px !important;
            color: #000 !important;
        }
    </style>

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

                    <asp:UpdatePanel ID="pnl" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="panel-heading panel-heading-divider">
                                <center>
                                                PAK PEARL COLLEGE (<%= Session["BranchName"] %>) <br />
                                  <span style="font-size:13px">School fee enrollment (Session 2016-17)</span>  
                            </center>

                            </div>
                            <asp:HiddenField ID="hfSchFeeID" runat="server" />
                            <div class="panel-body">

                                <div class="row">
                                    <div class="form-group">
                                        <div class="col-sm-4">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <label>Admission no:&nbsp&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtAdmissionNO" ErrorMessage="*" ForeColor="Red" ValidationGroup="validationSearch"></asp:RequiredFieldValidator></label>
                                                        <asp:TextBox ID="txtAdmissionNO" runat="server" CssClass="form-control"></asp:TextBox>

                                                    </td>
                                                    <td>&nbsp&nbsp&nbsp&nbsp
                                                    </td>
                                                    <td>
                                                        <label style="visibility: hidden!important">Admission no:&nbsp&nbsp<asp:RequiredFieldValidator Enabled="false" ID="RequiredFieldValidator6" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtAdmissionNO" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                                        <asp:Button ID="btnSearch" runat="server" Text="Go" class="btn btn-space btn-primary" OnClick="btnSearch_Click" ValidationGroup="validationSearch" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div class="col-sm-4">
                                            <label style="visibility: hidden!important">Admission no:&nbsp&nbsp<asp:RequiredFieldValidator Enabled="false" ID="RequiredFieldValidator9" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtAdmissionNO" ErrorMessage="*" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator></label>
                                            <br />
                                            <br />
                                            <a href="#">View Form</a>
                                        </div>
                                    </div>
                                </div>


                                <div class="panel-heading panel-heading-divider"></div>
                                <div class="row" id="BasciInfo" runat="server" visible="false">
                                    <div class="col-md-12">
                                        <div class="panel panel-border-color panel-border-color-primary">
                                            <div class="panel-heading">
                                                <div class="row">
                                                    <div class="col-sm-4">
                                                        <b>Student Name:</b>&nbsp<asp:Label ID="lblStudentName" runat="server" Text="Shayan"></asp:Label>
                                                    </div>
                                                    <div class="col-sm-4">
                                                        <b>Class:</b>&nbsp<asp:Label ID="lblClass" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>


                                            <div class="panel-body">
                                                <p>
                                                    <table border="1" style="width: 100%" class="table table-condensed table-bordered table-striped">
                                                        <tr>
                                                            <th>Class
                                                            </th>
                                                            <th>Admission fee(Once)
                                                            </th>
                                                            <th>Monthly fee
                                                            </th>
                                                        </tr>

                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblGrClass" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblAdmissionFee" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblMonthlyFee" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>

                                                    </table>
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                </div>


                                <div class="panel-heading panel-heading-divider" id="SectionScholarShipsHeading" runat="server">Scholar ships</div>



                                <div class="row" id="SectionScholarShips" runat="server">
                                    <div class="form-group">
                                        <div class="col-sm-12">

                                            <div class="panel-body table-responsive">
                                                <table style="width: 100%;" class="table table-borderless">

                                                    <tr>
                                                        <td>
                                                            <div class="be-radio inline">
                                                                <asp:RadioButton ID="RDHafiz" runat="server" GroupName="scholarShips" OnCheckedChanged="RDHafiz_CheckedChanged" AutoPostBack="true" />
                                                                <label for="ContentPlaceHolder1_RDHafiz" class="lblRDsch">Hafiz e Quran</label>
                                                            </div>

                                                        </td>


                                                        <td>

                                                            <div class="be-radio inline">
                                                                <asp:RadioButton ID="RdKinShip" runat="server" GroupName="scholarShips" OnCheckedChanged="RdKinShip_CheckedChanged" AutoPostBack="true" />
                                                                <label for="ContentPlaceHolder1_RdKinShip" class="lblRDsch">KinShip (Real brother & sisters)</label>
                                                            </div>
                                                        </td>

                                                        <td>

                                                            <div class="be-radio inline">
                                                                <asp:RadioButton ID="RDFata" runat="server" GroupName="scholarShips" OnCheckedChanged="RDFata_CheckedChanged" AutoPostBack="true" />
                                                                <label for="ContentPlaceHolder1_RDFata" class="lblRDsch">Fata Student</label>
                                                            </div>

                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td>

                                                            <div class="be-radio inline">
                                                                <asp:RadioButton ID="RdTeacher" runat="server" GroupName="scholarShips" OnCheckedChanged="RdTeacher_CheckedChanged" AutoPostBack="true" />
                                                                <label for="ContentPlaceHolder1_RdTeacher" class="lblRDsch">Teacher's son</label>
                                                            </div>

                                                        </td>
                                                        <td>
                                                            <div class="be-radio inline">
                                                                <asp:RadioButton ID="RdOrphan" runat="server" GroupName="scholarShips" OnCheckedChanged="RdOrphan_CheckedChanged" AutoPostBack="true" />
                                                                <label for="ContentPlaceHolder1_RdOrphan" class="lblRDsch">Orpahn</label>
                                                            </div>

                                                        </td>
                                                        <td>

                                                            <div class="be-radio inline">
                                                                <asp:RadioButton ID="rdNone" runat="server" GroupName="scholarShips" OnCheckedChanged="rdNone_CheckedChanged" AutoPostBack="true" Checked="true" />
                                                                <label for="ContentPlaceHolder1_rdNone" class="lblRDsch">without scholarship</label>
                                                            </div>


                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td>
                                                            <div class="be-radio inline">
                                                                <asp:RadioButton ID="rdOther" runat="server" GroupName="scholarShips" OnCheckedChanged="rdOther_CheckedChanged" AutoPostBack="true"/>
                                                                <label for="ContentPlaceHolder1_rdOther" class="lblRDsch">Other</label>
                                                            </div>
                                                        </td>
                                                    </tr>

                                                </table>

                                            </div>

                                        </div>

                                    </div>
                                </div>



                                <div class="panel-heading panel-heading-divider">Fee</div>


                                <div class="form-group xs-pt-12">
                                    <div class="row" style="margin: 7px !important;">

                                        <div class="col-lg-1">
                                            <label class="lblfee">Admission Fee:</label>
                                        </div>
                                        <div class="col-lg-6">
                                            <asp:TextBox ID="txtAdmisionFee" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                        </div>

                                    </div>

                                     <div class="row" style="margin: 7px !important;">

                                        <div class="col-lg-1">
                                            <label class="lblfee">Monthly Fee:</label>
                                        </div>
                                        <div class="col-lg-6">
                                            <asp:TextBox ID="txtMonthlyFee" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                        </div>

                                    </div>

                                  <%--  <div class="row" style="margin: 7px !important;">
                                        <div class="col-lg-1">
                                            <label class="lblfee">Advance:</label>
                                        </div>
                                        <div class="col-lg-6">

                                            <asp:TextBox ID="txtAdvance" runat="server" CssClass="form-control" Text="0" onkeypress="return isNumber(event)"></asp:TextBox>
                                                              </div>
                                    </div>--%>

                                    <div class="row" style="margin: 7px !important;" id="DiscountDiv" runat="server">
                                        <div class="col-lg-1">
                                            <label class="lblfee">Discount:</label>
                                        </div>
                                        <div class="col-lg-6">

                                            <asp:TextBox ID="txtDiscount" runat="server" CssClass="form-control" Text="0" onkeypress="return isNumber(event)"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="row" style="margin: 7px !important;" id="OtherDescDiv" runat="server" visible="false">
                                        <div class="col-lg-1">
                                            <label class="lblfee">Description:</label>
                                        </div>
                                        <div class="col-lg-6">

                                            <asp:TextBox ID="txtOtherDescr" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" style="resize:none!important"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row xs-pt-15">
                                    <div class="col-xs-6">
                                        <div class="be-checkbox">
                                        </div>
                                    </div>
                                    <div class="col-xs-6">
                                        <p class="text-right">
                                            <asp:LinkButton ID="btnSave" runat="server" Text="Submit" class="btn btn-space btn-primary" OnClick="btnSave_Click" ValidationGroup="validation"></asp:LinkButton>
                                        </p>
                                    </div>
                                </div>

                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>


                </div>
            </div>

        </div>
    </div>

    <script type="text/javascript">
        function openModal() {
            alert('No record found');
        }
    </script>



</asp:Content>
