using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nigmys.Models;

namespace Nigmys {
    public interface ISqlInvestmentInformationDatabase : ISqlDatabase {
        int addNewInvestment(InvestmentInformation investment);
    }
}
