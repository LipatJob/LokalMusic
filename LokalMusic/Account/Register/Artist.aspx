﻿<%@ Page Title="Artist Registration" Language="C#" MasterPageFile="~/Template/LoginLayout.master" AutoEventWireup="true" CodeBehind="Artist.aspx.cs" Inherits="LokalMusic.Account.Register.Artist" %>
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

        .login-header{
            display:flex;
            align-items:baseline;
        }

        .form-control {
             max-width:100%;
             width:100%
        }
    </style>

    <div class="signin-form">
        <%-- Brand Logo --%>
        <asp:Image ImageUrl="~/Content/Images/Logo.png" style="width:150px; height:auto;" runat="server" CssClass="my-3"/>

        <%-- Login Header --%>
        <div class="login-header">
            <h4 class="my-3">Create an Artist Account</h4>
            <small style="margin-left:auto; color:black;"> <a href="~/Account/Login" runat="server"> <u> or Sign in </u></a> </small>
        </div>

        <%-- Artist Name --%>
         <div class="form-group">
            <asp:Label Text="Artist Name" runat="server" />
            <asp:TextBox ID="ArtistNameTxt" runat="server" CssClass="form-control"/>
            <asp:CustomValidator id="ArtistNameTxtCv" ErrorMessage="Error Message" ControlToValidate="ArtistNameTxt" runat="server" CssClass="validation-message" ValidateEmptyText="true" Display="Dynamic" OnServerValidate="ArtistNameTxtCv_ServerValidate"/>
        </div>

        <hr />

        <%-- Username --%>
        <div class="form-group">
            <asp:Label Text="Username" runat="server" />
            <asp:TextBox ID="UsernameTxt" runat="server" CssClass="form-control"/>
            <asp:CustomValidator id="UsernameTxtCv" ErrorMessage="Error Message" ControlToValidate="UsernameTxt" runat="server" OnServerValidate="UsernameTxtCv_ServerValidate" CssClass="validation-message" ValidateEmptyText="true" Display="Dynamic"/>
        </div>

        <%-- Email --%>
        <div class="form-group">
            <asp:Label Text="Email" runat="server" />
            <asp:TextBox ID="EmailTxt" runat="server" CssClass="form-control" type="email"/>
            <asp:CustomValidator id="EmailTxtCv" ErrorMessage="Error Message" ControlToValidate="EmailTxt" runat="server" OnServerValidate="EmailTxtCv_ServerValidate"  CssClass="validation-message"  ValidateEmptyText="true" Display="Dynamic"/>
        </div>

        <%-- Password --%>
        <div class="form-group">
            <asp:Label Text="Password" runat="server" />
            <asp:TextBox ID="PasswordTxt" runat="server" CssClass="form-control" type="password"/>
            <asp:CustomValidator id="PasswordTxtCv" ErrorMessage="Error Message" ControlToValidate="PasswordTxt" runat="server" OnServerValidate="PasswordTxtCv_ServerValidate"  CssClass="validation-message"  ValidateEmptyText="true" Display="Dynamic"/>
        </div>

        <%-- Confirm Password --%>
        <div class="form-group">
            <asp:Label Text="Confirm Password" runat="server" />
            <asp:TextBox ID="ConfirmPasswordTxt" runat="server" CssClass="form-control" type="password"/>
            <asp:CustomValidator id="ConfirmPasswordTxtCv" ErrorMessage="Error Message" ControlToValidate="ConfirmPasswordTxt" runat="server" OnServerValidate="ConfirmPasswordTxtCv_ServerValidate"  CssClass="validation-message"  ValidateEmptyText="true" Display="Dynamic"/>
        </div>

        <%-- TOC Checkbox --%>
        <div class="form-group">
            <asp:CheckBox runat="server" ID="TosCb"/>
            <label class="form-check-label" for="TosCb">I Agree to Lokal's Terms and Conditions</label>
            <asp:CustomValidator id="TosCbCv" ErrorMessage="<br/>Please agree to our Terms and Conditions"  runat="server"  CssClass="validation-message" OnServerValidate="TosCbCv_ServerValidate"/>
        </div>

        <%-- Register Button --%>
        <asp:Button ID="btnSubmit" Text="Create an Account" runat="server" CssClass="btn btn-primary mb-3" OnClick="submitBtn_Click"/>
        
        <hr />

        <%-- Go to Fan Signup Page --%>
        <a href="~/Account/Register/Fan" style="text-align:center;" runat="server">Create an Fan Account</a>
    </div>
</asp:Content>