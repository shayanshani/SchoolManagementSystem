<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="SchoolManagementSystem.ContactUs" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="page-content">
        <div class="row">
            <article class="contact-form col-md-8 col-sm-7  page-row">
                <h3 class="title">Get in touch</h3>
                <p><asp:Label runat="server" ID="lblmsg" Text="We’d love to hear from you."></asp:Label></p>
                
                    <div class="form-group name">
                        <label for="txtName">Name</label>
                        <asp:TextBox runat="server" ID="txtName" class="form-control" placeholder="Enter your name" required="required"></asp:TextBox>
                      
                    </div>
                    <!--//form-group-->
                    <div class="form-group email">
                        <label for="txtEmail">Email Address</label>
                        <asp:TextBox runat="server" ID="txtEmail" class="form-control" placeholder="Enter Your Email" TextMode="Email" required="required" ></asp:TextBox>
                        
                        
                    </div>
                    <!--//form-group-->
                    <div class="form-group phone">
                        <label for="txtContactNo">Phone</label>
                        <asp:TextBox runat="server" ID="txtContactNo"  class="form-control" placeholder="Enter Your Contact No" TextMode="Number" required ></asp:TextBox>
                    </div>
                    <!--//form-group-->
                    <div class="form-group message">
                        <label for="message">Message<span class="required">*</span></label>
                        <asp:TextBox runat="server" ID="txtmsg" required="required"  class="form-control" TextMode="MultiLine" placeholder="Enter your message here..."></asp:TextBox>
                        
                    </div>
                    <!--//form-group-->
                   <asp:Button runat="server" class="btn btn-theme" OnClick="btnSend_Click"  Text="Your Message" ID="btnSend" />
                
            </article>
            <!--//contact-form-->
            <aside class="page-sidebar  col-md-3 col-md-offset-1 col-sm-4 col-sm-offset-1">
                <section class="widget has-divider">
                    <h3 class="title">Download Prospectus</h3>

                    <a class="btn btn-theme" href="#"><i class="fa fa-download"></i>Download now</a>
                </section>
                <!--//widget-->

                <section class="widget has-divider">
                    <h3 class="title">Postal Address</h3>
                    <p class="adr">
                        <span class="adr-group">
                            <span class="street-address">PAK PEARL SCHOOLS AND COLEGES</span><br>
                            <span class="region">KPK</span><br>
                            <span class="postal-code">29050</span><br>
                            <span class="country-name">Pakistan</span>
                        </span>
                    </p>
                </section>
                <!--//widget-->

                <section class="widget">
                    <h3 class="title">All Enquiries</h3>
                    <p class="tel"><i class="fa fa-phone"></i>Tel: 0800 123 4567</p>
                    <p class="email"><i class="fa fa-envelope"></i>Email: <a href="#">contact@pakpearl.edu.pk</a></p>
                </section>
            </aside>
            <!--//page-sidebar-->
        </div>
        <!--//page-row-->
        <div class="page-row">
            <article class="map-section">
                <h3 class="title">How to find us</h3>
                <div id="map"></div>
                <!--//map-->
            </article>
            <!--//map-->
        </div>
        <!--//page-row-->
    </div>
    <!--//page-content-->
</asp:Content>
