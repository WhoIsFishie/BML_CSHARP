using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static Lib_BML.Contacts;

namespace Lib_BML
{
    public class Statics
    {
        public static CookieContainer cookieContainer = new CookieContainer();
        public static HttpClientHandler handler = new HttpClientHandler();
        public static HttpClient httpClient = new HttpClient(handler);

        public static string URL = @"https://www.bankofmaldives.com.mv/internetbanking/api/login";

        public static ContactsList[] contactsList;

        public static ActivitiesList activitiesList;


        public static class UserData{
            public static string Email;
            public static string Mobile;
            public static string FullName;
            public static string ID;
        }
    }
}
