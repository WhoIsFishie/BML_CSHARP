using System;
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
            maintenance =37
        }
    }
}
