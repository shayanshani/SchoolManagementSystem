<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="Events.aspx.cs" Inherits="SchoolManagementSystem.Events" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">


    <div class="page-content">
        <div class="row page-row">
            <div class="events-wrapper col-md-8 col-sm-7">


                <section class="widget has-divider">
                    <h3 class="title">Upcoming Events</h3>
                    <asp:Repeater runat="server" ID="rptEvents">
                        <ItemTemplate>

                            <article class="events-item page-row has-divider clearfix">
                                <div class="date-label-wrapper col-md-1 col-sm-2">
                                    <p class="date-label">
                                        <span class="month"><%# Eval("EventDate" , "{0:MMM}") %></span>
                                        <span class="date-number"><%# Eval("EventDate" , "{0:dd}") %></span>
                                    </p>
                                </div>
                                <!--//date-label-wrapper-->
                                <div class="details col-md-11 col-sm-10">
                                    <h3 class="title"><%# Eval("EventHeading") %></h3>
                                    <p class="meta"><span class="time"><i class="fa fa-clock-o"></i><%# Eval("FromTime","{0:hh:mm tt}") %> - <%# Eval("ToTime","{0: hh:mm tt}") %></span><span class="location"><i class="fa fa-map-marker"></i><a href="#"> <%# Eval("Venue") %></a></span></p>
                                    <p class="desc"><%# Eval("EventDetail") %></p>
                                </div>
                                <!--//details-->
                            </article>
                            <!--//events-item-->



                        </ItemTemplate>


                    </asp:Repeater>


                </section>


                <ul class="pagination">
                    <li class="disabled"><a href="#">&laquo;</a></li>
                    <li class="active"><a href="#">1<span class="sr-only">(current)</span></a></li>
                    <li><a href="#">2</a></li>
                    <li><a href="#">3</a></li>
                    <li><a href="#">4</a></li>
                    <li><a href="#">5</a></li>
                    <li><a href="#">&raquo;</a></li>
                </ul>

            </div>
            <!--//events-wrapper-->
            <aside class="page-sidebar  col-md-3 col-md-offset-1 col-sm-4 col-sm-offset-1 col-xs-12">
                <section class="widget has-divider">
                    <h3 class="title">Other News</h3>

                    <!--//news-item-->
                    <asp:Repeater runat="server" ID="rptSideNews">

                        <ItemTemplate>



                            <article class="news-item row">
                                <figure class="thumb col-md-2 col-sm-3 col-xs-3">
                                    <img src='Admin/assets/CustomImages/NewsImages/<%# Eval("Image") %>' alt="" height="40" width="40" />
                                </figure>
                                <div class="details col-md-10 col-sm-9 col-xs-9">
                                    <h4 class="title"><a href='<%# ResolveUrl("News/"+Eval("NewsID")) %>'><%# Eval("Heading") %></a></h4>
                                </div>
                            </article>
                        </ItemTemplate>
                    </asp:Repeater>
                    <!--//news-item-->

                    <!--//news-item-->

                    <!--//news-item-->
                </section>
                <!--//widget-->

                <!--//widget-->
            </aside>
        </div>
        <!--//page-row-->
    </div>


</asp:Content>
