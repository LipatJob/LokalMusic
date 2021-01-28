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
    </style>

    <div class="container">
        <h1 class="mb-5  mt-5">Music Cart</h1>

        <div class="row">

            <%--products--%>
            <div class="col-xl-9">

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
                                    <img src=<%#Eval("AlbumCoverAddress") %> class="mx-auto d-block img-responsive" width="200" height="200"/>
                                </div>

                                <%--title and other description--%>
                                <div class="col-md-6">
                                    <h6 class="" style="font-size:16px; color: #C4C4C4">Album</h6>
                                    <h4 class="card-title" style="color:#AA3A3A; font-size:28px;"><%#Eval("AlbumName") %></h4>
                                    <h6 class="pb-xl-3 pb-md-3" style="font-size:16px; color: #5E5E5E">By <%#Eval("ArtistName") %></h6>

                                    <div class="mt-xl-5 pt-xl-4 mt-md-5 pt-md-4 mt-sm-0 pt-sm-0">
                                        <p class="mb-0" style="color:#8F8F8F; font-size: 15px;"><%#Eval("TrackCount") %> tracks, <%#Eval("TrackTotalMinutes") %> minutes.</p>
                                    </div>
                                </div>

                                <%--price--%>
                                <div class="col-md-2">
                                    <p class="text-right" style="color:#AA3A3A; font-size:29px; font-weight:600">₱<%#Eval("Price") %></p>
                                </div>

                            </div>
                        </div>

                    </ItemTemplate>
                </asp:Repeater>

                <%--individual tracks, 2 repeater, 2nd repeater data source is eval--%>
                <div class="card border-0 mb-5 shadow">

                    <div class="card-body">

                        <div class="ml-3">
                            <p style="font-size:20px; color:black; font-weight: 600;">Artist Name</p>
                            <p style="color:#C4C4C4; font-size:16px; font-weight: 600; margin-top:-17px;">Artist</p>
                        </div>
                        
                        <div class="row">
                            <%--checkbox--%>
                            <div class="col-md-1 mx-xl-auto my-xl-auto mx-md-auto my-md-auto mx-auto mb-4">
                                <input type="checkbox" id="" class="form-check-input mx-xl-auto my-xl-auto mx-md-auto my-md-auto mx-auto mb-4"/>
                            </div>

                            <%--image--%>
                            <div class="col-md-2 m-0 p-0">
                                <img src="../Content/Images/default_cover.jpg" class="mx-auto my-auto d-block img-responsive" width="100" height="100"/>
                            </div>

                            <%--title and other description--%>
                            <div class="col-md-7">
                                <h4 class="card-title" style="color:#AA3A3A; font-size:24;">Track title</h4>
                                <h6 class="" style="font-size:15px; color: #5E5E5E">Album Name</h6>

                                <div class="">
                                    <p class="mb-0" style="color:#8F8F8F; font-size: 16px;">2 minutes</p>
                                </div>
                            </div>

                            <%--price--%>
                            <div class="col-md-2">
                                <p class="text-right" style="color:#AA3A3A; font-size:26px; font-weight:600">₱600</p>
                            </div>
                        </div>  
                        <div style="" class="divider"></div>   

                        <div class="row">
                            <%--checkbox--%>
                            <div class="col-md-1 mx-xl-auto my-xl-auto mx-md-auto my-md-auto mx-auto mb-4">
                                <input type="checkbox" id="" class="form-check-input mx-xl-auto my-xl-auto mx-md-auto my-md-auto mx-auto mb-4"/>
                            </div>

                            <%--image--%>
                            <div class="col-md-2 m-0 p-0">
                                <img src="../Content/Images/default_cover.jpg" class="mx-auto my-auto d-block img-responsive" width="100" height="100"/>
                            </div>

                            <%--title and other description--%>
                            <div class="col-md-7">
                                <h4 class="card-title" style="color:#AA3A3A; font-size:24;">Track title</h4>
                                <h6 class="" style="font-size:15px; color: #5E5E5E">Album Name</h6>

                                <div class="">
                                    <p class="mb-0" style="color:#8F8F8F; font-size: 16px;">2 minutes</p>
                                </div>
                            </div>

                            <%--price--%>
                            <div class="col-md-2">
                                <p class="text-right" style="color:#AA3A3A; font-size:26px; font-weight:600">₱600</p>
                            </div>
                        </div>  
                        <div style="" class="divider"></div>   

                    </div>
                </div>

                <div class="card border-0 mb-5 shadow">

                    <div class="card-body">

                        <div class="ml-3">
                            <p style="font-size:20px; color:black; font-weight: 600;">Artist Name</p>
                            <p style="color:#C4C4C4; font-size:16px; font-weight: 600; margin-top:-17px;">Artist</p>
                        </div>
                        
                        <div class="row">
                            <%--checkbox--%>
                            <div class="col-md-1 mx-xl-auto my-xl-auto mx-md-auto my-md-auto mx-auto mb-4">
                                <input type="checkbox" id="" class="form-check-input mx-xl-auto my-xl-auto mx-md-auto my-md-auto mx-auto mb-4"/>
                            </div>

                            <%--image--%>
                            <div class="col-md-2 m-0 p-0">
                                <img src="../Content/Images/default_cover.jpg" class="mx-auto my-auto d-block img-responsive" width="100" height="100"/>
                            </div>

                            <%--title and other description--%>
                            <div class="col-md-7">
                                <h4 class="card-title" style="color:#AA3A3A; font-size:24;">Track title</h4>
                                <h6 class="" style="font-size:15px; color: #5E5E5E">Album Name</h6>

                                <div class="">
                                    <p class="mb-0" style="color:#8F8F8F; font-size: 16px;">2 minutes</p>
                                </div>
                            </div>

                            <%--price--%>
                            <div class="col-md-2">
                                <p class="text-right" style="color:#AA3A3A; font-size:26px; font-weight:600">₱600</p>
                            </div>
                        </div>  
                        <div style="" class="divider"></div>   

                        <div class="row">
                            <%--checkbox--%>
                            <div class="col-md-1 mx-xl-auto my-xl-auto mx-md-auto my-md-auto mx-auto mb-4">
                                <input type="checkbox" id="" class="form-check-input mx-xl-auto my-xl-auto mx-md-auto my-md-auto mx-auto mb-4"/>
                            </div>

                            <%--image--%>
                            <div class="col-md-2 m-0 p-0">
                                <img src="../Content/Images/default_cover.jpg" class="mx-auto my-auto d-block img-responsive" width="100" height="100"/>
                            </div>

                            <%--title and other description--%>
                            <div class="col-md-7">
                                <h4 class="card-title" style="color:#AA3A3A; font-size:24;">Track title</h4>
                                <h6 class="" style="font-size:15px; color: #5E5E5E">Album Name</h6>

                                <div class="">
                                    <p class="mb-0" style="color:#8F8F8F; font-size: 16px;">2 minutes</p>
                                </div>
                            </div>

                            <%--price--%>
                            <div class="col-md-2">
                                <p class="text-right" style="color:#AA3A3A; font-size:26px; font-weight:600">₱600</p>
                            </div>
                        </div>  
                        <div style="" class="divider"></div>   

                    </div>
                </div>


            </div>

            <%--summary and checkout--%>
            <div class="col-xl-3">

            </div>

        </div>

    </div>


</asp:Content>
