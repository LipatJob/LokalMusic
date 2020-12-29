<%@ Page Title="" Language="C#" MasterPageFile="~/Template/StoreLayout.master" AutoEventWireup="true" CodeBehind="Collection.aspx.cs" Inherits="LokalMusic.Fan.Collection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .user-info-container{
            display:flex;
            flex-direction:row;
            align-items:center;

        }

        .profile-picture{
            width:140px; 
            height:140px; 
            object-fit:cover; 
            border-radius:100%;
            border-color:black;
            border-width:2px;
            border-style:solid;
            margin:20px;
        }

        .user-info{
        }

        .collection-container {
            display: grid;
            grid-gap: 2rem;
            grid-template-columns: repeat(auto-fill, minmax(190px, 1fr));
        }

        .collection-item {
            display: flex;
            flex-direction: column;
            align-items: center;
            border: 1px solid white;
            padding: 10px;
            transition: 0.1s ease-out all;
        }

        .item-link:link{
            color:black;
        }

        .collection-item:hover {
            transition: border 0.1s ease-in-out !important;
            border: 1px dotted #ffbaba;
        }

        .item-picture {
            width: 180px;
            height: 180px;
            margin-bottom: 8px;
            border: 1px solid #e0e0e0;
            object-fit: cover;
        }

        .artist-link {
            color: gray;
        }
    </style>
    <div class="container">
        <div class="user-info-container">
            <img src="~/Content/Images/Logo.png" alt="Alternate Text" class="profile-picture shadow" runat="server">
            <div class="user-info">
                <h3><%Response.Write(Model.Username);%></h3>
                <p>Member Since: <%Response.Write(Model.DateRegistered.ToShortDateString());%></p>
            </div>
        </div>
        <hr />
        <h3>Collection</h3>
        <div class="collection-container">
            <%foreach (var product in Model.Collection)
            {%>
            <a href="<%Response.Write(product.GetUrl);%>" class="item-link">
                <div class="collection-item">
                    <img src="<% Response.Write(product.CoverLink); %>" alt="Alternate Text" class="item-picture" />
                    <b><% Response.Write(product.ProductName); %></b>
                    <p>By <% Response.Write(product.ArtistName); %></p>
                </div>
            </a>
            <%} %>
        </div>
    </div>
</asp:Content>
