<%@ Page Title="" Language="C#" MasterPageFile="~/Branch/Master.Master" AutoEventWireup="true" CodeBehind="ClgFeeEnrolement.aspx.cs" Inherits="SchoolManagementSystem.Branch.ClgFeeEnrolement" %>

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
                                  <span style="font-size:13px">College fee enrollment (Session 2016-17)</span>  
                            </center>

                            </div>
                            <asp:HiddenField ID="hfclgFeeID" runat="server" />
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
                                                        <b>Student Name:</b>&nbsp<asp:Label ID="lblStudentName" runat="server"></asp:Label>
                                                    </div>
                                                    <div class="col-sm-4">
                                                        <b>Program:</b>&nbsp<asp:Label ID="lblProgram" runat="server"></asp:Label>
                                                    </div>
                                                    <div class="col-sm-4">
                                                        <b>Percentage:</b>&nbsp<asp:Label ID="lblpercentage" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="panel-body">
                                                <p>
                                                    <table border="1" style="width: 100%" class="table table-condensed table-bordered table-striped">
                                                        <tr style="height: 80px;">
                                                            <th style="vertical-align: middle;"></th>
                                                            <th style="vertical-align: middle;">Scholarship Detail
                                                            </th>
                                                            <th style="vertical-align: middle;">
                                                                <table style="width: 100%">
                                                                    <tr>
                                                                        <td>
                                                                            <%= lblProgram.Text %>
                                                                        </td>
                                                                        <td>&nbsp&nbsp</td>
                                                                        <td>

                                                                            <table style="width: 100%">

                                                                                <tr>

                                                                                    <th>Total Fee&nbsp=&nbsp<asp:Label ID="lblTotalFee" runat="server"></asp:Label>
                                                                                    </th>
                                                                                </tr>


                                                                                <tr>
                                                                                    <th>Admission Fee&nbsp=&nbsp<asp:Label ID="lblAdmissionFee" runat="server"></asp:Label>
                                                                                    </th>
                                                                                </tr>
                                                                                <tr>
                                                                                    <th>Misc&nbsp=&nbsp
                                                                                        <asp:Label ID="lblMisc" runat="server"></asp:Label>
                                                                                    </th>
                                                                                </tr>
                                                                                <tr>
                                                                                    <th>Tution Fee&nbsp=&nbsp
                                                                                        <asp:Label ID="lblTutionFee" runat="server"></asp:Label>
                                                                                    </th>

                                                                                </tr>

                                                                            </table>

                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </th>
                                                        </tr>

                                                        <tr>
                                                            <td colspan="3" align="center">Scholarship Detail
                                                            </td>
                                                        </tr>

                                                        <tr style="background-color: transparent!important; text-align: center">
                                                            <td colspan="3">

                                                                <table style="width: 100%; background-color: transparent!important" border="1" class="table table-condensed table-bordered table-striped">

                                                                    <tr>
                                                                        <th style="width: 25%; text-align: center">Obtained
                                                                            <br />
                                                                            Marks %
                                                                        </th>
                                                                        <th style="text-align: center">
                                                                            <%= lblProgram.Text %>
                                                                        </th>
                                                                    </tr>

                                                                    <tr id="trFree" runat="server">
                                                                        <td style="width: 25%">85 % to above
                                                                            <br />
                                                                            (935 & above )
                                                                        </td>
                                                                        <td>Free
                                                                        </td>
                                                                    </tr>

                                                                    <tr id="trMiscOnly" runat="server">
                                                                        <td style="width: 25%">80 to 84 %
                                                                            <br />
                                                                            (880 & 924)
                                                                        </td>
                                                                        <td>Only MISC&nbsp=&nbsp <%= lblMisc.Text %>/-
                                                                        </td>
                                                                    </tr>

                                                                    <tr  id="trAdmssion" runat="server">
                                                                        <td style="width: 25%">75 to 79 %
                                                                            <br />
                                                                            (825 & 869)
                                                                        </td>
                                                                        <td>
                                                                            <table style="width: 100%">
                                                                                <tr>
                                                                                    <td style="width: 43.8%; border-right: 1px solid #DDD">Only Admission Fee
                                                                                    </td>
                                                                                    <td style="border-right: 1px solid #DDD; width: 26.9%;">= <%= lblAdmissionFee.Text %>/-
                                                                                    </td>
                                                                                    <td>= <%= lblAdmissionFee.Text %>/-
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>


                                                                    <tr  id="trAdmissionMisc" runat="server">
                                                                        <td style="width: 25%">70 to 74 %
                                                                            <br />
                                                                            (770 & 814)
                                                                        </td>
                                                                        <td>
                                                                            <table style="width: 100%">
                                                                                <tr>
                                                                                    <td style="border-right: 1px solid #DDD;width: 43.8%;">Only Admission Fee + Misc
                                                                                    </td>
                                                                                    <td style="border-right: 1px solid #DDD;">= <%= lblAdmissionFee.Text %>&nbsp+&nbsp<%= lblMisc.Text %>
                                                                                        <br />
                                                                                        =<asp:Label ID="lblAdmissionPlusMisc" runat="server"></asp:Label>/-
                                                                                    </td>
                                                                                    <td>= <%= lblAdmissionFee.Text %>&nbsp+&nbsp<%= lblMisc.Text %>
                                                                                        <br />
                                                                                        =<%= lblAdmissionPlusMisc.Text %>/-
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>

                                                                    <tr  id="tr80" runat="server">
                                                                        <td style="width: 25%">65 to 69 %
                                                                            <br />
                                                                            (715 & 759)
                                                                        </td>
                                                                        <td>
                                                                            <table style="width: 100%">
                                                                                <tr>
                                                                                    <td style="width: 43.8%; border-right: 1px solid #DDD;">80 % Tution Fee OFF
                                                                                    </td>
                                                                                    <td style="border-right: 1px solid #DDD; width: 26.9%">= <%= lblAdmissionFee.Text %>&nbsp+&nbsp<%= lblMisc.Text %>&nbsp+&nbsp<asp:Label ID="lbl80TutionFee" runat="server"></asp:Label>
                                                                                        <br />
                                                                                        =<asp:Label ID="lbl80Percent" runat="server"></asp:Label>/-
                                                                                    </td>
                                                                                    <td>= <%= lblAdmissionFee.Text %>&nbsp+&nbsp<%= lblMisc.Text %>&nbsp+&nbsp<asp:Label ID="lbl80TutionFeeSch" runat="server"></asp:Label>
                                                                                        <br />
                                                                                        =<asp:Label ID="lbl80PercentSch" runat="server"></asp:Label>/-
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>


                                                                    <tr  id="tr60" runat="server">
                                                                        <td style="width: 25%">60 to 64 %
                                                                            <br />
                                                                            (660 & 704)
                                                                        </td>
                                                                        <td>
                                                                            <table style="width: 100%">
                                                                                <tr>
                                                                                    <td style="width: 43.8%; border-right: 1px solid #DDD;">60 % Tution Fee OFF
                                                                                    </td>
                                                                                    <td style="border-right: 1px solid #DDD; width: 26.9%">= <%= lblAdmissionFee.Text %>&nbsp+&nbsp<%= lblMisc.Text %>&nbsp+&nbsp<asp:Label ID="lbl60TutionFee" runat="server"></asp:Label>
                                                                                        <br />
                                                                                        =<asp:Label ID="lbl60Percent" runat="server" Text=""></asp:Label>/-
                                                                                    </td>
                                                                                    <td>= <%= lblAdmissionFee.Text %>&nbsp+&nbsp<%= lblMisc.Text %>&nbsp+&nbsp<asp:Label ID="lbl60TutionFeeSch" runat="server"></asp:Label>
                                                                                        <br />
                                                                                        =<asp:Label ID="lbl60PercentSch" runat="server"></asp:Label>/-
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>


                                                                    <tr  id="tr40" runat="server">
                                                                        <td style="width: 25%">55 to 59 %
                                                                            <br />
                                                                            (605 & 649)
                                                                        </td>
                                                                        <td>
                                                                            <table style="width: 100%">
                                                                                <tr>
                                                                                    <td style="width: 43.8%; border-right: 1px solid #DDD;">40 % Tution Fee OFF
                                                                                    </td>
                                                                                    <td style="border-right: 1px solid #DDD; width: 26.9%">= <%= lblAdmissionFee.Text %>&nbsp+&nbsp<%= lblMisc.Text %>&nbsp+&nbsp<asp:Label ID="lbl40TutionFee" runat="server"></asp:Label>
                                                                                        <br />
                                                                                        =<asp:Label ID="lbl40Percent" runat="server" Text=""></asp:Label>/-
                                                                                    </td>
                                                                                    <td>= <%= lblAdmissionFee.Text %>&nbsp+&nbsp<%= lblMisc.Text %>&nbsp+&nbsp<asp:Label ID="lbl40TutionFeeSch" runat="server"></asp:Label>
                                                                                        <br />
                                                                                        =<asp:Label ID="lbl40PercentSch" runat="server"></asp:Label>/-
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>


                                                                    <tr  id="tr20" runat="server">
                                                                        <td style="width: 25%">50 to 54 %
                                                                            <br />
                                                                            (550 & 594)
                                                                        </td>
                                                                        <td>
                                                                            <table style="width: 100%">
                                                                                <tr>
                                                                                    <td style="width: 43.8%; border-right: 1px solid #DDD;">20 % Tution Fee OFF
                                                                                    </td>
                                                                                    <td style="border-right: 1px solid #DDD; width: 26.9%">= <%= lblAdmissionFee.Text %>&nbsp+&nbsp<%= lblMisc.Text %>&nbsp+&nbsp<asp:Label ID="lbl20TutionFee" runat="server"></asp:Label>
                                                                                        <br />
                                                                                        =<asp:Label ID="lbl20Percent" runat="server" Text=""></asp:Label>/-
                                                                                    </td>
                                                                                    <td>= <%= lblAdmissionFee.Text %>&nbsp+&nbsp<%= lblMisc.Text %>&nbsp+&nbsp<asp:Label ID="lbl20TutionFeeSch" runat="server"></asp:Label>
                                                                                        <br />
                                                                                        =<asp:Label ID="lbl20PercentSch" runat="server"></asp:Label>/-
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>

                                                                    <tr>
                                                                        <td></td>
                                                                        <td>
                                                                            <div style="background: none repeat scroll 0% 0% grey; color: #fff!important; height: 26px; width: 218px; float: right; margin-top: -7px; margin-right: -10px;">
                                                                                <p style="font-family: Verdana; font-weight: initial">E-Scholarship</p>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>

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
                                                                <asp:RadioButton ID="rdOldStudent" runat="server" GroupName="scholarShips" OnCheckedChanged="rdOldStudent_CheckedChanged" AutoPostBack="true" />
                                                                <label for="ContentPlaceHolder1_rdOldStudent" class="lblRDsch">Old Student</label>
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
                                                                <asp:RadioButton ID="RDSportsMan" runat="server" GroupName="scholarShips" OnCheckedChanged="RDSportsMan_CheckedChanged" AutoPostBack="true" />
                                                                <label for="ContentPlaceHolder1_RDSportsMan" class="lblRDsch">Sportsman(Province)</label>
                                                            </div>

                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td>
                                                            <div class="be-radio inline">
                                                                <asp:RadioButton ID="rdGemployee" runat="server" GroupName="scholarShips" OnCheckedChanged="rdGemployee_CheckedChanged" AutoPostBack="true" />
                                                                <label for="ContentPlaceHolder1_rdGemployee" class="lblRDsch">Government Employee</label>
                                                            </div>
                                                        </td>
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

                                                </table>

                                            </div>

                                        </div>

                                    </div>
                                </div>




                                <div class="panel-heading panel-heading-divider">Fee</div>


                                <div class="form-group xs-pt-12">
                                    <div class="row" style="margin: 7px !important;">

                                        <div class="col-lg-1">
                                            <label class="lblfee">Total:</label>
                                        </div>
                                        <div class="col-lg-6">

                                            <asp:TextBox ID="txtTotal" runat="server" CssClass="form-control" disabled="disabled"></asp:TextBox>
                                        </div>

                                    </div>

                                    <div class="row" style="margin: 7px !important;">
                                        <div class="col-lg-1">
                                            <label class="lblfee">Advance:</label>
                                        </div>
                                        <div class="col-lg-6">

                                            <asp:TextBox ID="txtAdvance" runat="server" CssClass="form-control" Text="0" onkeypress="return isNumber(event)"></asp:TextBox>
                                    <%--        <asp:CompareValidator ID="cmp" runat="server" Display="Dynamic" ControlToValidate="txtTotal" ControlToCompare="txtAdvance" Operator="GreaterThan" ErrorMessage="Advance fee must be less then Total Fee" ForeColor="Red" ValidationGroup="validation"></asp:CompareValidator>--%>
                                     </div>
                                    </div>

                                    <div class="row" style="margin: 7px !important;">
                                        <div class="col-lg-1">
                                            <label class="lblfee">Discount:</label>
                                        </div>
                                        <div class="col-lg-6">

                                            <asp:TextBox ID="txtDiscount" runat="server" CssClass="form-control" Text="0" onkeypress="return isNumber(event)"></asp:TextBox>
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
