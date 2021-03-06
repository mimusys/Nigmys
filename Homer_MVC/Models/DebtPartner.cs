﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nigmys.Models {
    public class DebtPartner {
        public int DebtPartnerID { get; set; }
        public string LenderName { get; set; }
        public int Term { get; set; }
        public double AnnualPercentageRate { get; set; }
        public DateTime LoanStartDate { get; set; }
        public double LoanAmount { get; set; }
        public double Payment { get; set; }
    }
}