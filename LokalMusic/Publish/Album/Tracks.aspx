<%@ Page Title="Tracks" Language="C#" MasterPageFile="~/Template/PublishLayout.master" AutoEventWireup="true" CodeBehind="Tracks.aspx.cs" Inherits="LokalMusic.Publish.Tracks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" style="margin-top:60px">
        <div>
            <h1><strong><asp:Label ID="ArtistName" runat="server" Text="Artist/Band Name"></asp:Label></strong></h1>
            <hr />
        </div>

        <div style="margin-top:30px" class="d-flex justify-content-between">
            <h4><asp:Label ID="AlbumName" runat="server" Text="Album Name"></asp:Label> - Tracks</h4>
            <div>
                <a href="~/Publish/Albums" runat="server">
                    <input type="button" name="viewAlbumsBtn" class="btn btn-publish" value="View Albums" />
                </a>
                &emsp;
                <a id="addTrack" href="~/Publish/Album/Add" runat="server">
                    <input type="button" name="addTrackBtn" class="btn btn-publish" value="Add Track" />
                </a>
            </div>
        </div>
        <div>
            <table id="albumTable" class="table table-striped table-hover dt-responsive" style="margin-top:30px"> 
                <asp:Repeater ID="TrackItemRepeater" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td style="text-align: right"><asp:Image ID="trackCover" runat="server" ImageUrl=<%#Eval("TrackCoverLink") %> Height="70" Width="70" /></td>
                            <td style="vertical-align: middle"><strong><%#Eval("TrackName") %></strong><br />Date Added: <%#Eval("DateAdded","{0:MM/dd/yyyy}") %></td>
                            <td style="vertical-align: middle">Genre: <%#Eval("Genre") %><br />Duration: <%#Eval("Duration","{0:hh\\:mm\\:ss}") %></td>
                            <td style="vertical-align: middle">Sales: <%#Eval("SalesCount") %><br />Price: <%#Eval("Price","{0:N}") %></td>
                            <td style="vertical-align: middle">
                                <a href='<%#Eval("EditURL") %>' runat="server">
                                    <input type="button" name="EditBtn" class="btn btn-publish" value="Edit" />
                                </a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <p id="instruction" style="font-size: x-large; text-align:center;" runat="server">Add your first track</p>
        </div>
    </div>

</asp:Content>
