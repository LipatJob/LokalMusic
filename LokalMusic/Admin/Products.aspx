<%@ Page Title="Products" Language="C#" MasterPageFile="~/Template/AdminLayout.master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="LokalMusic.Admin.Products" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
    </style>

    <div class="container">
        <h2>Products</h2>
        <div class="row">
            <div class="col-12">
                <asp:GridView ID="ProductsGridView" runat="server" AutoGenerateColumns="False" CssClass="table table-hover dt-responsive productsGv" OnRowCommand="ProductsGridView_RowCommand">
                    <Columns>
                        <asp:BoundField HeaderText="Title" DataField="ProductName" />
                        <asp:BoundField HeaderText="Artist" DataField="ArtistName" />
                        <asp:TemplateField HeaderText="Product Type">
                            <ItemTemplate><%# MiscUtils.UppercaseFirstOnly(Eval("ProductType").ToString()) %> </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Date Added" DataField="DateAdded" DataFormatString="{0:MMM dd yyyy}" />



                        <asp:TemplateField HeaderText=" ">
                            <ItemTemplate>
                                <a href='<%# Eval("StatusName").ToString().ToUpper() == "PUBLISHED" ? GetMarketPage((string) Eval("ProductType"), (int) Eval("ArtistId"), (int) Eval("AlbumId"), (int) Eval("ProductId")) : "#"%> ' 
                                    class='<%# Eval("StatusName").ToString().ToUpper() == "PUBLISHED" ? "text-danger" : "text-secondary" %>'>
                                    <%# Eval("StatusName").ToString().ToUpper() == "PUBLISHED" ? "Product Page" : "Unavailable" %>
                                </a>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:Button
                                    Text='<%# Eval("StatusName").ToString().ToUpper() == "WITHDRAWN" ? "Relist" : "Withdraw" %>' runat="server"
                                    CommandName="UnlistRepublish"
                                    CommandArgument='<%#Eval("ProductId")%>'
                                    Enabled=<%# !(Eval("AlbumStatusName").ToString().ToUpper() == "WITHDRAWN" && Eval("ProductType").ToString().ToUpper() == "TRACK")%>
                                    CssClass='<%# Eval("StatusName").ToString().ToUpper() == "WITHDRAWN" ? "btn btn-secondary" : "btn btn-outline-danger" %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                </asp:GridView>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        $(".productsGv").DataTable({
            "stateSave": true,
            "stateDuration": 60 * 10,
        });
    </script>
</asp:Content>
