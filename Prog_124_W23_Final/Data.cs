using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using ClassLibrary;
using CsvHelper;

namespace Prog_124_W23_Final
{
    public static class Data
    {
        //Declare fields including file strings and currentUser for working through list
        public static UserAccount currentUser = null;
        public static List<UserAccount> accounts = new List<UserAccount>();
        public static string userInformation = @"users.json";
        public static string transactionExtension = @"_transaction.csv";

        //Default constructor that calls ReadUsers to read when used
        static Data()
        {
            ReadUsers();
        }

        //Method to concatonate file info with username
        public static string UsersTransactions()
        {
            return currentUser.Name + transactionExtension;
        }

        //Preload to save to JSON and have users on load
        public static void PreLoad()
        {
            

            // Check if accounts list is already populated
            if (accounts == null || accounts.Count == 0)
            {
                // Create and add default users if the list is empty
                UserAccount newUser = new UserAccount("Me", "Z", "Z", UserAccount.Role.Admin);
                UserAccount newUser2 = new UserAccount("Someone", "A", "A", UserAccount.Role.User);

                Data.AddUser(newUser);
                Data.AddUser(newUser2);

                // Save users after adding defaults
                SaveUsers();

                MessageBox.Show("Default users loaded.", "Debug Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        //Method to add user and save to JSON
        public static void AddUser(UserAccount account)
        {
            accounts.Add(account);
            SaveUsers();
        }

        //JSON save user method
        public static void SaveUsers()
        {
            JsonSerializerOptions jso = new JsonSerializerOptions()
            {
                WriteIndented = true,
            };

            string jsonManager = JsonSerializer.Serialize(accounts, jso);

            
            File.WriteAllText(userInformation, jsonManager);
        }

        //JSON method to make readable
        public static void ReadUsers()
        {
            string filePath = userInformation;

            string listFromFile = File.ReadAllText(filePath);

            accounts = JsonSerializer.Deserialize<List<UserAccount>>(listFromFile);
        }

        

    }
}
