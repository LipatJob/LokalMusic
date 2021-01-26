<%@ Page Title="Add Track" Language="C#" MasterPageFile="~/Template/PublishLayout.master" AutoEventWireup="true" CodeBehind="AddTrack.aspx.cs" Inherits="LokalMusic.Publish.Album.Track.AddTrack" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        td{
            padding-bottom:48px;
        }
    </style>

    <div class="container" style="margin-top:60px;margin-bottom:100px;">
        <div>
            <h1><strong><asp:Label ID="artistName" runat="server" Text="Artist/Band Name"></asp:Label></strong></h1>
            <hr />
        </div>

        <div style="margin-top:30px" class="d-flex justify-content-between">
            <h4><asp:Label ID="albumName" runat="server" Text="Album Name"></asp:Label> - Add Track</h4>
            <a id="viewTracks" runat="server">
                <input type="button" name="viewTracksBtn" class="btn btn-publish" value="View Tracks" />
            </a>
        </div>

        <div style="margin-top:80px;" class="row">
            <div class="col-8">
                <table style="width: 100%;">
                    <tr>
                        <td>Track Name</td>
                        <td style="padding-left:24px;"><asp:TextBox ID="trackNameTxt" runat="server" Width="500" Height="36"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Genre</td>
                        <td style="padding-left:24px;"><asp:TextBox ID="genreTxt" runat="server" Width="500" Height="36"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Description</td>
                        <td style="padding-left:24px;"><asp:TextBox ID="descriptionTxt" runat="server" Width="500" Height="120" TextMode="MultiLine"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Price</td>
                        <td style="padding-left:24px;"><asp:TextBox ID="priceTxt" runat="server" Width="500" Height="36"></asp:TextBox></td>
                    </tr>
                </table>
            </div>
            <div class="col-4">
                <p>Track File</p>
                <div style="margin-bottom:20px;">
                    
                </div>
                <div style="margin-bottom:20px;">
                    <asp:FileUpload ID="trackFile" runat="server" />
                </div>
                <div>
                    <asp:Button ID="uploadTrackFileBtn" runat="server" Text="Upload Track File" CssClass="btn btn-publish" OnClick="uploadTrackFileBtn_Click" />
                </div>

                <p style="margin-top:50px">Clip File</p>
                <div style="margin-bottom:20px;">
                    
                </div>
                <div style="margin-bottom:20px;">
                    <asp:FileUpload ID="clipFile" runat="server" />
                </div>
                <div>
                    <asp:Button ID="uploadClipFileBtn" runat="server" Text="Upload Clip File" CssClass="btn btn-publish" OnClick="uploadClipFileBtn_Click" />
                </div>
            </div>            
        </div>

        <div class="row float-right">
            <div class="col-12">
                <asp:Button ID="cancelBtn" runat="server" Text="Cancel" CssClass="btn btn-publish-light" OnClick="cancelBtn_Click" />
                &emsp;
                <asp:Button ID="addBtn" runat="server" Text="Add" CssClass="btn btn-publish" OnClick="addBtn_Click" />
            </div>
        </div>
    
    </div>

</asp:Content>
