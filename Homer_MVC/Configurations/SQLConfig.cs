using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Web;

namespace Configurations
{
    public class SQLConfig : ConfigurationSection
    {
        // Create a "database" element.
        [ConfigurationProperty("database")]
        public DatabaseElement Database
        {
            get
            {
                return (DatabaseElement)this["database"];
            }
            set
            { this["database"] = value; }
        }

        // Define the "database" element
        // with "address", "username", "password", "name" .
        public class DatabaseElement : ConfigurationElement
        {
            [ConfigurationProperty("address", DefaultValue = "127.0.0.1", IsRequired = true)]
            public String Address
            {
                get
                {
                    return (String)this["address"];
                }
                set
                {
                    this["address"] = value;
                }
            }

            [ConfigurationProperty("username", DefaultValue = "N/A", IsRequired = true)]
            public String Username
            {
                get
                { return (String)this["username"]; }
                set
                { this["username"] = value; }
            }

            [ConfigurationProperty("password", DefaultValue = "N/A", IsRequired = true)]
            public String Password
            {
                get
                { return (String)this["password"]; }
                set
                { this["password"] = value; }
            }

            [ConfigurationProperty("name", DefaultValue = "N/A", IsRequired = true)]
            public String Name
            {
                get
                { return (String)this["name"]; }
                set
                { this["name"] = value; }
            }
        }
    }
}