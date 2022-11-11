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

            //try
            //{
            //    handler.CookieContainer = cookieContainer; // store cookies in the handler
            //}
            //catch (Exception ex)
            //{
            //    Console.Writ          eLine("Error Assigning Cookie in DoLogin");
            //}

            

            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.101 Safari/537.36 Edg/91.0.864.48");
            HttpResponseMessage responseMessage = await httpClient.PostAsync(BaseURL + "login", formContent);
            if(responseMessage.StatusCode == System.Net.HttpStatusCode.BadGateway)
            {
                return ResponseCode.Code.ProxyFail;
            }
            var responseJson = await responseMessage.Content.ReadAsStringAsync();
            formContent.Dispose();
            var jObject = JObject.Parse(responseJson);

            Console.WriteLine("Login Details\n" + responseJson);

            return (ResponseCode.Code)jObject.GetValue("code").ToString().ToInt32();
        }

        /// <summary>
        /// checks to see if the user is logged into bml or not
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> CheckIfLoggedIn()
        {
            //ping profile api so userinfo is allowed
            //idk why it is like this whoever made the bml api makes it so you have to do this
            //so ill just have to work with it
            await httpClient.GetAsync(BaseURL+"profile");

            //send a get request to bml servers to get userinfo
            HttpResponseMessage UserInfoMessage = await httpClient.GetAsync(BaseURL + "userinfo");
            string UserInfoJson = await UserInfoMessage.Content.ReadAsStringAsync();
            JObject jObject = JObject.Parse(UserInfoJson);


            var n = jObject.GetValue("success").Value<string>();
            if (n.ToLower() == "false")
            {
                return false;
            }
            return true;
        }
    }
}
