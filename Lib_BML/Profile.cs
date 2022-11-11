using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lib_BML.Statics;
using Lib_BML.Helpers;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using static Lib_BML.Dashboard;

namespace Lib_BML
{
    public class Profile
    {
        /// <summary>
        /// Gets User Info
        /// Lib_BML.Statics.UserData
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> GetUserInfoAsync()
        {
            //ping profile api so userinfo is allowed
            //idk why it is like this whoever made the bml api makes it so you have to do this
            //so ill just have to work with it
            HttpResponseMessage ProfileInfoMsg =  await httpClient.GetAsync(BaseURL + @"profile");
            string ProfileInfoJson = await ProfileInfoMsg.Content.ReadAsStringAsync();

            JObject jObject1 = JObject.Parse(ProfileInfoJson);
            JToken Token = jObject1.SelectToken("payload").SelectToken("profile");
            var profiles = Token.FirstOrDefault();
            var id = profiles.SelectToken("profile").ToString();

            var formContent = new FormUrlEncodedContent(new[]
            {
             new KeyValuePair<string, string>("profile", id),

            });

            HttpResponseMessage responseMessage = await httpClient.PostAsync(BaseURL + @"profile", formContent);
            var responseJson = await responseMessage.Content.ReadAsStringAsync();
            formContent.Dispose();


            //send a get request to bml servers to get userinfo
            HttpResponseMessage UserInfoMessage = await httpClient.GetAsync(BaseURL + @"userinfo");
            string UserInfoJson = await UserInfoMessage.Content.ReadAsStringAsync();
            JObject jObject = JObject.Parse(UserInfoJson);
            var n = jObject.GetValue("success").Value<string>();

            Console.WriteLine("User Info Details\n" + UserInfoJson);

            if (n.ToLower() == "false")
            {
                return false;
            }
            var UserJson = jObject.SelectToken("payload").SelectToken("user");
            Statics.UserData.Mobile = UserJson.SelectToken("mobile_phone").ToString();
            Statics.UserData.Email = UserJson.SelectToken("email").ToString();
            Statics.UserData.FullName = UserJson.SelectToken("fullname").ToString();
            Statics.UserData.ID = UserJson.SelectToken("idcard").ToString();

            return true;
        }
    }
}
