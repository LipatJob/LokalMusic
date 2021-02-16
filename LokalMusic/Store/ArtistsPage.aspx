<%@ Page Title="Artists" Language="C#" MasterPageFile="~/Template/StoreLayoutWithSideNav.master" AutoEventWireup="true" CodeBehind="ArtistsPage.aspx.cs" Inherits="LokalMusic.Store.ArtistsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>

        .top-tracks a:hover{
            text-decoration: none;
        }

        .artist-name{
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            color: #B82828;
            font-weight: 600;
        }

        .top-tracks h5{
            color: #AA3A3A;
            font-weight: 600;
            font-size: 17px;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        }

        .track-title{
            font-size: 14px;
            color:#7A7A7A;
            font-weight: 600;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        }
    </style>

    <div class="container">

        <nav aria-label="breadcrumb" class="">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="~/Store/Home.aspx" runat="server">Home</a></li>
                <li class="breadcrumb-item active" aria-current="page">Artists</li>
            </ol>
        </nav>

        <h1 class="mb-4">Lokal Artists</h1>

        <div class="pt-3 pb-2 pl-3 pr-3 rounded" style="background-color: #F4F4F4;">

            <asp:Repeater ID="artistContainer" runat="server">
                <ItemTemplate>

                    <div class="card border-0 shadow-sm mb-3">
                        <div class="card-body">

                            <div class="row w-100">
                                <div class="col-xl-3">
                                    <a href=<%#Eval("DetailsUrl") %> runat="server">
                                        <img src=<%#Eval("ArtistProfileImage")%> alt="artist_cover" class="d-block mx-auto mb-xl-0 mb-sm-2 img-hoverable shadow-sm" width="200" height="200" runat="server"/>
                                    </a>
                                </div>

                                <div class="col-md-6">
                                    <a href=<%#Eval("DetailsUrl") %> class="titleLink" runat="server">
                                        <h4 class="artist-name titleLink"><%#Eval("ArtistName")%></h4>
                                    </a>

                                    <div class="pt-xl-5 mt-md-5 mb-0"></div>
                                    <div class="mt-xl-2 mt-md-3"></div>
                                    <div class="mb-0 mt-0 pt-0 pb-0">
                                        <p style="font-size:13px; color: #8F8F8F; margin-bottom: 0; font-weight:400;"><%#Eval("AlbumCount")%> album(s), <%#Eval("TrackTotalCount") %> track(s)</p>
                                        <p style="font-size:13px; color: #8F8F8F; margin-bottom: 0;  font-weight:500;">joined <%#Eval("DateJoined", "{0:MMMM dd, yyyy}") %></p>
                                        <p style="font-size:13px; color: #C4C4C4; margin-bottom: 0;font-weight:400;">Genre(s): <%#Eval("Genre")%></p>
                                    </div>
                                </div>

                                <div class="col-xl-3 col-md-6 text-right top-tracks mt-3 mt-md-0 <%# Eval("LatestTrack1") == null ? "invisible" : "" %>">
                                    <h5 class="">Latest Track(s)</h5>

                                    <div class="">
                                        <a onclick='<%# "GetTrack(" +Eval("LatestTrack1.TrackId") + " );" %>' class="img-hoverable">
                                            <div class="row mt-4">
                                                <div class="col-9 text-right my-auto">
                                                    <p class="my-auto track-title titleLink"><%#Eval("LatestTrack1.TrackName") %></p>
                                                </div>

                                                <div class="col-3 mx-auto">
                                                    <%--link--%>
                                                    <img src=<%#Eval("LatestTrack1.AlbumCover")%> width="45" height="45" class="mx-auto d-block img-hoverable shadow-sm" runat="server" alt="track1"/>
                                                </div>
                                            </div>
                                        </a>
                                    </div>

                                    <div class="<%# Eval("LatestTrack2") == null ? "invisible" : "" %>">
                                        <a onclick='<%# "GetTrack(" +Eval("LatestTrack2.TrackId") + " );" %>' class="img-hoverable">
                                            <div class="row mt-4">
                                                <div class="col-9 text-right my-auto">
                                                    <p class="my-auto track-title titleLink"><%#Eval("LatestTrack2.TrackName")%></p>
                                                </div>

                                                <div class="col-3 mx-auto">
                                                    <img src=<%#Eval("LatestTrack2.AlbumCover")%> width="45" height="45" class="mx-auto d-block img-hoverable shadow-sm" runat="server" alt="track2" />
                                                </div>
                                            </div>
                                        </a>
                                    </div>

                                </div>

                            </div>
                        </div>
                    </div>

                </ItemTemplate>
            </asp:Repeater>

        </div>

    </div>

</asp:Content>
