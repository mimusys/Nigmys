using Nigmys.ActionFilters;
using Nigmys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nigmys.Controllers {
    [LoggedInFilter]
    public class InvestmentsController : Controller {
        ISqlInvestmentInformationDatabase investmentDb;
        ISqlPortfolioDatabase portfolioDb;

        public InvestmentsController(ISqlInvestmentInformationDatabase investmentDb, ISqlPortfolioDatabase portfolioDb) {
            this.investmentDb = investmentDb;
            this.portfolioDb = portfolioDb;
        }

        public ActionResult AddInvestment() {
            return View();
        }

        [HttpPost]
        public JsonResult AddInvestment(InvestmentInformation investment) {
            // todo: input validation
            
            int newInvestmentID = investmentDb.addNewInvestment(investment);
            bool success = portfolioDb.addInvestmentID(((User)(Session["user"])).PortfolioID, newInvestmentID);

            return Json(success);
        }
    }
}