<%@ Page Title="Lokal - Login" Language="C#" MasterPageFile="~/Template/StoreLayout.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LokalMusic.Webforms.Account.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div class="input-group">
            <asp:Label ID="emailLbl" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="emailTxt" runat="server" />
        </div>
        <div>
            <asp:Label ID="passwordLbl" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="passwordTxt" runat="server" TextMode="Password" />
        </div>
    </div>
    
    <asp:Button ID="submitBtn" Text="Login" runat="server" OnClick="submitBtn_Click" />
</asp:Content>
   