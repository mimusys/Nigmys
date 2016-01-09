using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homer_MVC.Models {
    public class EquityPartner {
        public int EquityPartnerID { get; set; }
        public string EquityPartnerName { get; set; }
        public double CashFlowPercent { get; set; }
        public double AppreciationPercent { get; set; }
        public double PrinciplePaydownPercent { get; set; }
        public double TaxDeductionPercent { get; set; }
        public double EquityInvestment { get; set; }
    }
}