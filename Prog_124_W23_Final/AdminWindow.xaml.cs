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
using System.Windows.Shapes;
using ClassLibrary;

namespace Prog_124_W23_Final
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            //Call LV updated for load
            UpdateListView();
            //Call combobox method
            PreloadComboBox();
            
        }

        //Button to add a user
        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            //Declare variables for inputs
            string name = tbName.Text;
            string userName = tbUsername.Text;
            string password = tbPassword.Text;
            int selectedRoleIndex = cbRole.SelectedIndex;

            //Check index for user which is index 0
            if (selectedRoleIndex == 0)
            {
                //Set new user to basic user
                UserAccount newUser = new UserAccount(name, userName, password, UserAccount.Role.User);
                //Add to list through data class
                Data.AddUser(newUser);
            }
            //Chose else if in the event more roles were added, but understand else makes more sense
            //Check for admin
            else if(selectedRoleIndex == 1)
            {
                //Set new user to admin
                UserAccount newUser = new UserAccount(name, userName, password, UserAccount.Role.Admin);
                //Add to list through data class
                Data.AddUser(newUser);
            }
            //Update LV after adding
            UpdateListView();
        }

        //Logout button
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            // Your logout logic here
            Data.currentUser = null;
            this.Close();
        }

        //Method to fill combobox
        public void PreloadComboBox()
        {
            cbRole.Items.Add("User");
            cbRole.Items.Add("Admin");
            cbRole.SelectedIndex = 0;
        }

        //Method to update LV
        public void UpdateListView()
        {
            //Clears on load/use
            lvAdminPageDisplay.Items.Clear();
            //Populates LV
            foreach(UserAccount user in Data.accounts)
            {
                lvAdminPageDisplay.Items.Add(user);
            }
        }
    }
}
