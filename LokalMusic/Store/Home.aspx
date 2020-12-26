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

        .view-all:hover{
            text-decoration: none;
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
        <div class="row">
            <h5 class="my-auto">Bestselling Albums</h5>
            <a href="Store/AlbumPage.apsx" class="text-danger ml-2 view-all my-auto">View All</a>
        </div> 
    </div>

    <div id="top-artists" class="container mt-4">
        <div class="row">
            <h5 class="my-auto">Top Artists</h5>
            <a href="Store/ArtistPage.aspx" class="text-danger ml-2 view-all my-auto">View All</a>
        </div> 
    </div>

</asp:Content>
