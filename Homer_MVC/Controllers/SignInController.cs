﻿using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace Nigmys.Controllers
{
    public class SignInController : Controller
    {
        private readonly ISqlUserDatabase userSql;
        private Random rand;
        private HashAlgorithm hasher = SHA256Managed.Create();

        [InjectionConstructor]
        public SignInController(ISqlUserDatabase userSql, Random rand)
        {
            this.userSql = userSql;
            this.rand = rand;
        }

        [HttpPost]
        public ActionResult GetLoginMetadata(string username)
        {
            System.Diagnostics.Debug.WriteLine("Checking Login");


            String[] passwordInfo = userSql.getPasswordInfo(username);
            String salt = "";
            String nonce = "";
            if (passwordInfo != null)
            {
                // get salt to return
                salt = passwordInfo[1];

                // save hash and nonce into session variables for lookup
                // in VerifyLogin()
                nonce = GenerateNonce();
                Session["hash"] = passwordInfo[0];
                Session["nonce"] = nonce;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("PasswordInfo not found in database");
            }

            // password info not found returns empty strings, otherwise return
            // the generated nonce and salt
            return Json(new { Nonce = nonce, Salt = salt });
        }

        // Do a hash against our stored hash with the generated nonce
        // and verify against what the client has sent
        [HttpPost]
        public ActionResult VerifyLogin(String username, String hashWithNonce)
        {
            bool success = false;
            String hash = (string)Session["hash"]; // stored from GetLoginMetadata
            String nonce = (string)Session["nonce"];

            Session["nonce"] = null; // invalidate the nonce once it's been used

            if (hash != null || hash != "")
            {
                // Do encoding and SHA256 hashing against the stored hash and nonce
                byte[] hashBytes = Encoding.UTF8.GetBytes(hash + nonce);
                byte[] newHashBytes = hasher.ComputeHash(hashBytes);
                String hashString = "";
                foreach (byte x in newHashBytes)
                {
                    hashString += String.Format("{0:x2}", x);
                }

                // compare the expected value with the stored value
                if (hashString.Equals(hashWithNonce))
                {
                    success = true;
                    Session["user"] = userSql.getUser(username);
                }
            }

            // return true if login success; false otherwise
            return Json(new { Success = success });
        }

        
        /// <summary>
        /// Generate random data to us in hashing (a nonce helps guard against replay attacks)
        /// </summary>
        /// <returns>nonce against replay attacks</returns>
        private String GenerateNonce()
        {
            return rand.Next(11111111, 99999999).ToString();
        }
    }

}

