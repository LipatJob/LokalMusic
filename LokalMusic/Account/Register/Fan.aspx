<%@ Page Title="Register" Language="C#" MasterPageFile="~/Template/LoginLayout.master" AutoEventWireup="true" CodeBehind="Fan.aspx.cs" Inherits="LokalMusic.Account.Register.Fan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .signin-form {
            display: flex;
            flex-direction: column;
            align-items: center;
            max-width: 450px;
            margin: auto;
        }

            .signin-form > * {
                max-width: 100%;
                width: 100%
            }

        .login-header {
            display: flex;
            align-items: baseline;
        }

        .form-control {
            max-width: 100%;
            width: 100%
        }
    </style>

    <div class="signin-form">
        <%-- Brand Logo --%>
        <asp:Image ImageUrl="~/Content/Images/lokal_logo_puzzle_O.png" runat="server" CssClass="login-brand-logo" style="width: 220px; height: auto; margin: 40px;"/>

        <%-- Login Header --%>
        <div class="login-header">
            <h4 class="my-3">Create a Fan Account</h4>
            <small style="margin-left: auto; color: black;"><a href="~/Account/Login" class="text-danger" runat="server"><u>or Sign in </u></a></small>
        </div>

        <%-- First Name and Last Name--%>
        <div class="row form-group">
            <div class="col-6" style="padding: 0; padding-right: 6px;">
                <asp:Label Text="First Name" runat="server" />
                <asp:TextBox ID="FirstNameTxt" runat="server" CssClass="form-control"  MaxLength="100" />
                <asp:RequiredFieldValidator ErrorMessage="This is a required field" ControlToValidate="FirstNameTxt" runat="server" CssClass="validation-message" Display="Dynamic" />
            </div>
            <div class="col-6" style="padding: 0; padding-left: 6px;">
                <asp:Label Text="Last Name" runat="server" />
                <asp:TextBox ID="LastNameTxt" runat="server" CssClass="form-control"  MaxLength="100" />
                <asp:RequiredFieldValidator ErrorMessage="This is a required field" ControlToValidate="LastNameTxt" runat="server" CssClass="validation-message" Display="Dynamic" />
            </div>
        </div>

        <%-- Username --%>
        <div class="form-group">
            <asp:Label Text="Username" runat="server" />
            <asp:TextBox ID="UsernameTxt" runat="server" CssClass="form-control"  MaxLength="100" />
            <asp:CustomValidator ID="UsernameTxtCv" ErrorMessage="Error Message" ControlToValidate="UsernameTxt" runat="server" OnServerValidate="UsernameTxtCv_ServerValidate" CssClass="validation-message" ValidateEmptyText="true" Display="Dynamic" />
        </div>

        <%-- Email --%>
        <div class="form-group">
            <asp:Label Text="Email" runat="server" />
            <asp:TextBox ID="EmailTxt" runat="server" CssClass="form-control" type="email"  MaxLength="100" />
            <asp:CustomValidator ID="EmailTxtCv" ErrorMessage="Error Message" ControlToValidate="EmailTxt" runat="server" OnServerValidate="EmailTxtCv_ServerValidate" CssClass="validation-message" ValidateEmptyText="true" Display="Dynamic" />
        </div>

        <%-- Password --%>
        <div class="form-group">
            <asp:Label Text="Password" runat="server" />
            <asp:TextBox ID="PasswordTxt" runat="server" CssClass="form-control" type="password"  MaxLength="100" />
            <asp:CustomValidator ID="PasswordTxtCv" ErrorMessage="Error Message" ControlToValidate="PasswordTxt" runat="server" OnServerValidate="PasswordTxtCv_ServerValidate" CssClass="validation-message" ValidateEmptyText="true" Display="Dynamic" />
        </div>

        <%-- Confirm Password --%>
        <div class="form-group">
            <asp:Label Text="Confirm Password" runat="server" />
            <asp:TextBox ID="ConfirmPasswordTxt" runat="server" CssClass="form-control" type="password"  MaxLength="100" />
            <asp:CustomValidator ID="ConfirmPasswordTxtCv" ErrorMessage="Error Message" ControlToValidate="ConfirmPasswordTxt" runat="server" OnServerValidate="ConfirmPasswordTxtCv_ServerValidate" CssClass="validation-message" ValidateEmptyText="true" Display="Dynamic" />

        </div>

        <%-- TOC Checkbox--%>
        <div class="form-group">
            <asp:CheckBox runat="server" ID="TosCb" />
            <label class="form-check-label" for="TosCb">I Agree to Lokal's Terms and Conditions</label>
            <asp:CustomValidator ID="TosCbCv" ErrorMessage="<br/>Please agree to our Terms and Conditions" runat="server" CssClass="validation-message" OnServerValidate="TosCbCv_ServerValidate" />
        </div>

        <%-- Register Button--%>
        <asp:Button ID="submitBtn" Text="Create an Account" runat="server" CssClass="btn btn-danger mb-3" OnClick="submitBtn_Click" />

        <hr />

        <%-- Go to Artist Signup Page --%>
        <a href="~/Account/Register/Artist" class="text-danger" style="text-align: center; margin-bottom: 40px;" runat="server">Create an Artist Account</a>
    </div>
</asp:Content>
