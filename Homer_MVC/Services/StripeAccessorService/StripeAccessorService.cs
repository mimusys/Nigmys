using System;
using Stripe;

namespace Nigmys.Services.StripeAccessorService
{
    public class StripeAccessorService : IStripeAccessorService
    {
        StripeSubscriptionService subService;
        StripeChargeService charService;
        StripeCustomerService cusService;

        public StripeAccessorService(StripeSubscriptionService subService, StripeChargeService charService, StripeCustomerService cusService)
        {
            this.subService = subService;
            this.charService = charService;
            this.cusService = cusService;
        }

        public string CancelSubscription(string customerId, string subscriptionId)
        {
            try
            {
                subService.Cancel(customerId, subscriptionId);
                return subscriptionId;
            }
            catch (Exception ex)
            {
                if (ex is StripeException)
                {
                    StripeException exception = (StripeException)ex;
                    StripeError err = exception.StripeError;
                    return err.ErrorType;
                }
                return null;
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
            catch (Exception ex)
            {
                if (ex is StripeException)
                {
                    StripeException exception = (StripeException)ex;
                    StripeError err = exception.StripeError;
                    return err.ErrorType;
                }
                return null;
            }
        }

        public string CreateCustomer(string email, string firstName, string lastName)
        {
            string description = firstName + " " + lastName + " (" + email + ")";
            try
            {
                var customerOptions = new StripeCustomerCreateOptions();
                customerOptions.Email = email;
                customerOptions.Description = description;

                StripeCustomer customer = cusService.Create(customerOptions);
                return customer.Id;
            }
            catch (Exception ex)
            {
                if (ex is StripeException)
                {
                    StripeException exception = (StripeException) ex;
                    StripeError err = exception.StripeError;
                    return err.ErrorType;
                }
                return null;
            }
          
        }

        public string SubscribeCustomer(string customerId, string planId)
        {
            try
            {
                StripeSubscription subscription = subService.Create(customerId, planId);
                return subscription.Id;
            }
            catch (Exception ex)
            {
                if (ex is StripeException)
                {
                    StripeException exception = (StripeException)ex;
                    StripeError err = exception.StripeError;
                    return err.ErrorType;
                }
                return null;
            }
        }

        public string UpdateCustomer(string customerId, string email, string firstName, string lastName)
        {
            string description = firstName + " " + lastName + " (" + email + ")";
            try
            {
                var customerUpdate = new StripeCustomerUpdateOptions();
                customerUpdate.Email = email;
                customerUpdate.Description = description;

                StripeCustomer customer = cusService.Update(customerId, customerUpdate);
                return customer.Id;
            }
            catch (Exception ex)
            {
                if (ex is StripeException)
                {
                    StripeException exception = (StripeException)ex;
                    StripeError err = exception.StripeError;
                    return err.ErrorType;
                }
                return null;
            }
        }

        public string UpdateSubscription(string customerId, string subscriptionId, string planId)
        {
            try
            {
                var subscriptionUpdate = new StripeSubscriptionUpdateOptions();
                subscriptionUpdate.PlanId = planId;

                StripeSubscription subscription = subService.Update(customerId, subscriptionId, subscriptionUpdate);
                return subscription.Id;
            }
            catch (Exception ex)
            {
                if (ex is StripeException)
                {
                    StripeException exception = (StripeException)ex;
                    StripeError err = exception.StripeError;
                    return err.ErrorType;
                }
                return null;
            }
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