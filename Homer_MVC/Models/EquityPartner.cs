using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nigmys.Models {
    public class EquityPartner {
        public int EquityPartnerID { get; set; }
        public string EquityPartnerName { get; set; }
        public double CashFlowPercent { get; set; }
        public double AppreciationPercent { get; set; }
        public double PrincipalPaydownPercent { get; set; }
        public double TaxDeductionPercent { get; set; }
        public double EquityInvestment { get; set; }
    }
}