using MySql.Data.MySqlClient;
using System;
using Nigmys.Models;

namespace Nigmys.Services.SqlInvestmentInformationDatabase
{
    public class SqlInvestmentInformationDatabase : SqlDatabase, ISqlInvestmentInformationDatabase {
        public SqlInvestmentInformationDatabase(MySqlConnection conn) : base(conn) {

        }

        public int addNewInvestment(InvestmentInformation investment) {
            int newId = createNewInvestmentID();

            if (newId != -1 && Open()) {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;

                for (int i = 0; i < investment.CostItems.Length; ++i) {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "INSERT INTO costItems (investmentInformationID, costItemName, costItemValue) VALUES " +
                        "(@investmentInformationID, @costItemName, @costItemValue);";
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@investmentInformationID", newId);
                    cmd.Parameters.AddWithValue("@costItemName", investment.CostItems[i].CostItemName);
                    cmd.Parameters.AddWithValue("@costItemValue", investment.CostItems[i].CostItemValue);

                    if (cmd.ExecuteNonQuery() != 1) {
                        // uh-oh something bad happened
                    }
                }

                if (investment.DebtPartners != null) {
                    for (int i = 0; i < investment.DebtPartners.Length; ++i) {
                        cmd.Parameters.Clear();
                        cmd.CommandText = "INSERT INTO debtPartners (investmentInformationID, loanAmount, term, annualPercentageRate, lenderName, loanStartDate, payment) " +
                            "VALUES (@investmentInformationID, @loanAmount, @term, @annualPercentageRate, @lenderName, @loanStartDate, @payment);";
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@investmentInformationID", newId);
                        cmd.Parameters.AddWithValue("@loanAmount", investment.DebtPartners[i].LoanAmount);
                        cmd.Parameters.AddWithValue("@term", investment.DebtPartners[i].Term);
                        cmd.Parameters.AddWithValue("@annualPercentageRate", investment.DebtPartners[i].AnnualPercentageRate);
                        cmd.Parameters.AddWithValue("@lenderName", investment.DebtPartners[i].LenderName);
                        cmd.Parameters.AddWithValue("@loanStartDate", investment.DebtPartners[i].LoanStartDate);
                        cmd.Parameters.AddWithValue("@payment", investment.DebtPartners[i].Payment);

                        if (cmd.ExecuteNonQuery() != 1) {
                            // uh-oh something bad happened
                        }
                    }
                }

                if (investment.EquityPartners != null) {
                    for (int i = 0; i < investment.EquityPartners.Length; ++i) {
                        cmd.Parameters.Clear();
                        cmd.CommandText = "INSERT INTO equityPartners (investmentInformationID, equityPartnerName, cashFlowPercent, appreciationPercent, " +
                                                                       "principalPaydownPercent, taxDeductionPercent, equityInvestment) " +
                                          "VALUES (@investmentInformationID, @equityPartnerName, @cashFlowPercent, @appreciationPercent, " +
                                                  "@principalPaydownPercent, @taxDeductionPercent, @equityInvestment);";
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@investmentInformationID", newId);
                        cmd.Parameters.AddWithValue("@equityPartnerName", investment.EquityPartners[i].EquityPartnerName);
                        cmd.Parameters.AddWithValue("@cashFlowPercent", investment.EquityPartners[i].CashFlowPercent);
                        cmd.Parameters.AddWithValue("@appreciationPercent", investment.EquityPartners[i].AppreciationPercent);
                        cmd.Parameters.AddWithValue("@principalPaydownPercent", investment.EquityPartners[i].PrincipalPaydownPercent);
                        cmd.Parameters.AddWithValue("@taxDeductionPercent", investment.EquityPartners[i].TaxDeductionPercent);
                        cmd.Parameters.AddWithValue("@equityInvestment", investment.EquityPartners[i].EquityInvestment);

                        if (cmd.ExecuteNonQuery() != 1) {
                            // uh-oh something bad happened
                        }
                    }
                }
                
                if (investment.DepreciationItems != null) {
                    for (int i = 0; i < investment.DepreciationItems.Length; ++i) {
                        cmd.Parameters.Clear();
                        cmd.CommandText = "INSERT INTO depreciationItems (investmentInformationID, depreciationItemName, depreciationItemValue, depreciationItemTimeDuration) " +
                            "VALUES (@investmentInformationID, @depreciationItemName, @depreciationItemValue, @depreciationItemTimeDuration);";
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@investmentInformationID", newId);
                        cmd.Parameters.AddWithValue("@depreciationItemName", investment.DepreciationItems[i].DepreciationItemName);
                        cmd.Parameters.AddWithValue("@depreciationItemValue", investment.DepreciationItems[i].DepreciationItemValue);
                        cmd.Parameters.AddWithValue("@depreciationItemTimeDuration", investment.DepreciationItems[i].DepreciationItemTimeDuration);

                        if (cmd.ExecuteNonQuery() != 1) {
                            // uh-oh something bad happened
                        }
                    }
                }

                cmd.Parameters.Clear();
                cmd.CommandText = "INSERT INTO potentialReturnInformation (investmentInformationID, annualAppreciationRate, salesCommission, capitalGainsTax, " +
                    "incomeTaxRate, discountRate) VALUES (@investmentInformationID, @annualAppreciationRate, @salesCommission, @capitalGainsTax, @incomeTaxRate, @discountRate);";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@investmentInformationID", newId);
                cmd.Parameters.AddWithValue("@annualAppreciationRate", investment.AnnualAppreciationRate);
                cmd.Parameters.AddWithValue("@salesCommission", investment.SalesCommission);
                cmd.Parameters.AddWithValue("@capitalGainsTax", investment.CapitalGainsTax);
                cmd.Parameters.AddWithValue("@incomeTaxRate", investment.IncomeTaxRate);
                cmd.Parameters.AddWithValue("@discountRate", investment.DiscountRate);

                if (cmd.ExecuteNonQuery() != 1) {
                    // uh-oh something bad happened
                }

                cmd.Parameters.Clear();
                cmd.CommandText = "INSERT INTO propertyInformation (investmentInformationID, address, city, state, bedrooms, baths, squareFootage, pricePerSquareFoot) " +
                    "VALUES (@investmentInformationID, @address, @city, @state, @bedrooms, @baths, @squareFootage, @pricePerSquareFoot);";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@investmentInformationID", newId);
                cmd.Parameters.AddWithValue("@address", investment.Address);
                cmd.Parameters.AddWithValue("@city", investment.City);
                cmd.Parameters.AddWithValue("@state", investment.State);
                cmd.Parameters.AddWithValue("@bedrooms", investment.Bedrooms);
                cmd.Parameters.AddWithValue("@baths", investment.Baths);
                cmd.Parameters.AddWithValue("@squareFootage", investment.SquareFootage);
                cmd.Parameters.AddWithValue("@pricePerSquareFoot", investment.PricePerSqFoot);

                if (cmd.ExecuteNonQuery() != 1) {
                    // uh-oh something bad happened
                }

                cmd.Parameters.Clear();
                cmd.CommandText = "INSERT INTO purchaseInformation (investmentInformationID, purchasePrice, purchaseDate, marketPrice, downPayment, totalInvestmentCost, landValue) " +
                    "VALUES (@investmentInformationID, @purchasePrice, @purchaseDate, @marketPrice, @downPayment, @totalInvestmentCost, @landValue);";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@investmentInformationID", newId);
                cmd.Parameters.AddWithValue("@purchasePrice", investment.PurchasePrice);
                cmd.Parameters.AddWithValue("@purchaseDate", investment.PurchaseDate);
                cmd.Parameters.AddWithValue("@marketPrice", investment.MarketPrice);
                cmd.Parameters.AddWithValue("@downPayment", investment.DownPayment);
                cmd.Parameters.AddWithValue("@totalInvestmentCost", investment.TotalInvestmentCost);
                cmd.Parameters.AddWithValue("@landValue", investment.LandValue);

                if (cmd.ExecuteNonQuery() != 1) {
                    // uh-oh something bad happened
                }
            }
            return newId;
        }

        private int createNewInvestmentID() {
            int newId = -1;
            if (Open()) {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO investmentInformation VALUES (null, null); select LAST_INSERT_ID();", conn);
                cmd.Prepare();

                object newIdRet = cmd.ExecuteScalar();
                if (newIdRet != null) {
                    newId = Convert.ToInt32(newIdRet);
                }

                Close();
            }
            return newId;
        }
    }
}