﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Models.Publish
{
    public class SalesItem
    {
        public int OrderID { get; set; }

        public DateTime Date { get; set; }

        public string Customer { get; set; }

        public string Products { get; set; }

        public decimal AmountPaid { get; set; }

    }
}