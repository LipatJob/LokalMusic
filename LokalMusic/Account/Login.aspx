<%@ Page Title="Lokal - Login" Language="C#" MasterPageFile="~/Template/LoginLayout.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LokalMusic.Webforms.Account.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
    .signin-form{
            display:flex;
            flex-direction:column;
            align-items: center;
            max-width:450px;
            margin: auto;

        }

        .signin-form > *{
             max-width:100%; 
             width:100%
        }

        .form-control {
             max-width:100%; 
             width:100%
        }

        .login-header{
            display:flex;
            align-items:baseline;
        }
    </style>

    <div class="signin-form mx-auto">

        <asp:Image ImageUrl="~/Content/Images/Logo.png" style="width:150px; height:auto;" runat="server" CssClass="my-3"/>

        <div class="login-header">
            <h3 class="my-3">Sign In</h3>
            <small style="margin-left:auto; color:black;"> <a href="~/Account/Register/Fan" runat="server"> <u> or Create an Account</u></a> </small>
        </div>

        <div class="form-group">
            <asp:Label Text="Email" runat="server" />
            <asp:TextBox ID="EmailTxt" runat="server" CssClass="form-control" type="email"/>
        </div>

        <div class="form-group">
            <asp:Label Text="Password" runat="server" />
            <asp:TextBox ID="PasswordTxt" runat="server" CssClass="form-control" type="password"/>
        </div>

        <div  style="display:flex; flex-direction: row;">
            <a href="#"> <u>Forgot your Password</u> </a>
            <asp:Button ID="submitBtn" Text="Sign In" runat="server" CssClass="btn btn-primary"  style="margin-left: auto; width:14ch;"/>
        </div>
        
    </div>
</asp:Content>
   