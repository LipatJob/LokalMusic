<%@ Page Title="" Language="C#" MasterPageFile="~/Template/StoreLayout.master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="LokalMusic.Account.Settings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div>
        <div>
            <asp:Label Text="Username" runat="server" />
            <asp:TextBox ID="UsernameTxt" runat="server" />
        </div>
        <div>
            <asp:Label Text="Email" runat="server" />
            <asp:TextBox ID="EmailTxt" runat="server" />
        </div>
    </div>

    <div>
        <div>
            <asp:Label Text="Old Password" runat="server" />
            <asp:TextBox ID="OldPasswordTxt" runat="server" />
        </div>

        <div>
            <asp:Label Text="New Password" runat="server" />
            <asp:TextBox ID="NewPasswordTxt" runat="server" />
        </div>

        <div>
            <asp:Label Text="Confirm New Password" runat="server" />
            <asp:TextBox ID="ConfirmNewPasswordTxt" runat="server" />
        </div>
    </div>

    <div>

    </div>
</asp:Content>
