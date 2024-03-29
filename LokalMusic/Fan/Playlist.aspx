﻿<%@ Page Title="Playlist" Language="C#" MasterPageFile="~/Template/Site.Master" AutoEventWireup="true" CodeBehind="Playlist.aspx.cs" Inherits="LokalMusic.Playlist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>

        /* The side navigation menu */
        .sidebar {
          margin: 0;
          padding: 0;
          width: 400px;
          background-color: #f1f1f1;
          position: fixed;
          height: 100%;
          overflow: auto;
        }

        /* Sidebar links */
        /*.sidebar a {
          display: block;
          color: black;
          padding: 16px;
          text-decoration: none;
        }*/

        /* Page content. The value of the margin-left property should match the value of the sidebar's width property */
        div.content {
          margin-left: 400px;
          padding: 1px 16px;
          height: 1000px;
        }

        /* On screens that are less than 700px wide, make the sidebar into a topbar */
        @media screen and (max-width: 800px) {
          .sidebar {
            width: 100%;
            height: auto;
            position: relative;
          }
          .sidebar {float: left;}
          div.content {margin-left: 0;}
        }

        /* On screens that are less than 400px, display the bar vertically, instead of horizontally */
        @media screen and (max-width: 400px) {
          .sidebar {
            text-align: center;
            float: none;
          }
        }

        body, .card{
            background-color: #bd4f6c;
            background-image: linear-gradient(326deg, #bd4f6c 0%, #d7816a 74%);
            background-repeat: no-repeat;
            background-attachment: fixed;
        }

        .bold-text{
            font-weight:700;
        }
        
        .bold-text span{
            font-size: 13px;
        }

        .album-name{
            color:white/*#B82828*/;
            font-weight:600;
        }

        .artist-name{
            font-size: 15px;
            font-weight: 700;
            color:#3C3C3C;
        }

        .track-name{
            color:#ffd8d8;
            font-weight: 600;
            font-size:20px;
            margin-bottom:7px;
        }


        @media (min-width: 0px) {
            .card-columns {
                column-count: 1;
            }
        }

        @media (min-width: 1600px) {
            .card-columns {
                column-count: 2;
            }
        }

    </style>

    <div>

        <!-- The sidebar -->
        <div class="sidebar">
            
            <div class="mt-md-5 pt-md-5 mt-3"></div>

            <img src="~/Content/Images/lokal_logo_puzzle_O.png" alt="LOKAL-Logo" runat="server" class="mx-auto d-block w-50"/>

            <div class="mx-auto text-center mt-md-5 mt-3 mb-3">
                <a href="~/Store/Home.aspx" class="btn btn-outline-danger badge-pill bold-text" runat="server"><span>Return</span></a>
                    
                <a class="btn btn-outline-info badge-pill bold-text" runat="server" id="collectionLink"><span>Collection</span></a>

                <a href="~/Account/Signout" class="btn btn-dark badge-pill bold-text" runat="server"><span>Signout</span></a>
            </div>

        </div>

        <!-- Page content -->
        <div class="content">
            <div class="row">

                <%--<div class="col-1"></div>--%>

                <%--Repeater: 1st part--%>
                <div class="col-xl-5 col-lg-12">

                    <asp:Repeater ID="partition1AlbumContainer" runat="server">
                        <ItemTemplate>

                            <div class="card shadow-lg mt-3">
                                <div class="card-body">

                                    <%--image and information--%>
                                    <div class="row mb-4">
                                        <div class="col-5">
                                            <img src=<%#Eval("AlbumCover") %> class="mx-auto my-auto d-block shadow w-100" alt="album-cover"/>
                                        </div>

                                        <div class="col-7">
                                            <h3 class="album-name mt-sm-4 mt-md-0"><%#Eval("AlbumName") %></h3>
                                            <p class="artist-name"><span>by</span> <%#Eval("ArtistName") %></p>
                                        </div>
                                    </div>

                                    <div>

                                        <asp:Repeater runat="server" DataSource=<%#Eval("tracks") %>>
                                            <ItemTemplate>

                                                <div class="text-center">
                                                    <p class="track-name"><%#Eval("TrackName") %></p>
                                                    <audio controls src=<%#Eval("TrackAudio") %> class="w-100">
                                                    </audio>
                                                </div>

                                            </ItemTemplate>
                                        </asp:Repeater>

                                    </div>

                                </div>
                            </div>

                        </ItemTemplate>
                    </asp:Repeater>
                    
                </div>

                <div class="col-lg-1 col-0"></div>

                <%--Repeater: 2nd part--%>
                <div class="col-xl-5 col-lg-12">
                    
                    <asp:Repeater ID="partition2AlbumContainer" runat="server">
                        <ItemTemplate>

                            <div class="card shadow-lg mt-3">
                                <div class="card-body">

                                    <%--image and information--%>
                                    <div class="row mb-4">
                                        <div class="col-5">
                                            <img src=<%#Eval("AlbumCover") %> class="mx-auto my-auto d-block shadow w-100" alt="album-cover"/>
                                        </div>

                                        <div class="col-7">
                                            <h3 class="album-name mt-sm-4 mt-md-0"><%#Eval("AlbumName") %></h3>
                                            <p class="artist-name"><span>by</span> <%#Eval("ArtistName") %></p>
                                        </div>
                                    </div>

                                    <div>

                                        <asp:Repeater runat="server" DataSource=<%#Eval("tracks") %>>
                                            <ItemTemplate>

                                                <div class="text-center">
                                                    <p class="track-name"><%#Eval("TrackName") %></p>
                                                    <audio controls src=<%#Eval("TrackAudio") %> class="w-100">
                                                    </audio>
                                                </div>

                                            </ItemTemplate>
                                        </asp:Repeater>

                                    </div>

                                </div>
                            </div>

                        </ItemTemplate>
                    </asp:Repeater>

                </div>

                <%--<div class="col-1"></div>--%>

            </div>
        </div>

    </div>

    <script>
        document.addEventListener('play', function (e) {
            var audios = document.getElementsByTagName('audio');
            for (var i = 0, len = audios.length; i < len; i++) {
                if (audios[i] != e.target) {
                    audios[i].pause();
                }
            }
        }, true);
    </script>

</asp:Content>
