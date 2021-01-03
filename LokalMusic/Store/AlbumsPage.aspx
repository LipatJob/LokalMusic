﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Template/StoreLayoutWithSideNav.master" AutoEventWireup="true" CodeBehind="AlbumsPage.aspx.cs" Inherits="LokalMusic.Store.AlbumsPage" %>
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
        <h1 class="mb-4">Lokal Albums</h1>

        <div class="pt-4 pb-4 pl-3 pr-3" style="background-color: #F4F4F4;">

            <asp:Repeater ID="albumContainer" runat="server">
                <ItemTemplate>

                    <div class="card border-0 shadow-sm mb-4">
                        <div class="card-body">
                            <div class="row w-100">
                                <div class="col-xl-3">
                                    <a href="#">
                                        <img src=<%#Eval("AlbumCover")%> alt="album_cover" class="d-block mx-auto" width="200" height="200"/>
                                    </a>
                                </div>

                                <div class="col-md-6 col-md-6">
                                    <h4 class="album-title"><%#Eval("AlbumName")%></h4>
                                    <p style="font-size:14px; color: #5E5E5E; margin-top: -10px; font-weight:400;"><%#Eval("ArtistName")%></p>

                                    <div class="mt-5 mt-md-0 mt-sm-0 mt-0">
                                        <p style="font-size:13px; color: #8F8F8F; font-weight:400;"><%#Eval("TrackCount")%> tracks, <%#Eval("TrackMinutes") %> minutes</p>
                                        <p style="font-size:13px; color: #8F8F8F; margin-top: -15px; font-weight:500;">released <%#Eval("DateReleased")%></p>
                                        <p style="font-size:13px; color: #C4C4C4; margin-top: -15px; font-weight:400;">Genre(s): <%#Eval("Genre")%></p>
                                    </div>                            
                                </div>

                                <div class="col-md-3 col-xl-3 col-md-6">
                                    <div class="float-right">
                                        <h4 class="album-price"><%#Eval("Price")%></h4>
                                        <a href="" class="btn btn-danger float-right" style="background-color: #B82828; font-size: 12px; font-weight: 600">Add to Cart</a>
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
