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

        .item-link:link, .item-link:visited {
            color: black;
        }

        .item-link:hover {
            text-decoration: none;
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

        .view-playlist{
            font-weight: 500;
            font-size: 12px;
            border: solid;
            border-width: 1px;
            border-color: #dc3545;
            border-radius: 5px;
            padding: 3px 6px;
        }

        .view-playlist:hover{
            text-decoration:none;
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
                <a href="~/Account/Settings/Profile" runat="server">
                    <input type="button" name="name" value="Edit Profile" class="btn btn-danger" />
                </a>
                <%}%>
            </div>
        </div>

        <hr />

        <%-- Collection --%>
        <div style="display:flex; flex-direction:row; align-items:flex-end; margin-bottom:12px;">
        <h3 style="margin-bottom: 0; margin-right: 12px;">Collection</h3>
            <div>
                <%if (Model.UserId == AuthenticationHelper.UserId) %>
            <%{%>
                <a href="/Fan/Playlist" class="view-playlist text-danger">View Playlist</a>
            <%}%>
            </div>
        </div>
        <div class="collection-container">
            <asp:Repeater ID="collectionItemRepeater" runat="server">
                <%-- Template for Collection Item --%>
                <ItemTemplate>
                    <%-- Like to Product Page --%>

                    <%--album--%>
                    <a href='<%#Eval("GetUrl")%>' class="item-link <%# Eval("ProductType").ToString().ToLower().Equals("album") ? "" : "d-none" %>">
                        <div class="collection-item">
                            <%-- Album Cover --%>
                            <asp:Image ImageUrl='<%#Eval("CoverLink")%>' runat="server" class="item-picture" />

                            <%-- Album/Track Name --%>
                            <b><%#Eval("ProductName") %></b>

                            <%-- Artist Name --%>
                            <p>By <%#Eval("ArtistName")%></p>
                        </div>
                    </a>

                    <%--track--%>
                    <a href="#" onclick='<%# "GetTrack(" +Eval("TrackId") + " );" %>' class="item-link text-dark <%# Eval("ProductType").ToString().ToLower().Equals("track") ? "" : "d-none" %>">
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
          <%if (collectionItemRepeater.Items.Count == 0) %>
            <%{%>
            <div style="width:100%; text-align:center; height: 300px; margin-top:50px;">
                <p style="font-size:26px;">
                    <%if(Model.UserId == AuthenticationHelper.UserId)%>
                    <%{%>
                        Buy Your first Album/Track on the <a href="~/Store/Search" runat="server" class="text-danger">Store</a>
                    <%}%>
                    <%else%>
                    <%{%>
                        <%=Model.Username%> Doesn't have Anything in their Collection
                    <%}%>

                </p>
            </div>
            <%}%>
    </div>
</asp:Content>
