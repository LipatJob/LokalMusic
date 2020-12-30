<%@ Page Language="C#" MasterPageFile="~/Template/StoreLayout.master" AutoEventWireup="true" CodeBehind="Collection.aspx.cs" Inherits="LokalMusic.Fan.Collection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .user-info-container {
            display: flex;
            flex-direction: row;
            align-items: center;
        }

        .profile-picture {
            width: 140px;
            height: 140px;
            object-fit: cover;
            border: 2px solid black;
            border-radius: 100%;
            margin: 20px;
        }

        .collection-container {
            display: grid;
            grid-gap: 2rem;
            grid-template-columns: repeat(auto-fill, minmax(190px, 1fr));
        }

        .collection-item {
            display: flex;
            flex-direction: column;
            align-items: center;
            border: 1px solid white;
            padding: 10px;
            transition: 0.1s ease-out all;
        }

            .collection-item:hover {
                transition: border 0.1s ease-in-out !important;
                border: 1px dotted #ffbaba;
            }

        .item-link:link {
            color: black;
        }

        .item-picture {
            width: 180px;
            height: 180px;
            margin-bottom: 8px;
            border: 1px solid #e0e0e0;
            object-fit: cover;
        }

        .artist-link {
            color: gray;
        }
    </style>

    <div class="container">
        <%-- User Information --%>
        <div class="user-info-container">
            <%-- Profile Picture --%>
            <asp:Image ImageUrl="imageurl" ID="profilePicture" class="profile-picture shadow" runat="server" />

            <%-- User Information --%>
            <div class="user-info">
                <%-- Username --%>
                <h3><%Response.Write(Model.Username);%></h3>

                <%-- Date Joined --%>
                <p>Member Since: <%Response.Write(Model.DateRegistered.ToShortDateString());%></p>

                <%-- Edit Profile Button --%>
                <%if (Model.UserId == AuthenticationHelper.UserId)%>
                <%{%>
                <a href="~/Account/Settings" runat="server">
                    <input type="button" name="name" value="Edit Profile" class="btn btn-primary" />
                </a>
                <%}%>
            </div>
        </div>

        <hr />

        <%-- Collection --%>
        <h3>Collection</h3>
        <div class="collection-container">
            <asp:Repeater ID="collectionItemRepeater" runat="server">
                <%-- Template for Collection Item --%>
                <ItemTemplate>
                    <%-- Like to Product Page --%>
                    <a href='<%#Eval("GetUrl")%>' class="item-link">
                        <div class="collection-item">
                            <%-- Album Cover --%>
                            <asp:Image ImageUrl='<%#Eval("CoverLink")%>' runat="server" class="item-picture" />

                            <%-- Album/Track Name --%>
                            <b><%#Eval("ProductName") %></b>

                            <%-- Artist Name --%>
                            <p>By <%#Eval("ArtistName")%></p>
                        </div>
                    </a>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>