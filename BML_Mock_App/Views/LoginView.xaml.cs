using System;
using System.Collections.Generic;
using System.Linq;
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

namespace BML_Mock_App.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
            //make sure to remove this line
            username.Text = Statics.name;
            password.Password = Statics.Key;
            //it wont work if this line is here
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //try to login and get login result
            bool result = await Lib_BML.Login.DoLogin(username.Text, password.Password);

            switch (result)
            {
                case true:
                    //if login true then try to get user details
                    await Lib_BML.Profile.GetUserInfoAsync();
                    ShowDetailsAsync();
                    break;
                case false:
                    break;
                default:
                    break;
            }
        }

        //make a popup saying users name
        private async void ShowDetailsAsync()
        {
            //MessageBox.Show("Welcome "+Lib_BML.Statics.UserData.FullName);
            await Lib_BML.Activities.GetActivities();
            MainWindow.main.LoginDone = 1;
        }
    }
}
