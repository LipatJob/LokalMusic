<%@ Page Title="Edit Album" Language="C#" MasterPageFile="~/Template/PublishLayout.master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="LokalMusic.Publish.Album.Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .imgPreview{
            border-radius: 0.25rem;
        }
    </style>

    <div class="container">
        <div>
            <h1><strong><asp:Label ID="artistName" runat="server" Text="Artist/Band Name"></asp:Label></strong></h1>
            <hr />
        </div>

        <div style="margin-top:30px" class="d-flex justify-content-between">
            <h4>Edit Album</h4>
            <div>
                <asp:LinkButton ID="withdrawBtn" runat="server" ForeColor="#B82828" OnClick="withdrawBtn_Click" CausesValidation="False">Withdraw Album</asp:LinkButton>
                &emsp;
                <asp:Button ID="publishUnpublishBtn" runat="server" Text="Publish" CssClass="btn btn-publish" OnClick="publishUnpublishBtn_Click" />
            </div>
        </div>

        <div style="margin:80px auto 0px auto; width: 90%;" class="row">
            <div class="col-8">
                <div class="form-group">
                    <asp:Label Text="Album Name" runat="server" />
                    <asp:TextBox ID="albumNameTxt" runat="server" Width="500" CssClass="form-control"></asp:TextBox>
                    <asp:CustomValidator ID="albumNameTxtCv" runat="server" ErrorMessage="CustomValidator" Display="Dynamic" ControlToValidate="albumNameTxt" ValidateEmptyText="True" CssClass="validation-message" OnServerValidate="albumNameTxtCv_ServerValidate"></asp:CustomValidator>
                </div>
                <div class="form-group">
                    <asp:Label Text="Description" runat="server" />
                    <asp:TextBox ID="descriptionTxt" runat="server" Width="500" Height="120" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label Text="Date Released" runat="server" />
                    <asp:TextBox ID="dateReleasedTxt" runat="server" TextMode="Date" Width="500" CssClass="form-control"></asp:TextBox>
                    <asp:CustomValidator ID="dateReleasedTxtCv" runat="server" ErrorMessage="CustomValidator" Display="Dynamic" ControlToValidate="dateReleasedTxt" CssClass="validation-message" OnServerValidate="dateReleasedTxtCv_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator>
                </div>
                <div class="form-group">
                    <asp:Label Text="Producer" runat="server" />
                    <asp:TextBox ID="producerTxt" runat="server" Width="500" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label Text="Price (₱)" runat="server" />
                    <asp:TextBox ID="priceTxt" runat="server" type="number" step=".01" min="0" max="214748.3647" Width="500" CssClass="form-control" OnTextChanged="priceTxt_TextChanged" AutoPostBack="True"></asp:TextBox>
                    <p style="font-size: small; color: #525252;">Earnings: ₱<asp:Label ID="earnings" runat="server" Text="0.00"></asp:Label> (Transaction fee: ₱<asp:Label ID="transactionFee" runat="server" Text="0.00"></asp:Label>)</p>
                    <asp:CustomValidator ID="priceTxtCv" runat="server" ErrorMessage="CustomValidator" Display="Dynamic" ControlToValidate="priceTxt" ValidateEmptyText="True" CssClass="validation-message" OnServerValidate="priceTxtCv_ServerValidate"></asp:CustomValidator>
                </div>
            </div>
            <div class="col-4">
                <p>Album Cover</p>
                <div style="margin-bottom:20px;">
                    <asp:Image ID="albumCoverPreview" runat="server" ImageUrl="~\Content\Images\default_cover.jpg" Width="200" Height="200" CssClass="imgPreview albumCoverPreview" BorderColor="#F82B2B" BorderStyle="Solid" BorderWidth="2px" />
                </div>
                <div>
                    <div class="custom-file">
                        <asp:FileUpload runat="server" ID="albumCoverFile" CssClass="form-control-file custom-file-input albumCoverFile" accept="image/*"/>
                        <label class="custom-file-label" for="custom-file">Choose file</label>
                    </div>
                </div>
            </div>         
        </div>

        <div class="row float-right">
            <div class="col-12">
                <asp:Button ID="cancelBtn" runat="server" Text="Cancel" CssClass="btn btn-publish-light" OnClick="cancelBtn_Click" CausesValidation="False" />
                &emsp;
                <asp:Button ID="saveBtn" runat="server" Text="Save" CssClass="btn btn-publish" OnClick="saveBtn_Click" />
            </div>
        </div>
    
    </div>

    <script>
        $('document').ready(function () {
            $(".albumCoverFile").change(function () {
                if (this.files && this.files[0]) {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $('.albumCoverPreview').attr('src', e.target.result);
                    }
                    reader.readAsDataURL(this.files[0]);
                }
            });
        });

    </script>
</asp:Content>
