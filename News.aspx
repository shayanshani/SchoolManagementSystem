<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="SchoolManagementSystem.News" MasterPageFile="~/Site1.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <div class="content container">
        <div class="page-wrapper">

            <asp:Repeater runat="server" ID="rptNews">

                <ItemTemplate>
                    <header class="page-heading clearfix">
                        <h1 class="heading-title pull-left"><%# Eval("Heading") %></h1>

                    </header>
                    <div class="page-content">
                        <div class="row page-row">

                            <div class="news-wrapper col-md-8 col-sm-7">
                                <article class="news-item">
                                    <p class="meta text-muted">By: <a href="#">Admin</a> | Posted on: <%# Convert.ToDateTime(Eval("PostedDate")).ToString("dd/MM/yyyy") %></p>
                                    <p class="featured-image">
                                        <img class="img-responsive" src='/Admin/assets/CustomImages/NewsImages/<%# Eval("Image") %>' alt="" /></p>
                                    <p>
                                        <p><%# Eval("Description") %></p>
                                    </p>
                                </article>
                                <!--//news-item-->
                            </div>
                </ItemTemplate>
            </asp:Repeater>
            </
                       <!--//news-wrapper-->
            <aside class="page-sidebar  col-md-3 col-md-offset-1 col-sm-4 col-sm-offset-1 col-xs-12">
                <section class="widget has-divider">
                    <h3 class="title">Other News</h3>
                    
                    <!--//news-item-->
                     <asp:Repeater runat="server" ID="rptSideNews">

                        <ItemTemplate>



                           <article class="news-item row">
                        <figure class="thumb col-md-2 col-sm-3 col-xs-3">
                            <img src='<%# ResolveUrl("Admin/assets/CustomImages/NewsImages/"+Eval("Image")) %>' alt="" height="40" width="40" />
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
                <section class="widget has-divider">
                    <h3 class="title">Upcoming Events</h3>
                    <asp:Repeater runat="server" ID="rptEvents">
                        <ItemTemplate>
                            <article class="events-item row page-row">
                                <div class="date-label-wrapper col-md-3 col-sm-4 col-xs-4">
                                    <p class="date-label">
                                        <span class="month"><%# Eval("EventDate" , "{0:MMM}") %></span>
                                        <span class="date-number"><%# Eval("EventDate" , "{0:dd}") %></span>
                                    </p>
                                </div>
                                <!--//date-label-wrapper-->
                                <div class="details col-md-9 col-sm-8 col-xs-8">
                                    <h5 class="title"><%# Eval("EventHeading") %></h5>
                                    <p class="time text-muted"><%# Eval("FromTime","{0:hh:mm tt}") %> - <%# Eval("ToTime","{0: hh:mm tt}") %>
                                        <br />
                                        At <%# Eval("Venue") %><br />
                                         
                                    <%# Eval("EventDetail").ToString().Length>150? Eval("EventDetail").ToString().Substring(0,80):Eval("EventDetail") %>...</p>
                                </div>
                                <!--//details-->
                            </article>
                        </ItemTemplate>


                    </asp:Repeater>


                </section>
                <!--//widget-->
            </aside>
        </div>
        <!--//page-row-->
    </div>
    <!--//page-content-->
    </div><!--//page-->
    </div>


</asp:Content>
