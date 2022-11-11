using Lib_BML.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Lib_BML.Statics;

namespace Lib_BML
{
    public class Dashboard
    {
        #region Creating classes for json

        public class DashboardClass
        {
            public List<DashboardAccounts> dashboardAccounts = new List<DashboardAccounts>();
        }

        public class DashboardAccounts
        {
            [JsonProperty("customer")]
            [JsonConverter(typeof(ParseStringConverter))]
            public long Customer { get; set; }

            [JsonProperty("account_type")]
            public string AccountType { get; set; }

            [JsonProperty("product")]
            public string Product { get; set; }

            [JsonProperty("product_code")]
            public string ProductCode { get; set; }

            [JsonProperty("currency")]
            public string Currency { get; set; }

            [JsonProperty("product_group")]
            [JsonConverter(typeof(ParseStringConverter))]
            public long ProductGroup { get; set; }

            [JsonProperty("primary_supplementary")]
            public string PrimarySupplementary { get; set; }

            [JsonProperty("secondary_customer")]
            public object SecondaryCustomer { get; set; }

            [JsonProperty("statecode")]
            [JsonConverter(typeof(ParseStringConverter))]
            public long Statecode { get; set; }

            [JsonProperty("statuscode")]
            [JsonConverter(typeof(ParseStringConverter))]
            public long Statuscode { get; set; }

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

            [JsonProperty("workingBalance", NullValueHandling = NullValueHandling.Ignore)]
            public double? WorkingBalance { get; set; }

            [JsonProperty("ledgerBalance", NullValueHandling = NullValueHandling.Ignore)]
            public double? LedgerBalance { get; set; }

            [JsonProperty("clearedBalance", NullValueHandling = NullValueHandling.Ignore)]
            public double? ClearedBalance { get; set; }

            [JsonProperty("availableBalance", NullValueHandling = NullValueHandling.Ignore)]
            public double? AvailableBalance { get; set; }

            [JsonProperty("lockedAmount", NullValueHandling = NullValueHandling.Ignore)]
            public double? LockedAmount { get; set; }

            [JsonProperty("minimumBalance", NullValueHandling = NullValueHandling.Ignore)]
            public string MinimumBalance { get; set; }

            [JsonProperty("overdraftLimit", NullValueHandling = NullValueHandling.Ignore)]
            public long? OverdraftLimit { get; set; }

            [JsonProperty("availableLimit")]
            public object AvailableLimit { get; set; }

            [JsonProperty("creditLimit")]
            public object CreditLimit { get; set; }

            [JsonProperty("branch", NullValueHandling = NullValueHandling.Ignore)]
            public string Branch { get; set; }

            [JsonProperty("success")]
            public bool Success { get; set; }

            [JsonProperty("cardBalance", NullValueHandling = NullValueHandling.Ignore)]
            public CardBalance CardBalance { get; set; }

            [JsonProperty("paymentOptions", NullValueHandling = NullValueHandling.Ignore)]
            public object[] PaymentOptions { get; set; }
        }

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

        public class CardBalance
        {
            [JsonProperty("CurrentBalance")]
            public long CurrentBalance { get; set; }

            [JsonProperty("CustomerAvaiLimit")]
            public long CustomerAvaiLimit { get; set; }

            [JsonProperty("CustomerLimit")]
            public long CustomerLimit { get; set; }

            [JsonProperty("LastStmtBalance")]
            public long LastStmtBalance { get; set; }

            [JsonProperty("LastStmtDueAmount")]
            public long LastStmtDueAmount { get; set; }

            [JsonProperty("LastStmtDueDate")]
            [JsonConverter(typeof(ParseStringConverter))]
            public long LastStmtDueDate { get; set; }

            [JsonProperty("OutstandingAuth")]
            public long OutstandingAuth { get; set; }

            [JsonProperty("AvailableLimit")]
            public long AvailableLimit { get; set; }
        }

