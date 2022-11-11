using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_BML.Helpers
{
    public static class ListHelper
    {
        public static List<T> Concat<T>(params List<T>[] lists)
        {
            return lists.Aggregate(new List<T>(), (x, y) => x.Concat(y).ToList()); ;
        }
    }
}
