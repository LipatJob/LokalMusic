<%@ Page Title="Settings" Language="C#" MasterPageFile="~/Template/StoreLayout.master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="LokalMusic.Account.Settings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style> 
        .profile-picture{
            width:150px; 
            height:150px; 
            object-fit:cover; 
            border-radius:100%;
            border-color:black;
            border-width:2px;
            border-style:solid;
            margin:20px;
        }

        .form-control{
            max-width:100%;
            width:100%;
        }

        .item-group{
            max-width:400px;
        }

    </style>

    <div class="container mt-3">
        <div class="row ">
            <div class="col-6">
                <div class="item-group mx-auto">
                    <h5>Account Details</h5>
                    <div class="form-group">
                        <asp:Label Text="Username" runat="server" />
                        <asp:TextBox ID="UsernameTxt" runat="server" ValidateRequestMode="Disabled" CssClass="form-control" ReadOnly="true"/>
                    </div>
                    <div class="form-group">
                        <asp:Label Text="Email" runat="server" />
                        <asp:TextBox ID="EmailTxt" runat="server" ValidateRequestMode="Disabled"  CssClass="form-control" ReadOnly="true" />
                    </div>

                    <h5 class="mt-4">Profile Picture</h5>
                    <div style="display:flex; flex-direction:column; align-items:center">
                        <div style="display:flex; flex-direction:column; align-items:center; width:250px" class="mb-3">
                            <asp:Image ImageUrl="~/Content/Images/Logo.png" runat="server" CssClass="profile-picture shadow mb-3"/>
                            <div class="custom-file">
                                <asp:FileUpload id="FileUploadControl" runat="server" CssClass="form-control-file custom-file-input"/>
                                <label class="custom-file-label" for="customFile">Choose file</label>
                            </div>
                            <asp:Button Text="Update Picture" runat="server" CssClass="btn btn-primary mt-2" style="width:100%"/>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-6">
                <div id="successAlert" class="alert alert-success" role="alert" runat="server" visible="false">
                    <span id="alertMessage" runat="server"></span>
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>

                <div class="item-group mx-auto">
                    <h5>Change Password</h5>
                    <div class="form-group">
                        <asp:Label Text="Old Password" runat="server" />
                        <asp:TextBox ID="OldPasswordTxt" runat="server" type="password"  CssClass="form-control"/>
                        <asp:CustomValidator ID="OldPasswordTxtCv" ErrorMessage="Error Message" ControlToValidate="OldPasswordTxt" runat="server" OnServerValidate="OldPasswordTxtCv_ServerValidate" Display="Dynamic" ValidateEmptyText="True" CssClass="validation-message" />
                    </div>
                    <hr />
                    <div class="form-group">
                        <asp:Label Text="New Password" runat="server" />
                        <asp:TextBox ID="NewPasswordTxt" runat="server" type="password"  CssClass="form-control"/>
                        <asp:CustomValidator ID="NewPasswordTxtCv" ErrorMessage="Error Message" ControlToValidate="NewPasswordTxt" runat="server" OnServerValidate="NewPasswordTxtCv_ServerValidate" Display="Dynamic" ValidateEmptyText="True" CssClass="validation-message" />
                    </div>

                    <div class="form-group">
                        <asp:Label Text="Confirm New Password" runat="server" />
                        <asp:TextBox ID="ConfirmNewPasswordTxt" runat="server" type="password"  CssClass="form-control"/>
                        <asp:CustomValidator ID="ConfirmNewPasswordTxtCv" ErrorMessage="Error Message" ControlToValidate="ConfirmNewPasswordTxt" runat="server" OnServerValidate="ConfirmNewPasswordTxtCv_ServerValidate" Display="Dynamic" ValidateEmptyText="True"  CssClass="validation-message" />
                    </div>
                    <div style="display:flex; flex-direction: column; align-items: center; width: 100%;">
                        <asp:Button ID="submitBtn" Text="Change Password" runat="server" OnClick="submitBtn_Click" CssClass="btn btn-primary"/>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script>
        $(document).ready(function () {
          bsCustomFileInput.init()
        })
    </script>

</asp:Content>
