<%@ Page Title="Lokal Album" Language="C#" MasterPageFile="~/Template/StoreLayout.master" AutoEventWireup="true" CodeBehind="AlbumDetails.aspx.cs" Inherits="LokalMusic.Store.Details.AlbumDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        #img-bottom p {
            color: #969696;
            font-size: 13px;
        }

        #album-img img{
            min-width: 200px;
            min-height: 10px;
        }

        #album-name{
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

         #artist-name{
            font-size:16px;
            color: #3C3C3C;
            font-weight: 600;
        }

        #artist-name{
            margin-top: -15px;
        }
        
        .sub{
            color:#757575;
            font-size: 14px;
        }

        .redirect-link{
            color: #3C3C3C;
            font-weight: 600;
        }

        .redirect-link:hover{
            color:#A42E2E;
            text-decoration: none;
        }

        #album-description p {
            line-height: 30px;
        }

        #date-released{
            color: #757575;
            font-weight: 600;
            font-size: 13px;
        }
    </style>

    <div class="container">

        <nav aria-label="breadcrumb" class="mt-4">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="~/Store/Home.aspx" runat="server">Home</a></li>
                <li class="breadcrumb-item"><a href="~/Store/AlbumsPage.aspx" runat="server">Albums</a></li>
                <li class="breadcrumb-item active" aria-current="page">Details</li>
            </ol>
        </nav>

        <h1 class="mb-4 mt-4">Lokal Album</h1>

        <div class="row">

            <asp:Repeater ID="albumContainer" runat="server">
                <ItemTemplate>

                    <%--Image--%>
                    <div class="col-lg-3 col-md-5">

                        <div class="w-100" id="album-img">
                            <img src=<%#Eval("AlbumCover") %> class="mx-auto d-block shadow rounded border w-100"/>
                        </div>

                        <div class="mt-3"  id="img-bottom">
                            <div class="row">
                                <div class="col-6">
                                    <p class=""><%#Eval("TrackCount") %> tracks, <%#Eval("MinuteCount") %> minutes</p>
                                </div>

                                <div class="col-6">
                                    <p class="text-right">genre(s): <%#Eval("Genres") %></p>
                                </div>
                            </div>
                        </div>
                    </div>


                    <%--Description--%>
                    <div class="col-lg-9 col-md-5 w-100">

                        <div class="row w-100 ml-2">
                            <h3 id="album-name" class=""><%#Eval("AlbumName") %></h3>
                            <p id="price" class="ml-auto">₱<%#Eval("Price", "{0:n}") %></p> 
                        </div>

                
                        <div class="row ml-2">
                            <p id="artist-name">
                                <span class="sub">by</span> 
                                <a href=<%#Eval("AlbumArtistUrl") %> runat="server" class="redirect-link"><%#Eval("ArtistName") %></a><%--GetURL--%>
                            </p>
                        </div>

                        <div class="row ml-2 mt-2" id="album-description">
                            <p><%#Eval("Description") %></p>
                        </div>


                        <div class="row ml-2 mt-sm-3">
                            <div class="col-sm-6">
                                <p id="date-released">released <%#Eval("ReleaseDate", "{0:MMMM dd, yyyy}") %></p>
                            </div>

                            <div class="col-sm-6 w-100">
                                <%--GetURL--%>
                                <div class="text-right">
                                    <a href="" class="btn btn-danger" style="background-color: #B82828; font-size: 12px; font-weight: 600" onclick='AddToCart(<%#Eval("AlbumId")%>); return false;'>Add to Cart</a>     
                                </div>
                            </div>
                        </div>
                    </div>

                </ItemTemplate>
            </asp:Repeater>

        </div>

        <%--list of tracks--%>

        <h5 class="mt-4" style="color:#7A7A7A; font-size: 16px; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;">Album's Tracks</h5>

        <div class="p-3 mt-4" style="background-color: #F4F4F4;">
            <div class="table-responsive shadow-sm rounded" style="background-color: #FFFFFF">
                <table class="table table-striped">

                    <thead>
                        <tr class="text-center font-weight-bold">
                            <td >Track Name</td>
                            <td>Genre</td>
                            <td>Price</td>
                            <td>Add to Cart</td>
                        </tr>
                    </thead>
                
                    <tbody>
                        <asp:Repeater ID="tracksContainer" runat="server">
                            <ItemTemplate>

                                <tr class="text-center">
                                    <td class="emphasize">
                                        <a href=<%#Eval("DetailsUrl") %> runat="server" class="titleLink">
                                            <%#Eval("TrackName") %>
                                        </a>
                                    </td>
                                    <td><%#Eval("Genre") %></td>
                                    <td class="emphasize">₱<%#Eval("Price", "{0:n}") %></td>
                                    <td>
                                        <button onclick='AddToCart(<%#Eval("TrackId")%>); return false;'> <%-- GetUrl --%>
                                            <img src="../../Content/Images/cart.png" class="" width="20" height="20" runat="server"/>
                                        </button>
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
