using LokalMusic._Code.Repositories.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LokalMusic.Finance
{
    public partial class Reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static Object GetReportData(DateTime startDate, DateTime endDate, string frequency)
        {
            var repository = new ReportsRepository();

            // validate frequency
            string methodName = "";
            if(frequency == "WEEKLY")
            {
                methodName = ReportsRepository.WEEKLY;
            }
            else if(frequency == "MONTHLY")
            {
                methodName = ReportsRepository.MONTHLY;
            }
            else if (frequency == "YEARLY")
            {
                methodName = ReportsRepository.YEARLY;
            }
            else
            {
                return new { errorMessage = "invalid frequency" };
            }

            return repository.GetReport(startDate, endDate, methodName);
        }
    }
}