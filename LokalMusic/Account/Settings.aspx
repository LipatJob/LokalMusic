<%@ Page Title="Settings" Language="C#" MasterPageFile="~/Template/StoreLayout.master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="LokalMusic.Account.Settings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .item-group {
            max-width: 400px;
        }

        .form-control {
            max-width: 100%;
            width: 100%;
        }

        .profile-picture {
            width: 150px;
            height: 150px;
            object-fit: cover;
            margin: 20px;
            border: 2px solid black;
            border-radius: 100%;
        }

        .change-profile-picture-container {
            display: flex;
            flex-direction: column;
            align-items: center
        }

        .change-profile-picture {
            display: flex;
            flex-direction: column;
            align-items: center;
            width: 250px
        }

        #purchaseHistoryGv {
            width: 100%;
        }
    </style>

    <div class="container mt-3">
        <%-- Account Settings --%>
        <h4>Account Settings</h4>
        <div class="row mt-4">
            <%-- Account Details and Profile Picture --%>
            <div class="col-6">
                <div class="item-group mx-auto">
                    <%-- Account Details --%>
                    <div>
                        <h5>Account Details</h5>

                        <%-- Username --%>
                        <div class="form-group">
                            <asp:Label Text="Username" runat="server" />
                            <asp:TextBox ID="UsernameTxt" runat="server" ValidateRequestMode="Disabled" CssClass="form-control" ReadOnly="true" />
                        </div>

                        <%-- Email --%>
                        <div class="form-group">
                            <asp:Label Text="Email" runat="server" />
                            <asp:TextBox ID="EmailTxt" runat="server" ValidateRequestMode="Disabled" CssClass="form-control" ReadOnly="true" />
                        </div>
                    </div>

                    <%-- Profile Picture --%>
                    <div>
                        <%-- Profile Picture Display--%>
                        <h5 class="mt-4">Profile Picture</h5>
                        <div class="change-profile-picture-container">
                            <div class="change-profile-picture mb-3">
                                <%-- Profile Picture--%>
                                <asp:Image ID="ProfilePictureImg" ImageUrl="~/Content/Images/Logo.png" runat="server" CssClass="profile-picture shadow mb-3" />

                                <%-- Profile Picture File Upload--%>
                                <div class="custom-file">
                                    <asp:FileUpload runat="server" ID="ProfilePictureFile" CssClass="form-control-file custom-file-input" accept="image/*"/>
                                    <label class="custom-file-label" for="customFile">Choose file</label>
                                </div>

                                <%-- Submit Profile Picture--%>
                                <asp:Button ID="submitProfilePicture" Text="Update Picture" runat="server" CssClass="btn btn-primary mt-2" Style="width: 100%" OnClick="submitProfilePicture_Click" ValidationGroup="ChangeProfilePicture" />
                                <asp:CustomValidator ID="ProfilePictureFileCv" ErrorMessage="Error Message" ControlToValidate="ProfilePictureFile" runat="server" ValidationGroup="ChangeProfilePicture" OnServerValidate="ProfilePictureFileCv_ServerValidate" CssClass="validation-message" Display="Dynamic" />
                                
                            </div>
                        </div>

                        <%-- Profile Picture Changed Alert --%>
                        <div id="changeProfilePictureAlert" class="alert alert-success" role="alert" runat="server" visible="false">
                            <span id="changeProfilePictureMessage" runat="server"></span>
                            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-6">
                <div id="changePasswordSuccessAlert" class="alert alert-success" role="alert" runat="server" visible="false">
                    <span id="changePasswordSuccessMessage" runat="server"></span>
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>

                <div class="item-group mx-auto">
                    <h5>Change Password</h5>
                    <div class="form-group">
                        <asp:Label Text="Old Password" runat="server" />
                        <asp:TextBox ID="OldPasswordTxt" runat="server" type="password" CssClass="form-control" />
                        <asp:CustomValidator ID="OldPasswordTxtCv" ErrorMessage="Error Message" ControlToValidate="OldPasswordTxt" runat="server" OnServerValidate="OldPasswordTxtCv_ServerValidate" Display="Dynamic" ValidateEmptyText="True" CssClass="validation-message" ValidationGroup="ChangePassword" />
                    </div>
                    <hr />
                    <div class="form-group">
                        <asp:Label Text="New Password" runat="server" />
                        <asp:TextBox ID="NewPasswordTxt" runat="server" type="password" CssClass="form-control" />
                        <asp:CustomValidator ID="NewPasswordTxtCv" ErrorMessage="Error Message" ControlToValidate="NewPasswordTxt" runat="server" OnServerValidate="NewPasswordTxtCv_ServerValidate" Display="Dynamic" ValidateEmptyText="True" CssClass="validation-message" ValidationGroup="ChangePassword" />
                    </div>

                    <div class="form-group">
                        <asp:Label Text="Confirm New Password" runat="server" />
                        <asp:TextBox ID="ConfirmNewPasswordTxt" runat="server" type="password" CssClass="form-control" />
                        <asp:CustomValidator ID="ConfirmNewPasswordTxtCv" ErrorMessage="Error Message" ControlToValidate="ConfirmNewPasswordTxt" runat="server" OnServerValidate="ConfirmNewPasswordTxtCv_ServerValidate" Display="Dynamic" ValidateEmptyText="True" CssClass="validation-message" ValidationGroup="ChangePassword" />
                    </div>
                    <div style="display: flex; flex-direction: column; align-items: center; width: 100%;">
                        <asp:Button ID="submitBtn" Text="Change Password" runat="server" OnClick="submitBtn_Click" CssClass="btn btn-primary" ValidationGroup="ChangePassword" />
                    </div>
                </div>
            </div>
        </div>

        <hr />

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
    </div>

    <script type="text/javascript">
        $(function () {
            bsCustomFileInput.init()

            $.ajax({
                type: "POST",
                url: "/Account/Settings.aspx/GetPaymentHistory",
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