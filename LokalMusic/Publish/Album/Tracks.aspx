<%@ Page Title="Tracks" Language="C#" MasterPageFile="~/Template/PublishLayout.master" AutoEventWireup="true" CodeBehind="Tracks.aspx.cs" Inherits="LokalMusic.Publish.Tracks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
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
                <a id="addTrack" runat="server">
                    <input type="button" id="addTrackBtn" name="addTrackBtn" class="btn btn-publish" value="Add Track" runat="server" />
                </a>
            </div>
        </div>
        <div style="text-align: right; margin-top: 5px;">
            <asp:Label ID="maxAlert" runat="server" Text="Max track count for album reached" ForeColor="Red" Display="Dynamic"></asp:Label>
        </div>
        <div>
            <table id="albumTable" class="table table-striped table-hover dt-responsive" style="margin-top:30px"> 
                <asp:Repeater ID="TrackItemRepeater" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td style="text-align: right"><asp:Image ID="trackCover" runat="server" ImageUrl=<%#Eval("TrackCoverLink") %> Height="70" Width="70" /></td>
                            <td style="vertical-align: middle"><strong class='<%# (Eval("Status").Equals("Published")) ?  "redtext" : "graytext" %>'><%#Eval("TrackName") %></strong></td>
                            <td style="vertical-align: middle">Status: <%#Eval("Status") %><br />Date Added: <%#Eval("DateAdded","{0:dd MMM yyyy}") %></td>
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
            <a id="addTrackInstruction" runat="server" style="color: #212529;">
                <p style="font-size: x-large; text-align:center;" runat="server">Add your first track</p>            
            </a>
        </div>
    </div>

</asp:Content>
