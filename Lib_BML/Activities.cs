using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using static Lib_BML.Statics;

namespace Lib_BML
{
    public class Activities
    {
        #region Creating Classes For Json

        public class Content : INotifyPropertyChanged
        {
            private string name;
            [JsonProperty("name")]
            public string Name
            {
                get { return name; }
                set
                {
                    if (value != name)
                    {
                        name = value;
                        OnPropertyChanged();
                    }
                }
            }

            private string type;
            [JsonProperty("type")]
            public string Type
            {
                get { return type; }
                set
                {
                    if (value != type)
                    {
                        type = value;
                        OnPropertyChanged();
                    }
                }
            }

            private string _value;
            [JsonProperty("value")]
            public string Value
            {
                get { return _value; }
                set
                {
                    if (value != _value)
                    {
                        _value = value;
                        OnPropertyChanged();
                    }
                }
            }

            private string currency;
            [JsonProperty("currency")]
            public string Currency
            {
                get { return currency; }
                set
                {
                    if (value != currency)
                    {
                        currency = value;
                        OnPropertyChanged();
                    }
                }
            }

            private int? contact_id;
            [JsonProperty("contact_id")]
            public int? ContactId
            {
                get { return contact_id; }
                set
                {
                    if (value != contact_id)
                    {
                        contact_id = value;
                        OnPropertyChanged();
                    }
                }
            }


            private bool? success;
            [JsonProperty("success")]
            public bool? Success
            {
                get { return success; }
                set
                {
                    if (value != success)
                    {
                        success = value;
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

        public class Datum : INotifyPropertyChanged
        {
            private string type;
            [JsonProperty("type")]
            public string Type
            {
                get { return type; }
                set
                {
                    if (value != type)
                    {
                        type = value;
                        OnPropertyChanged();
                    }
                }
            }

            private DateTime dateTime;
            [JsonProperty("datetime")]
            public DateTime Datetime
            {
                get { return dateTime; }
                set
                {
                    if (value != dateTime)
                    {
                        dateTime = value;
                        OnPropertyChanged();
                    }
                }
            }

            private string creditName;
            [JsonProperty("creditName")]
            public string CreditName
            {
                get { return creditName; }
                set
                {
                    if (value != creditName)
                    {
                        creditName = value;
                        OnPropertyChanged();
                    }
                }
            }

            private string formattedAmount;
            [JsonProperty("formattedAmount")]
            public string FormattedAmount
            {
                get { return formattedAmount; }
                set
                {
                    if (value != formattedAmount)
                    {
                        formattedAmount = value;
                        OnPropertyChanged();
                    }
                }
            }

            private string message;
            [JsonProperty("message")]
            public string Message
            {
                get { return message; }
                set
                {
                    if (value != message)
                    {
                        message = value;
                        OnPropertyChanged();
                    }
                }
            }

            private List<Content> content;
            [JsonProperty("content")]
            public List<Content> Content
            {
                get { return content; }
                set
                {
                    if (value != content)
                    {
                        content = value;
                        OnPropertyChanged();
                    }
                }
            }

            private string status;
            [JsonProperty("status")]
            public string Status
            {
                get { return status; }
                set
                {
                    if (value != status)
                    {
                        status = value;
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

        public class ActivitiesList : INotifyPropertyChanged
        {
            private int current_page;
            [JsonProperty("current_page")]
            public int CurrentPage
            {
                get { return current_page; }
                set
                {
                    if (value != current_page)
                    {
                        current_page = value;
                        OnPropertyChanged();
                    }
                }
            }

            private ObservableCollection<Datum> data;
            [JsonProperty("data")]
            public ObservableCollection<Datum> Data
            {
                get { return data; }
                set
                {
                    if (value != data)
                    {
                        data = value;
                        OnPropertyChanged();
                    }
                }
            }

            private string first_page_url;
            [JsonProperty("first_page_url")]
            public string FirstPageUrl
            {
                get { return first_page_url; }
                set
                {
                    if (value != first_page_url)
                    {
                        first_page_url = value;
                        OnPropertyChanged();
                    }
                }
            }

            private int from;
            [JsonProperty("from")]
            public int From
            {
                get { return from; }
                set
                {
                    if (value != from)
                    {
                        from = value;
                        OnPropertyChanged();
                    }
                }
            }

            private int last_page;
            [JsonProperty("last_page")]
            public int LastPage
            {
                get { return last_page; }
                set
                {
                    if (value != last_page)
                    {
                        last_page = value;
                        OnPropertyChanged();
                    }
                }
            }

            private string last_page_url;
            [JsonProperty("last_page_url")]
            public string LastPageUrl
            {
                get { return last_page_url; }
                set
                {
                    if (value != last_page_url)
                    {
                        last_page_url = value;
                        OnPropertyChanged();
                    }
                }
            }

            private string next_page_url;
            [JsonProperty("next_page_url")]
            public string NextPageUrl
            {
                get { return next_page_url; }
                set
                {
                    if (value != next_page_url)
                    {
                        next_page_url = value;
                        OnPropertyChanged();
                    }
                }
            }

            private string path;
            [JsonProperty("path")]
            public string Path
            {
                get { return path; }
                set
                {
                    if (value != path)
                    {
                        path = value;
                        OnPropertyChanged();
                    }
                }
            }

            private int per_page;
            [JsonProperty("per_page")]
            public int PerPage
            {
                get { return per_page; }
                set
                {
                    if (value != per_page)
                    {
                        per_page = value;
                        OnPropertyChanged();
                    }
                }
            }

            private object prev_page_url;
            [JsonProperty("prev_page_url")]
            public object PrevPageUrl
            {
                get { return prev_page_url; }
                set
                {
                    if (value != prev_page_url)
                    {
                        prev_page_url = value;
                        OnPropertyChanged();
                    }
                }
            }

            private int to;
            [JsonProperty("to")]
            public int To
            {
                get { return to; }
                set
                {
                    if (value != to)
                    {
                        to = value;
                        OnPropertyChanged();
                    }
                }
            }

            private int total;
            [JsonProperty("total")]
            public int Total
            {
                get { return total; }
                set
                {
                    if (value != total)
                    {
                        total = value;
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
        #endregion

        /// <summary>
        /// Calls the bml activities api and gets page 1
        /// and adds the data to Lib_BML.Statics.activitiesList
        /// </summary>
        /// <returns></returns>
        public static async Task GetActivities()
        {
            HttpResponseMessage ActivitiesInfoMessage = await httpClient.GetAsync(BaseURL + @"activities");
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
            HttpResponseMessage ActivitiesInfoMessage = await httpClient.GetAsync(BaseURL + @"activities?page=" + page);
            string ActivitiesInfoJson = await ActivitiesInfoMessage.Content.ReadAsStringAsync();
            JObject jObject = JObject.Parse(ActivitiesInfoJson);
            var n = jObject.GetValue("success").Value<string>();
            if(n.ToLower() == "false")
            {

            }
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

            var m = activitiesList;
        }
    }
}
