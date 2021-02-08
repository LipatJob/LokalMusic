<%@ Page Title="Add Track" Language="C#" MasterPageFile="~/Template/PublishLayout.master" AutoEventWireup="true" CodeBehind="AddTrack.aspx.cs" Inherits="LokalMusic.Publish.Album.Track.AddTrack" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        td{
            padding-bottom:48px;
        }
    </style>

    <div class="container">
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
                        <td style="padding-left:24px;">
                            <asp:TextBox ID="trackNameTxt" runat="server" Width="500" CssClass="form-control"></asp:TextBox>
                            <asp:CustomValidator ID="trackNameTxtCv" runat="server" ErrorMessage="CustomValidator" Display="Dynamic" ControlToValidate="trackNameTxt" ValidateEmptyText="True" CssClass="validation-message" OnServerValidate="trackNameTxtCv_ServerValidate"></asp:CustomValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Genre</td>
                        <td style="padding-left:24px;"><asp:TextBox ID="genreTxt" runat="server" Width="500" CssClass="form-control"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Description</td>
                        <td style="padding-left:24px;"><asp:TextBox ID="descriptionTxt" runat="server" Width="500" Height="120" CssClass="form-control" TextMode="MultiLine"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Price</td>
                        <td style="padding-left:24px;">
                            <asp:TextBox ID="priceTxt" runat="server" type="number" step=".01" min="0" max="214748.3647" Width="500" CssClass="form-control"></asp:TextBox>
                            <asp:CustomValidator ID="priceTxtCv" runat="server" ErrorMessage="CustomValidator" Display="Dynamic" ControlToValidate="priceTxt" ValidateEmptyText="True" CssClass="validation-message" OnServerValidate="priceTxtCv_ServerValidate"></asp:CustomValidator>
                        </td>
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
                    <asp:FileUpload ID="trackFile" runat="server" /><br />
                    <asp:CustomValidator ID="trackFileCv" runat="server" ErrorMessage="CustomValidator" Display="Dynamic" ControlToValidate="trackFile" ValidateEmptyText="True" CssClass="validation-message" OnServerValidate="trackFileCv_ServerValidate"></asp:CustomValidator>
                </div>

                <p style="margin-top:50px">Clip File</p>
                <div style="margin-bottom:20px;">
                    <audio controls id="clipSource" src="" runat="server">
                    </audio>
                </div>
                <div style="margin-bottom:20px;">
                    <asp:FileUpload ID="clipFile" runat="server" /><br />
                    <asp:CustomValidator ID="clipFileCv" runat="server" ErrorMessage="CustomValidator" Display="Dynamic" ControlToValidate="clipFile" ValidateEmptyText="True" CssClass="validation-message" OnServerValidate="clipFileCv_ServerValidate"></asp:CustomValidator>
                </div>
            </div>            
        </div>

        <div class="row float-right" style="margin-top: 40px;>
            <div class="col-12">
                <asp:Label ID="maxAlert" runat="server" Text="Max track count for album reached" ForeColor="Red" Display="Dynamic"></asp:Label>
                &emsp;
                <asp:Button ID="cancelBtn" runat="server" Text="Cancel" CssClass="btn btn-publish-light" OnClick="cancelBtn_Click" CausesValidation="False" />
                &emsp;
                <asp:Button ID="addBtn" runat="server" Text="Add" CssClass="btn btn-publish" OnClick="addBtn_Click" />
            </div>
        </div>
    
    </div>

</asp:Content>
