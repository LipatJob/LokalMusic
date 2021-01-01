<%@ Page Title="Products" Language="C#" MasterPageFile="~/Template/AdminLayout.master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="LokalMusic.Admin.Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
    </style>

    <div class="container">
        <h2>Products</h2>
        <div class="row">
            <div class="col-12">
                <table class="table table-hover dt-responsive" id="productsTbl">
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Title</th>
                            <th>Artist</th>
                            <th>Product Type</th>
                            <th>Date Listed</th>
                            <th></th>
                            <th>Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        $(".productsSideItem").addClass("sidebar-active");

        $(function () {
            bsCustomFileInput.init()

            $.ajax({
                type: "POST",
                url: "/Admin/Products.aspx/GetProductList",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(JSON.stringify(response));
                },
                error: function (response) {
                    alert(JSON.stringify(response));
                }
            });
        });

        function OnSuccess(response) {
            $("#productsTbl").DataTable(
                {
                    bLengthChange: true,
                    lengthMenu: [[5, 10, -1], [5, 10, "All"]],
                    bFilter: true,
                    bSort: true,
                    bPaginate: true,
                    data: response.d,
                    columns: [
                        { 'data': 'ProductId' },
                        { 'data': 'ProductName' },
                        { 'data': 'ArtistName' },
                        { 'data': 'ProductType' },
                        { 'data': 'FormattedDateListed' },
                        {
                            data: "MarketPage",
                            render: function (data) {
                                data = `<a href="${data}"> Product Page </a>`;
                                return data;
                            }
                        },
                        {
                            'data': 'null',
                            'render': function (data, type, row) {
                                if (row["ProductStatus"] != "LISTED") {
                                    return `<button class="btn btn-secondary" onclick="RelistItem(${row["ProductId"]}, this); return false;">Relist</button>`;
                                }
                                return `<button class="btn btn-primary" onclick="UnlistItem(${row["ProductId"]}, this); return false;">Unlist</button></a>`;
                            }

                        },
                    ],
                    "columnDefs": [
                        {
                            "targets": [0],
                            "visible": false,
                            "searchable": false
                        },
                    ]
                });
        };

        function UnlistItem(id, parent) {
            $.ajax({
                type: "POST",
                url: "/Admin/Products.aspx/Unlist",
                contentType: "application/json; charset=utf-8",
                data: "{ 'productId': '" + id + "' }",
                dataType: "json",
                success: function () {
                    ChangeToRelist(id, parent);
                },
                error: function () {
                    alert("An Error has occured while unlisting the item");
                }
            });
            return false;
        }

        function ChangeToRelist(id, item) {
            item.classList.remove('btn-primary');
            item.classList.add('btn-secondary');
            item.innerHTML = "Relist";
            item.onclick = function () { RelistItem(id, item); return false;};
        }

        function RelistItem(id, parent) {
            $.ajax({
                type: "POST",
                url: "/Admin/Products.aspx/Relist",
                data: "{ 'productId': '" + id + "' }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function () {
                    ChangeToUnlist(id, parent);
                },
                error: function () {
                    alert("An Error has occured while unlisting the item");
                    return false;
                }
            });
            return false;
        }

        function ChangeToUnlist(id, item) {
            item.classList.remove('btn-secondary');
            item.classList.add('btn-primary');
            item.innerHTML = "Unlist"
            item.onclick = function () { UnlistItem(id, item); return false; };
        }


    </script>
</asp:Content>
