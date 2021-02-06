<%@ Page Title="Purchases" Language="C#" MasterPageFile="~/Template/SettingsLayout.master" AutoEventWireup="true" CodeBehind="Purchases.aspx.cs" Inherits="LokalMusic.Account.Settings.Purchases" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SettingsContent" runat="server">
    <script> $(".purchases-nav-item").addClass("active"); </script>

    <%-- Purchase History --%>
    <h4>Purchase History</h4>
    <div class="row">
        <%-- Purchase History Table --%>
        <div class="col-12">
            <table class="table table-striped table-bordered table-hover dt-responsive" id="purchaseHistoryGv">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Time Purchased</th>
                        <th>Items Purchased</th>
                        <th>Amount</th>
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
            $("#purchaseHistoryGv").DataTable(
                {
                    bLengthChange: true,
                    lengthMenu: [[5, 10, -1], [5, 10, "All"]],
                    bFilter: true,
                    bSort: true,
                    bPaginate: true,
                    data: response.d,
                    columns: [
                        { 'data': 'TransactionId' },
                        { 'data': 'FormattedDate', "width": "25%" },
                        { 'data': 'ItemsPurchased', "width": "50%" },
                        { 'data': 'Amount', "width": "25%" }],
                    "columnDefs": [
                        {
                            "targets": [0],
                            "visible": false,
                            "searchable": false
                        },
                    ]
                });
        };
    </script>
</asp:Content>
