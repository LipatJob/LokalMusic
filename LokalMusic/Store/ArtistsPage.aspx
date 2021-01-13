<%@ Page Title="Artists" Language="C#" MasterPageFile="~/Template/StoreLayoutWithSideNav.master" AutoEventWireup="true" CodeBehind="ArtistsPage.aspx.cs" Inherits="LokalMusic.Store.ArtistsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .creatorProfileLink:hover{
            text-decoration: none;
            font-weight: 600;
            color: #B82828;
        }

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
        <h1 class="mb-4">Lokal Artists</h1>

        <div class="pt-3 pb-2 pl-3 pr-3" style="background-color: #F4F4F4;">

            <asp:Repeater ID="artistContainer" runat="server">
                <ItemTemplate>

                    <div class="card border-0 shadow-sm mb-3">
                        <div class="card-body">

                            <div class="row w-100">
                                <div class="col-xl-3">
                                    <a href=<%#Eval("DetailsUrl") %> runat="server">
                                        <img src=<%#Eval("ArtistProfileImage")%> alt="artist_cover" class="d-block mx-auto mb-xl-0 mb-sm-2" width="200" height="200" runat="server"/>
                                    </a>
                                </div>

                                <div class="col-md-6 col-md-6">
                                    <h4 class="artist-name" style="color:#B82828;"><%#Eval("ArtistName")%></h4>
                                    
                                    <div class="pt-xl-3"></div>

                                    <div class="mt-xl-5 mt-md-3 mb-0">
                                        <p style="font-size:13px; color: #8F8F8F; font-weight:400;"><%#Eval("AlbumCount")%> album(s), <%#Eval("TrackTotalCount") %> track(s)</p>
                                        <p style="font-size:13px; color: #8F8F8F; margin-top: -15px; font-weight:500;">joined <%#Eval("DateJoined", "{0:MMMM dd, yyyy}") %></p>
                                        <p style="font-size:13px; color: #CF2A2A; margin-top: -15px; font-weight:500;">
                                            <a href=<%#Eval("DetailsUrl") %> runat="server" class="creatorProfileLink" style="color: #CF2A2A;">https://lokal.azurewebsites.net/Store/<%#Eval("ArtistName") %></a>
                                        </p>                                        
                                        <p style="font-size:13px; color: #C4C4C4; margin-top: -15px; font-weight:400;">Genre(s): <%#Eval("Genre")%></p>
                                    </div>                            
                                </div>
                                    
                                <div class="col-md-3 col-xl-3 col-md-6 text-right top-tracks <%# Eval("TrackTop1") == null ? "invisible" : "" %>">
                                    <h5 class="">Top Tracks</h5>

                                    <div class="">
                                        <a href=<%#Eval("TrackTop1.DetailsUrl") %> runat="server">
                                            <div class="row mt-4">
                                                <div class="col-9 text-right my-auto">
                                                    <p class="my-auto track-title"><%#Eval("TrackTop1.TrackName") %></p>
                                                </div>

                                                <div class="col-3 mx-auto">
                                                    <%--link--%>
                                                    <img src=<%#Eval("TrackTop1.AlbumCover")%> width="45" height="45" class="mx-auto d-block" runat="server" alt="track1"/>
                                                </div>
                                            </div>
                                        </a>                                        
                                    </div>

                                    <div class="<%# Eval("TrackTop2") == null ? "invisible" : "" %>">
                                        <a href=<%#Eval("TrackTop2.DetailsUrl") %> runat="server">
                                            <div class="row mt-4">
                                                <div class="col-9 text-right my-auto">
                                                    <p class="my-auto track-title"><%#Eval("TrackTop2.TrackName")%></p>
                                                </div>

                                                <div class="col-3 mx-auto">
                                                    <img src=<%#Eval("TrackTop2.AlbumCover")%> width="45" height="45" class="mx-auto d-block" runat="server" alt="track2" />
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
