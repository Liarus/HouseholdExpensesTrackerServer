﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Common.Configuration
{
    public class ApplicationConfiguration : IApplicationConfiguration
    {
        public string HouseholdConnectionString { get; private set; }

        public int SqlCommandTimeoutSeconds { get; }

        public static ApplicationConfiguration Create(string householdConnectionString, int sqlCommandTimeoutSeconds)
        => new ApplicationConfiguration(householdConnectionString, sqlCommandTimeoutSeconds);

        protected ApplicationConfiguration(string householdConnectionString, int sqlCommandTimeoutSeconds)
        {
            this.HouseholdConnectionString = householdConnectionString;
            this.SqlCommandTimeoutSeconds = sqlCommandTimeoutSeconds;
        }
    }
}
