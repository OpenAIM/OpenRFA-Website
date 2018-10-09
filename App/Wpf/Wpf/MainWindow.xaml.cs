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
using RestSharp;

namespace Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Pagination settings
        public int currentPage { get; set; }
        public int paramsPerPage = 100;

        // Authentication
        public static Session Session = new Session();
        public static CsrfToken CsrfToken = new CsrfToken();

        public string userName = string.Empty;
        public string userPassword = string.Empty;


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
            // Get credentials from text boxes
            ORfaAuth.LogIn(txtUsername.Text, txtPassword.Password);

            // Hide login form if session is successful.
            // NOOB: There is definitely a better way to do this
            if (MainWindow.CsrfToken.Token.Length > 10)
            {
                pnlLogin.Visibility = Visibility.Hidden;
                mainGrid.Visibility = Visibility.Visible;
            }

            // Display current session data in sidebar
            txtSidebar.Text = "Welcome, " + Session.User.Name + "!";
            txtSidebar.Text += "\n" + Session.User.Mail;
        }

        private void btnInputGuid_Click(object sender, RoutedEventArgs e)
        {
            string json = SharedParameter.GetParameterByGuid(new Guid(inputGuid.Text), Session.Token);

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

            btnPrevious.IsEnabled = true;
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            // Go to previous page
            currentPage -= paramsPerPage;

            DisplayParameterPage(currentPage);
        }

        private void DisplayParameterPage(int offset)
        {
            string json = string.Empty;

            if (comboState.SelectedIndex == 0)
                json = SharedParameter.GetPagedParameters(paramsPerPage, currentPage, 3, Session.Token);
            if (comboState.SelectedIndex == 1)
                json = SharedParameter.GetPagedParameters(paramsPerPage, currentPage, 2, Session.Token);
            if (comboState.SelectedIndex == 2)
                json = SharedParameter.GetPagedParameters(paramsPerPage, currentPage, 4, Session.Token);

            // Deserialize JSON to list of Shared Parameter objects
            List<SharedParameter> sharedParameters = JsonConvert.DeserializeObject<List<SharedParameter>>(json);

            DisplayObjectsInDataGrid(sharedParameters);

            // Enable next button if there are more items
            if (sharedParameters.Count == paramsPerPage)
                btnNext.IsEnabled = true;
            else
                btnNext.IsEnabled = false;

            // Enable previous button if there are previous items
            if (currentPage > paramsPerPage)
                btnPrevious.IsEnabled = true;
            else
                btnPrevious.IsEnabled = false;
        }


        /// <summary>
        /// Displays a list of objects in the MainDataGrid
        /// </summary>
        /// <param name="list">A list of objects to display in the data grid</param>
        private void DisplayObjectsInDataGrid(List<SharedParameter> list)
        {
            CollectionViewSource itemCollectionViewSource;
            itemCollectionViewSource = (CollectionViewSource)(FindResource("ItemCollectionViewSource"));
            itemCollectionViewSource.Source = list;
        }

        // Open a web page when parameter is double-clicked
        private void DataGridMain_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender != null)
            {
                DataGrid grid = sender as DataGrid;
                if (grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1)
                {
                    DataGridRow dgr = grid.ItemContainerGenerator.ContainerFromItem(grid.SelectedItem) as DataGridRow;

                    SharedParameter selectedParam = dgr.Item as SharedParameter;

                    System.Diagnostics.Process.Start(OpenRfa.baseUrl + selectedParam.Guid);
                }
            }
        }

        private void btnNewParam_Click(object sender, RoutedEventArgs e)
        {
            NewParameterWindow newParameterWindow = new NewParameterWindow();
            newParameterWindow.Show();
        }
    }
}
