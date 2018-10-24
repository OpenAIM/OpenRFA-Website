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
using Newtonsoft.Json;

namespace Wpf
{
    /// <summary>
    /// Interaction logic for NewParameterWindow.xaml
    /// </summary>
    public partial class NewParameterWindow : Window
    {
        public NewParameterWindow()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            // Pass values from form to create new shared parameter
            string newSharedParameterResponse = SharedParameter.NewParameter(
                MainWindow.Session, 
                txtParamName.Text, 
                Int32.Parse(txtDataTypeId.Text), 
                Int32.Parse(txtGroupId.Text), 
                txtGroupId.Text
                );

            // Deserialize JSON to Node object
            Node node = new Node();
            node = JsonConvert.DeserializeObject<Node>(newSharedParameterResponse);

            // Open shared parameter page in browser
            System.Diagnostics.Process.Start(node.Uri.ToString());

            // Close window
            this.Close();
        }
    }
}
