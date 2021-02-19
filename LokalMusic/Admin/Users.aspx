<%@ Page Title="Users" Language="C#" MasterPageFile="~/Template/AdminLayout.master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="LokalMusic.Admin.Users" MaintainScrollPositionOnPostback="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">




    <div class="container">
        <h2>Users</h2>
        <div class="row">
            <div class="col-12">
                <asp:GridView ID="UsersGridView" runat="server" AutoGenerateColumns="False" CssClass="table table-hover dt-responsive usersGv" OnRowCommand="UsersGridView_RowCommand">
                    <Columns>
                        <asp:BoundField HeaderText="Username" DataField="Username" />

                        <asp:BoundField HeaderText="Email" DataField="Email" />

                        <asp:BoundField HeaderText="Date Registered" DataField="DateRegistered" DataFormatString="{0:MMM dd yyyy}" />

                        <asp:TemplateField HeaderText="User Type">
                            <ItemTemplate><%# MiscUtils.UppercaseFirstOnly(Eval("UserType").ToString()) %> </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText=" ">
                            <ItemTemplate>
                                <div runat="server" visible='<%#Eval("UserStatus").ToString().ToUpper() == "ACTIVE" %>'>
                                    <a
                                        target="_blank"
                                        runat="server"
                                        href='<%# "~/Fan/"+Eval("Username").ToString()%>'
                                        class="text-danger">Fan Page
                                    </a>
                                    <br />
                                    <a
                                        target="_blank"
                                        runat="server"
                                        visible='<%# Eval("UserType").ToString().ToUpper() == "ARTIST" %>'
                                        href='<%#"~/Store/"+Eval("UserId").ToString()%> '
                                        class='text-danger'>Artist Page
                                    </a>
                                </div>
                                <div runat="server" visible='<%#Eval("UserStatus").ToString().ToUpper() != "ACTIVE" %>'>
                                    <p class="text-secondary">Unavailable</p>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:Button
                                    Text='<%# Eval("UserStatus").ToString().ToUpper() == "ACTIVE" ? "Deactivate" : "Reactivate" %>' runat="server"
                                    CommandName="ActivateReactivate"
                                    CommandArgument='<%#Eval("UserId")%>'
                                    CssClass='<%# Eval("UserStatus").ToString().ToUpper() == "ACTIVE" ? "btn btn-outline-danger" : "btn btn-secondary"%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                </asp:GridView>

            </div>
        </div>
    </div>

    <script type="text/javascript">
        $(".usersSideItem").addClass("sidebar-active");

        $(".usersGv").DataTable({
            "stateSave": true,
            "stateDuration": 60 * 10,
        });

    </script>

</asp:Content>
