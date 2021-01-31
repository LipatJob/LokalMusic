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

       .line{
           padding-top: .5px;
           padding-bottom: .5px;
           background-color: #dddddd;
       }

       #productNameContainer p, #productPriceContainer p{
           font-size: 17px;
           font-weight: 600;
       }

       #productPriceContainer p{
           color: #AA3A3A;
       }

       #grandTotal{
           font-weight: 700;
           color: #AA3A3A;
           font-size: 19px;
       }

       label{
           font-size: 13px;
           color: #8F8F8F;
           margin-bottom: -5px;
           font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
       }

       .form-control{
           margin-top: -5px;
           color: #3A3A3A;
           font-weight: 700;
       }
    </style>

    <div class="container">
        <h1 class="mb-5 mt-5">Music Cart</h1>

        <div class="row">

            <%--products--%>
            <div class="col-xl-8">

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
                                                onclick='<%# string.Format("CheckChanged(this, {0}, \"{1}\", {2}, \"{3}\");", Eval("TrackId"), Eval("TrackName"), Eval("Price"), "TRACK") %>' />
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
                                        onclick='<%# string.Format("CheckChanged(this, {0}, \"{1}\", {2}, \"{3}\");", Eval("AlbumId"), Eval("AlbumName"), Eval("Price"), "ALBUM") %>'/>
                                </div>

                                <%--image--%>
                                <div class="col-md-3 m-0 p-0">
                                    <a href=<%#Eval("DetailsUrl") %> class="titleLink" target="_blank" runat="server">
                                        <img src=<%#Eval("AlbumCoverAddress") %> class="mx-auto d-block img-responsive img-hoverable" width="150" height="150"/>
                                    </a>
                                </div>

                                <%--title and other description--%>
                                <div class="col-md-5 col-xl-5">
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
                                <div class="col-md-3 col-xl-3">
                                    <p class="text-right" style="color:#AA3A3A; font-size:25px; font-weight:600">₱<%#Eval("Price") %></p>
                                </div>

                            </div>
                        </div>

                    </ItemTemplate>
                </asp:Repeater>

            </div>

            <%--summary and checkout--%>
            <div class="col-xl-4">

                <%--summary of selected products--%>
                <div class="card shadow-sm mb-3 border-0" style="background-color: #F4F4F4;">
                    <div class="card-body">
                        <h5 class="card-title" style="color:#7a7a7a;">Checkout Summary</h5>
                        <div class="line"></div>

                        <div class="row mt-3">
                            <div class="col-md-6" id="productNameContainer">
                            </div>

                            <div class="col-md-6" id="productPriceContainer">
                            </div>
                        </div>

                        <div class="line"></div>
                        <div class="row mt-3">
                            <div class="col-md-6">
                                <h5 class="cart-title mb-0" style="color:#7a7a7a;">Grand Total</h5>
                            </div>

                            <div class="col-md-6">
                                <p id="grandTotal" class="mb-0">₱00.0</p>
                            </div>
                        </div>
                    </div>
                </div>

                <%--online payment information--%>
                <div class="card shadow-sm border-0" style="background-color: #F4F4F4;">
                    <div class="card-body ml-2 mr-2">
                        <h5 class="card-title" style="color:#7a7a7a;">Payment Information</h5>
                        <div class="line"></div>

                        <span id="errorPlaceHolder" class="text-danger" style="font-weight: 600;"></span>

                        <div class="form-row mt-3">
                            <div class="col-12">
                                <select class="form-control border-0 rounded pb-0">
                                    <option>MASTERCARD</option>
                                    <option>VISA</option>
                                </select>
                            </div>
                        </div>

                        <div class="form-row mt-3">
                            <div class="col-12">
                                <label for="cardHolderName" class="bg-white w-100 pl-2 rounded pb-0">CARDHOLDER'S NAME</label>
                                <input type="text" id="cardHolderName" class="form-control border-0 pt-0" placeholder="John Doe" required>
                            </div>
                        </div>

                        <div class="form-row mt-3">
                            <div class="col-12">
                                <label for="cardNumber" class="bg-white w-100 pl-2 rounded pb-0">CARD NUMBER</label>
                                <input type="text" id="cardNumber" class="form-control border-0 pt-0" placeholder="XXXXXXXXXXXXXXXX" required>
                            </div>
                        </div>

                        <div class="form-row mt-3 mb-2">
                            <div class="col-md-8">
                                <label for="expDate" class="bg-white w-100 pl-2 rounded pb-0">EXPIRATION DATE</label>
                                <input type="month" id="expDate" class="form-control border-0 pt-0" required>
                            </div>

                            <div class="col-md-4">
                                <label for="securityCode" class="bg-white w-100 pl-2 rounded pb-0">SEC CODE</label>
                                <input type="number" id="securityCode" min="100" max="999" class="form-control border-0 pt-0" required>
                            </div>
                        </div>
                    </div>
                </div>

                <button type="button" id="" class="btn btn-danger btn-block" onclick="PayNow()" style="background-color: #B82828; font-weight: 700;" >PAY NOW</button>
            </div>

        </div>

    </div>

    <script>

        /*data structure
         * {id# : [id, trackname, price, productType],
         *  id# : [id, albumname, price, productType]}
         */

        var forCheckout = {};

        function CheckChanged(source, productId, trackName, price, productType) {

            if (source.checked) {
                AddForCheckout(productId, trackName, price, productType);
            }
            else {
                RemoveFromCheckout(productId);
            }

            ClearSummary();
            RenderCheckoutSummary();
        }

        function AddForCheckout(productId, titleName, productPrice, productType) {
            forCheckout[productId] = [productId.toString(), titleName, productPrice.toString(), productType];
        }

        function RemoveFromCheckout(productId) {
            if (productId in forCheckout) {
                delete forCheckout[productId];
            }
        }

        function RenderCheckoutSummary() {
            var grandTotal = 0;

            for (var productId in forCheckout) {
                //create p childs
                var nameTag = document.createElement("p");
                var nameText = document.createTextNode(forCheckout[productId][1]);
                nameTag.appendChild(nameText);
                var priceTag = document.createElement("p");
                var priceText = document.createTextNode("₱"+forCheckout[productId][2]);
                priceTag.appendChild(priceText);

                // update product names
                var element = document.getElementById("productNameContainer");
                element.appendChild(nameTag);

                // update product price
                var element = document.getElementById("productPriceContainer");
                element.appendChild(priceTag);

                // compute grand total
                grandTotal += parseFloat(forCheckout[productId][2]);
            }

            // update grand total
            document.getElementById("grandTotal").innerHTML = "₱" + grandTotal;
        }

        function ClearSummary() {
            document.getElementById("productNameContainer").textContent = '';
            document.getElementById("productPriceContainer").textContent = '';
            document.getElementById("grandTotal").innerHTML = "₱00.0";
        }

        function ValidateFields() {

        }

        function PayNow() {
            var items = [];

            for (var productId in forCheckout) {
                items.push(forCheckout[productId]);
            }

            var providerName = "MASTER CARD";

            if (items.length > 0) {
                $.ajax({
                    type: "POST",
                    url: "/Cart/CartService.asmx/ProcessCheckout",
                    contentType: "application/json; charset=utf-8",
                    data: "{ 'forCheckout' : '" + JSON.stringify(items) + "', 'paymentProvider' : '" + providerName + "'}",
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
