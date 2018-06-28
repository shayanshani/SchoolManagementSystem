<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllNews.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="SchoolManagementSystem.AllNews" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <div class="page-content">
        <div class="row page-row">
            <div class="news-wrapper col-md-8 col-sm-7">
                <article class="news-item page-row has-divider clearfix row">

                    <asp:Repeater runat="server" ID="rptNews">

                        <ItemTemplate>



                            <figure class="thumb col-md-2 col-sm-3 col-xs-4">
                                <img class="img-responsive" src='Admin/assets/CustomImages/NewsImages/<%# Eval("Image") %>' alt="" />
                            </figure>
                            <div class="details col-md-10 col-sm-9 col-xs-8">
                                <h3 class="title"><a href='<%# ResolveUrl("News/"+Eval("NewsID")) %>'><%# Eval("Heading") %></a></h3>
                                <p><%# Eval("Description") %></p>
                                <a class="btn btn-theme read-more" href='<%# ResolveUrl("News/"+Eval("NewsID")) %>'>Read more<i class="fa fa-chevron-right"></i></a>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </article>
                <!--//news-item-->


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
            <!--//news-wrapper-->
            <aside class="page-sidebar  col-md-3 col-md-offset-1 col-sm-4 col-sm-offset-1">

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
</asp:Content>
