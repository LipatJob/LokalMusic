﻿<%@ Page Title="Sales History" Language="C#" MasterPageFile="~/Template/FinanceLayout.master" AutoEventWireup="true" CodeBehind="SalesHistory.aspx.cs" Inherits="LokalMusic.Finance.SalesHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .items-header {
            margin-top: 12px;
            display: flex;
            align-items: center;
            margin-bottom: 20px;
        }

        .date-selection-container {
            margin-left: auto;
            display: flex;
            flex-direction: row;
        }

        .max-lines {
            display: block; /* or inline-block */
            text-overflow: ellipsis;
            word-wrap: break-word;
            overflow: hidden;
            max-height: 3.6em;
            line-height: 1.8em;
        }
    </style>

    <div>
        <%-- Receipts --%>
        <div class="items-header">
            <h2 style="margin-bottom: 0;">Sales History</h2>
            <div class="date-selection-container">
                <div class="mx-2" style="display: flex; align-items: center;">
                    <label for="startDate" style="margin-bottom: 0; padding-right: 8px;">Start </label>
                    <input type="date" name="startDate" id="startDate" class="form-control" />
                </div>

                <div class="mx-2" style="display: flex; align-items: center;">
                    <label for="endDate" style="margin-bottom: 0; padding-right: 8px;">End </label>
                    <input type="date" name="endDate" id="endDate" class="form-control" />
                </div>
            </div>
        </div>
        <hr />
        <div class="row">
            <%-- Receipts Table --%>
            <div class="col-8">
                <table class="table table-striped table-bordered table-hover dt-responsive" id="receiptsTable">
                    <thead>
                        <tr>
                            <th>Order Id</th>
                            <th>Name</th>
                            <th>Order Date</th>
                            <th>Amount (₱)</th>
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
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="col">
                <div id="mostBought">
                    <h4>Most Bought</h4>
                    <div class="card">
                        <div style="height: 8rem; display: flex;">
                            <img src="../Content/Images/default_artist_image.JPG" id="mostProductCover" style="height: 100%; width: auto;">
                            <div class="p-2 pl-4">
                                <h5 class=""><span id="mostProductName"></span></h5>
                                <p class="mb-1 "><span id="mostProductArtistName"></span></p>
                                <p><span id="mostProductType"></span></p>

                            </div>
                        </div>

                    </div>
                </div>

                <div id="leastBought" class="mt-3">
                    <h4>Least Bought</h4>
                    <div class="card">
                        <div style="height: 8rem; display: flex;">
                            <img src="../Content/Images/default_artist_image.JPG" id="leastProductCover" style="height: 100%; width: auto;">
                            <div class="p-2 pl-4">
                                <h5><span id="leastProductName"></span></h5>
                                <p class="mb-1"><span id="leastProductArtistName"></span></p>
                                <p><span id="leastProductType"></span></p>
                            </div>
                        </div>

                    </div>
                </div>

            </div>
        </div>
    </div>

    <div class="modal" tabindex="-1" role="dialog" id="receiptModal">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Order Details</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <p><b>Order ID: </b><span id="OrderId"></span></p>
                    <p><b>Name: </b><span id="Name"></span></p>
                    <p><b>Transaction Date : </b><span id="TransactionDate"></span></p>


                    <table class="table">
                        <thead>
                            <tr>
                                <th>Product</th>
                                <th>Amount</th>
                            </tr>
                        </thead>
                        <tbody id="products">
                        </tbody>
                        <tfoot>
                            <tr>
                                <td><b>Amount Paid</b></td>
                                <td><b><span id="AmountPaid"></span></b></td>
                            </tr>
                        </tfoot>
                    </table>

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        var today = new Date();
        var currentDateString = new Date().toISOString().split("T")[0];
        var lastWeekString = new Date(today.getFullYear(), today.getMonth(), today.getDate() - 7).toISOString().split("T")[0]

        datatable = initializeSalesHistoryTable();

        startDate.value = lastWeekString;
        endDate.max = currentDateString;
        endDate.value = currentDateString;
        updateSalesHistory();

        startDate.onchange = updateSalesHistory;
        endDate.onchange = updateSalesHistory;

        function initializeSalesHistoryTable() {
            var dataTable = $("#receiptsTable").DataTable(
                {
                    columns: [
                        { 'data': 'OrderId' },
                        { 'data': 'Name' },
                        { 'data': 'FormattedDate' },
                        { 'data': 'FormattedAmount', 'width': '22%' },
                        {
                            'data': 'null',
                            'render': function (data, type, row) {
                                return `<button class="btn btn-outline-danger" onclick="ViewReceipt(${row["OrderId"]}, this); return false;">Details</button></a>`;
                            },
                            'width': '15%'

                        }
                    ],
                    "columnDefs": [
                        {
                            "targets": [0],
                            "visible": false,
                            "searchable": false
                        },
                    ]
                });
            return dataTable;
        }

        function updateSalesHistory() {
            if (startDate.value > endDate.value) {
                startDate.value = endDate.value;
            }
            startDate.max = endDate.value;
            loadSalesHistory(startDate.value, endDate.value);
        }

        function loadSalesHistory(startDate, endDate) {
            data = getSalesHistoryData(startDate, endDate);
            updateHistoryTable(data["SalesItems"]);
            updateMostBought(data["MostBoughtProduct"]);
            updateLeastBought(data["LeastBoughtProduct"]);

        }

        function getSalesHistoryData(startDate, endDate) {
            historyData = null;
            $.ajax({
                type: "POST",
                url: "/Finance/SalesHistory.aspx/GetSalesHistory",
                data: `{ startDate: '${startDate}', endDate: '${endDate}'}`,
                contentType: "application/json; charset=utf-8",
                async: false,
                dataType: "json",
                success: function (data) {
                    historyData = data;
                },
                failure: function (response) {
                    alert(JSON.stringify(response));
                },
                error: function (response) {
                    alert(JSON.stringify(response));
                }
            });
            return historyData["d"];
        }

        function updateHistoryTable(data) {
            datatable.clear().draw();
            datatable.rows.add(data); // Add new data
            datatable.columns.adjust().draw(); // Redraw the DataTable
        }

        function updateMostBought(data) {
            if (data == null) {
                $("#mostBought").hide();
                return;
            } else {
                $("#mostBought").show();
            }

            $("#mostProductName").text(data["ProductName"]);
            $("#mostProductArtistName").text(data["ArtistName"]);
            $("#mostProductCover").attr("src", data["AlbumCover"]);
            $("#mostProductType").text(data["ProductType"]);

        }

        function updateLeastBought(data) {
            if (data == null) {
                $("#leastBought").hide();
                return;
            } else {
                $("#leastBought").show();
            }
            $("#leastProductName").text(data["ProductName"]);
            $("#leastProductArtistName").text(data["ArtistName"]);
            $("#leastProductCover").attr("src", data["AlbumCover"]);
            $("#leastProductType").text(data["ProductType"]);

        }





        function ViewReceipt(transactionId) {
            $.ajax({
                type: "POST",
                url: "/Finance/SalesHistory.aspx/GetReceipt",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: `{receiptId: '${transactionId}'}`,
                success: (data) => ShowReceiptModal(data["d"]),
                error: function (data) {
                    alert(JSON.stringify(data));
                }
            })
        }

        function ShowReceiptModal(data) {
            $("#receiptModal").modal('show');
            $("#Username").text(data["Username"]);
            $("#TransactionDate").text(data["FormattedDate"]);
            $("#OrderId").text(data["OrderId"]);
            $("#AmountPaid").text(data["FormattedAmountPaid"]);
            $("#products").html("");
            data["Products"].forEach((productItem) => {
                $("#products").append(`<tr> <td>${productItem["ProductName"]}</td><td>${productItem["FormattedPrice"]}</td> </tr>`)
            });
        }


    </script>
</asp:Content>
