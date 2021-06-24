using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using static Lib_BML.Statics;

namespace Lib_BML
{
    public class Activities
    {
        #region Creating Classes For Json

        public class Content
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("value")]
            public string Value { get; set; }

            [JsonProperty("currency")]
            public string Currency { get; set; }

            [JsonProperty("contact_id")]
            public int? ContactId { get; set; }

            [JsonProperty("success")]
            public bool? Success { get; set; }
        }

        public class Datum
        {
            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("datetime")]
            public DateTime Datetime { get; set; }

            [JsonProperty("creditName")]
            public string CreditName { get; set; }

            [JsonProperty("formattedAmount")]
            public string FormattedAmount { get; set; }

            [JsonProperty("message")]
            public string Message { get; set; }

            [JsonProperty("content")]
            public List<Content> Content { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }
        }

        public class ActivitiesList
        {
            [JsonProperty("current_page")]
            public int CurrentPage { get; set; }

            [JsonProperty("data")]
            public List<Datum> Data { get; set; }

            [JsonProperty("first_page_url")]
            public string FirstPageUrl { get; set; }

            [JsonProperty("from")]
            public int From { get; set; }

            [JsonProperty("last_page")]
            public int LastPage { get; set; }

            [JsonProperty("last_page_url")]
            public string LastPageUrl { get; set; }

            [JsonProperty("next_page_url")]
            public string NextPageUrl { get; set; }

            [JsonProperty("path")]
            public string Path { get; set; }

            [JsonProperty("per_page")]
            public int PerPage { get; set; }

            [JsonProperty("prev_page_url")]
            public object PrevPageUrl { get; set; }

            [JsonProperty("to")]
            public int To { get; set; }

            [JsonProperty("total")]
            public int Total { get; set; }
        }
        #endregion

        /// <summary>
        /// Calls the bml activities api and gets page 1
        /// and adds the data to Lib_BML.Statics.activitiesList
        /// </summary>
        /// <returns></returns>
        public static async Task GetActivities()
        {
            HttpResponseMessage ActivitiesInfoMessage = await httpClient.GetAsync(@"https://www.bankofmaldives.com.mv/internetbanking/api/activities");
            string ActivitiesInfoJson = await ActivitiesInfoMessage.Content.ReadAsStringAsync();
            JObject jObject = JObject.Parse(ActivitiesInfoJson);
            var Activitieslist = jObject.SelectToken("payload").SelectToken("content").ToString();

            Lib_BML.Statics.activitiesList = JsonConvert.DeserializeObject<ActivitiesList>(Activitieslist);
            Console.WriteLine(Lib_BML.Statics.activitiesList.LastPageUrl);
            //await GetActivities(2);
        }

        /// <summary>
        /// Calls the bml activities api and get the page and add it to the ActivitiesList
        /// make sure to call GetActivities() first before calling this method
        /// </summary>
        /// <param name="page">Page Number to Get</param>
        /// <returns></returns>
        public static async Task GetActivities(int page)
        {
            HttpResponseMessage ActivitiesInfoMessage = await httpClient.GetAsync(@"https://www.bankofmaldives.com.mv/internetbanking/api/activities?page=" + page);
            string ActivitiesInfoJson = await ActivitiesInfoMessage.Content.ReadAsStringAsync();
            JObject jObject = JObject.Parse(ActivitiesInfoJson);
            var Activitieslist = jObject.SelectToken("payload").SelectToken("content").ToString();

            ActivitiesList temp = JsonConvert.DeserializeObject<ActivitiesList>(Activitieslist);
            activitiesList.LastPage = temp.LastPage;
            activitiesList.LastPageUrl = temp.LastPageUrl;

            foreach (var item in temp.Data)
            {
                activitiesList.Data.Add(item);
            }

            Console.WriteLine(Lib_BML.Statics.activitiesList.LastPageUrl);
        }

        /// <summary>
        /// calls GetActivities() and GetActivities(int page) in a loop to automatically get all activities 
        /// </summary>
        /// <returns></returns>
        public static async Task GetAllActivities()
        {
            //call getactivities to get initial data
            await GetActivities();

            //starts at 2 cause the first page is 1 and loops till last page is reached
            for (int i = 2; i < activitiesList.LastPage; i++)
            {
              //runs get selected activity 
              await GetActivities(i);
            }
        }
    }
}
