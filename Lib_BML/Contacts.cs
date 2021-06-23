using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lib_BML.Statics;
using Newtonsoft.Json.Converters;
using Lib_BML.Helpers;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Lib_BML
{
   public class Contacts
    {
        #region Creating classes for json
        public partial class ContactsList
        {
            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("avatar")]
            public object Avatar { get; set; }

            [JsonProperty("favorite")]
            public long Favorite { get; set; }

            [JsonProperty("account")]
            public string Account { get; set; }

            [JsonProperty("swift")]
            public object Swift { get; set; }

            [JsonProperty("correspondent_swift")]
            public object CorrespondentSwift { get; set; }

            [JsonProperty("address")]
            public object Address { get; set; }

            [JsonProperty("city")]
            public object City { get; set; }

            [JsonProperty("state")]
            public object State { get; set; }

            [JsonProperty("postcode")]
            public object Postcode { get; set; }

            [JsonProperty("country")]
            public object Country { get; set; }

            [JsonProperty("contact_type")]
            public ContactType ContactType { get; set; }

            [JsonProperty("merchant")]
            public object Merchant { get; set; }

            [JsonProperty("created_at")]
            public DateTimeOffset CreatedAt { get; set; }

            [JsonProperty("updated_at")]
            public DateTimeOffset UpdatedAt { get; set; }

            [JsonProperty("deleted_at")]
            public object DeletedAt { get; set; }

            [JsonProperty("bpay_vendor")]
            public object BpayVendor { get; set; }

            [JsonProperty("domestic_bank_code")]
            public object DomesticBankCode { get; set; }

            [JsonProperty("service_number")]
            public object ServiceNumber { get; set; }

            [JsonProperty("mobile_number")]
            public object MobileNumber { get; set; }

            [JsonProperty("alias")]
            public string Alias { get; set; }

            [JsonProperty("status")]
            public Status Status { get; set; }

            [JsonProperty("inputter")]
            public long? Inputter { get; set; }

            [JsonProperty("owner")]
            public long Owner { get; set; }

            [JsonProperty("currency")]
            public Currency Currency { get; set; }

            [JsonProperty("removable")]
            public bool Removable { get; set; }

            [JsonProperty("vendor")]
            public object Vendor { get; set; }
        }

        public enum ContactType { Iat };

        public enum Currency { Mvr, Usd };

        public enum Status { S };
        #endregion

        /// <summary>
        /// gets all the contacts in contacts list and adds it to Lib_BML.Statics.contactsList
        /// </summary>
        /// <returns></returns>
        public static async Task GetContats()
        {
            HttpResponseMessage contactsInfoMessage = await httpClient.GetAsync(@"https://www.bankofmaldives.com.mv/internetbanking/api/contacts");
            string contactsInfoJson = await contactsInfoMessage.Content.ReadAsStringAsync();
            JObject jObject = JObject.Parse(contactsInfoJson);
            var contactlist = jObject.SelectToken("payload").ToString();

            contactsList = JsonConvert.DeserializeObject<ContactsList[]>(contactlist);
            //return true;
        }
    }
}
