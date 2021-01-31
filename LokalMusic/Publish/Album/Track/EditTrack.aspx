﻿<%@ Page Title="Edit Track" Language="C#" MasterPageFile="~/Template/PublishLayout.master" AutoEventWireup="true" CodeBehind="EditTrack.aspx.cs" Inherits="LokalMusic.Publish.Album.Track.EditTrack" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <style>
        td{
            padding-bottom:48px;
        }
    </style>

    <div class="container" style="margin-top:60px;margin-bottom:140px;">
        <div>
            <h1><strong><asp:Label ID="artistName" runat="server" Text="Artist/Band Name"></asp:Label></strong></h1>
            <hr />
        </div>

        <div style="margin-top:30px" class="d-flex justify-content-between">
            <h4><asp:Label ID="albumName" runat="server" Text="Album Name"></asp:Label> - Edit Track</h4>
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
                    <audio controls id="trackSource" src="" runat="server">
                    </audio>
                </div>
                <div style="margin-bottom:20px;">
                    <asp:FileUpload ID="trackFile" runat="server" />
                </div>
                <div>
                    <asp:Button ID="uploadTrackFileBtn" runat="server" Text="Upload Track File" CssClass="btn btn-publish" OnClick="uploadTrackFileBtn_Click" />
                </div>

                <p style="margin-top:50px">Clip File</p>
                <div style="margin-bottom:20px;">
                    <audio controls id="clipSource" src="" runat="server">
                    </audio>
                </div>
                <div style="margin-bottom:20px;">
                    <asp:FileUpload ID="clipFile" runat="server" />
                </div>
                <div>
                    <asp:Button ID="uploadClipFileBtn" runat="server" Text="Upload Clip File" CssClass="btn btn-publish" OnClick="uploadClipFileBtn_Click" />
                </div>
            </div>            
        </div>

        <div class="row float-right" style="margin-top: 40px">
            <div class="col-12">
                <asp:LinkButton ID="unlistBtn" runat="server" ForeColor="#B82828" OnClick="unlistBtn_Click">Unlist Track</asp:LinkButton>
                &emsp;
                <asp:Button ID="cancelBtn" runat="server" Text="Cancel" CssClass="btn btn-publish-light" OnClick="cancelBtn_Click" />
                &emsp;
                <asp:Button ID="saveBtn" runat="server" Text="Save" CssClass="btn btn-publish" OnClick="saveBtn_Click" />
            </div>
        </div>
    
    </div>
</asp:Content>
