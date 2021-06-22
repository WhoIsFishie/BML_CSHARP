using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lib_BML.Statics;
using Lib_BML.Helpers;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace Lib_BML
{
    public class Profile
    {
        public static async Task GetUserInfoAsync()
        {
            //ping profile api so userinfo is allowed
            //idk why it is like this whoever made the bml api makes it so you have to do this
            //so ill just have to work with it
            await httpClient.GetAsync(@"https://www.bankofmaldives.com.mv/internetbanking/api/profile");

            //send a get request to bml servers to get userinfo
            HttpResponseMessage UserInfoMessage = await httpClient.GetAsync(@"https://www.bankofmaldives.com.mv/internetbanking/api/userinfo");
            string UserInfoJson = await UserInfoMessage.Content.ReadAsStringAsync();
            JObject jObject = JObject.Parse(UserInfoJson);
            var UserJson = jObject.SelectToken("payload").SelectToken("user");
            Statics.UserData.Mobile = UserJson.SelectToken("mobile_phone").ToString();
            Statics.UserData.Email = UserJson.SelectToken("email").ToString();
            Statics.UserData.FullName = UserJson.SelectToken("fullname").ToString();
            Statics.UserData.ID = UserJson.SelectToken("idcard").ToString();
        }
    }
}
