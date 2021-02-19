<%@ Page Title="Products" Language="C#" MasterPageFile="~/Template/AdminLayout.master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="LokalMusic.Admin.Products" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .action-btn {
            width: 100px;
        }
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

                        
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate><%# MiscUtils.UppercaseFirstOnly(Eval("StatusName").ToString()) %> </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText=" ">
                            <ItemTemplate>
                                <div 
                                    runat="server"
                                    visible=<%# Eval("StatusName").ToString().ToUpper() == "PUBLISHED"%>>
                                    <a target="_blank"
                                        href='<%# GetMarketPage((string) Eval("ProductType"), (int) Eval("ArtistId"), (int) Eval("AlbumId"), (int) Eval("ProductId"))%> '
                                        class="text-danger">
                                        Product Page
                                    </a>
                                </div>
                                <div
                                    runat="server"
                                    visible=<%# Eval("StatusName").ToString().ToUpper() != "PUBLISHED"%>>
                                    <p class="text-secondary">Unavailable</p>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:Button
                                    Text='<%# Eval("StatusName").ToString().ToUpper() == "WITHDRAWN" ? "Relist" : "Withdraw" %>' runat="server"
                                    CommandName="UnlistRepublish"
                                    CommandArgument='<%#Eval("ProductId")%>'
                                    Enabled='<%#     Eval("ArtistStatus").ToString().ToUpper() == "ACTIVE"
                                                    && !(Eval("AlbumStatusName").ToString().ToUpper() == "WITHDRAWN" 
                                                    && Eval("ProductType").ToString().ToUpper() == "TRACK")%>'
                                    CssClass='<%# Eval("StatusName").ToString().ToUpper() == "WITHDRAWN" ? "btn btn-secondary action-btn" : "btn btn-outline-danger action-btn" %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                </asp:GridView>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        $(".productsSideItem").addClass("sidebar-active");

        $(".productsGv").DataTable({
            "stateSave": true,
            "stateDuration": 60 * 10,
        });
    </script>
</asp:Content>
