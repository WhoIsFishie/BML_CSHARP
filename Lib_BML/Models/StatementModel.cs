using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lib_BML.Models
{
    public class StatementModel
    {
        public bool success { get; set; }
        public Helpers.ResponseCode.Code code { get; set; }
        public string message { get; set; }
        public Payload payload { get; set; }

        public class Account
        {
            public string cardnumber { get; set; }
            public string customer { get; set; }
            public string account_type { get; set; }
            public string product { get; set; }
            public string product_code { get; set; }
            public string title { get; set; }
            public string currency { get; set; }
            public string bml_customerproductId { get; set; }
            public string product_group { get; set; }
            public string primary_supplementary { get; set; }
            public string bml_branchcode { get; set; }
            public object secondary_customer { get; set; }
            public string statecode { get; set; }
            public string statuscode { get; set; }
            public string account_status { get; set; }
        }

        public class History : INotifyPropertyChanged
        {
            private string id;
            private string description;
            private string reference;
            private DateTime bookingDate;
            private DateTime valueDate;
            private string currency;
            private double amount;
            private double balance;
            private string narrative1;
            private string narrative2;
            private string narrative3;
            private string narrative4;
            private bool minus;

            public string Id
            {
                get => id;
                set
                {
                    if (value != id)
                    {
                        id = value;
                        OnPropertyChanged();
                    }
                }
            }
            public string Description
            {
                get => description;
                set
                {
                    description = value; OnPropertyChanged();
                }
            }
            public string Reference
            {
                get => reference;
                set
                {
                    reference = value; OnPropertyChanged();
                }
            }
            public DateTime BookingDate
            {
                get => bookingDate;
                set
                {
                    bookingDate = value; OnPropertyChanged();
                }
            }
            public DateTime ValueDate
            {
                get => valueDate;
                set
                {
                    valueDate = value; OnPropertyChanged();
                }
            }
            public string Currency
            {
                get => currency;
                set
                {
                    currency = value; OnPropertyChanged();
                }
            }
            public double Amount
            {
                get => amount;
                set
                {
                    amount = value; OnPropertyChanged();
                }
            }
            public double Balance
            {
                get => balance;
                set
                {
                    balance = value; OnPropertyChanged();
                }
            }
            public string Narrative1
            {
                get => narrative1;
                set
                {
                    narrative1 = value; OnPropertyChanged();
                }
            }
            public string Narrative2
            {
                get => narrative2;
                set
                {
                    narrative2 = value; OnPropertyChanged();
                }
            }
            public string Narrative3
            {
                get => narrative3;
                set
                {
                    narrative3 = value; OnPropertyChanged();
                }
            }

            public string Narrative4
            {
                get => narrative4;
                set
                {
                    narrative4 = value; OnPropertyChanged();
                }
            }
            public bool Minus
            {
                get => minus;
                set
                {
                    minus = value; OnPropertyChanged();
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            protected void OnPropertyChanged([CallerMemberName] string info = "")
            {
                var handler = PropertyChanged;
                handler?.Invoke(this, new PropertyChangedEventArgs(info));
            }
        }

        public class Payload
        {
            public int currentPage { get; set; }
            public int totalPages { get; set; }
            public List<History> history { get; set; }
            public Account account { get; set; }
        }
    }
}
