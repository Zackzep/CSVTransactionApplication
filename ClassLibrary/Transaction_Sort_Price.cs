using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    //IComparer class for sorting
    public class Transaction_Sort_Price : IComparer<Transaction>
    {
        //Method to sort by total cost of item
        public int Compare(Transaction x, Transaction y)
        {
            //Returns ordered by cost
            return x.Total.CompareTo(y.Total);
        }
    }
}
