using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static Lib_BML.Statics;

namespace Lib_BML
{
    public class Activities
    {
        //pings the activities api and gets page 1 of the activities page
        public static async Task GetActivities()
        {
            HttpResponseMessage ActivitiesInfoMessage = await httpClient.GetAsync(@"https://www.bankofmaldives.com.mv/internetbanking/api/activities");
            string ActivitiesInfoJson = await ActivitiesInfoMessage.Content.ReadAsStringAsync();
            JObject jObject = JObject.Parse(ActivitiesInfoJson);
            var Activitieslist = jObject.SelectToken("payload").ToString();
        }
    }
}
