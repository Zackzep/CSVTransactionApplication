using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    //IComparer class for sorting
    public class Transaction_Sort_Time : IComparer<Transaction>
    {
        //Method to compare by time
        public int Compare(Transaction x, Transaction y)
        {
            //Returns ordered by time
            return x.TransactionTime.CompareTo(y.TransactionTime);
        }
    }
}
