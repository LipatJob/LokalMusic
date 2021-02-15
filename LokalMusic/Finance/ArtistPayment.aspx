<%@ Page Title="Artist Payment" Language="C#" MasterPageFile="~/Template/FinanceLayout.master" AutoEventWireup="true" CodeBehind="ArtistPayment.aspx.cs" Inherits="LokalMusic.Finance.ArtistPayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .items-header {
            margin-top: 12px;
            display: flex;
            align-items: center;
            margin-bottom: 20px;
            width: 100%;
        }
    </style>

    <%-- Receipts --%>
    <div class="items-header">
        <h2 style="margin-bottom: 0;">Artist Payment</h2>
        <div class="" style="margin-left: auto;">
            <asp:Button Text="Pay Artists" CssClass="btn btn-danger" runat="server" ID="PayArtistsBtn" OnClick="PayArtistsBtn_Click" />
        </div>
    </div>
    <hr />

    <div class="content">
        <div class="row">
            <div class="col-6">
                <h4>Remaining Balances</h4>
                <asp:GridView ID="RemainingBalances" runat="server" CssClass="RemainingBalanceTable table" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="ArtistName" HeaderText="Artist Name" />
                        <asp:BoundField DataField="AmountDue" HeaderText="Amount Due" DataFormatString="{0:0.00}"/>
                    </Columns>
                </asp:GridView>
            </div>

            <div class="col-6">
                <h4>Recent Artist Payments</h4>
                <asp:GridView ID="ArtistPayments" runat="server" CssClass="ArtistPaymentsTable table" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="ArtistName" HeaderText="Artist Name" />
                        <asp:BoundField DataField="DatePaid" HeaderText="Date Paid" DataFormatString="{0:MMM dd yyyy}"/>
                        <asp:BoundField DataField="TransactionFee" HeaderText="Transaction Fee" DataFormatString="{0:0.00}"/>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <script>
        $(".RemainingBalanceTable").DataTable();
        $(".ArtistPaymentsTable").DataTable();

    </script>
</asp:Content>
