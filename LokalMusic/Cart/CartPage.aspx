<%@ Page Title="Cart" Language="C#" MasterPageFile="~/Template/StoreLayout.master" AutoEventWireup="true" CodeBehind="CartPage.aspx.cs" Inherits="LokalMusic.Cart.CartPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <style>
       .form-check-input{
           transform: scale(1.5);
       }

       .divider{
           background-color:#AA3A3A; 
           padding:.1px; 
           margin:15px 0px 15px 50px;
       }

       h3{
           font-size: 18px;
           font-family: Montserrat;
           color:#AA3A3A;
           
       }
    </style>

    <div class="container">
        <h1 class="mb-5 mt-5">Music Cart</h1>

        <div class="row">

            <%--products--%>
            <div class="col-xl-9">

                <h3 class="mb-3">Individual Tracks per Artists</h3>

                <%--individual tracks r--%>
                <asp:Repeater ID="artistsContainer" runat="server">
                    <ItemTemplate>

                    <div class="card border-0 mb-3 shadow">

                        <div class="card-body">

                            <div class="ml-3">
                                <p style="font-size:20px; color:black; font-weight: 600;"><%#Eval("ArtistName") %></p>
                                <p style="color:#C4C4C4; font-size:16px; font-weight: 600; margin-top:-17px;">Artist</p>
                            </div>
                        

                            <%--artist's tracks r--%>
                            <asp:Repeater ID="artistTracksContainer" runat="server" DataSource=<%#Eval("tracks")%>>
                                <ItemTemplate>

                                    <div class="row">
                                        <%--checkbox--%>
                                        <div class="col-md-1 mx-xl-auto my-xl-auto mx-md-auto my-md-auto mx-auto mb-4">
                                            <input type="checkbox" id="" class="form-check-input mx-xl-auto my-xl-auto mx-md-auto my-md-auto mx-auto mb-4"/>
                                        </div>

                                        <%--image--%>
                                        <div class="col-md-2 m-0 p-0">
                                            <img src=<%#Eval("AlbumCover") %> class="mx-auto my-auto d-block img-responsive" width="100" height="100"/>
                                        </div>

                                        <%--title and other description--%>
                                        <div class="col-md-7">
                                            <h4 class="card-title" style="color:#AA3A3A; font-size:24px;"><%#Eval("TrackName") %></h4>
                                            <h6 class="" style="font-size:15px; color: #5E5E5E"><%#Eval("AlbumName") %></h6>

                                            <div class="">
                                                <p class="mb-0" style="color:#8F8F8F; font-size: 16px;"><%#Eval("AudioLength") %> minutes</p>
                                            </div>
                                        </div>

                                        <%--price--%>
                                        <div class="col-md-2">
                                            <p class="text-right" style="color:#AA3A3A; font-size:26px; font-weight:600">₱<%#Eval("Price") %></p>
                                        </div>
                                    </div>  
                                    <div style="" class="divider"></div> 

                                </ItemTemplate>
                            </asp:Repeater>

                        </div>
                    </div>

                    </ItemTemplate>
                </asp:Repeater>

                <h3 class="mb-3 mt-5">Albums</h3>

                <%--individual album--%>
                <asp:Repeater ID="albumContainer" runat="server">
                    <ItemTemplate>

                        <div class="card border-0 mb-3 shadow">
                            <div class="card-body row">

                                <%--checkbox--%>
                                <div class="col-md-1 mx-xl-auto my-xl-auto mx-md-auto my-md-auto mx-auto mb-4">
                                    <input type="checkbox" id="" class="form-check-input mx-xl-auto my-xl-auto mx-md-auto my-md-auto mx-auto mb-4"/>
                                </div>

                                <%--image--%>
                                <div class="col-md-3 m-0 p-0">
                                    <img src=<%#Eval("AlbumCoverAddress") %> class="mx-auto d-block img-responsive" width="150" height="150"/>
                                </div>

                                <%--title and other description--%>
                                <div class="col-md-5 col-xl-6">
                                    <h6 class="" style="font-size:16px; color: #C4C4C4">Album</h6>
                                    <h4 class="card-title" style="color:#AA3A3A; font-size:28px;"><%#Eval("AlbumName") %></h4>
                                    <h6 class="" style="font-size:16px; color: #5E5E5E">By <%#Eval("ArtistName") %></h6>

                                    <div class="mt-xl-4 pt-xl-2 mt-md-4 pt-md-2 mt-sm-0 pt-sm-0">
                                        <p class="mb-0" style="color:#8F8F8F; font-size: 15px;"><%#Eval("TrackCount") %> tracks, <%#Eval("TrackTotalMinutes") %> minutes.</p>
                                    </div>
                                </div>

                                <%--price--%>
                                <div class="col-md-3 col-xl-2">
                                    <p class="text-right" style="color:#AA3A3A; font-size:29px; font-weight:600">₱<%#Eval("Price") %></p>
                                </div>

                            </div>
                        </div>

                    </ItemTemplate>
                </asp:Repeater>

            </div>

            <%--summary and checkout--%>
            <div class="col-xl-3">

            </div>

        </div>

    </div>


</asp:Content>
