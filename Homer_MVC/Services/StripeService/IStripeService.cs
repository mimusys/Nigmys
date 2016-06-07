using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Nigmys.Services.StripeService
{
    /// <summary>
    /// Stripe Service used to interface with the stripe API
    /// </summary>
    interface IStripeService
    {
        /// <summary>
        /// Create a customer in stripe
        /// </summary>
        /// <param name="email">customer's associated email</param>
        /// <param name="description">customer's first name and last name</param>
        /// <returns>customer id created in stripe</returns>
        String CreateCustomer(String email, String firstName, String lastName);

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
        String UpdateSubscription(String subscriptionId, String planId);

        /// <summary>
        /// Cancel a subscription within stripe
        /// </summary>
        /// <param name="subscriptionId"> the subscription id being canceled</param>
        /// <returns>the canceled subscription id</returns>
        String CancelSubscription(String subscriptionId);
    }
}
