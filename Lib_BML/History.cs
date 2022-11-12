using Lib_BML.Helpers;
using Lib_BML.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using static Lib_BML.Statics;

namespace Lib_BML
{
    public class History
    {

        public class AccountHistory
        {
            public bool success { get; set; }
            public int code { get; set; }
            public string message { get; set; }
            public Payload payload { get; set; }
        }



        public class Payload
        {
            public ObservableCollection<HistoryObject> history { get; set; }
        }

        public class HistoryObject : INotifyPropertyChanged
        {
            private string _id;
            private string _description;
            private string _reference;
            private DateTime _bookingDate;
            private DateTime _valueDate;
            private string _currency;
            private float _amount;
            private float _balance;
            private string _narrative1;
            private string _narrative2;
            private string _narrative3;
            private string _narrative4;
            private bool _minus;


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
            public string description
            {
                get { return _description; }
                set
                {
                    if (value != _description)
                    {
                        _description = value;
                        OnPropertyChanged();
                    }
                }
            }
            public string reference
            {
                get { return _reference; }
                set
                {
                    if (value != _reference)
                    {
                        _reference = value;
                        OnPropertyChanged();
                    }
                }
            }
            public DateTime bookingDate
            {
                get { return _bookingDate; }
                set
                {
                    if (value != _bookingDate)
                    {
                        _bookingDate = value;
                        OnPropertyChanged();
                    }
                }
            }
            public DateTime valueDate
            {
                get { return _valueDate; }
                set
                {
                    if (value != _valueDate)
                    {
                        _valueDate = value;
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
            public float amount
            {
                get { return _amount; }
                set
                {
                    if (value != _amount)
                    {
                        _amount = value;
                        OnPropertyChanged();
                    }
                }
            }
            public float balance
            {
                get { return _balance; }
                set
                {
                    if (value != _balance)
                    {
                        _balance = value;
                        OnPropertyChanged();
                    }
                }
            }
            public string narrative1
            {
                get { return _narrative1; }
                set
                {
                    if (value != _narrative1)
                    {
                        _narrative1 = value;
                        OnPropertyChanged();
                    }
                }
            }
            public string narrative2
            {
                get { return _narrative2; }
                set
                {
                    if (value != _narrative2)
                    {
                        _narrative2 = value;
                        OnPropertyChanged();
                    }
                }
            }
            public string narrative3
            {
                get { return _narrative3; }
                set
                {
                    if (value != _narrative3)
                    {
                        _narrative3 = value;
                        OnPropertyChanged();
                    }
                }
            }
            public string narrative4
            {
                get { return _narrative4; }
                set
                {
                    if (value != _narrative4)
                    {
                        _narrative4 = value;
                        OnPropertyChanged();
                    }
                }
            }
            public bool minus
            {
                get { return _minus; }
                set
                {
                    if (value != _minus)
                    {
                        _minus = value;
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


        /// <summary>
        /// Calls the bml activities api and gets page 1
        /// and adds the data to Lib_BML.Statics.activitiesList
        /// </summary>
        /// <returns></returns>
        public static async Task<ResponseCode.Code> GetTodaysHistory()
        {
            HttpResponseMessage accountHistoryInfoMessageInfoMessage = await httpClient.GetAsync(BaseURL + $@"account/{AccountList[0].id}/history/today");
            string accountHistoryInfoJson = await accountHistoryInfoMessageInfoMessage.Content.ReadAsStringAsync();
            JObject jObject = JObject.Parse(accountHistoryInfoJson);

            //quick and dirty hack to remove some items
            AccountHistory m = JsonConvert.DeserializeObject<AccountHistory>(accountHistoryInfoJson);

            ResponseCode.Code responseCode = (ResponseCode.Code)m.code;
            if (responseCode != ResponseCode.Code.success)
            {
                return responseCode;
            }
            foreach (var item in m.payload.history)
            {
                if (item.minus == true)
                {
                    m.payload.history.Remove(item);
                }
            }

            Lib_BML.Statics.accountHistory = m; // JsonConvert.DeserializeObject<AccountHistory>(accountHistoryInfoJson);
            return responseCode;
        }

        /// <summary>
        /// Calls the bml activities api and gets page 1 from a specific Account
        /// and adds the data to Lib_BML.Statics.activitiesList
        /// </summary>
        /// <returns></returns>
        public static async Task<ResponseCode.Code> GetTodaysHistory(string id)
        {
            HttpResponseMessage accountHistoryInfoMessageInfoMessage = await httpClient.GetAsync(BaseURL + $@"account/{id}/history/today");
            string accountHistoryInfoJson = await accountHistoryInfoMessageInfoMessage.Content.ReadAsStringAsync();
            if (!accountHistoryInfoJson.Contains("Invalid Account Number"))
            {
                //quick and dirty hack to remove some items
                AccountHistory m = JsonConvert.DeserializeObject<AccountHistory>(accountHistoryInfoJson);

                //instead of removing items from the list new method is to
                //make a copy and add items to the list and assign it to view
                AccountHistory copy = new AccountHistory();

                copy.message = m.message;
                copy.success = m.success;
                copy.code = m.code;
                copy.payload = new Payload();

                ResponseCode.Code responseCode = (ResponseCode.Code)m.code;

                if (responseCode != ResponseCode.Code.success)
                {
                    return responseCode;
                }
                copy.payload.history = new ObservableCollection<HistoryObject>();


                //this reverses the list cause bml dumb and lists old transfers at the top
                foreach (var item in m.payload.history.Reverse())
                {
                    try
                    {
                        //this is to remove outgoing transfers 
                        if (item.minus != true)
                        {
                            copy.payload.history.Add(item);
                        }
                    }
                    catch
                    {

                    }
                }


                //var n = m.payload.history;
                //var b = Enumerable.Reverse(n);

                //m.payload.history = (ObservableCollection<HistoryObject>)b;

                Lib_BML.Statics.accountHistory = copy;
                return responseCode;
            }

            return ResponseCode.Code.accountIDIssue;
        }

        public static async Task<(ResponseCode.Code, List<StatementModel.History>)> GetAccountHistory(string id, DateTime startDate, DateTime endDate, int page = 1)
        {  
            return await GetAccountHistory(id, startDate.ToString("yyyyMMdd"), endDate.ToString("yyyyMMdd"), page);
        }

        public static async Task<(ResponseCode.Code, List<StatementModel.History>)> GetAccountHistory(string id, string startDate, string endDate, int page = 1)
        {
            HttpResponseMessage accountHistoryInfoMessageInfoMessage = await httpClient.GetAsync(BaseURL + $@"account/{id}/history/{endDate}/{startDate}/{page}");
            string accountHistoryInfoJson = await accountHistoryInfoMessageInfoMessage.Content.ReadAsStringAsync();
            //quick and dirty hack to remove some items
            StatementModel response = JsonConvert.DeserializeObject<StatementModel>(accountHistoryInfoJson);

            if(response.code != ResponseCode.Code.success)
            {
                return (response.code, null);
            }

            return (response.code, response.payload.history);
        }

        public static async Task<(ResponseCode.Code, List<StatementModel.History>)> GetFullHistory(string id, DateTime startDate, DateTime endDate)
        {
            return await GetFullHistory(id, startDate.ToString("yyyyMMdd"), endDate.ToString("yyyyMMdd"));
        }

        public static async Task<(ResponseCode.Code, List<StatementModel.History>)> GetFullHistory(string id,string startDate,string endDate)
        {                                                                                                               
            HttpResponseMessage accountHistoryInfoMessageInfoMessage = await httpClient.GetAsync(BaseURL + $@"account/{id}/history/{endDate}/{startDate}/1");
            string accountHistoryInfoJson = await accountHistoryInfoMessageInfoMessage.Content.ReadAsStringAsync();
            //quick and dirty hack to remove some items
            StatementModel response = JsonConvert.DeserializeObject<StatementModel>(accountHistoryInfoJson);

            if (response.code != ResponseCode.Code.success)
            {
                return (response.code, null);
            }
            
            List<StatementModel.History> Fullhistory = new List<StatementModel.History>();

            for (int i = 2; i < response.payload.totalPages; i++)
            {
                (var code, var history) = await GetAccountHistory(id,startDate,endDate,i);

                if(code != ResponseCode.Code.success)
                {
                    return (code, null);
                }

                Fullhistory = ListHelper.Concat(history, Fullhistory);

            }

          

            return (ResponseCode.Code.success, Fullhistory);
        }
    }
}
