using Newtonsoft.Json;
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
    public class Dashboard
    {
        #region Creating classes for json
        public class Actions
        {
            [JsonProperty("transfer")]
            public bool Transfer { get; set; }

            [JsonProperty("history")]
            public bool History { get; set; }

            [JsonProperty("pay")]
            public bool Pay { get; set; }

            [JsonProperty("topup")]
            public bool Topup { get; set; }
        }


        public class DashboardClass
        {
            [JsonProperty("customer")]
            public string Customer { get; set; }

            [JsonProperty("account_type")]
            public string AccountType { get; set; }

            [JsonProperty("product")]
            public string Product { get; set; }

            [JsonProperty("product_code")]
            public string ProductCode { get; set; }

            [JsonProperty("currency")]
            public string Currency { get; set; }

            [JsonProperty("product_group")]
            public string ProductGroup { get; set; }

            [JsonProperty("primary_supplementary")]
            public string PrimarySupplementary { get; set; }

            [JsonProperty("secondary_customer")]
            public object SecondaryCustomer { get; set; }

            [JsonProperty("statecode")]
            public string Statecode { get; set; }

            [JsonProperty("statuscode")]
            public string Statuscode { get; set; }

            [JsonProperty("account_status")]
            public string AccountStatus { get; set; }

            [JsonProperty("actions")]
            public Actions Actions { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("account")]
            public string Account { get; set; }

            [JsonProperty("alias")]
            public string Alias { get; set; }

            [JsonProperty("contact_type")]
            public string ContactType { get; set; }

            [JsonProperty("workingBalance")]
            public double WorkingBalance { get; set; }

            [JsonProperty("ledgerBalance")]
            public double LedgerBalance { get; set; }

            [JsonProperty("clearedBalance")]
            public double ClearedBalance { get; set; }

            [JsonProperty("availableBalance")]
            public double AvailableBalance { get; set; }

            [JsonProperty("lockedAmount")]
            public int LockedAmount { get; set; }

            [JsonProperty("minimumBalance")]
            public string MinimumBalance { get; set; }

            [JsonProperty("overdraftLimit")]
            public int OverdraftLimit { get; set; }

            [JsonProperty("availableLimit")]
            public object AvailableLimit { get; set; }

            [JsonProperty("creditLimit")]
            public object CreditLimit { get; set; }

            [JsonProperty("branch")]
            public string Branch { get; set; }

            [JsonProperty("success")]
            public bool Success { get; set; }
        }

        #endregion

        public static async Task GetDashboard()
        {
            HttpResponseMessage DashboardInfoMessage = await httpClient.GetAsync(@"https://www.bankofmaldives.com.mv/internetbanking/api/dashboard");
            string DashboardInfoJson = await DashboardInfoMessage.Content.ReadAsStringAsync();
            JObject jObject = JObject.Parse(DashboardInfoJson);
            var Dashboardlist = jObject.SelectToken("payload").SelectToken("dashboard").ToString();

            dashboardClass = JsonConvert.DeserializeObject<DashboardClass>(Dashboardlist);
        }
    }
}
