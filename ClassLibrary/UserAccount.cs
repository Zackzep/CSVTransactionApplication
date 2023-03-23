using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class UserAccount
    {
        //Declare fields
        public enum Role { User, Admin };

        string _name;
        string _userName;
        string _password;
        Role _userRole;

        //Set properties
        public string Name { get => _name; set => _name = value; }
        public string UserName { get => _userName; set => _userName = value; }
        public string Password { get => _password; set => _password = value; }
        public Role UserRole { get => _userRole; set => _userRole = value; }

        //Constructor for all fields
        public UserAccount(string name, string userName, string password, Role role)
        {
            _name = name;
            _userName = userName;
            _password = password;
            _userRole = role;
        }

        //Default constructor
        public UserAccount() 
        {

        }

        //Method to check if input is an existing user
        public bool IsUser(string userName)
        {
            //Return validation
            return _userName == userName;
        }

        //Method to make sure name and password are correct
        public bool ValidateUser(string userName, string password)
        {
            //Return validation
            return _userName == userName && _password == password;
        }
    }
}
