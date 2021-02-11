<%@ Page Title="Edit Track" Language="C#" MasterPageFile="~/Template/PublishLayout.master" AutoEventWireup="true" CodeBehind="EditTrack.aspx.cs" Inherits="LokalMusic.Publish.Album.Track.EditTrack" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div>
            <h1><strong><asp:Label ID="artistName" runat="server" Text="Artist/Band Name"></asp:Label></strong></h1>
            <hr />
        </div>

        <div style="margin-top:30px" class="d-flex justify-content-between">
            <h4><asp:Label ID="albumName" runat="server" Text="Album Name"></asp:Label> - Edit Track</h4>
            <div>
                <asp:LinkButton ID="withdrawBtn" runat="server" ForeColor="#B82828" OnClick="withdrawBtn_Click" CausesValidation="False">Withdraw Track</asp:LinkButton>
                &emsp;
                <asp:Button ID="publishUnpublishBtn" runat="server" Text="Publish" CssClass="btn btn-publish" OnClick="publishUnpublishBtn_Click" />
            </div>
        </div>

        <div style="margin:80px auto 0px auto; width: 90%;" class="row">
            <div class="col-8">
                <div class="form-group">
                    <asp:Label Text="Track Name" runat="server" />
                    <asp:TextBox ID="trackNameTxt" runat="server" Width="500" CssClass="form-control"></asp:TextBox>
                    <asp:CustomValidator ID="trackNameTxtCv" runat="server" ErrorMessage="CustomValidator" Display="Dynamic" ControlToValidate="trackNameTxt" ValidateEmptyText="True" CssClass="validation-message" OnServerValidate="trackNameTxtCv_ServerValidate"></asp:CustomValidator>
                </div>
                <div class="form-group">
                    <asp:Label Text="Genre" runat="server" />
                    <asp:TextBox ID="genreTxt" runat="server" Width="500" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label Text="Description" runat="server" />
                    <asp:TextBox ID="descriptionTxt" runat="server" Width="500" Height="120" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label Text="Price (₱)" runat="server" />
                    <asp:TextBox ID="priceTxt" runat="server" type="number" step=".01" min="0" max="214748.3647" Width="500" CssClass="form-control" AutoPostBack="True" OnTextChanged="priceTxt_TextChanged"></asp:TextBox>
                    <p style="font-size: small; color: #525252;">Earnings: ₱<asp:Label ID="earnings" runat="server" Text="0.00"></asp:Label> (Transaction fee: ₱<asp:Label ID="transactionFee" runat="server" Text="0.00"></asp:Label>)</p>
                    <asp:CustomValidator ID="priceTxtCv" runat="server" ErrorMessage="CustomValidator" Display="Dynamic" ControlToValidate="priceTxt" ValidateEmptyText="True" CssClass="validation-message" OnServerValidate="priceTxtCv_ServerValidate"></asp:CustomValidator>
                </div>
            </div>
            <div class="col-4">
                <p>Track File</p>
                <div style="margin-bottom:20px;">
                    <audio controls id="trackSource" src="" runat="server">
                    </audio>
                </div>
                <div style="margin-bottom:20px;">
                    <div class="custom-file">
                        <asp:FileUpload runat="server" ID="trackFile" CssClass="form-control-file custom-file-input trackFile"/>
                        <label class="custom-file-label" for="custom-file">Choose file</label>
                    </div>
                </div>

                <p style="margin-top:50px">Clip File</p>
                <div style="margin-bottom:20px;">
                    <audio controls id="clipSource" src="" runat="server">
                    </audio>
                </div>
                <div style="margin-bottom:20px;">
                    <div class="custom-file">
                        <asp:FileUpload runat="server" ID="clipFile" CssClass="form-control-file custom-file-input clipFile"/>
                        <label class="custom-file-label" for="custom-file">Choose file</label>
                    </div>
                    <asp:CustomValidator ID="clipFileCv" runat="server" ErrorMessage="CustomValidator" Display="Dynamic" ControlToValidate="clipFile" ValidateEmptyText="True" CssClass="validation-message" OnServerValidate="clipFileCv_ServerValidate"></asp:CustomValidator>
                </div>
            </div>            
        </div>

        <div class="row float-right" style="margin-top: 40px">
            <div class="col-12">
                <asp:Button ID="cancelBtn" runat="server" Text="Cancel" CssClass="btn btn-publish-light" OnClick="cancelBtn_Click" CausesValidation="False" />
                &emsp;
                <asp:Button ID="saveBtn" runat="server" Text="Save" CssClass="btn btn-publish" OnClick="saveBtn_Click" />
            </div>
        </div>
    
    </div>
</asp:Content>
