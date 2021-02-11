<%@ Page Title="Finance Report" Language="C#" MasterPageFile="~/Template/FinanceLayout.master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="LokalMusic.Finance.Reports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .items-container {
            display: flex;
            flex-direction: column;
            height: 100%;
        }

        .figure-container {
            display: flex;
            flex-direction: row;
        }

        .figure-item:nth-child(1) {
            border-color: #ffb7b7;
        }

        .figure-item:nth-child(2) {
            border-color: #ffc9c9;
        }

        .figure-item:nth-child(3) {
            border-color: #ffdbdb;
        }

        .figure-item:nth-child(4) {
            border-color: #ffeded;
        }

        .figure-item {
            width: 300px;
            height: 140px;
            margin: 10px;
            padding: 20px;
            border-style: solid;
            border-width: 3px;
            border-radius: 10px;
        }

        .figure-amount {
            font-weight: 700;
            font-size: 32px;
        }

        .graph-container {
            flex-grow: 1;
            margin: 14px;
            padding: 16px;
            border: 3px solid #ffdbdb;
            border-radius: 10px;
        }

        #graph {
        }

        .items-header {
            margin-top: 12px;
            display: flex;
            align-items: center;
        }

        .date-selection-container {
            margin-left: auto;
            display: flex;
            flex-direction: row;
        }
    </style>
    <div class="items-container">
        <div class="items-header">
            <h2>Finance Report</h2>
            <div class="date-selection-container">
                <div class="mx-2">
                    <label for="startDate">Start Date </label>
                    <input type="date" name="startDate" id="startDate" class="form-control"/>
                </div>

                <div class="mx-2">
                    <label for="endDate">End Date </label>
                    <input type="date" name="endDate" id="endDate" class="form-control"/>
                </div>
                <div class="mx-2">
                    <label for="frequency">Frequency</label>
                    <select class="date-range-selector form-control" name="frequency" id="frequency">
                        <option class="dropdown-item" value="WEEKLY">Weekly</option>
                        <option class="dropdown-item" value="MONTHLY">Monthly</option>
                        <option class="dropdown-item" value="YEARLY">Yearly</option>
                    </select>
                </div>
        </div>
    </div>
    <div class="figure-container">
        <%-- Net Sales --%>
        <div class="figure-item">
            <h5>Net Sales</h5>
            <span class="figure-amount" id="netSales">0</span>

        </div>

        <%-- Gross Sales --%>
        <div class="figure-item">
            <h5>Gross Sales</h5>
            <span class="figure-amount" id="grossSales">0</span>

        </div>

        <%-- Total Artist Revenue --%>
        <div class="figure-item">
            <h5>Total Artist Revenue </h5>
            <span class="figure-amount" id="totalArtistRevenue">0</span>

        </div>

        <%-- Products Sold --%>
        <div class="figure-item">
            <h5>Products Sold</h5>
            <span class="figure-amount" id="productsSold">0</span>
        </div>
    </div>

    <%-- Graph --%>
    <div class="graph-container">
        <canvas id="graph"></canvas>
    </div>
    </div>
    <script>
        var ctx = document.getElementById('graph').getContext('2d');
        var chart = new Chart(ctx, {
            type: 'bar',
            data: {},
            options: {
                responsive: true,
                maintainAspectRatio: false,
                scales: {
                    xAxes: [{
                        stacked: true
                    }],
                    yAxes: [{
                        stacked: true,
                        ticks: {
                            beginAtZero: true
                        }
                    }]
                }
            }
        });

        var today = new Date();
        var currentDateString = new Date().toISOString().split("T")[0];
        var lastWeekString = new Date(today.getFullYear(), today.getMonth(), today.getDate() - 7).toISOString().split("T")[0]


        startDate.value = lastWeekString;
        endDate.max = currentDateString;
        endDate.value = currentDateString;
        frequency.value = "WEEKLY";
        updateReport();


        startDate.onchange = function () {
            checkDate();
            updateReport();
        }
        endDate.onchange = function () {
            checkDate();
            $("#startDate").attr({
                "max": endDate.value,
            });
            updateReport();
        }
        frequency.onchange = function () { updateReport(); }


        function checkDate()
        {
            if (startDate.value > endDate.value) {
                startDate.value = endDate.value;
            }
        }

        function updateReport() {
            callWebService(startDate.value, endDate.value, frequency.value);
        }

        function callWebService(startDate, endDate, frequency) {
            $.ajax({
                type: "POST",
                url: "/Finance/Reports.aspx/GetReportData",
                data: `{ startDate: '${startDate}', endDate: '${endDate}', frequency: '${frequency}'}`,
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: updateData,
                error: function (e) {
                    console.log(JSON.stringify(e));
                }
            })
        }

        function updateData(response) {
            updateFigures(response["d"].figures);
            updateChart(response["d"].chart);
        }

        function updateFigures(response) {
            $("#netSales").text(response.NetSales);
            $("#grossSales").text(response.GrossSales);
            $("#totalArtistRevenue").text(response.TotalArtistRevenue);
            $("#productsSold").text(response.ProductsSold);


        }

        function updateChart(response)
        {
            removeData(chart);
            addData(chart, response.labels, response.data);
        }

        function addData(chart, labels, data) {
            var newDataset = {
                label: "Sales",
                backgroundColor: 'rgba(255, 92, 92, .5)',
                data: data,
            }

            chart.data.labels.push(...labels);
            chart.data.datasets.push(newDataset);
            chart.update();
        }

        function removeData(chart) {
            chart.data.labels = [];
            chart.data.datasets = [];
            chart.update();
        }


    </script>
</asp:Content>
