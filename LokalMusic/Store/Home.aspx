<%@ Page Title="Home" Language="C#" MasterPageFile="~/Template/StoreLayout.master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="LokalMusic.Store.Home" ErrorPage="~/ErrorPage.aspx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        #featured-artist {
         /* background-color: #FFDCDC;*/
            background-color: #bd4f6c;
            background-image: linear-gradient(326deg, #bd4f6c 0%, #d7816a 74%);
        }

        h1, p {
            font-family: Montserrat;
        }

        h5{
            font-size: 21px;
        }

        #featured-artist p {
            font-weight: 400;
        }

        .view-all {
            font-weight: 500;
            font-size: 11px;
            border: solid;
            border-width: 1px;
            border-color: #dc3545;
            border-radius: 5px;
            padding: 0px 3px 0px 3px;
        }

        .view-all:hover, #best-selling-albums a:hover, #top-artists a:hover, #famous-tracks a:hover {
            text-decoration: none;
        }

        .card-body {
            margin: -14px -18px 0 -18px;
        }
        
        .card-body p {
            color: black;
            font-size: 13px;
            font-weight: 500;
            margin: 0 0 0 0;
        }

        .by-artist {
            color: #808080;
        }

        .featured-text{
            font-size: 36px;
        }

        .featured-text-display{
            color: #FFDCDC;
        }
    </style>

    <div id="featured-artist" class="pt-5 pb-4">
        <div class="container py-2">
            <div class="row">
                <div class="col-lg-3 col-sm-12">
                    <div class="">
                        <h1 class="text-center font-weight-bold featured-text featured-text-display">Featured<br />
                            Albums
                        </h1>
                        <p class="text-center featured-text-display" style="font-weight: 600;">
                            Albums Around<br />
                            the Philippines
                        </p>
                    </div>
                </div>

                <asp:Repeater runat="server" ID="FeaturedProductRepeater">
                    <ItemTemplate>
                        <div class="col-lg-3 col-md-4 col-sm-5 mb-lg-0 mx-auto mb-sm-4 mb-4">
                            <a href="<%# Eval("MarketPage")%>"" class="">
                                <img src="<%# Eval("ProductImage")%>"" class="img-hoverable mx-auto d-block shadow rounded" style="width:200px; height:auto;" alt="feature-artist-name" />
                            </a>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>

    <div id="best-selling-albums" class="container mt-5">
        <div class="row mb-4">
            <h5 class="my-auto ml-4 ml-sm-0">Bestselling Albums</h5>
            <a class="text-danger ml-2 view-all my-auto" id="albumViewAll" runat="server">View All</a>
        </div>

        <%--Albums--%>
        <div class="row">
            <asp:Repeater ID="albumContainer" runat="server">
                <ItemTemplate>
                    <div class="col-lg-2 col-sm-4">
                        <div class="card border-0 ml-5 mr-5 ml-sm-0 mr-sm-0">
                            <a href='<%#Eval("DetailsUrl") %>' runat="server">
                                <img src="<%#Eval("AlbumCover") %>" class="card-img-top img-hoverable shadow-sm" alt="album-name" /></a>
                            <div class="card-body">
                                <p class="productName"><%#Eval("AlbumName")%></p>
                                <p class="" style="color: #F82B2B; font-weight: 600;">₱<%#Eval("Price", "{0:n}")%></p>
                                <p class="by-artist float-right" style="color: #767676;"><%#Eval("ArtistName")%></p>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

    </div>

    <div id="top-artists" class="container mt-4">
        <div class="row mb-4">
            <h5 class="my-auto ml-4 ml-sm-0">Top Artists</h5>
            <a class="text-danger ml-2 view-all my-auto" id="artistViewAll" runat="server">View All</a>
        </div>

        <%--Artists--%>
        <div class="row">
            <asp:Repeater ID="artistContainer" runat="server">
                <ItemTemplate>
                    <div class="col-lg-2 col-sm-4">
                        <div class="card border-0 ml-5 mr-5 ml-sm-0 mr-sm-0">
                            <a href='<%#Eval("DetailsUrl") %>' runat="server">
                                <img src="<%#Eval("ArtistProfileImage")%>" class="card-img-top img-hoverable shadow-sm" alt="artist-name" /></a>
                            <div class="card-body">
                                <p class="productName"><%#Eval("ArtistName")%></p>
                                <p style="font-weight: 400;"><%#Eval("Bio")%></p>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

    </div>

    <div id="famous-tracks" class="container mt-4">
        <div class="row mb-4">
            <h5 class="my-auto ml-4 ml-sm-0">Famous Tracks</h5>
            <a class="text-danger ml-2 view-all my-auto" id="trackViewAll" runat="server">View All</a>
        </div>

        <%--Track--%>
        <div class="row">
            <asp:Repeater ID="trackContainer" runat="server">
                <ItemTemplate>
                    <div class="col-lg-2 col-sm-4">
                        <div class="card border-0 ml-5 mr-5 ml-sm-0 mr-sm-0">
                           <a  onclick='<%# "GetTrack(" +Eval("TrackId") + " );" %>' class="img-hoverable">
                                <img src="<%#Eval("AlbumCover")%>" class="card-img-top img-hoverable shadow-sm" alt="track-name" />
                            </a>
                            <div class="card-body">
                                <p class="productName"><%#Eval("TrackName")%></p>
                                <p class="" style="color: #F82B2B; font-weight: 600;">₱<%#Eval("Price", "{0:n}")%></p>
                                <p class="by-artist float-right" style="color: #767676;"><%#Eval("ArtistName")%></p>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>

</asp:Content>
