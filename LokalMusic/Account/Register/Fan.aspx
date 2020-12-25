<%@ Page Title="Register" Language="C#" MasterPageFile="~/Template/StoreLayout.master" AutoEventWireup="true" CodeBehind="Fan.aspx.cs" Inherits="LokalMusic.Account.Register.Fan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>

        .signin-form{
            display:flex;
            flex-direction:column;
            align-items: center;
            max-width:400px;
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
            <h3>Join Lokal</h3>
            <small style="margin-left:auto; color:black;"> <a href="~/Account/Login" runat="server"> <u> or Sign in </u></a> </small>
        </div>

        <div class="form-group">
            <asp:Label Text="Username" runat="server" />
            <asp:TextBox ID="UsernameTxt" runat="server" CssClass="form-control"/>
        </div>

        <div class="form-group">
            <asp:Label Text="Email" runat="server" />
            <asp:TextBox ID="EmailTxt" runat="server" CssClass="form-control" type="email"/>
        </div>

        <div class="form-group">
            <asp:Label Text="Password" runat="server" />
            <asp:TextBox ID="PasswordTxt" runat="server" CssClass="form-control" type="password"/>
        </div>

        <div class="form-group">
            <asp:Label Text="Confirm Password" runat="server" />
            <asp:TextBox ID="ConfirmPasswordTxt" runat="server" CssClass="form-control" type="password"/>
        </div>
        
        <div class="form-group">
            <asp:CheckBox runat="server" ID="TosCb"/>
            <label class="form-check-label" for="TosCb">I Agree to Lokal's Terms of Service</label>
        </div>
        <asp:Button Text="Create an Account" runat="server" CssClass="btn btn-primary"/>
    </div>
</asp:Content>
