<%@ Page Title="Albums" Language="C#" MasterPageFile="~/Template/StoreLayout.master" AutoEventWireup="true" CodeBehind="Albums.aspx.cs" Inherits="LokalMusic.Publish.Albums" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <style>

    </style>

    <div class="container" style="margin-top:60px">
        <div>
            <h1><strong><asp:Label ID="ArtistName" runat="server" Text="Artist/Band Name"></asp:Label></strong></h1>
            <hr />
        </div>

        <div style="margin-top:30px" class="d-flex justify-content-between">
            <h4>Albums</h4>
            <asp:Button ID="addAlbumBtn" runat="server" Text="Add Album" CssClass="btn btn-publish" />
        </div>
        <div>
            <table id="albumTable" class="table table-striped table-bordered table-hover dt-responsive" style="margin-top:30px"> 
                <tr>
                    <td><asp:Image ID="albumCover" runat="server" ImageUrl="~/Content/Images/default_cover.jpg" Height="70" Width="70" /></td>
                    <td>AlbumName<br />Date Added: 01-01-2021</td>
                    <td>Tracks: 9<br />Producer: Producer Name</td>
                    <td>Sales: 12<br />Price: 100.00</td>
                    <td><asp:Button ID="Button1" runat="server" Text="Button" /><asp:Button ID="Button2" runat="server" Text="Button" /></td>
                </tr>
                <asp:Repeater ID="AlbumItemRepeater" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><asp:Image ID="albumCover" runat="server" ImageUrl="~/Content/Images/default_cover.jpg" Height="70" Width="70" /></td>
                            <td>AlbumName<br />Date Added: 01-01-2021</td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
    </div>

</asp:Content>
