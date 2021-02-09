<%@ Page Title="Tracks" Language="C#" MasterPageFile="~/Template/StoreLayoutWithSideNav.master" AutoEventWireup="true" CodeBehind="TracksPage.aspx.cs" Inherits="LokalMusic.Store.TracksPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .side-links  {
            color: #B82828;
            font-weight: 700;
            font-size:15px;
        } 

        thead tr td {
            font-size: 12px;
        }

        tbody tr td {
            font-size: 14px;
        }
    </style>

    <div class="container">

        <nav aria-label="breadcrumb" class="">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="~/Store/Home.aspx" runat="server">Home</a></li>
                <li class="breadcrumb-item active" aria-current="page">Tracks</li>
            </ol>
        </nav>

        <h1 class="mb-4">Lokal Tracks</h1>

        <div class="pt-3 pb-2 pl-3 pr-3 rounded" style="background-color: #faf9f9;">
            <div class="table-responsive shadow-sm rounded" style="background-color: #FFFFFF">
                <table class="table table-striped">
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
                                <tr class="text-center ">
                                    <td class="float-right">
                                        <a href=<%#Eval("DetailsUrl") %> runat="server">
                                            <img src="<%#Eval("AlbumCover")%>" width="30" height="30" class="mx-auto img-hoverable"/>
                                        </a>
                                    </td>   
                                    <td class="emphasize my-auto">
                                        <a href=<%#Eval("DetailsUrl") %> runat="server" class="titleLink">
                                            <%#Eval("TrackName") %>
                                        </a>
                                    </td>
                                    <td><%#Eval("AlbumName") %></td>
                                    <td class="my-auto"><%#Eval("ArtistName") %></td>
                                    <td><%#Eval("Genre") %></td>
                                    <td><%#Eval("AudioDuration", "{0:g}") %></td>
                                    <td class="emphasize">₱<%#Eval("Price", "{0:n}") %></td>
                                    <td class="">
                                        <button onclick='AddToCart(<%#Eval("TrackId")%>)' class="p-0" style="margin-top: -12px;">
                                            <%--<img src="../Content/Images/cart.png" class="" width="20" height="20" runat="server" />--%>
                                            <span class="bi bi-cart-plus cart" style="font-size: 22px;"></span>
                                        </button>
                                    </td>
                                </tr>
                                </a>
                            </ItemTemplate>
                        </asp:Repeater>

                    </tbody>
                </table>
            </div>
        </div>

        </div>


</asp:Content>
