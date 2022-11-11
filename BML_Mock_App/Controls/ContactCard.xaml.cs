using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BML_Mock_App.popup;
using static Lib_BML.Transfer;

namespace BML_Mock_App.Controls
{
    /// <summary>
    /// Interaction logic for ContactCard.xaml
    /// </summary>
    public partial class ContactCard : System.Windows.Controls.UserControl
    {

        public ContactCard()
        {
            InitializeComponent();
        }

        #region Settings
        private string _Name;
        [Category("Settings")]
        public string HolderNames
        {
            get { return _Name; }
            set { _Name = value; HolderName.Content = value; }
        }

        private string _AccountNumber;
        [Category("Settings")]
        public string AccountNumber
        {
            get { return _AccountNumber; }
            set { _AccountNumber = value; Account_Number.Content = value; }
        }
        #endregion

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //here we initialize transfer data 
            TransferBuilder transfer = new TransferBuilder
            {
                creditAccount = AccountNumber,
                debitAmount = "0.01",
                remarks = "Fishie Was Here :)"
            };

            //we send the data to bml and bml will send an otp
            await Lib_BML.Transfer.InitiateTransferAsync(transfer);

            string otpcode = null;
            otp inputDialog = new otp("Enter OTP", "");
            if (inputDialog.ShowDialog() == true)
            {
                otpcode = inputDialog.Answer;

                //we take the otp value and the transfer data and give it to this method to process the payment
                await Lib_BML.Transfer.SubmitOTP(otpcode, transfer);
            }
        }
    }
}
