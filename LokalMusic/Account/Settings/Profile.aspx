<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Template/SettingsLayout.master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="LokalMusic.Account.Settings.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SettingsContent" runat="server">
    <script> $(".profile-nav-item").addClass("active"); </script>

    <%if (AuthenticationHelper.UserType == AuthenticationHelper.ARTIST_USER_TYPE)%>
    <%{%>
    <asp:Panel CssClass="item-group mx-auto" runat="server" DefaultButton="submitBtnUpdateBio">
        <%-- Change Bio Success Alert --%>
        <div id="changeBioSuccessAlert" class="alert alert-success" role="alert" runat="server" visible="false">
            <span id="changeBioSuccessMessage" runat="server"></span>
            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                <span aria-hidden="true">&times;</span>
            </button>
        </div>
        <h5>Artist Information</h5>
        <div class="form-group">
            <asp:Label Text="Artist Name" runat="server" />
            <asp:TextBox ID="ArtistNameTxt" runat="server" ValidateRequestMode="Disabled" CssClass="form-control" ReadOnly="true" />
        </div>
        <div class="form-group">
            <asp:Label Text="Bio" runat="server" />
            <asp:TextBox ID="BioTxt" runat="server" CssClass="form-control" TextMode="MultiLine" ValidationGroup="UpdateBio" />
        </div>
        <%-- Update Bio Button--%>
        <div style="display: flex; flex-direction: column; width: 100%;">
            <asp:CustomValidator ID="BioTxtCv" ErrorMessage="Error Message" ControlToValidate="BioTxt" runat="server" Display="Dynamic" ValidateEmptyText="True" CssClass="validation-message" ValidationGroup="ChangePassword" OnServerValidate="BioTxtCv_ServerValidate" />
            <asp:Button ID="submitBtnUpdateBio" Text="Update Bio" runat="server" OnClick="submitBtnUpdateBio_Click" CssClass="btn btn-danger submitBtnUpdateBio" ValidationGroup="UpdateBio" />
        </div>
    </asp:Panel>
    <%} %>

    <%-- Profile Picture --%>
    <div>
        <%-- Profile Picture Display--%>
        <h5 class="mt-4">Profile Picture</h5>
        <div class="change-profile-picture-container">
            <div class="change-profile-picture mb-3">
                <%-- Profile Picture--%>
                <asp:Image ID="ProfilePictureImg" ImageUrl="~/Content/Images/Logo.png" runat="server" CssClass="profile-picture shadow mb-3" />

                <%-- Profile Picture File Upload--%>
                <div class="custom-file">
                    <asp:FileUpload runat="server" ID="ProfilePictureFile" CssClass="form-control-file custom-file-input" accept="image/*" />
                    <label class="custom-file-label" for="customFile">Choose file</label>
                </div>

                <%-- Submit Profile Picture--%>
                <asp:Button ID="submitProfilePicture" Text="Update Picture" runat="server" CssClass="btn btn-danger mt-2" Style="width: 100%" OnClick="submitProfilePicture_Click" ValidationGroup="ChangeProfilePicture" />
                <asp:CustomValidator ID="ProfilePictureFileCv" ErrorMessage="Error Message" ControlToValidate="ProfilePictureFile" runat="server" ValidationGroup="ChangeProfilePicture" OnServerValidate="ProfilePictureFileCv_ServerValidate" CssClass="validation-message" Display="Dynamic" />

            </div>
        </div>

        <%-- Profile Picture Changed Alert --%>
        <div id="changeProfilePictureAlert" class="alert alert-success" role="alert" runat="server" visible="false">
            <span id="changeProfilePictureMessage" runat="server"></span>
            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                <span aria-hidden="true">&times;</span>
            </button>
        </div>
    </div>
</asp:Content>
