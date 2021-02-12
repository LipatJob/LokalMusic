<%@ Page Title="Add Track" Language="C#" MasterPageFile="~/Template/PublishLayout.master" AutoEventWireup="true" CodeBehind="AddTrack.aspx.cs" Inherits="LokalMusic.Publish.Album.Track.AddTrack" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div>
            <h1><strong><asp:Label ID="artistName" runat="server" Text="Artist/Band Name"></asp:Label></strong></h1>
            <hr />
        </div>

        <div style="margin-top:30px" class="d-flex justify-content-between">
            <h4><asp:Label ID="albumName" runat="server" Text="Album Name"></asp:Label> - Add Track</h4>
        </div>

        <div style="margin:80px auto 0px auto; width: 90%;" class="row">
            <div class="col-8">
                <div class="form-group">
                    <asp:Label Text="Track Name" runat="server" />
                    <asp:TextBox ID="trackNameTxt" runat="server" Width="500" CssClass="form-control" MaxLength="70"></asp:TextBox>
                    <asp:CustomValidator ID="trackNameTxtCv" runat="server" ErrorMessage="CustomValidator" Display="Dynamic" ControlToValidate="trackNameTxt" ValidateEmptyText="True" CssClass="validation-message" OnServerValidate="trackNameTxtCv_ServerValidate"></asp:CustomValidator>
                </div>
                <div class="form-group">
                    <asp:Label Text="Genre" runat="server" />
                    <asp:TextBox ID="genreTxt" list="genres" runat="server" Width="500" CssClass="form-control" MaxLength="70"></asp:TextBox>
                    <datalist id="genres" runat="server" ClientIDMode="Static"></datalist>
                </div>
                <div class="form-group">
                    <asp:Label Text="Description" runat="server" />
                    <asp:TextBox ID="descriptionTxt" runat="server" Width="500" Height="120" CssClass="form-control" TextMode="MultiLine" MaxLength="2000"></asp:TextBox>
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
                    <asp:CustomValidator ID="trackFileCv" runat="server" ErrorMessage="CustomValidator" Display="Dynamic" ControlToValidate="trackFile" ValidateEmptyText="True" CssClass="validation-message" OnServerValidate="trackFileCv_ServerValidate"></asp:CustomValidator>
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

        <div class="row float-right" style="margin-top: 40px;">
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
