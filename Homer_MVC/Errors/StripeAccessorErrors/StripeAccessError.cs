using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stripe;

namespace Nigmys.Errors.StripeAccessorErrors
{
    public abstract class StripeAccessError : StripeObject
    {
        public string Error_Type { get; set; }
    }
}