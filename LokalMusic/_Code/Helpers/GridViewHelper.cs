using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace LokalMusic._Code.Helpers
{
    public static class GridViewHelper
    {
        public static void BindData(GridView view, object data)
        {
            view.DataSource = data;
            view.DataBind();

            view.UseAccessibleHeader = true;
            view.HeaderRow.TableSection = TableRowSection.TableHeader;
            view.GridLines = GridLines.None;
        }

        public static void BindDataTable(GridView view, DataTable dataTable)
        {
            if(dataTable.Rows.Count == 0) { return; }
            BindData(view, dataTable);
        }
    }
}