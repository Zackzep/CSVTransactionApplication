using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ClassLibrary;
using CsvHelper;

namespace Prog_124_W23_Final
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        //Declare transactions list
        List<Transaction> transactions = new List<Transaction>();
        public UserWindow()
        {
            InitializeComponent();
            //Call to create file passing in concatonation method
            CreateNewFile(Data.UsersTransactions());
            //Call read csv file
            ReadTransactions();
            //Call LV update
            UpdateListView();
        }

        //Method to create a file
        private void CreateNewFile(string filePath)
        {
            FileStream tryout = File.OpenWrite(filePath);
            tryout.Close();
            tryout.Dispose();
        }

        //Method to update LV
        public void UpdateListView()
        {
            //First clear when called
            lvDisplayTransactions.Items.Clear();

            //Populates LV
            foreach (Transaction transaction in transactions)
            {
                lvDisplayTransactions.Items.Add(transaction);
            }
        }

        //CSV writer method
        public void WriteTransactions(string filePath)
        {
            CultureInfo ci = CultureInfo.InvariantCulture;
            filePath = Data.UsersTransactions();

            using (var stream = File.Open(filePath, FileMode.OpenOrCreate))
            using (var writer = new StreamWriter(stream))
            //Right click dependencies > manage nuget package > browse csvhelper > add
            using (var csvWriter = new CsvWriter(writer, ci))
            {
                csvWriter.WriteRecords(transactions);
                writer.Flush();
            }
        }

        //CSV reader method
        public void ReadTransactions()
        {
            string filePath = Data.UsersTransactions();

            using (StreamReader reader = new StreamReader(filePath))
            using (CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                transactions = csv.GetRecords<Transaction>().ToList();
            }
        }

        //Button that calls sort name and updates LV
        private void btnSortName_Click(object sender, RoutedEventArgs e)
        {
            transactions.Sort();
            UpdateListView();
        }

        //Button that calls sort time and updates LV
        private void btnSortTime_Click(object sender, RoutedEventArgs e)
        {
            Transaction_Sort_Time sortTime = new Transaction_Sort_Time();
            
            transactions.Sort(sortTime);
            UpdateListView();
        }

        //Button that calls sort pricw and updates LV
        private void btnSortPrice_Click(object sender, RoutedEventArgs e)
        {
            Transaction_Sort_Price sortPrice = new Transaction_Sort_Price();

            transactions.Sort(sortPrice);
            UpdateListView();
        }

        //Method to add transaction
        private void btnAddTransaction_Click(object sender, RoutedEventArgs e)
        {
            //Declare variables to take text info
            string name = tbAddTransName.Text;
            decimal price = decimal.Parse(tbAddTransPrice.Text);

            //Add to transactions list
            transactions.Add(new Transaction(name, price));

            //Add to CSV
            WriteTransactions(Data.UsersTransactions());

            //Update LV
            UpdateListView();
        }

        //Method to create custom file
        private void btnExportCSV_Click(object sender, RoutedEventArgs e)
        {
            //Variable to take in text info
            string fileExport = tbCSVName.Text;
            
            //Call Create file method and concatonate with current user name, underscore, and input
            CreateNewFile(Data.currentUser.Name + "_" + fileExport);
        }

        //Logout button
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            //Sets current user to null
            Data.currentUser = null;

            //Close the window
            this.Close();

            //Redirect to the login window
            //MainWindow loginWindow = new MainWindow();
            //loginWindow.Show();
        }

        
    }
}
