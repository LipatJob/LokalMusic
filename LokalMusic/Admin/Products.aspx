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
                    "pageLength": 8,
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
                                if (row["ProductStatus"].toUpperCase() == "WITHDRAWN") {
                                    return `<button class="btn btn-secondary" onclick="RepublishItem(${row["ProductId"]}, this); return false;">Republish</button>`;
                                }
                                return `<button class="btn btn-primary" onclick="WithdrawItem(${row["ProductId"]}, this); return false;">Withdraw</button></a>`;
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

        function WithdrawItem(id, parent) {
            $.ajax({
                type: "POST",
                url: "/Admin/Products.aspx/WithdrawItem",
                contentType: "application/json; charset=utf-8",
                data: "{ 'productId': '" + id + "' }",
                dataType: "json",
                success: function () {
                    ChangeToRepublish(id, parent);
                },
                error: function () {
                    alert("An Error has occured while unlisting the item");
                }
            });
            return false;
        }

        function ChangeToRepublish(id, item) {
            item.classList.remove('btn-primary');
            item.classList.add('btn-secondary');
            item.innerHTML = "Republish";
            item.onclick = function () { RepublishItem(id, item); return false; };
        }

        function RepublishItem(id, parent) {
            $.ajax({
                type: "POST",
                url: "/Admin/Products.aspx/RepublishItem",
                data: "{ 'productId': '" + id + "' }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function () {
                    ChangeToWithdraw(id, parent);
                },
                error: function () {
                    alert("An Error has occured while unlisting the item");
                    return false;
                }
            });
            return false;
        }

        function ChangeToWithdraw(id, item) {
            item.classList.remove('btn-secondary');
            item.classList.add('btn-primary');
            item.innerHTML = "Withdraw"
            item.onclick = function () { WithdrawItem(id, item); return false; };
        }


    </script>
</asp:Content>
