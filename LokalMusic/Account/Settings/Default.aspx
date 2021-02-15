<%@ Page Title="Account" Language="C#" MasterPageFile="~/Template/SettingsLayout.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LokalMusic.Account.Settings.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SettingsContent" runat="server">
    <script> $(".account-nav-item").addClass("active"); </script>
    <div>
        <h5>Account Details</h5>

        <%-- First Name and Last Name --%>
        <div class="container">
            <div class="row form-group">
                <div class="col-6" style="padding: 0; padding-right: 6px;">
                    <asp:Label Text="First Name" runat="server" />
                    <asp:TextBox ID="FirstNameTxt" runat="server" ValidateRequestMode="Disabled" CssClass="form-control" ReadOnly="true" />
                </div>
                <div class="col-6" style="padding: 0; padding-left: 6px;">
                    <asp:Label Text="Last Name" runat="server" />
                    <asp:TextBox ID="LastNameTxt" runat="server" ValidateRequestMode="Disabled" CssClass="form-control" ReadOnly="true" />
                </div>
            </div>
        </div>
        <%-- Username --%>
        <div class="form-group">
            <asp:Label Text="Username" runat="server" />
            <asp:TextBox ID="UsernameTxt" runat="server" ValidateRequestMode="Disabled" CssClass="form-control" ReadOnly="true" />
        </div>

        <%-- Email --%>
        <div class="form-group">
            <asp:Label Text="Email" runat="server" />
            <asp:TextBox ID="EmailTxt" runat="server" ValidateRequestMode="Disabled" CssClass="form-control" ReadOnly="true" />
        </div>
    </div>

    <asp:Panel CssClass="item-group" runat="server" DefaultButton="submitBtnChangePassword">
        <%-- Change Password Success Alert --%>
        <div id="changePasswordSuccessAlert" class="alert alert-success" role="alert" runat="server" visible="false">
            <span id="changePasswordSuccessMessage" runat="server"></span>
            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                <span aria-hidden="true">&times;</span>
            </button>
        </div>

        <%-- Group Header --%>
        <h5>Change Password</h5>

        <%-- Old Password --%>
        <div class="form-group">
            <asp:Label Text="Old Password" runat="server"  MaxLength="100" />
            <asp:TextBox ID="OldPasswordTxt" runat="server" type="password" CssClass="form-control" />
            <asp:CustomValidator ID="OldPasswordTxtCv" ErrorMessage="Error Message" ControlToValidate="OldPasswordTxt" runat="server" OnServerValidate="OldPasswordTxtCv_ServerValidate" Display="Dynamic" ValidateEmptyText="True" CssClass="validation-message" ValidationGroup="ChangePassword" />
        </div>
        <hr />

        <%-- New Password --%>
        <div class="form-group">
            <asp:Label Text="New Password" runat="server"  MaxLength="100" />
            <asp:TextBox ID="NewPasswordTxt" runat="server" type="password" CssClass="form-control" />
            <asp:CustomValidator ID="NewPasswordTxtCv" ErrorMessage="Error Message" ControlToValidate="NewPasswordTxt" runat="server" OnServerValidate="NewPasswordTxtCv_ServerValidate" Display="Dynamic" ValidateEmptyText="True" CssClass="validation-message" ValidationGroup="ChangePassword" />
        </div>

        <%-- Confirm New Password--%>
        <div class="form-group">
            <asp:Label Text="Confirm New Password" runat="server" />
            <asp:TextBox ID="ConfirmNewPasswordTxt" runat="server" type="password" CssClass="form-control" />
            <asp:CustomValidator ID="ConfirmNewPasswordTxtCv" ErrorMessage="Error Message" ControlToValidate="ConfirmNewPasswordTxt" runat="server" OnServerValidate="ConfirmNewPasswordTxtCv_ServerValidate" Display="Dynamic" ValidateEmptyText="True" CssClass="validation-message" ValidationGroup="ChangePassword" />
        </div>

        <%-- Change Password Button--%>
        <div style="display: flex; flex-direction: column; align-items: center; width: 100%;">
            <asp:Button ID="submitBtnChangePassword" Text="Change Password" runat="server" OnClick="submitBtn_Click" CssClass="btn btn-danger" ValidationGroup="ChangePassword" />
        </div>
    </asp:Panel>

</asp:Content>
