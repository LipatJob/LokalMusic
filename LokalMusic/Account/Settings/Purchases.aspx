﻿<%@ Page Title="Purchases" Language="C#" MasterPageFile="~/Template/SettingsLayout.master" AutoEventWireup="true" CodeBehind="Purchases.aspx.cs" Inherits="LokalMusic.Account.Settings.Purchases" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SettingsContent" runat="server">
    <script> $(".purchases-nav-item").addClass("active"); </script>



    <div>
        <%-- Receipts --%>
        <h4>Purchase History</h4>
        <div class="row">
            <%-- Receipts Table --%>
            <div class="col-12">
                <table class="table table-striped table-bordered table-hover dt-responsive" id="receiptsTable">
                    <thead>
                        <tr>
                            <th>Order Id</th>
                            <th>Order Date</th>
                            <th>Amount Paid (₱)</th>
                            <th>Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
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
                    <p><b>Name : </b><span id="Name"></span></p>
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
        $(function () {
            bsCustomFileInput.init()

            $.ajax({
                type: "POST",
                url: "/Account/Settings/Purchases.aspx/GetPaymentHistory",
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
            $("#receiptsTable").DataTable(
                {
                    bLengthChange: true,
                    lengthMenu: [[5, 10, -1], [5, 10, "All"]],
                    bFilter: true,
                    bSort: true,
                    bPaginate: true,
                    data: response.d,
                    columns: [
                        { 'data': 'OrderId' },
                        { 'data': 'FormattedDate' },
                        { 'data': 'FormattedAmount' },
                        {
                            'data': 'null',
                            'render': function (data, type, row) {
                                return `<button class="btn btn-outline-danger" onclick="ViewReceipt(${row["OrderId"]}, this); return false;">Details</button></a>`;
                            },
                            "width": "15%"

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
        };

        function ViewReceipt(transactionId) {
            $.ajax({
                type: "POST",
                url: "/Account/Settings/Purchases.aspx/GetReceipt",
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
            $("#Name").text(data["Name"]);
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
