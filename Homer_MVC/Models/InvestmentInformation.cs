using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homer_MVC.Models {
    public class InvestmentInformation {
        public CostItem[] CostItems { get; set; }
        public DebtPartner[] DebtPartners { get; set; }
        public EquityPartner[] EquityPartners { get; set; }
        public DepreciationItem[] DepreciationItems { get; set; }

        public int InvestmentInformationID { get; set; }

        // Potential Return Info
        public int PotentialReturnID { get; set; }
        public double AnnualAppreciationRate { get; set; }
        public double SalesCommission { get; set; }
        public double CapitalGainsTax { get; set; }
        public double IncomeTaxRate { get; set; }
        public double DiscountRate { get; set; }

        // Purchase Info
        public int PurchaseInformationID { get; set; }
        public double PurchasePrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public double MarketPrice { get; set; }
        public double DownPayment { get; set; }
        public double TotalInvestmentCost { get; set; }
        public double LandValue { get; set; }

        // Property Info
        public int PropertyInformationID { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Bedrooms { get; set; }
        public int Baths { get; set; }
        public int SquareFootage { get; set; }
        public double PricePerSqFoot { get; set; }


    }
}