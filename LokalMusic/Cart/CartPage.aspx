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
                                <a href=<%#Eval("DetailsUrl") %> class="titleLink" target="_blank" runat="server">
                                    <p style="font-size:20px; color:black; font-weight: 600;"><%#Eval("ArtistName") %></p>
                                </a>
                                <p style="color:#C4C4C4; font-size:16px; font-weight: 600; margin-top:-17px;">Artist</p>
                            </div>
                        

                            <%--artist's tracks r--%>
                            <asp:Repeater ID="artistTracksContainer" runat="server" DataSource=<%#Eval("tracks")%>>
                                <ItemTemplate>

                                    <div class="row">
                                        <%--checkbox--%>
                                        <div class="col-md-1 mx-xl-auto my-xl-auto mx-md-auto my-md-auto mx-auto mb-4">
                                            <input type="checkbox"
                                                id='<%#Eval("TrackId") %>'
                                                class="form-check-input mx-xl-auto my-xl-auto mx-md-auto my-md-auto mx-auto mb-4"
                                                onclick='<%# string.Format("CheckChanged(this, {0}, \"{1}\", {2});", Eval("TrackId"), Eval("TrackName"), Eval("Price")) %>' />
                                        </div>

                                        <%--image--%>
                                        <div class="col-md-2 m-0 p-0">
                                            <a href=<%#Eval("DetailsUrl") %> class="titleLink" target="_blank" runat="server">
                                                <img src=<%#Eval("AlbumCover") %> class="mx-auto my-auto d-block img-responsive img-hoverable" width="100" height="100"/>
                                            </a>
                                        </div>

                                        <%--title and other description--%>
                                        <div class="col-md-7">
                                            <a href=<%#Eval("DetailsUrl") %> class="titleLink" target="_blank" runat="server">
                                                <h4 class="card-title" style="color:#AA3A3A; font-size:24px;"><%#Eval("TrackName") %></h4>
                                            </a>

                                            <a href=<%#Eval("TrackAlbumDetails") %> class="titleLink" target="_blank" runat="server">
                                                <h6 class="" style="font-size:15px; color: #5E5E5E"><%#Eval("AlbumName") %></h6>
                                            </a>

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
                                    <input type="checkbox" 
                                        id='<%#Eval("AlbumId") %>'
                                        class="form-check-input mx-xl-auto my-xl-auto mx-md-auto my-md-auto mx-auto mb-4"
                                        onclick='<%# string.Format("CheckChanged(this, {0}, \"{1}\", {2});", Eval("AlbumId"), Eval("AlbumName"), Eval("Price")) %>'/>
                                </div>

                                <%--image--%>
                                <div class="col-md-3 m-0 p-0">
                                    <a href=<%#Eval("DetailsUrl") %> class="titleLink" target="_blank" runat="server">
                                        <img src=<%#Eval("AlbumCoverAddress") %> class="mx-auto d-block img-responsive img-hoverable" width="150" height="150"/>
                                    </a>
                                </div>

                                <%--title and other description--%>
                                <div class="col-md-5 col-xl-6">
                                    <h6 class="" style="font-size:16px; color: #C4C4C4">Album</h6>

                                    <a href=<%#Eval("DetailsUrl") %> class="titleLink" target="_blank" runat="server">
                                        <h4 class="card-title" style="color:#AA3A3A; font-size:28px;"><%#Eval("AlbumName") %></h4>
                                    </a>

                                    <a href=<%#Eval("AlbumArtistUrl") %> class="titleLink" target="_blank" runat="server">
                                        <h6 class="" style="font-size:16px; color: #5E5E5E">By <%#Eval("ArtistName") %></h6>
                                    </a>

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
                <button type="button" id="" class="btn btn-danger btn-primary" onclick="RenderCheckoutSummary()" >PROCESS CHECKOUT</button>
                <button type="button" id="" class="btn btn-danger btn-block" onclick="PayNow()" >PAY NOW</button>
            </div>

        </div>

    </div>

    <script>

        // data structure
        /*
         * {
         *
         *   id# : [id, trackname, price],
         *   id# : [id, albumname, price]
         *
         * }
         * if (1 in selectedItems)
                alert("track name " + selectedItems[1][0] + " price " + selectedItems[1][1]);

            delete selectedItems[1] 
            if (1 in selectedItems)
                alert("track name " + selectedItems[1][0] + " price " + selectedItems[1][1]);
         *
         */

        var forCheckout = {};

        function CheckChanged(source, productId, trackName, price) {

            if (source.checked) {
                AddForCheckout(productId, trackName, price);
            }
            else {
                RemoveFromCheckout(productId);
            }
        }

        function AddForCheckout(productId, titleName, productPrice) {
            forCheckout[productId] = [productId.toString(), titleName, productPrice.toString()];
        }

        function RemoveFromCheckout(productId) {
            if (productId in forCheckout) {
                delete forCheckout[productId];
            }
        }

        function RenderCheckoutSummary() {
            //displays summary in div
            // PAY NOW button will not call this function

            for (var productId in forCheckout) {
                //console.log(typeof (productId));
                //console.log(typeof (forCheckout[productId]));
                //console.log(typeof (forCheckout[productId][0]));
                //console.log(typeof (forCheckout[productId][1]));
                //console.log(typeof (forCheckout[productId][2]));
                console.log("product Id " + productId + " values " + forCheckout[productId]);
            }
        }

        function ClearSummary() {

        }

        function PayNow() {
            var items = [];

            for (var productId in forCheckout) {
                items.push(forCheckout[productId]);
            }

            if (items.length > 0) {
                $.ajax({
                    type: "POST",
                    url: "/Cart/CartService.asmx/ProcessCheckout",
                    contentType: "application/json; charset=utf-8",
                    data: "{ 'forCheckout' : '" + JSON.stringify(items) + "'}",
                    dataType: "json",
                    success: function (message) {
                        alert(message.d);
                    },
                    error: function () {
                        alert("An Error has occured");
                    }
                });
                return false;
            }            
        }

    </script>

</asp:Content>
