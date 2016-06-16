using Stripe;

namespace Nigmys.App_Start
{
    /// <summary>
    /// Configuration key for the stripe api
    /// </summary>
    public class StripeConfig
    {
        static string stripeApiKey = "sk_test_r1Vca4XiVpofCmbndcrhTF52";

        /// <summary>
        /// Set Stripe Configuration Key
        /// </summary>
        public static void ConfigureStripe()
        {
            StripeConfiguration.SetApiKey(stripeApiKey);
        }
    }
}