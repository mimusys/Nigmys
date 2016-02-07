using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homer_MVC.Models {
    public class DepreciationItem {
        public int DepreciationItemID { get; set; }
        public string DepreciationItemName { get; set; }
        public double DepreciationItemValue { get; set; }
        public int DepreciationItemTimeDuration { get; set; }
    }
}