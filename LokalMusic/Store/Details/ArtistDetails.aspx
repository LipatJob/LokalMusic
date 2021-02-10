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
            color: #AA3A3A;
            font-weight: 600;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            font-size: 23px;
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

                            <div class="col-lg-5 col-sm-6 pb-4 ml-lg-4 mb-3">
                                <div class="card bg-white shadow border-0 rounded ml-sm-1 mr-sm-1 ml-5 mr-5 h-100">
                                    <div class="card-body" style="margin-bottom: -8px; padding:0;">
                                        <%--date released & genre(s)--%>
                                        <div class="row" style="margin-top: -8px;">


                                            <%--<div class="col-6 text-right">
                                            <p class="text-grey" style="font-size:14px; font-weight:600;"><i><%#Eval("Genres") %></i></p>
                                        </div>--%>
                                        </div>

                                        <%--album cover--%>
                                        <a href='<%#Eval("DetailsUrl") %>' runat="server">
                                            <img src='<%#Eval("AlbumCover") %>' class="mx-auto img-hoverable w-100" runat="server" style="margin: -5px;" />
                                        </a>

                                        <div class="mt-3 px-3">
                                            <a href='<%#Eval("DetailsUrl") %>' runat="server" class="titleLink">
                                                <span style="font-size: 17px;"><%#Eval("AlbumName") %></span>
                                            </a>

                                            <button class="float-right" style="padding: 0; margin: 0; margin-top: -8px; background: -webkit-linear-gradient(326deg, #bd4f6c 0%, #d7816a 74%); -webkit-background-clip: text; -webkit-text-fill-color: transparent;" onclick='AddToCart(<%#Eval("AlbumId")%>)'>
                                                <span class="bi bi-cart-plus-fill cart" style="font-size: 22px; margin: 0; padding: 0;"></span>
                                            </button>
                                            <div class="">
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
