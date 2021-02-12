using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Models.Finance
{
    public class SalesHistoryModel
    {
        public SalesProductModel MostBoughtProduct { get; set; }
        public SalesProductModel LeastBoughtProduct { get; set; }
        public IList<SalesListItem> SalesItems { get; set; }

    }
}