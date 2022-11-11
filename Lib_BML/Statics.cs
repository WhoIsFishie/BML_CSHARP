using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static Lib_BML.Activities;
using static Lib_BML.Dashboard;
using static Lib_BML.Contacts;
using static Lib_BML.History;
using System.Collections.ObjectModel;
using System.Security.Authentication;

namespace Lib_BML
{
    public class Statics
    {
        public static CookieContainer cookieContainer = new CookieContainer();
        public static HttpClientHandler handler = new HttpClientHandler() 
        {
            SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls,
            CookieContainer = cookieContainer,
            UseCookies = true};

        public static HttpClient httpClient = new HttpClient(handler) ;

        /// <summary>
        /// set your own link to point to your bank's api endpoint
        /// </summary>
        public static string BaseURL = "https://website.com/";

        public static ContactsList[] contactsList;

        public static ActivitiesList activitiesList;

        public static AccountHistory accountHistory;

        public static DashboardClass dashboardClass = new DashboardClass();

        public static ObservableCollection<SmallDashBoardClass> AccountList = new ObservableCollection<SmallDashBoardClass>();

        public static class UserData{
            public static string Email;
            public static string Mobile;
            public static string FullName;
            public static string ID;
        }
    }
}
