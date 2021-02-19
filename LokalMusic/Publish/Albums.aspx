<%@ Page Title="Albums" Language="C#" MasterPageFile="~/Template/PublishLayout.master" AutoEventWireup="true" CodeBehind="Albums.aspx.cs" Inherits="LokalMusic.Publish.Albums" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div>
            <h1><strong><asp:Label ID="ArtistName" runat="server" Text="Artist/Band Name"></asp:Label></strong></h1>
            <hr />
        </div>

        <div style="margin-top:30px" class="d-flex justify-content-between">
            <h4>Albums</h4>
            <a href="~/Publish/Album/Add" runat="server">
                <input type="button" name="addAlbumBtn" class="btn btn-publish" value="Add Album" />
            </a>
        </div>
        <div>
            <table id="albumTable" class="table table-striped table-hover dt-responsive" style="margin-top:30px"> 
                <asp:Repeater ID="AlbumItemRepeater" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td style="text-align: right"><asp:Image ID="albumCover" runat="server" ImageUrl=<%#Eval("AlbumCoverLink") %> Height="70" Width="70" /></td>
                            <td style="vertical-align: middle"><strong class='<%# (Eval("Status").Equals("Published")) ?  "redtext" : "graytext" %>'><%#Eval("AlbumName") %></strong></td>
                            <td style="vertical-align: middle">Status: <%#Eval("Status") %><br />Date Added: <%#Eval("DateAdded","{0:dd MMM yyyy}") %></td>
                            <td style="vertical-align: middle">Tracks: <%#Eval("TrackCount") %><br />Producer: <%#Eval("Producer") %></td>
                            <td style="vertical-align: middle">Sales: <%#Eval("SalesCount") %><br />Price: <%#Eval("Price","{0:N}") %></td>
                            <td style="vertical-align: middle">
                                <a href='<%#Eval("TracksURL") %>' runat="server">
                                    <input type="button" name="TracksBtn" class="btn btn-publish" value="Tracks" />
                                </a>
                                &emsp;
                                <a href='<%#Eval("EditURL") %>' runat="server">
                                    <input type="button" name="EditBtn" class="btn btn-publish" value="Edit" />
                                </a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <a id="addAlbumInstruction" href="~/Publish/Album/Add" runat="server" style="color: #212529;">
                <p style="font-size: x-large; text-align:center;" runat="server">Add your first album</p>            
            </a>
        </div>
    </div>

</asp:Content>
