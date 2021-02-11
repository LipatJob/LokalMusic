<%@ Page Title="Lokal Artist" Language="C#" MasterPageFile="~/Template/StoreLayout.master" AutoEventWireup="true" CodeBehind="ArtistDetails.aspx.cs" Inherits="LokalMusic.Store.Details.ArtistDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        #artist-img img {
            min-width: 200px;
            min-height: 10px;
        }

        #artist-name {
            color: #B82828;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            font-weight: 600;
            font-size: 28px;
        }

        #price {
            font-weight: 600;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            font-size: 14px;
        }

        .text-grey {
            color: #757575;
        }

        .text-dark {
            color: #3C3C3C;
        }
    </style>

    <div class="container">

        <nav aria-label="breadcrumb" class="mt-4">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="~/Store/Home.aspx" runat="server">Home</a></li>
                <li class="breadcrumb-item"><a href="~/Store/ArtistPage.aspx" runat="server">Artists</a></li>
                <li class="breadcrumb-item active" aria-current="page">Details</li>
            </ol>
        </nav>

        <h1 class="mb-4 mt-4">Lokal Artist</h1>

        <div class="row">

            <%--Summary--%>
            <div class="col-lg-3 col-md-4 ml-sm-0 mr-sm-0 ml-5 mr-5 ">

                <asp:Repeater ID="artistContainer" runat="server">
                    <ItemTemplate>

                        <%--photo--%>
                        <div class="w-100" id="artist-img">
                            <img src='<%#Eval("ArtistImage") %>' runat="server" alt="artist's profile image" class="mx-auto d-block shadow rounded border w-100" />
                        </div>

                        <%--left aligned--%>
                        <div class="mt-4">
                            <h4 id="artist-name"><%#Eval("ArtistName")%></h4>

                            <p class="text-grey" style="font-weight: 600; font-size: 15px;">
                                <i><%#Eval("Location")%></i>
                            </p>

                            <p style="font-size: 14px; font-weight: 700; margin-top: -10px;" class="text-dark">
                                <%#Eval("Genres")%>
                            </p>
                            <p style="font-size: 14px; font-weight: 600; margin-top: -7px;">joined <%#Eval("DateJoined", "{0:MMMM dd, yyyy}")%></p>

                        </div>

                        <%--right aligned--%>
                        <div class="mt-5">
                            <p style="font-weight: 600; color: black; margin-top: -10px;"><%#Eval("Bio")%></p>
                        </div>

                        <%--<div class="mt-3"  id="img-bottom">
                            <div class="row">
                                <div class="col-6">
                                    <p class=""><%#Eval("AlbumCount")%> album(s), <%#Eval("TrackCount")%> track(s)</p>
                                </div>

                                <div class="col-6">
                                    <p class="text-right">genre(s): <%#Eval("Genres")%></p>
                                </div>
                            </div>
                        </div>--%>
                    </ItemTemplate>
                </asp:Repeater>

            </div>

            <%--artists--%>
            <div class="col-lg-9 col-md-8">
                <div class="row">
                    <asp:Repeater ID="albumsContainer" runat="server">
                        <ItemTemplate>

                            <div class="col-lg-4 col-sm-6 pb-4">
                                <div class="card bg-white shadow border-0 rounded ml-sm-1 mr-sm-1 ml-5 mr-5 h-100">
                                    <%--album cover--%>
                                    <a href='<%#Eval("DetailsUrl") %>' runat="server">
                                        <img src='<%#Eval("AlbumCover") %>' class="mx-auto card-image w-100" runat="server"/>
                                    </a>

                                    <div class="card-img-overlay text-right">
                                        <button type="button" class="btn btn-light btn-sm shadow-lg my-auto" style="font-size: 12px; font-weight: 600" onclick='AddToCart(<%#Eval("AlbumId")%>)'>
                                            <span id="price" class="mr-1">₱<%#Eval("Price", "{0:n}") %></span>
                                            <img src="~/Content/Images/cart.png" runat="server" width="18"/>
                                        </button>
                                    </div>

                                    <div class="card-body pl-3 pr-3 pb-0 pt-0">
                                        <div class="row mt-2">
                                            <div class="col-12">
                                                <a href='<%#Eval("DetailsUrl") %>' runat="server" class="titleLink">
                                                    <span style="font-size: 17px;"><%#Eval("AlbumName") %></span>
                                                </a>

                                                <p class="text-dark" style="font-size: 14px; font-weight: 600;"><i><%#Eval("ReleaseDate", "{0:MMM-dd-yy}") %></i></p>
                                            </div>

                                        </div>
                                    </div>

                                </div>
                            </div>

                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>

        </div>

    </div>

</asp:Content>
