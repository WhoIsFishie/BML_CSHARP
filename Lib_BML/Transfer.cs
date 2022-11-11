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
    public class Transfer
    {

        public class TransferBuilder
        {
            /// <summary>
            /// remarks for the transection 
            /// </summary>
            public string remarks { get; set; }

            /// <summary>
            /// the account the money is being transfered to 
            /// </summary>
            public string creditAccount { get; set; }

            /// <summary>
            /// the amount of money being transfered 
            /// </summary>
            public string debitAmount { get; set; }

        }


        private static readonly string TransferUrl = BaseURL + "transfer";
        /// <summary>
        /// this class will handles the part 1 of a transfer which is requesting otp code and sending a call to the api with info about the transfer details
        /// </summary>
        public static async Task InitiateTransferAsync(TransferBuilder transfer)
        {
            var formContent = new FormUrlEncodedContent(new[]
            {
             new KeyValuePair<string, string>("transfertype", "IAT"), //fuck if i know what this means
             new KeyValuePair<string, string>("channel", "mobile"), //this is the otp method
             new KeyValuePair<string, string>("debitAmount", transfer.debitAmount), //this is how much money will be sent
             new KeyValuePair<string, string>("creditAccount", transfer.creditAccount), //this is the account the money will go to
             new KeyValuePair<string, string>("debitAccount", dashboardClass.dashboardAccounts[0].Id), //uhhhh its like the guid? for the account or something
            });


            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.101 Safari/537.36 Edg/91.0.864.48");
            HttpResponseMessage responseMessage = await httpClient.PostAsync(TransferUrl, formContent);
            var responseJson = await responseMessage.Content.ReadAsStringAsync();
            formContent.Dispose();
            var jObject = JObject.Parse(responseJson);
        }


        /// <summary>
        /// this class will handle part 2 of the process which is submiting the otp code and getting a response 
        /// </summary>
        /// <param name="otp"></param>
        /// <returns></returns>
        public static async Task SubmitOTP(string otp, TransferBuilder transfer)
        {
            var formContent = new FormUrlEncodedContent(new[]
            {
             new KeyValuePair<string, string>("currency", dashboardClass.dashboardAccounts[0].Currency), //type of money
             new KeyValuePair<string, string>("transfertype", "IAT"), //fuck if i know what this means
             new KeyValuePair<string, string>("debitAmount", transfer.debitAmount), //this is how much money will be sent
             new KeyValuePair<string, string>("remarks", transfer.remarks), //this is the remarks
             new KeyValuePair<string, string>("channel", "mobile"), //this is the otp method
             new KeyValuePair<string, string>("debitAccount", dashboardClass.dashboardAccounts[0].Id), //uhhhh its like the guid? for the account or something
             new KeyValuePair<string, string>("creditAccount", transfer.creditAccount), //this is the account the money will go to
             new KeyValuePair<string, string>("otp", otp), //recived otp code
            });


            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.101 Safari/537.36 Edg/91.0.864.48");
            HttpResponseMessage responseMessage = await httpClient.PostAsync(TransferUrl, formContent);
            var responseJson = await responseMessage.Content.ReadAsStringAsync();
            formContent.Dispose();
            var jObject = JObject.Parse(responseJson);
        }
    }
}
