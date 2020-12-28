<%@ Page Title="" Language="C#" MasterPageFile="~/Template/StoreLayout.master" AutoEventWireup="true" CodeBehind="Collection.aspx.cs" Inherits="LokalMusic.Fan.Collection" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .collection-container{
            display: grid;
            grid-gap: 2rem;
            grid-template-columns: repeat(auto-fit, minmax(190px, 1fr));
        }

        .collection-item{
            display:flex;
            flex-direction:column;
            align-items:center;
            border: 1px solid white;
            padding:10px;
            transition: 0.1s ease-out all;
        }

        .collection-item:hover{
            transition: border 0.1s ease-in-out !important;
            border: 1px dotted #ffbaba;
        }

        .item-picture{
            width:180px;
            height: 180px;
            margin-bottom:8px;
            border: 1px solid #e0e0e0;
            object-fit:cover;
        }

        .artist-link{
            color:gray;
        }
    </style>
    <div class="container">
        <h4>Username</h4>
        <hr />
        <div class="collection-container">

            <div class="collection-item">
                <asp:Image ImageUrl="~/Content/Images/Logo.png" runat="server" CssClass="item-picture"/>
                <b>Product Name</b>
                <p>By Artist Name</p>
            </div>
            <div class="collection-item">
                <asp:Image ImageUrl="~/Content/Images/Logo.png" runat="server" CssClass="item-picture"/>
                <b>Product Name</b>
                <p>By Artist Name</p>
            </div>
            <div class="collection-item">
                <asp:Image ImageUrl="~/Content/Images/Logo.png" runat="server" CssClass="item-picture"/>
                <b>Product Name</b>
                <p>By Artist Name</p>
            </div>
            <div class="collection-item">
                <asp:Image ImageUrl="~/Content/Images/Logo.png" runat="server" CssClass="item-picture"/>
                <b>Product Name</b>
                <p>By Artist Name</p>
            </div>
            <div class="collection-item">
                <asp:Image ImageUrl="~/Content/Images/Logo.png" runat="server" CssClass="item-picture"/>
                <b>Product Name</b>
                <p>By Artist Name</p>
            </div>
             <div class="collection-item">
                <asp:Image ImageUrl="~/Content/Images/Logo.png" runat="server" CssClass="item-picture"/>
                <b>Product Name</b>
                <p>By Artist Name</p>
            </div>
             <div class="collection-item">
                <asp:Image ImageUrl="~/Content/Images/Logo.png" runat="server" CssClass="item-picture"/>
                <b>Product Name</b>
                <p>By Artist Name</p>
            </div>





        </div>
    </div>
</asp:Content>
