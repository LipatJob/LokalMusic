<%@ Page Title="Sales History" Language="C#" MasterPageFile="~/Template/StoreLayout.master" AutoEventWireup="true" CodeBehind="Sales.aspx.cs" Inherits="LokalMusic.Publish.Sales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="margin-top:60px">
        <div>
            <h1><strong><asp:Label ID="ArtistName" runat="server" Text="Artist/Band Name"></asp:Label></strong></h1>
            <hr />
        </div>
        <div style="margin-top:30px">
            <h4>Sales History</h4>
            <div class="row" style="margin-top:20px">
                <div class="col-12">
                    <table id="salesTable" class="table table-striped table-bordered table-hover dt-responsive">
                        <thead>
                            <tr>
                                <th>Transaction ID</th>
                                <th>Date</th>
                                <th>Customer</th>
                                <th>Products</th>
                                <th>Total Price</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="SalesItemRepeater" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%#Eval("TransactionID") %></td>
                                        <td><%#Eval("Date") %></td>
                                        <td><%#Eval("Customer") %></td>
                                        <td><%#Eval("Products") %></td>
                                        <td><%#Eval("TotalPrice") %></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

