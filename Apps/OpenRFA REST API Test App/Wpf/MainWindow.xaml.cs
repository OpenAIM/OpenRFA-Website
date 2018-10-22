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
using Newtonsoft.Json;

namespace Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Temporary field for storing data
        public static string RawData { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            // Show login form
            pnlLogin.Visibility = Visibility.Visible;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            // CSRF is required for login
            ORfaAuth.GetCsrfToken();

            ORfaAuth.userName = txtUsername.Text;
            ORfaAuth.userPassword = txtPassword.Password;

            ORfaAuth.LogIn();

            // Hide login form if session is successful.
            // NOOB: There is definitely a better way to do this
            if (ORfaAuth.currentSession.Token.Length > 10)
            {
                pnlLogin.Visibility = Visibility.Hidden;
            }

            // Temporary retrieval of shared parameters
            SharedParameter.GetParameters();

            // Display current session data in sidebar
            txtSidebar.Text = "Welcome, " + ORfaAuth.currentSession.User.Name + "!";
            txtSidebar.Text += "\n" + ORfaAuth.currentSession.User.Mail;

            // Display raw data in text box as indented JSON
            txtRawData.Text = RawData;
            //System.Windows.Clipboard.SetText(RawData);

        }
    }
}
