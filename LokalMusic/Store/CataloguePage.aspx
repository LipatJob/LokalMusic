<%@ Page Title="Product Catalogue" Language="C#" MasterPageFile="~/Template/StoreLayout.master" AutoEventWireup="true" CodeBehind="CataloguePage.aspx.cs" Inherits="LokalMusic.Store.CataloguePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .card-body{
            margin: -14px -18px 0 -18px;
        }

        .card-body p {
            color: black;
            font-size: 14px;
            font-weight: 500;
            margin: 0 0 0 0;
        }
    </style>

    <div class="container">
        <h1 class="mb-5 mt-5">Searched Products</h1>

        <div class="row">   
            <asp:Repeater ID="productContainer" runat="server">
                <ItemTemplate>
                    <div class="col-xl-2 col-md-3 mb-5 ml-3 mr-3 shadow-sm">
                        <div class="card border-0">
                            <p class="mt-2" style="color:#7a7a7a; font-weight:600; font-size: 13px;"><%#Eval("ProductType") %></p>
                            <a href=<%#Eval("DetailsUrl") %> runat="server" target="_blank"><img src="<%#Eval("ImageCoverAddress")%>" class="card-img-top img-hoverable" alt="catalogue-item"/></a>
                            <div class="card-body">
                                <p><%#Eval("ProductName")%></p>
                                <p class="" style="color: #F82B2B; font-weight: 600;">₱<%#Eval("Price")%></p>
                                <p class="by-artist float-right" style="color:#767676;"><%#Eval("ArtistName")%></p>
                            </div>
                        </div>            
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

    </div>

</asp:Content>
