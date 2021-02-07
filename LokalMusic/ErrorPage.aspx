<%@ Page Title="Error" Language="C#" MasterPageFile="~/Template/Site.Master" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="LokalMusic.ErrorPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        body{
            background-color: #bd4f6c;
            background-image: linear-gradient(326deg, #bd4f6c 0%, #d7816a 74%);
        }

        .card{
            background-color: #fef6fb;
            position: absolute;
            left: 50%;
            top: 50%;
            -webkit-transform: translate(-50%, -50%);
            transform: translate(-50%, -50%);
        }

        #logo{
            position: absolute;
            left: 50%;
            top: 20%;
            -webkit-transform: translate(-50%, -50%);
            transform: translate(-50%, -50%);
        }
    </style>

    <div>
        <div id="logo">
            <img src="~/Content/Images/Old Logo.png" runat="server" alt="lokal-logo" class="mx-auto d-block" width="200"/>
        </div>

        <div class="card mx-auto shadow-lg text-center" style="width:35rem;">
            <div class="card-body">
                <h1 id="errorTitle" runat="server" style="margin-top: -17px; font-weight: 700; font-size: 160px; background: -webkit-linear-gradient(326deg, #bd4f6c 0%, #d7816a 74%); -webkit-background-clip: text; -webkit-text-fill-color: transparent;">
                    <%#Eval("error") %>
                </h1>

                <p id="errorText" runat="server" style="font-size: 16px; font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-weight: 600; color: #AA3A3A;">
                    <%#Eval("description") %>
                </p>

                <div class="mt-4">
                    <a href="~/Store/Home.aspx" runat="server" class="btn btn-outline-danger badge-pill pl-4 pr-4" style="font-size: 13px; font-weight: 700;">Return Home</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
