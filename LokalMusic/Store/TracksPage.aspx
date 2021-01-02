﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Template/StoreLayoutWithSideNav.master" AutoEventWireup="true" CodeBehind="TracksPage.aspx.cs" Inherits="LokalMusic.Store.TracksPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .side-links  {
            color: #B82828;
            font-weight: 700;
            font-size:15px;
        } 

        thead tr td {
            font-size: 13px;
        }
    </style>

    <div class="container">
        <h1 class="mb-4">Lokal Tracks</h1>

        <div class="pt-4 pb-4 pl-3 pr-3" style="background-color: #F4F4F4;">
            <div class="table-responsive shadow-sm rounded" style="background-color: #FFFFFF">
                <table class="table table-hover">
                    <thead>
                        <tr class="text-center font-weight-bold">
                            <td></td>
                            <td >Track Name</td>
                            <td>Album</td>
                            <td>Artist</td>
                            <td>Genre </td>
                            <td>Track Duration</td>
                            <td>Price</td>
                            <td>Add to Cart</td>
                        </tr>
                    </thead>
                
                    <tbody>
                        <asp:Repeater ID="trackContainer" runat="server">
                            <ItemTemplate>
                                <tr class="text-center">
                                    <td class="float-right">
                                        <img src="../Content/Images/default_cover.jpg" width="30" height="30" class="mx-auto" runat="server"/>
                                    </td>   
                                    <td class="emphasize"><%#Eval("TrackName") %></td>
                                    <td><%#Eval("AlbumName") %></td>
                                    <td><%#Eval("ArtistName") %></td>
                                    <td><%#Eval("Genre") %></td>
                                    <td><%#Eval("TrackDuration") %></td>
                                    <td class="emphasize">₱<%#Eval("Price") %></td>
                                    <td>
                                        <a href="#">
                                            <img src="../Content/Images/cart.png" class="" width="20" height="20" runat="server"/>
                                        </a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>

        </div>


</asp:Content>
