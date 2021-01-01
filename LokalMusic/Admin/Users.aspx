<%@ Page Title="Users" Language="C#" MasterPageFile="~/Template/AdminLayout.master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="LokalMusic.Admin.Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <h2>Users</h2>
        <div class="row">
            <div class="col-12">
                <table class="table table-hover dt-responsive" id="productsTbl">
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Username</th>
                            <th>Email</th>
                            <th>Date Registered</th>
                            <th>UserType</th>
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
        $(".usersSideItem").addClass("sidebar-active");


        $(function () {
            bsCustomFileInput.init()

            $.ajax({
                type: "POST",
                url: "/Admin/Users.aspx/GetUsers",
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
                        { 'data': 'UserId' },
                        { 'data': 'Username' },
                        { 'data': 'Email' },
                        { 'data': 'FormattedDate' },
                        { 'data': 'UserType' },
                        {
                            data: "ProfilePage",
                            render: function (data) {
                                data = `<a href="${data}"> Product Page </a>`;
                                return data;
                            }
                        },
                        {
                            'data': 'null',
                            'render': function (data, type, row) {
                                if (row["UserStatus"] != "ACTIVE") {
                                    return `<button class="btn btn-secondary" onclick="ReactivateUser(${row["UserId"]}, this); return false;">Reactivate</button>`;
                                }
                                return `<button class="btn btn-primary" onclick="DeactivateUser(${row["UserId"]}, this); return false;">Deactivate</button></a>`;
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

        function DeactivateUser(id, parent) {
            $.ajax({
                type: "POST",
                url: "/Admin/Users.aspx/DeactivateUser",
                contentType: "application/json; charset=utf-8",
                data: `{ 'userId' : '${id}'}`,
                dataType: "json",
                success: function () {
                    ChangeToReactivate(id, parent);
                },
                error: function () {
                    alert("An Error has occured while unlisting the item");
                }
            });
            return false;
        }

        function ChangeToReactivate(id, item) {
            item.classList.remove('btn-primary');
            item.classList.add('btn-secondary');
            item.innerHTML = "Reactivate";
            item.onclick = function () { ReactivateUser(id, item); return false; };
        }

        function ReactivateUser(id, parent) {
            $.ajax({
                type: "POST",
                url: "/Admin/Users.aspx/ReactivateUser",
                data: `{ 'userId' : '${id}'}`,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function () {
                    ChangeToDeactivate(id, parent);
                },
                error: function () {
                    alert("An Error has occured while unlisting the item");
                    return false;
                }
            });
            return false;
        }

        function ChangeToDeactivate(id, item) {
            item.classList.remove('btn-secondary');
            item.classList.add('btn-primary');
            item.innerHTML = "Deactivate"
            item.onclick = function () { DeactivateUser(id, item); return false; };
        }


    </script>

</asp:Content>
