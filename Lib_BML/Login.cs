using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static Lib_BML.Statics;
using Lib_BML.Helpers;

namespace Lib_BML
{
    public class Login
    {
        /// <summary>
        /// Attempts to login to bml and return the status 
        /// </summary>
        /// <param name="username">BML Username</param>
        /// <param name="password">BML Password</param>
        /// <returns>respons statuus code</returns>
        public static async Task<ResponseCode.Code> DoLogin(string username, string password)
        {
            var formContent = new FormUrlEncodedContent(new[]
            {
             new KeyValuePair<string, string>("username", username),
             new KeyValuePair<string, string>("password", password),
            });

            handler.CookieContainer = cookieContainer; // store cookies in the handler

            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.101 Safari/537.36 Edg/91.0.864.48");
            HttpResponseMessage responseMessage = await httpClient.PostAsync(URL, formContent);
            var responseJson = await responseMessage.Content.ReadAsStringAsync();
            formContent.Dispose();
            var jObject = JObject.Parse(responseJson);

            return (ResponseCode.Code)jObject.GetValue("code").ToString().ToInt32();
            //return jObject.GetValue("code").ToString().ToBoolean();

        }
    }
}
