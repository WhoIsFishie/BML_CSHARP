﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_BML.Helpers
{
    public class ResponseCode
    {
        /// <summary>
        /// response codes given by bml api
        /// </summary>
        public enum Code
        {
            success = 0,
            fail = 2,
            locked = 20,
            maintenance = 37,

            /// <summary>
            /// No access to Account
            /// to repeat submit a fake account number
            /// https://www.bankofmaldives.com.mv/internetbanking/api/account/{INVALIDID}/history/20221012/20221111/1
            /// </summary>
            invalidAccount = 25,

            /// <summary>
            /// Invalid Date Range
            /// encountered while trying to get statment with an Invalid Date Range
            /// </summary>
            invalid_date = 10,

            /// <summary>
            /// An error occurred. Please try again
            /// encountered while refreshing bml history for today
            /// </summary>
            error = 8,
            accountIDIssue = 6969,

            /// <summary>
            /// in case of this error it means the bml proxy has failed to tunnel correctly
            /// and bml has detected this as an unauth application
            /// </summary>
            ProxyFail = 1020
        } 
    }
}
