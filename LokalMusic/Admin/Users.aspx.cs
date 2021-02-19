using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Admin;
using LokalMusic._Code.Presenters.Admin;
using System;
using System.Collections.Generic;
using System.Web.Services;

namespace LokalMusic.Admin
{
    public partial class Users : System.Web.UI.Page
    {
        private UsersPresenter presenter;
        public Users()
        {
            this.presenter = new UsersPresenter(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                Bind();
            }
        }

        public void Bind()
        {
            GridViewHelper.BindDataTable(UsersGridView, presenter.GetUsers());
        }

        protected void UsersGridView_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ActivateReactivate")
            {
                presenter.ActivateReactivateAccount(int.Parse(e.CommandArgument.ToString()));
                Bind();
            }
        }
    }
}