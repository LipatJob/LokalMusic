<%@ Page Title="Lokal Track" Language="C#" MasterPageFile="~/Template/StoreLayout.master" AutoEventWireup="true" CodeBehind="TrackDetails.aspx.cs" Inherits="LokalMusic.Store.Details.TrackDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        #img-bottom p {
            color: #969696;
            font-size: 13px;
        }

        #track_img img{
            min-width: 200px;
            min-height: 10px;
        }

        #track-name{
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

        #album-name, #artist-name{
            font-size:16px;
            color: #3C3C3C;
            font-weight: 600;
        }

        #album-name{
            margin-top: -15px;
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

        #track-description p {
            line-height: 30px;
        }

        #date-released{
            color: #757575;
            font-weight: 600;
            font-size: 13px;
        }
    </style>

    <div class="container">
        <h1 class="mb-5  mt-5">Lokal Track</h1>

        <div class="row">

            <%--Image--%>
            <div class="col-md-3">

                <div class="w-100" id="track-img">
                    <img src="../../Content/Images/default_cover.jpg" runat="server" class="mx-auto d-block shadow rounded border w-100"/>
                </div>

                <div class="mt-3"  id="img-bottom">
                    <div class="row mx-auto d-block">
                        <p class="float-left">2:05 minutes</p>
                        <p class="float-right">genre(s): Pop</p>
                    </div>
                     
                    <%--Player--%>
                    <div class="row mx-auto d-block">
                        <audio controls src="https://lokalmusicfs.blob.core.windows.net/songs/wiimusic.mp3" class="w-100">
                        </audio>
                    </div>
                </div>
            </div>

            <%--Description--%>
            <div class="col-md-9 w-100">

                <div class="row w-100 ml-2">
                    <h3 id="track-name" class="">Lorem ipsum</h3>
                    <p id="price" class="ml-auto">₱350.00</p> <%--GetURL--%>
                </div>

                <div class="row ml-2">
                    <p id="album-name">
                        <span class="sub">album:</span> 
                        <a href="" class="redirect-link">Dolor sit amet</a> <%--GetURL--%>
                    </p>
                </div>
                
                <div class="row ml-2">
                    <p id="artist-name">
                        <span class="sub">by</span> 
                        <a href="" class="redirect-link">Tim Cook</a>
                    </p>
                </div>

                <div class="row ml-2 mt-2" id="track-description">
                    <p>
                        Proin mattis in nunc et placerat. Donec sagittis velit accumsan imperdiet ornare. Quisque ut lorem vel diam facilisis rutrum sed in arcu. Donec sit amet aliquam sapien. Nunc sit amet nisi interdum, aliquam turpis eu, rhoncus metus. Integer lacinia tortor id nulla volutpat eleifend. Aliquam erat volutpat. Nulla facilisi. Interdum et malesuada fames ac ante ipsum primis in faucibus. Donec varius imperdiet tempus. Phasellus commodo porttitor iaculis. Nunc hendrerit nulla ac porttitor sodales. Nunc vel dui in libero finibus maximus. Phasellus elementum consequat erat eu luctus.
                    </p>
                </div>


                <div class="row ml-2 mt-sm-3">
                    <div class="col-sm-6">
                        <p id="date-released">released January 2, 2021</p>
                    </div>

                    <div class="col-sm-6 w-100">
                        <%--GetURL--%>
                        <div class="text-right">
                            <a href="" class="btn btn-danger" style="background-color: #B82828; font-size: 12px; font-weight: 600">Add to Cart</a>     
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>

</asp:Content>
