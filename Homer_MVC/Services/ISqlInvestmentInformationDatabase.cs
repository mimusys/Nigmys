using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homer_MVC.Models;

namespace Homer_MVC {
    public interface ISqlInvestmentInformationDatabase : ISqlDatabase {
        int addNewInvestment(InvestmentInformation investment);
    }
}
