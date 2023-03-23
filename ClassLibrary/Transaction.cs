using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    //IComparable class to sort by name
    public class Transaction : IComparable<Transaction>
    {
        //Declare fields
        DateTime _transactionTime;
        string _name;
        decimal _price;
        decimal _tax;
        decimal _total;

        //Constructor that only takes in name and price(the rest is calculated, not input)
        public Transaction(string name, decimal price)
        {
            _name = name;
            _price = price;
            //Set how much tax is on item
            _tax = price * (decimal).01;
            //Set total by adding
            _total = _tax + _price;
            //Set time to now
            _transactionTime = DateTime.Now;
        }

        //Default constructor
        public Transaction()
        {

        }

        //Properties
        public DateTime TransactionTime { get => _transactionTime; set => _transactionTime = value; }
        public string Name { get => _name; set => _name = value; }
        public decimal Price { get => _price; set => _price = value; }
        public decimal Tax { get => _tax; set => _tax = value; }
        public decimal Total { get => _total; set => _total = value; }

        //Method to sort by name
        public int CompareTo(Transaction other)
        {
            //Orders items by name
            return _name.CompareTo(other._name);
        }
    }
}
