﻿using System;
using Stripe;
namespace Nigmys.Services.StripeAccessorService
{
    /// <summary>
    /// Stripe Service used to interface with the stripe API
    /// </summary>
    public interface IStripeAccessorService
    {
        /// <summary>
        /// Create a customer in stripe
        /// </summary>
        /// <param name="email">customer's associated email</param>
        /// <param name="description">customer's first name and last name</param>
        /// <returns>customer created in stripe or error</returns>
        StripeObject CreateCustomer(String email, String firstName, String lastName);

        /// <summary>
        /// Obtain a customer give their unique identification
        /// </summary>
        /// <param name="customerId">The customer's unique ID</param>
        /// <returns></returns>
        StripeObject GetCustomer(string customerId);

        /// <summary>
        /// Update an existing customer's information within stripe
        /// </summary>
        /// <param name="customerId">The customer's unique id in stripe</param>
        /// <param name="email">The customer's new (or original) id</param>
        /// <param name="firstName">The customer's new (or original) first name</param>
        /// <param name="lastName">The customer's new (or original) last name</param>
        /// <returns>the customer's id who was updated</returns>
        String UpdateCustomer(String customerId, String email, String firstName, String lastName);

        /// <summary>
        /// Subscribe a customer to an operating plan in stripe
        /// </summary>
        /// <param name="customerId">The customer's unique identification in stripe</param>
        /// <param name="planId">An operating plan's uniqe identification in stripe</param>
        /// <returns>Returns the subscription id which was created</returns>
        String SubscribeCustomer(String customerId, String planId);

        /// <summary>
        /// Update a subscription to a new plan
        /// </summary>
        /// <param name="subscriptionId">the unique subscription id which is being changed</param>
        /// <param name="planId">the new plan id which is being associated with the subscription</param>
        /// <returns>the subscription id which was updated</returns>
        String UpdateSubscription(String customerId, String subscriptionId, String planId);

        /// <summary>
        /// Cancel a subscription within stripe
        /// </summary>
        /// <param name="customerId">The customer who holds the subscription</param>
        /// <param name="subscriptionId"> the subscription id being canceled</param>
        /// <returns>the canceled subscription id</returns>
        String CancelSubscription(String customerId, String subscriptionId);

        /// <summary>
        /// Charge the customer a pro-rated amount (or full amount if chargeDay == subscription
        /// </summary>
        /// <param name="customerId">The customer who is being charged</param>
        /// <param name="cMonth">The month which the charge is occuring</param>
        /// <param name="cDay">The day which the customer is being charged (1 - 31)</param>
        /// <param name="cYear">The year which the charge is made</param>
        /// <param name="subscriptionDay">The day which the subscription starts for the customer</param>
        /// <param name="price">The full charge to the customer</param>
        /// <returns>The id of the customer who was charged</returns>
        String ChargeCustomer(String customerId, int cMonth, int cDay, int cYear, int subscriptionDay, int price);

    }
}
