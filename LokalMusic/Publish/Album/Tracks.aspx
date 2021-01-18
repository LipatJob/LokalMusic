<%@ Page Title="Tracks" Language="C#" MasterPageFile="~/Template/PublishLayout.master" AutoEventWireup="true" CodeBehind="Tracks.aspx.cs" Inherits="LokalMusic.Publish.Tracks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" style="margin-top:60px">
        <div>
            <h1><strong><asp:Label ID="ArtistName" runat="server" Text="Artist/Band Name"></asp:Label></strong></h1>
            <hr />
        </div>

        <div style="margin-top:30px" class="d-flex justify-content-between">
            <h4><asp:Label ID="AlbumName" runat="server" Text="Album Name"></asp:Label> - Tracks</h4>
            <asp:Button ID="addAlbumBtn" runat="server" Text="Add Track" CssClass="btn btn-publish" />
        </div>
        <div>
            <table id="albumTable" class="table table-striped table-hover dt-responsive" style="margin-top:30px"> 
                <asp:Repeater ID="TrackItemRepeater" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td style="text-align: right"><asp:Image ID="trackCover" runat="server" ImageUrl=<%#Eval("TrackCoverLink") %> Height="70" Width="70" /></td>
                            <td style="vertical-align: middle"><strong><%#Eval("TrackName") %></strong><br />Date Added: <%#Eval("DateAdded","{0:MM/dd/yyyy}") %></td>
                            <td style="vertical-align: middle">Genre: <%#Eval("Genre") %><br />Duration: <%#Eval("Duration") %></td>
                            <td style="vertical-align: middle">Sales: <%#Eval("SalesCount") %><br />Price: <%#Eval("Price","{0:N}") %></td>
                            <td style="vertical-align: middle">
                                <asp:Button ID="EditBtn" runat="server" Text="Edit" CssClass="btn btn-publish" PostBackUrl='<%#Eval("EditURL") %>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
    </div>

</asp:Content>
