<%@ Page Title="Add Album" Language="C#" MasterPageFile="~/Template/PublishLayout.master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="LokalMusic.Publish.Album.Add" %>

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
            <h4>Add Album</h4>
            <a href="~/Publish/Albums" runat="server">
                <input type="button" name="viewAlbumsBtn" class="btn btn-publish" value="View Albums" />
            </a>
        </div>

        <div style="margin-top:80px;" class="row">
            <div class="col-8">
                <table style="width: 100%;">
                    <tr>
                        <td>Album Name</td>
                        <td style="padding-left:24px;">
                            <asp:TextBox ID="albumNameTxt" runat="server" Width="500" Height="36"></asp:TextBox><br />
                            <asp:CustomValidator ID="albumNameTxtCv" runat="server" ErrorMessage="CustomValidator" Display="Dynamic" ControlToValidate="albumNameTxt" ValidateEmptyText="True" CssClass="validation-message" OnServerValidate="albumNameTxtCv_ServerValidate"></asp:CustomValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Description</td>
                        <td style="padding-left:24px;"><asp:TextBox ID="descriptionTxt" runat="server" Width="500" Height="120" TextMode="MultiLine"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Date Released</td>
                        <td style="padding-left:24px;">
                            <asp:TextBox ID="dateReleasedTxt" runat="server" Width="500" Height="36" placeholder="MM/DD/YYYY"></asp:TextBox><br />
                            <asp:CustomValidator ID="dateReleasedTxtCv" runat="server" ErrorMessage="CustomValidator" Display="Dynamic" ControlToValidate="dateReleasedTxt" CssClass="validation-message" OnServerValidate="dateReleasedTxtCv_ServerValidate"></asp:CustomValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Producer</td>
                        <td style="padding-left:24px;"><asp:TextBox ID="producerTxt" runat="server" Width="500" Height="36"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Price</td>
                        <td style="padding-left:24px;">
                            <asp:TextBox ID="priceTxt" runat="server" Width="500" Height="36">0.00</asp:TextBox><br />
                            <asp:CustomValidator ID="priceTxtCv" runat="server" ErrorMessage="CustomValidator" Display="Dynamic" ControlToValidate="priceTxt" ValidateEmptyText="True" CssClass="validation-message" OnServerValidate="priceTxtCv_ServerValidate"></asp:CustomValidator>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="col-4">
                <p>Album Cover</p>
                <div style="margin-bottom:20px;">
                    <asp:Image ID="albumCoverPreview" runat="server" ImageUrl="~\Content\Images\default_cover.jpg" Width="200" Height="200" />
                </div>
                <div style="margin-bottom:20px;">
                    <asp:FileUpload ID="albumCoverFile" accept="image/*" runat="server" /><br />
                    <asp:CustomValidator ID="albumCoverFileCv" runat="server" ErrorMessage="CustomValidator" Display="Dynamic" ControlToValidate="albumCoverFile" ValidateEmptyText="True" CssClass="validation-message" OnServerValidate="albumCoverFileCv_ServerValidate"></asp:CustomValidator>
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
