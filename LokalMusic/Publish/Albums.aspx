﻿<%@ Page Title="Albums" Language="C#" MasterPageFile="~/Template/PublishLayout.master" AutoEventWireup="true" CodeBehind="Albums.aspx.cs" Inherits="LokalMusic.Publish.Albums" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" style="margin-top:60px">
        <div>
            <h1><strong><asp:Label ID="ArtistName" runat="server" Text="Artist/Band Name"></asp:Label></strong></h1>
            <hr />
        </div>

        <div style="margin-top:30px" class="d-flex justify-content-between">
            <h4>Albums</h4>
            <asp:LinkButton ID="addAlbumBtn" runat="server" CssClass="btn btn-publish" PostBackUrl="~/Publish/Album/Add">Add Album</asp:LinkButton>
        </div>
        <div>
            <table id="albumTable" class="table table-striped table-hover dt-responsive" style="margin-top:30px"> 
                <asp:Repeater ID="AlbumItemRepeater" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td style="text-align: right"><asp:Image ID="albumCover" runat="server" ImageUrl=<%#Eval("AlbumCoverLink") %> Height="70" Width="70" /></td>
                            <td style="vertical-align: middle"><strong><%#Eval("AlbumName") %></strong><br />Date Added: <%#Eval("DateAdded","{0:MM/dd/yyyy}") %></td>
                            <td style="vertical-align: middle">Tracks: <%#Eval("TrackCount") %><br />Producer: <%#Eval("Producer") %></td>
                            <td style="vertical-align: middle">Sales: <%#Eval("SalesCount") %><br />Price: <%#Eval("Price","{0:N}") %></td>
                            <td style="vertical-align: middle">
                                <asp:LinkButton ID="TracksBtn" runat="server" CssClass="btn btn-publish" PostBackUrl='<%#Eval("TracksURL") %>'>Tracks</asp:LinkButton>&emsp;
                                <asp:LinkButton ID="EditBtn" runat="server" CssClass="btn btn-publish">Edit</asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
    </div>

</asp:Content>