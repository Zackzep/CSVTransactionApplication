//Zack Zepezauer
//3-22-23
//124 Final
using System;
using System.Collections.Generic;
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
using ClassLibrary;

namespace Prog_124_W23_Final
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            //Call Preload to have users on load
            Data.PreLoad();
        }

        //Login Button
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //Validation method call
            ValidateUser();
        }

        //Method to validate credentials
        public void ValidateUser()
        {
            //Declare variables for text box inputs
            string adminInputName = tbUsername.Text;
            string adminInputPassword = tbPassword.Text;

            //Foreach to run through accounts
            foreach (UserAccount user in Data.accounts)
            {
                //If statement to call IsUser method
                if (user.IsUser(adminInputName))
                {
                    //If statement to call ValidateUser method
                    if (user.ValidateUser(adminInputName, adminInputPassword))
                    {
                        //Sets user in loop to current user
                        Data.currentUser = user;
                        //Checks what current users role is, then opens appropriate window
                        if (Data.currentUser.UserRole == UserAccount.Role.Admin)
                        {
                            new AdminWindow().Show();
                        }
                        else
                        {
                            new UserWindow().Show();
                        }
                        // Exit the loop once the user is validated and a window is opened
                        return;
                    }

                }
            }
            // If no user was found display an error message
            MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
