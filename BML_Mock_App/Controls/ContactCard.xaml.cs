using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace BML_Mock_App.Controls
{
    /// <summary>
    /// Interaction logic for ContactCard.xaml
    /// </summary>
    public partial class ContactCard : UserControl
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
    }
}
