<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SchoolManagementSystem.index" MasterPageFile="~/Site1.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <div class="home-page">
            <div id="promo-slider" class="slider flexslider">
                <ul class="slides">
                    <li>
                        <img src="assets/images/slides/slide-1.jpg"  alt="" />
                        <p class="flex-caption">
                            <span class="main" >Join Pak Pearl Online</span>
                            <br />
                            <span class="secondary clearfix" >Choose from over 100 online and offline courses</span>
                        </p>
                    </li>
                    <li>
                        <img src="assets/images/slides/slide-2.jpg"  alt="" />
                        <p class="flex-caption">
                            <span class="main" >Illumination through education</span>
                            <br />
                            <span class="secondary clearfix" >Foreign Universities from sixteen countries accross the globle are enlisted</span>
                        </p>
                    </li>
                    <li>
                        <img src="assets/images/slides/slide-3.jpg"  alt="" />
                        <p class="flex-caption">
                            <span class="main" >Discover online courses</span>
                            <br />
                            <span class="secondary clearfix" >Pak pearl colleges have been pioneered with a resolution to be the best leading Education Brand in Country</span>
                        </p>
                    </li>
                    
                </ul><!--//slides-->
            </div><!--//flexslider-->
            <section class="promo box box-dark">        
                <div class="col-md-9">
                <h1 class="section-heading">Check Result Online</h1>
                    <p>  </p>   
                </div>  
                <div class="col-md-3">
                    <a class="btn btn-cta" href="#"><i class="fa fa-folder"></i>Results</a>  
                </div>
            </section><!--//promo-->
            <section class="news">
                <h1 class="section-heading text-highlight"><span class="line">Latest News</span></h1>     
                <div class="carousel-controls">
                    <a class="prev" href="#news-carousel" data-slide="prev"><i class="fa fa-caret-left"></i></a>
                    <a class="next" href="#news-carousel" data-slide="next"><i class="fa fa-caret-right"></i></a>
                </div><!--//carousel-controls--> 
                <div class="section-content clearfix">
                    <div id="news-carousel" class="news-carousel carousel slide">
                        <div class="carousel-inner">
                            <div class="item active"> 
                                 <asp:Repeater runat="server" ID="rptNews">

                                    <ItemTemplate>
                                    <div class="col-md-4 news-item">
                                    <h2 class="title"><a href='News.aspx?val=<%# Eval("NewsID") %>'><%# Eval("Heading") %></a></h2>
                                    <p><%# Eval("Description").ToString().Length>150? Eval("Description").ToString().Substring(0,150):Eval("Description") %></p>
                                    <a class="read-more" href='<%# ResolveUrl("News/"+Eval("NewsID")) %>'>Read more<i class="fa fa-chevron-right"></i></a>
                                    <img class="thumb" src='<%# ResolveUrl("Admin/assets/CustomImages/NewsImages/"+Eval("Image")) %>' style="height:100px!important;width:100px!important"  alt="" />
                                </div><!--//news-item-->
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div><!--//item-->
                        
                        </div><!--//carousel-inner-->
                    </div><!--//news-carousel-->  
                </div><!--//section-content-->     
            </section><!--//news-->
            <div class="row cols-wrapper">
                <div class="col-md-3">
                   <div class="Ad">
                    
                   </div>
                  <!--//events-->
                </div><!--//col-md-3-->
                
                <div class="col-lg-9">
                <div class="col-md-9 col-sm-9 col-xs-9">
                <p>


    Initiative to promote access, affordability and attainment in education by reining in costs, providing value, and preparing students with a high quality education to succeed in their careers
    To create an economy built to last, we aim to provide complete and competitive education to our children that will enable them to succeed in a global economy based on knowledge and innovation
    For the purpose – establishing countrywide Education Network under the banner of “Pak Pearl Schools and Colleges”. PPS Vision-2020 constitutes a Three Digit benchmark referring to the number of our institutes
    One step solution to all educational needs – Playgroup to Post-Graduate level. Ensuring most modern education through:
    Latest Curriculum
    Purposive Co-Curricular Practices
    High Profile Faculty
    Professionally Trained Staff
    PakPearl is to be established as a mark of excellence and an identity to be reckoned. Its motto caters the theme as:
 </p>
                <strong>Younis Ali Gohar</strong>
               
				</div>
	
               
               
                </div>
            </div><!--//cols-wrapper-->
            <section class="awards">
                <div id="awards-carousel" class="awards-carousel carousel slide">
                    <div class="carousel-inner">
                        <div class="item active">
                            <ul class="logos">
                                <li class="col-md-4 col-sm-4 col-xs-4">
                                    <a href="#">
                                    <img class="img-responsive"  src="assets/images/slides/slide-4.jpg"  alt="" /></a>
                                </li>
                                 <li class="col-md-4 col-sm-4 col-xs-4">
                                    <a href="#">
                                    <img class="img-responsive"  src="assets/images/slides/slide-4.jpg"  alt="" /></a>
                                </li>
                                 <li class="col-md-4 col-sm-4 col-xs-4">
                                    <a href="#">
                                    <img class="img-responsive"  src="assets/images/slides/slide-4.jpg"  alt="" /></a>
                                </li>
                               
                                          
                            </ul><!--//slides-->
                        </div><!--//item-->
                        
                        <div class="item">
                            <ul class="logos">
                               <li class="col-md-4 col-sm-4 col-xs-4">
                                    <a href="#">
                                    <img class="img-responsive"  src="assets/images/slides/slide-4.jpg"  alt="" /></a>
                                </li>
                                 <li class="col-md-4 col-sm-4 col-xs-4">
                                    <a href="#">
                                    <img class="img-responsive"  src="assets/images/slides/slide-4.jpg"  alt="" /></a>
                                </li>
                                 <li class="col-md-4 col-sm-4 col-xs-4">
                                    <a href="#">
                                    <img class="img-responsive"  src="assets/images/slides/slide-4.jpg"  alt="" /></a>
                                </li>             
                            </ul><!--//slides-->
                        </div><!--//item-->
                    </div><!--//carousel-inner-->
                    <a class="left carousel-control" href="#awards-carousel" data-slide="prev">
                        <i class="fa fa-angle-left"></i>
                    </a>
                    <a class="right carousel-control" href="#awards-carousel" data-slide="next">
                        <i class="fa fa-angle-right"></i>
                    </a>
        
                </div>
            </section>

    </div>

  


</asp:Content>
 