        internal static class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
            };
        }

        internal class ParseStringConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                long l;
                if (Int64.TryParse(value, out l))
                {
                    return l;
                }
                throw new Exception("Cannot unmarshal type long");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (long)untypedValue;
                serializer.Serialize(writer, value.ToString());
                return;
            }

            public static readonly ParseStringConverter Singleton = new ParseStringConverter();
        }
        #endregion


        public class Accounts
        {
            public string AccountNumber { get; set; }
            public string AccountID { get; set; }
        }

        /// <summary>
        /// lmao its been so long i forgot what data this gets
        /// all i know is that there was a bug in it and i patched it so all is good now
        /// </summary>
        /// <returns></returns>
        public static async Task GetDashboard()
        {

            await Login.CheckIfLoggedIn();
            HttpResponseMessage DashboardInfoMessage = await httpClient.GetAsync(BaseURL + @"dashboard");
            string DashboardInfoJson = await DashboardInfoMessage.Content.ReadAsStringAsync();
            // string DashboardInfoJsonFixed = DashboardInfoJson.Substring(1, DashboardInfoJson.Length - 2);
            JObject jObject = JObject.Parse(DashboardInfoJson);

            

            string Dashboardlist = jObject.SelectToken("payload").SelectToken("dashboard").ToString();


            using (StreamWriter writer = File.CreateText("output.txt"))
            {
                await writer.WriteLineAsync(DashboardInfoJson);
            }

            //this is to fix a json phasing issue where json starts with a [ and ends with a ] causing it to look like an array
            //this line removes first and last char in the string
            //Dashboardlist = Dashboardlist.Substring(1, Dashboardlist.Length - 2);
            //lmao turns out adding this line of code was a huge mistake
            //this line only works if the account holder only has one bml account if there is more then one
            //the whole thing breaks

            try
            {
                DashboardAccounts[] DashboardAccountArray = JsonConvert.DeserializeObject<DashboardAccounts[]>(Dashboardlist, Dashboard.Converter.Settings);

                Statics.dashboardClass.dashboardAccounts = DashboardAccountArray.ToList();
            }
            catch (Exception ex)
            {

            }
            await GetSimplifiedDashBoard();
        }

        public static async Task<ResponseCode.Code> GetSimplifiedDashBoard()
        {
            HttpResponseMessage DashboardInfoMessage = await httpClient.GetAsync(BaseURL + @"dashboard");
            string DashboardInfoJson = await DashboardInfoMessage.Content.ReadAsStringAsync();
            // string DashboardInfoJsonFixed = DashboardInfoJson.Substring(1, DashboardInfoJson.Length - 2);
            JObject jObject = JObject.Parse(DashboardInfoJson);

            var code = jObject.SelectToken("code");

            ResponseCode.Code responseCode = (ResponseCode.Code)code.ToString().ToInt32();
            if (responseCode != ResponseCode.Code.success)
            {
                return responseCode;
            }

            JToken Token = jObject.SelectToken("payload").SelectToken("dashboard");

            Console.WriteLine("GetSimplifiedDashBoard Details\n" + DashboardInfoJson);

            foreach (var item in Token.Children())
            {
                SmallDashBoardClass temp = new SmallDashBoardClass();

                var account = item.SelectToken("account");
                temp.accounts = account.ToString();

                var id = item.SelectToken("id");
                temp.id = id.ToString();

                //this fix is in case bml doesnt return an alias. in such a case
                //use title instead. sometimes bml dont return title
                var alias = item.SelectToken("alias");
                if (alias == null)
                {
                    temp.alias = item.SelectToken("title").ToString();
                }
                else
                    temp.alias = alias.ToString();

                var product = item.SelectToken("product");
                temp.product = product.ToString();

                var currency = item.SelectToken("currency");
                temp.currency = currency.ToString();

                Statics.AccountList.Add(temp);
            }

            return responseCode;

        }

        /// <summary>
        /// converts a account list of accounts to json and then to base64 
        /// </summary>
        /// <param name="accounts">Account List To Serialize</param>
        /// <returns></returns>
        public static string AccountSerializer(List<Accounts> accounts)
        {
            return System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(accounts)));
        }

        /// <summary>
        /// Deserializes a List of Accounts and returns the obj
        /// </summary>
        /// <param name="base64">String containing the data</param>
        /// <returns></returns>
        public static List<Accounts> AccountDeserializer(string base64)
        {
           var base64EncodedBytes = System.Convert.FromBase64String(base64);
           return JsonConvert.DeserializeObject<List<Accounts>>(System.Text.Encoding.UTF8.GetString(base64EncodedBytes));
        }

        public class SmallDashBoardClass : INotifyPropertyChanged
        {
            private string _accounts;
            private string _id;
            private string _alias;
            private string _currency;
            private string _product;

            public string accounts
            {
                get { return _accounts; }
                set
                {
                    if (value != _accounts)
                    {
                        _accounts = value;
                        OnPropertyChanged();
                    }
                }
            }
            public string id
            {
                get { return _id; }
                set
                {
                    if (value != _id)
                    {
                        _id = value;
                        OnPropertyChanged();
                    }
                }
            }
            public string alias
            {
                get { return _alias; }
                set
                {
                    if (value != _alias)
                    {
                        _alias = value;
                        OnPropertyChanged();
                    }
                }
            }
            public string currency
            {
                get { return _currency; }
                set
                {
                    if (value != _currency)
                    {
                        _currency = value;
                        OnPropertyChanged();
                    }
                }
            }
            public string product
            {
                get { return _product; }
                set
                {
                    if (value != _product)
                    {
                        _product = value;
                        OnPropertyChanged();
                    }
                }
            }


            public event PropertyChangedEventHandler PropertyChanged;

            protected void OnPropertyChanged([CallerMemberName] string info = "")
            {
                var handler = PropertyChanged;
                handler?.Invoke(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}
