﻿<%@ Page Title="Login" Language="C#" MasterPageFile="~/Template/LoginLayout.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LokalMusic.Webforms.Account.Login" %>

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

        .submit-btn{
            margin-left: auto;
            width: 14ch;
        }
    </style>

    <div class="signin-form">
        <%-- Brand Logo --%>
        <asp:Image ImageUrl="~/Content/Images/lokal_logo_puzzle_O.png" runat="server" CssClass="login-brand-logo" style="width: 220px; height: auto; margin: 40px;"/>

        <%-- Login Header --%>
        <div class="login-header">
            <h3 class="my-3">Sign In</h3>
            <small style="margin-left: auto; color: black;"><a href="~/Account/Register/Fan" runat="server" class="text-danger"><u>or Create an Account</u></a> </small>
        </div>

        <%-- Error Message --%>
        <asp:CustomValidator ErrorMessage="Error Message" ControlToValidate="EmailTxt" runat="server" ID="loginCv" CssClass="validation-message" />

        <%-- Email --%>
        <div class="form-group">
            <asp:Label Text="Email" runat="server"  MaxLength="100"/>
            <asp:TextBox ID="EmailTxt" runat="server" CssClass="form-control" type="email" />
            <asp:RequiredFieldValidator ErrorMessage="Please enter your Email" ControlToValidate="EmailTxt" runat="server" CssClass="validation-message" Display="Dynamic"/>
        </div>

        <%-- Password --%>
        <div class="form-group">
            <asp:Label Text="Password" runat="server"  MaxLength="100"/>
            <asp:TextBox ID="PasswordTxt" runat="server" CssClass="form-control" type="password" />
            <asp:RequiredFieldValidator ErrorMessage="Please enter your password" ControlToValidate="PasswordTxt" runat="server" CssClass="validation-message" Display="Dynamic" />
        </div>

        <%-- Submit Button --%>
        <div style="display: flex; flex-direction: row;">
            <asp:Button ID="submitBtn" Text="Sign In" runat="server" CssClass="submit-btn btn btn-danger" OnClick="submitBtn_Click"/>
        </div>
    </div>
</asp:Content>