<%@ Page Title="Settings" Language="C#" MasterPageFile="~/Template/StoreLayout.master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="LokalMusic.Account.Settings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div>
        <div>
            <asp:Label Text="Username" runat="server" />
            <asp:TextBox ID="UsernameTxt" runat="server" ValidateRequestMode="Disabled"/>
        </div>
        <div>
            <asp:Label Text="Email" runat="server" />
            <asp:TextBox ID="EmailTxt" runat="server" ValidateRequestMode="Disabled" />
        </div>
    </div>

    <div>
        <div id="successAlert" class="alert alert-success" role="alert" runat="server" visible="false">
            <span id="alertMessage" runat="server"></span>
            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                <span aria-hidden="true">&times;</span>
            </button>
        </div>

        <div>
            <asp:Label Text="Old Password" runat="server" />
            <asp:TextBox ID="OldPasswordTxt" runat="server"  type="password"/>
            <asp:CustomValidator ID="OldPasswordTxtCv" ErrorMessage="Error Message" ControlToValidate="OldPasswordTxt" runat="server" OnServerValidate="OldPasswordTxtCv_ServerValidate" Display="Static" />
        </div>

        <div>
            <asp:Label Text="New Password" runat="server" />
            <asp:TextBox ID="NewPasswordTxt" runat="server"  type="password"/>
            <asp:CustomValidator ID="NewPasswordTxtCv" ErrorMessage="Error Message" ControlToValidate="NewPasswordTxt" runat="server" OnServerValidate="NewPasswordTxtCv_ServerValidate" Display="Static" />
        </div>

        <div>
            <asp:Label Text="Confirm New Password" runat="server" />
            <asp:TextBox ID="ConfirmNewPasswordTxt" runat="server" type="password"/>
            <asp:CustomValidator ID="ConfirmNewPasswordTxtCv" ErrorMessage="Error Message" ControlToValidate="ConfirmNewPasswordTxt" runat="server" OnServerValidate="ConfirmNewPasswordTxtCv_ServerValidate" Display="Static" />
        </div>
        <asp:Button id="submitBtn" Text="Change Password" runat="server" OnClick="submitBtn_Click" />
    </div>


</asp:Content>
