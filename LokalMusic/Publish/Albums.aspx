<%@ Page Title="Albums" Language="C#" MasterPageFile="~/Template/PublishLayout.master" AutoEventWireup="true" CodeBehind="Albums.aspx.cs" Inherits="LokalMusic.Publish.Albums" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <style>
        td{
            
        }
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
            <table id="albumTable" class="table table-striped table-hover dt-responsive" style="margin-top:30px"> 
                <asp:Repeater ID="AlbumItemRepeater" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td style="text-align: right"><asp:Image ID="albumCover" runat="server" ImageUrl=<%#Eval("AlbumCoverLink") %> Height="70" Width="70" /></td>
                            <td style="vertical-align: middle"><strong><%#Eval("AlbumName") %></strong><br />Date Added: <%#Eval("DateAdded") %></td>
                            <td style="vertical-align: middle">Tracks: <%#Eval("TrackCount") %><br />Producer: <%#Eval("Producer") %></td>
                            <td style="vertical-align: middle">Sales: <%#Eval("SalesCount") %><br />Price: <%#Eval("Price") %></td>
                            <td style="vertical-align: middle">
                                <asp:Button ID="TracksBtn" runat="server" Text="Tracks" CssClass="btn btn-publish" />&emsp;
                                <asp:Button ID="EditBtn" runat="server" Text="Edit" CssClass="btn btn-publish" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
    </div>

</asp:Content>
