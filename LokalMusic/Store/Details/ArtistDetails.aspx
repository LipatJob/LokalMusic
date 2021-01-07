﻿<%@ Page Title="Lokal Artist" Language="C#" MasterPageFile="~/Template/StoreLayout.master" AutoEventWireup="true" CodeBehind="ArtistDetails.aspx.cs" Inherits="LokalMusic.Store.Details.ArtistDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        #img-bottom p {
            color: #969696;
            font-size: 13px;
        }

        #artist-img img{
            min-width: 200px;
            min-height: 10px;
        }

        #artist-name{
            color: #B82828;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            font-weight:600;
            font-size: 25px;
        }

        #price{
            color: #AA3A3A;
            font-weight: 600;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;

            font-size: 23px;
        }

         #location{
            font-size:16px;
            color: #3C3C3C;
            font-weight: 600;
        }

        #location{
            margin-top: -8px;
        }
        

        #bio p {
            line-height: 30px;
        }

        #date-released{
            color: #757575;
            font-weight: 600;
            font-size: 13px;
        }
    </style>

    <div class="container">
        <h1 class="mb-5  mt-5">Lokal Artist</h1>

        <div class="row">

            <%--Image--%>
            <div class="col-md-3">

                <div class="w-100" id="artist-img">
                    <img src="~/Content/Images/default_artist_image.JPG" runat="server" class="mx-auto d-block shadow rounded border w-100"/>
                </div>

                <div class="mt-3"  id="img-bottom">
                    <div class="row mx-auto d-block">
                        <p class="">2 albums, 20 tracks</p>
                    </div>
                    <div class="row mx-auto d-block" style="margin-top: -10px;">
                        <p class="">genre(s): Pop</p>
                    </div>
                </div>
            </div>


            <%--Bio--%>
            <div class="col-md-9 w-100">

                <div class="row w-100 ml-2">
                    <h3 id="artist-name" class="">Tim Cook</h3>
                </div>

                <div class="row ml-2">
                    <p id="location">
                        Cebu, Philippines
                    </p>
                </div>

                <div class="row ml-2 mt-2" id="bio">
                    <p>
                        Sed vel efficitur diam, ac congue nibh. Donec tincidunt vulputate orci at euismod. Donec sit amet porta est. Nam rhoncus dui massa, vel vulputate neque molestie id. In hac habitasse.
                    </p>
                </div>


                <div class="row ml-2 mt-sm-3">
                    <p id="date-released">joined January 2, 2021</p>
                </div>
            </div>

        </div>

        <%--list of albums --%>

        <h5 class="mt-4" style="color:#7A7A7A; font-size: 16px; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;">Artist's Albums</h5>

        <div class="p-3 mt-4" style="background-color: #F4F4F4;">
            <div class="table-responsive shadow-sm rounded" style="background-color: #FFFFFF">
                <table class="table table-hover">
                    <thead>
                        <tr class="text-center font-weight-bold">
                            <td></td>
                            <td >Track Name</td>
                            <td>Genres</td>
                            <td>Price</td>
                            <td>Add to Cart</td>
                        </tr>
                    </thead>
                
                    <tbody>
                        <tr class="text-center h-100 my-auto">
                            <td class="">
                                <img src="~/Content/Images/default_cover.jpg" width="35" height="35" class="mx-auto" runat="server" style="margin: -5px;"/>
                            </td> 
                            <td class="emphasize">Track Name</td>
                            <td>Genre</td>
                            <td class="emphasize">₱</td>
                            <td>
                                <a href="#"> <%-- GetUrl --%>
                                    <img src="../../Content/Images/cart.png" class="" width="20" height="20" runat="server"/>
                                </a>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>

    </div>

</asp:Content>
