<%@ Page Title="Albums" Language="C#" MasterPageFile="~/Template/StoreLayoutWithSideNav.master" AutoEventWireup="true" CodeBehind="AlbumsPage.aspx.cs" Inherits="LokalMusic.Store.AlbumsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <style>
        #albums-page {
            color: #B82828;
            font-weight: 700;
            font-size:15px;
        } 
        .album-title{
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            color: #B82828;
            font-weight: 600;
        }

        .album-price{
            color: #AA3A3A;
            font-weight: 600;
            font-size: 28px;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        }
    </style>

    <div class="container">

        <nav aria-label="breadcrumb" class="">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="~/Store/Home.aspx" runat="server">Home</a></li>
                <li class="breadcrumb-item active" aria-current="page">Albums</li>
            </ol>
        </nav>

        <h1 class="mb-4">Lokal Albums</h1>

        <div class="pt-3 pb-2 pl-3 pr-3" style="background-color: #F4F4F4;">

            <asp:Repeater ID="albumContainer" runat="server">
                <ItemTemplate>

                    <div class="card border-0 shadow-sm mb-3">
                        <div class="card-body">

                            <div class="row w-100">
                                <div class="col-xl-3">
                                    <a href=<%#Eval("DetailsUrl") %> runat="server">
                                        <img src=<%#Eval("AlbumCover")%> alt="album_cover" class="d-block mx-auto mb-xl-0 mb-sm-2 img-hoverable" width="200" height="200"/>
                                    </a>
                                </div>

                                <div class="col-md-6 col-md-6">
                                    <a href=<%#Eval("DetailsUrl") %> runat="server" class="titleLink"><h4 class="album-title titleLink"><%#Eval("AlbumName")%></h4></a>
                                    <p style="font-size:18px; color: #5E5E5E; margin-top: -5px; font-weight:500;"><%#Eval("ArtistName")%></p>
                                    
                                    <div class="pt-xl-3"></div>

                                    <div class="mt-xl-5 mt-md-3 mb-0">
                                        <p style="font-size:13px; color: #8F8F8F; font-weight:400;"><%#Eval("TrackCount")%> track(s), <%#Eval("TrackMinutes") %> minute(s)</p>
                                        <p style="font-size:13px; color: #8F8F8F; margin-top: -15px; font-weight:500;">released <%#Eval("DateReleased", "{0:MMMM dd, yyyy}") %></p>
                                        <p style="font-size:13px; color: #C4C4C4; margin-top: -15px; font-weight:400;">Genre(s): <%#Eval("Genre")%></p>
                                    </div>                            
                                </div>

                                <div class="col-md-3 col-xl-3 col-md-6 text-right">
                                    <h4 class="album-price">₱<%#Eval("Price")%></h4>
                                    
                                    <div class="mt-xl-4 pt-xl-5 mt-md-5">
                                        <a class="btn btn-danger mt-xl-5 mt-md-3" style="background-color: #B82828; font-size: 12px; font-weight: 600"  onclick='AddToCart(<%#Eval("AlbumId")%>)'>Add to Cart</a>     
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
