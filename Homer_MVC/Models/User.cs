﻿using System;
using Stripe;
namespace Nigmys.Models
{
    public class User {
        public string UserID { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public DateTime Birthday { get; set; }
        public string CompanyName { get; set; }
        public string PictureURL { get; set; }
        public int PortfolioID { get; set; }
        public status status { get; set; }
        public string stripeId { get; set; }
        public StripeCustomer stripeObject { get; set; }
    }

    public enum status
    {
        freeTrial,
        premium,
        pending,
        inactive,
        administrator
    };
}