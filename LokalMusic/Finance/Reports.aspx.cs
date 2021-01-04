using LokalMusic._Code.Repositories.Finance;
using System;
using System.Web.Services;

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