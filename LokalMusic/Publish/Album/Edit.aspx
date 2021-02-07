﻿<%@ Page Title="Edit Album" Language="C#" MasterPageFile="~/Template/PublishLayout.master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="LokalMusic.Publish.Album.Edit" %>

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
            <h4>Edit Album</h4>
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
                            <asp:TextBox ID="albumNameTxt" runat="server" Width="500" CssClass="form-control"></asp:TextBox>
                            <asp:CustomValidator ID="albumNameTxtCv" runat="server" ErrorMessage="CustomValidator" Display="Dynamic" ControlToValidate="albumNameTxt" ValidateEmptyText="True" CssClass="validation-message" OnServerValidate="albumNameTxtCv_ServerValidate"></asp:CustomValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Description</td>
                        <td style="padding-left:24px;"><asp:TextBox ID="descriptionTxt" runat="server" Width="500" Height="120" CssClass="form-control" TextMode="MultiLine"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Date Released</td>
                        <td style="padding-left:24px;">
                            <asp:TextBox ID="dateReleasedTxt" runat="server" TextMode="Date" Width="500" CssClass="form-control"></asp:TextBox>
                            <asp:CustomValidator ID="dateReleasedTxtCv" runat="server" ErrorMessage="CustomValidator" Display="Dynamic" ControlToValidate="dateReleasedTxt" CssClass="validation-message" OnServerValidate="dateReleasedTxtCv_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Producer</td>
                        <td style="padding-left:24px;"><asp:TextBox ID="producerTxt" runat="server" Width="500" CssClass="form-control"></asp:TextBox></td>
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
                <p>Album Cover</p>
                <div style="margin-bottom:20px;">
                    <asp:Image ID="albumCoverPreview" runat="server" ImageUrl="~\Content\Images\default_cover.jpg" Width="200" Height="200" />
                </div>
                <div style="margin-bottom:20px;">
                    <asp:FileUpload ID="albumCoverFile" accept="image/*" runat="server" />
                </div>
            </div>            
        </div>

        <div class="row float-right">
            <div class="col-12">
                <asp:LinkButton ID="unlistBtn" runat="server" ForeColor="#B82828" OnClick="unlistBtn_Click" CausesValidation="False">Unlist Album</asp:LinkButton>
                &emsp;
                <asp:Button ID="cancelBtn" runat="server" Text="Cancel" CssClass="btn btn-publish-light" OnClick="cancelBtn_Click" CausesValidation="False" />
                &emsp;
                <asp:Button ID="saveBtn" runat="server" Text="Save" CssClass="btn btn-publish" OnClick="saveBtn_Click" />
            </div>
        </div>
    
    </div>
</asp:Content>
