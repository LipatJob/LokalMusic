<%@ Page Title="Artist Registration" Language="C#" MasterPageFile="~/Template/LoginLayout.master" AutoEventWireup="true" CodeBehind="Artist.aspx.cs" Inherits="LokalMusic.Account.Register.Artist" %>
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
            <h3 class="my-3">Create an Artist Account</h3>
            <small style="margin-left:auto; color:black;"> <a href="~/Account/Login" runat="server"> <u> or Sign in </u></a> </small>
        </div>

        <div class="form-group">
            <asp:Label Text="Artist Name" runat="server" />
            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"/>
        </div>

        <hr />

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
        <asp:Button ID="submitBtn" Text="Create an Account" runat="server" CssClass="btn btn-primary mb-3"/>
        <hr />
        <a href="~/Account/Register/Fan" style="text-align:center;" runat="server">Join as a Fan</a>
    </div>
</asp:Content>
