using BML_Mock_App.Controls;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static BML_Mock_App.Statics;

namespace BML_Mock_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

         
        public string url = @"https://www.bankofmaldives.com.mv/internetbanking/api/login";
        public MainWindow()
        {
            InitializeComponent();
            main = this;
        }

        #region Outside Calls
        internal static MainWindow main;
        internal int LoginDone
        {
            set { Dispatcher.Invoke(new Action(() => {
                loginview.Visibility = Visibility.Hidden;
                ContactCard[] Card = new ContactCard[Lib_BML.Statics.contactsList.Length];
                for (int i = 0; i < Lib_BML.Statics.contactsList.Length; i++)
                {
                    Card[i] = new ContactCard
                    {
                        HolderNames = Lib_BML.Statics.contactsList[i].Alias,
                        AccountNumber = Lib_BML.Statics.contactsList[i].Account
                    };
                }
                contact_list.ItemsSource = Card;
                contact_list.Visibility = Visibility.Visible;
            })); }
        }

        #endregion







    }
}
