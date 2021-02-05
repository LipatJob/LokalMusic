<%@ Page Title="Home" Language="C#" MasterPageFile="~/Template/StoreLayout.master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="LokalMusic.Store.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        #featured-artist {
            background-color: #FFDCDC;
        }

        h1, p {
            font-family: Montserrat;
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
    </style>

    <div id="featured-artist" class="pt-5 pb-4">
        <div class="container py-2">
            <div class="row">
                <div class="col-lg-3 col-md-12" style="display:flex; flex-direction:column; justify-content:center;">
                    <h1 class="text-center font-weight-bold featured-text">Featured<br />
                        Albums
                    </h1>
                    <p class="text-center">
                        Albums Around<br />
                        the Philippines
                    </p>
                </div>

                <asp:Repeater runat="server" ID="FeaturedProductRepeater">
                    <ItemTemplate>
                        <div class="col-lg-3 col-sm-12 mb-md-3 mb-sm-3 mb-lg-0">
                            <a href="<%# Eval("MarketPage")%>"" class="" target="_blank">
                                <img src="<%# Eval("ProductImage")%>"" class="img-hoverable" style="width:180px; height:auto;" alt="feature-artist-name" />
                            </a>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>

    <div id="best-selling-albums" class="container mt-4">
        <div class="row mb-4">
            <h5 class="my-auto">Bestselling Albums</h5>
            <a class="text-danger ml-2 view-all my-auto" id="albumViewAll" runat="server">View All</a>
        </div>

        <%--Albums--%>
        <div class="row">
            <asp:Repeater ID="albumContainer" runat="server">
                <ItemTemplate>
                    <div class="col-lg-2 col-sm-4">
                        <div class="card border-0">
                            <a href='<%#Eval("DetailsUrl") %>' runat="server">
                                <img src="<%#Eval("AlbumCover") %>" class="card-img-top img-hoverable" alt="album-name" /></a>
                            <div class="card-body">
                                <p><%#Eval("AlbumName")%></p>
                                <p class="" style="color: #F82B2B; font-weight: 600;">₱<%#Eval("Price")%></p>
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
            <h5 class="my-auto">Top Artists</h5>
            <a class="text-danger ml-2 view-all my-auto" id="artistViewAll" runat="server">View All</a>
        </div>

        <%--Artists--%>
        <div class="row">
            <asp:Repeater ID="artistContainer" runat="server">
                <ItemTemplate>
                    <div class="col-lg-2 col-sm-4">
                        <div class="card border-0">
                            <a href='<%#Eval("DetailsUrl") %>' runat="server">
                                <img src="<%#Eval("ArtistProfileImage")%>" class="card-img-top img-hoverable" alt="artist-name" /></a>
                            <div class="card-body">
                                <p><%#Eval("ArtistName")%></p>
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
            <h5 class="my-auto">Famous Tracks</h5>
            <a class="text-danger ml-2 view-all my-auto" id="trackViewAll" runat="server">View All</a>
        </div>

        <%--Track--%>
        <div class="row">
            <asp:Repeater ID="trackContainer" runat="server">
                <ItemTemplate>
                    <div class="col-lg-2 col-sm-4">
                        <div class="card border-0">
                            <a href='<%#Eval("DetailsUrl") %>' runat="server">
                                <img src="<%#Eval("AlbumCover")%>" class="card-img-top img-hoverable" alt="track-name" /></a>
                            <div class="card-body">
                                <p><%#Eval("TrackName")%></p>
                                <p class="" style="color: #F82B2B; font-weight: 600;">₱<%#Eval("Price")%></p>
                                <p class="by-artist float-right" style="color: #767676;"><%#Eval("ArtistName")%></p>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>

</asp:Content>
