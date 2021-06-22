using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BML_Mock_App
{
   public class Statics
    {

        public static string Key
        {
            get
            {
                string[] lines = File.ReadAllLines(@"C:\Users\User\Desktop\Keys.txt");
                return lines[0];
            }
        }
        public static string name
        {
            get
            {
                string[] lines = File.ReadAllLines(@"C:\Users\User\Desktop\Keys.txt");
                return lines[1];
            }
        }


    }
}
