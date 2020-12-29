<%@ Page Title="" Language="C#" MasterPageFile="~/Template/StoreLayout.master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="LokalMusic.Store.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        #featured-artist{
            background-color: #FFDCDC;
        }

        h1, p{
            font-family: Montserrat;
        }

        #featured-artist p {
            font-weight:400;
        }

        .view-all{
            font-weight:500;
            font-size:11px;

            border:solid;
            border-width: 1px;
            border-color: red;

            padding: 0px 3px 0px 3px;
        }

        .view-all:hover, #best-selling-albums a:hover{
            text-decoration: none;
        }

        .card-body{
            margin: -14px -18px 0 -18px;
        }

        .card-body p {
            color: black;
            font-size: 13px;
            font-weight: 500;
            margin: 0 0 0 0;
        }

        .by-artist{
            color:#808080;
        }

    </style>

    <div id="featured-artist" class="pt-5 pb-4">
        <div class="container">
            <div class="row">
                <div class="col-md-3">
                    <h1 class="text-center font-weight-bold">
                        Featured<br />Artists
                    </h1>
                    <p class="text-center">
                        Our Weekly Artist<br />Selection
                    </p>
                </div>

                <div class="col-md-3">
                    <a href="#" class="" target="_blank">
                        <img src="../Content/Images/testpicture1.jpg" class="w-100 h-100" alt="feature-artist-name"/>
                    </a>
                </div>

                <div class="col-md-3">
                    <a href="#" class="" target="_blank">
                        <img src="../Content/Images/testpicture2.png" class="w-100 h-100" alt="feature-artist-name"/>
                    </a>
                </div>

                <div class="col-md-3">
                    <a href="#" class="" target="_blank">
                        <img src="../Content/Images/testpicture3.jpg" class="w-100 h-100" alt="feature-artist-name"/>
                    </a>
                </div>
            </div>        
        </div>
    </div>

    <div id="best-selling-albums" class="container mt-4">
        <div class="row mb-4">
            <h5 class="my-auto">Bestselling Albums</h5>
            <a href="Store/AlbumPage.apsx" class="text-danger ml-2 view-all my-auto">View All</a>
        </div>

        <%--Albums--%>
        <div class="row">   
            
            <%foreach (var album in bestSellingAlbums)
            {%>
                <div class="col-md-2">
                    <a href="#" >
                        <div class="card border-0">
                            <img src="../Content/Images/default_cover.jpg" class="card-img-top" alt="album-name"/>
                            <div class="card-body">
                                <p><%Response.Write(album.AlbumName);%></p>
                                <p class="" style="color: #F82B2B; font-weight: 600;">₱<%Response.Write(album.Price);%></p>
                                <p class="by-artist float-right" style="color:#767676;"><%Response.Write(album.ArtistName);%></p>
                            </div>
                        </div>
                    </a>                    
                </div>
            <%}%>
        </div>

    </div>

    <div id="top-artists" class="container mt-4">
        <div class="row">
            <h5 class="my-auto">Top Artists</h5>
            <a href="Store/ArtistPage.aspx" class="text-danger ml-2 view-all my-auto">View All</a>
        </div> 
    </div>

</asp:Content>
