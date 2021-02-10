<%@ Page Title="" Language="C#" MasterPageFile="~/Template/Site.Master" AutoEventWireup="true" CodeBehind="Playlist.aspx.cs" Inherits="LokalMusic.Playlist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        body{
            background-color: #bd4f6c;
            background-image: linear-gradient(326deg, #bd4f6c 0%, #d7816a 74%);
            background-repeat: no-repeat;
            background-attachment: fixed;
        }

        .partition{
            
        }

        #playlist-partition{
            
        }

        #menu-partition {
            background-color: #F4F4F4;
            height: 100vh;
            right: 0;
            position: fixed;
        }

        .bold-text{
            font-weight:700;
        }
        
        .bold-text span{
            font-size: 13px;
        }

        .album-name{
            color:#B82828;
            font-weight:600;
        }

        .artist-name{
            font-size: 15px;
            font-weight: 600;
            color:#3C3C3C;
        }

        ol li p{
            font-weight:600;
        }

        @media (min-width: 34em) {
            .card-columns {
                -webkit-column-count: 1;
                -moz-column-count:1;
                column-count:1;
            }
        }

        @media (min-width: 76em) {
            .card-columns {
                -webkit-column-count: 2;
                -moz-column-count:2;
                column-count:2;
            }
        }
    

    </style>

    <div class="">

        <div class="row">

        <div class="col-sm-8 col-9 partition" id="playlist-partition">

            <div class="card-columns mt-4 pr-sm-5 mr-sm-4 pr-0 mr-0">

                <div class="mt-3">
                    <div class="card ml-5 mr-5">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-sm-4">
                                    <img src="Content/Images/default_cover.jpg" class="w-100 mx-auto my-auto d-block shadow" alt="album-cover" runat="server" />
                                </div>

                                <div class="col-sm-8">
                                    <h3 class="album-name">Ya-anam</h3>
                                    <p class="artist-name">by Simply Almonds</p>

                                    <ol>
                                        <li>
                                            <p>Track Name</p>
                                            <audio controls src="https://lokalmusicfs.blob.core.windows.net/clips/5_clip3.mp3" class="w-100">
                                            </audio>
                                        </li>
                                        <li>
                                            <p>Track Name</p>
                                            <audio controls src="https://lokalmusicfs.blob.core.windows.net/clips/5_clip3.mp3" class="w-100">
                                            </audio>
                                        </li>
                                        <li>
                                            <p>Track Name</p>
                                            <audio controls src="https://lokalmusicfs.blob.core.windows.net/clips/5_clip3.mp3" class="w-100">
                                            </audio>
                                        </li>
                                        <li>
                                            <p>Track Name</p>
                                            <audio controls src="https://lokalmusicfs.blob.core.windows.net/clips/5_clip3.mp3" class="w-100">
                                            </audio>
                                        </li>
                                    </ol>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class=" mt-3">
                    <div class="card ml-5 mr-5">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-sm-4">
                                    <img src="Content/Images/default_cover.jpg" class="w-100 mx-auto my-auto d-block shadow" alt="album-cover" runat="server" />
                                </div>

                                <div class="col-sm-8">
                                    <h3 class="album-name">Lezned</h3>
                                    <p class="artist-name">by Simply Almonds</p>

                                    <ol>
                                        <li>
                                            <p>Track Name</p>
                                            <audio controls src="https://lokalmusicfs.blob.core.windows.net/clips/5_clip3.mp3" class="w-100">
                                            </audio>
                                        </li>
                                        <li>
                                            <p>Track Name</p>
                                            <audio controls src="https://lokalmusicfs.blob.core.windows.net/clips/5_clip3.mp3" class="w-100">
                                            </audio>
                                        </li>
                                    </ol>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="mt-3">
                    <div class="card ml-5 mr-5">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-sm-4">
                                    <img src="Content/Images/default_cover.jpg" class="w-100 mx-auto my-auto d-block shadow" alt="album-cover" runat="server" />
                                </div>

                                <div class="col-sm-8">
                                    <h3 class="album-name">Kups Manas</h3>
                                    <p class="artist-name">by Simply Denzel</p>

                                    <ol>
                                        <li>
                                            <p>Track Name</p>
                                            <audio controls src="https://lokalmusicfs.blob.core.windows.net/clips/5_clip3.mp3" class="w-100">
                                            </audio>
                                        </li>
                                    </ol>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="mt-3">
                    <div class="card ml-5 mr-5">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-sm-4">
                                    <img src="Content/Images/default_cover.jpg" class="w-100 mx-auto my-auto d-block shadow" alt="album-cover" runat="server" />
                                </div>

                                <div class="col-sm-8">
                                    <h3 class="album-name">Lezy Mana</h3>
                                    <p class="artist-name">by Denzel-the-Superman</p>

                                    <ol>
                                        <li>
                                            <p>Track Name</p>
                                            <audio controls src="https://lokalmusicfs.blob.core.windows.net/clips/5_clip3.mp3" class="w-100">
                                            </audio>
                                        </li>
                                        <li>
                                            <p>Track Name</p>
                                            <audio controls src="https://lokalmusicfs.blob.core.windows.net/clips/5_clip3.mp3" class="w-100">
                                            </audio>
                                        </li>
                                        <li>
                                            <p>Track Name</p>
                                            <audio controls src="https://lokalmusicfs.blob.core.windows.net/clips/5_clip3.mp3" class="w-100">
                                            </audio>
                                        </li>
                                    </ol>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class=" mt-3">
                    <div class="card ml-5 mr-5">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-sm-4">
                                    <img src="Content/Images/default_cover.jpg" class="w-100 mx-auto my-auto d-block shadow" alt="album-cover" runat="server" />
                                </div>

                                <div class="col-sm-8">
                                    <h3 class="album-name">DM</h3>
                                    <p class="artist-name">by DM Lang Sakalam</p>

                                    <ol>
                                        <li>
                                            <p>Track Name</p>
                                            <audio controls src="https://lokalmusicfs.blob.core.windows.net/clips/5_clip3.mp3" class="w-100">
                                            </audio>
                                        </li>
                                        <li>
                                            <p>Track Name</p>
                                            <audio controls src="https://lokalmusicfs.blob.core.windows.net/clips/5_clip3.mp3" class="w-100">
                                            </audio>
                                        </li>
                                        <li>
                                            <p>Track Name</p>
                                            <audio controls src="https://lokalmusicfs.blob.core.windows.net/clips/5_clip3.mp3" class="w-100">
                                            </audio>
                                        </li>
                                    </ol>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="mt-3">
                    <div class="card ml-5 mr-5">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-sm-4">
                                    <img src="Content/Images/default_cover.jpg" class="w-100 mx-auto my-auto d-block shadow" alt="album-cover" runat="server" />
                                </div>

                                <div class="col-sm-8">
                                    <h3 class="album-name">Ya-anam</h3>
                                    <p class="artist-name">by Simply Almonds</p>

                                    <ol>
                                        <li>
                                            <p>Track Name</p>
                                            <audio controls src="https://lokalmusicfs.blob.core.windows.net/clips/5_clip3.mp3" class="w-100">
                                            </audio>
                                        </li>
                                        <li>
                                            <p>Track Name</p>
                                            <audio controls src="https://lokalmusicfs.blob.core.windows.net/clips/5_clip3.mp3" class="w-100">
                                            </audio>
                                        </li>
                                        <li>
                                            <p>Track Name</p>
                                            <audio controls src="https://lokalmusicfs.blob.core.windows.net/clips/5_clip3.mp3" class="w-100">
                                            </audio>
                                        </li>
                                        <li>
                                            <p>Track Name</p>
                                            <audio controls src="https://lokalmusicfs.blob.core.windows.net/clips/5_clip3.mp3" class="w-100">
                                            </audio>
                                        </li>
                                    </ol>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>

        </div>

        <div class="col-sm-4 col-3 partition" id="menu-partition">
            <div id="content">
                <img src="Content/Images/lokal_logo_puzzle_O.png" alt="LOKAL-Logo" runat="server" class="w-75 mt-5 pt-5 mx-auto d-block" />

                <%--links--%>
                <div class="mx-auto text-center mt-5">
                    <a href="Store/Home" class="btn btn-outline-danger badge-pill bold-text pl-3 pr-3"><span>Home</span></a>
                    
                    <a href="#" class="btn btn-outline-info badge-pill bold-text pl-3 pr-3"><span>Collection</span></a>

                    <a href="#" class="btn btn-dark badge-pill bold-text pl-3 pr-3"><span>Signout</span></a>
                </div>
            </div>
        </div>

        </div>

    </div>

</asp:Content>

<%--<img src="Content/Images/lokal_logo_puzzle_O.png" alt="LOKAL-Logo" runat="server" class="w-50"/>

<%--links--%>
<%--<div class="mx-auto text-center mt-5">
    <a href="#" class="btn btn-outline-danger badge-pill bold-text">Return to Home</a>
                    
    <a href="#" class="btn btn-outline-info badge-pill bold-text">Go to Collection</a>

    <a href="#" class="btn btn-dark badge-pill bold-text">Signout</a>
</div>--%>