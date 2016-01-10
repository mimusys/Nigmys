using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homer_MVC {
    public interface ISqlPortfolioDatabase : ISqlDatabase {

        int createNewPortfolioID();

        bool deletePortfolioID(int id);

    }
}
