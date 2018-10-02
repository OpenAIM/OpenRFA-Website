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

        public int currentPage { get; set; }
        public int paramsPerPage = 100;

        public MainWindow()
        {
            InitializeComponent();

            // Startup Visibility
            pnlLogin.Visibility = Visibility.Visible;
            mainGrid.Visibility = Visibility.Hidden;
        }

        // Login Submit Button
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
                mainGrid.Visibility = Visibility.Visible;
            }

            //// Temporary retrieval of shared parameters
            //txtRawData.Text = SharedParameter.GetParameters();

            // Display current session data in sidebar
            txtSidebar.Text = "Welcome, " + ORfaAuth.currentSession.User.Name + "!";
            txtSidebar.Text += "\n" + ORfaAuth.currentSession.User.Mail;
        }

        private void btnInputGuid_Click(object sender, RoutedEventArgs e)
        {
            string json = SharedParameter.GetParameterByGuid(new Guid(inputGuid.Text));

            // Deserialize JSON to list of Shared Parameter objects
            List<SharedParameter> sharedParameters = JsonConvert.DeserializeObject<List<SharedParameter>>(json);

            DisplayObjectsInDataGrid(sharedParameters);
        }

        private void btnLoadAll_Click(object sender, RoutedEventArgs e)
        {
            DisplayParameterPage(0);
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            // Go to next page
            currentPage += paramsPerPage;

            DisplayParameterPage(currentPage);
        }

        private void DisplayParameterPage(int offset)
        {
            string json = SharedParameter.GetPagedParameters(paramsPerPage, currentPage);

            // Deserialize JSON to list of Shared Parameter objects
            List<SharedParameter> sharedParameters = JsonConvert.DeserializeObject<List<SharedParameter>>(json);

            DisplayObjectsInDataGrid(sharedParameters);

            // Enable next button if there are more items
            if (sharedParameters.Count == paramsPerPage)
                btnNext.IsEnabled = true;
            else
                btnNext.IsEnabled = false;
        }


        /// <summary>
        /// Displays a list of objects in the MainDataGrid
        /// </summary>
        /// <param name="list">A list of objects to display in the data grid</param>
        private void DisplayObjectsInDataGrid (List<SharedParameter> list)
        {
            CollectionViewSource itemCollectionViewSource;
            itemCollectionViewSource = (CollectionViewSource)(FindResource("ItemCollectionViewSource"));
            itemCollectionViewSource.Source = list;
        }

    }
}
