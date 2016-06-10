using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stripe;

namespace Nigmys.Services.StripeService
{
    public class StripeService : IStripeService
    {
        StripeSubscriptionService subService;
        StripeChargeService charService;

        public StripeService(StripeSubscriptionService subService, StripeChargeService charService)
        {
            this.subService = subService;
            this.charService = charService;
        }

        public string CancelSubscription(string customerId, string subscriptionId)
        {
            try
            {
                subService.Cancel(customerId, subscriptionId);
                return subscriptionId;
            } catch (StripeException ex)
            {
                StripeError err = ex.StripeError;
                return err.Error;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string ChargeCustomer(string customerId, int cMonth, int cDay, int cYear, int subscriptionDay, int price)
        {
            try
            {
                //Set up charge amount
                int days = DateTime.DaysInMonth(cYear, cMonth);
                double daylyCharge = price / (double)days;
                int chargedDays = days - cDay + 1;
                double proCharge = daylyCharge * chargedDays;

                //Set up charge
                var chargeOptions = new StripeChargeCreateOptions();

                chargeOptions.Amount = (int)proCharge * 100;
                chargeOptions.Currency = "usd";
                chargeOptions.CustomerId = customerId;
                chargeOptions.Capture = true;

                //Create Charge
                StripeCharge charge = charService.Create(chargeOptions);
                return charge.Id;
            }
            catch (StripeException ex)
            {
                StripeError err = ex.StripeError;
                return err.Error;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string CreateCustomer(string email, string firstName, string lastName)
        {
            throw new NotImplementedException();
        }

        public string SubscribeCustomer(string customerId, string planId)
        {
            throw new NotImplementedException();
        }

        public string UpdateCustomer(string customerId, string email, string firstName, string lastName)
        {
            throw new NotImplementedException();
        }

        public string UpdateSubscription(string subscriptionId, string planId)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// A class describing each possible stripe error which could occur
    /// </summary>
    public class StripeErrorType
    {
        private StripeErrorType(string value) { Value = value; }
        public string Value { get; set; }
        public static StripeErrorType api_connection_error { get { return new StripeErrorType("api_connection_error"); } }
        public static StripeErrorType api_error { get { return new StripeErrorType("api_error"); } }
        public static StripeErrorType authentication_error { get { return new StripeErrorType("authentication_error"); } }
        public static StripeErrorType card_error { get { return new StripeErrorType("card_error"); } }
        public static StripeErrorType invalid_request_error { get { return new StripeErrorType("invalid_request_error"); } }
        public static StripeErrorType rate_limit_error { get { return new StripeErrorType("rate_limit_error"); } }
    }
}