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

namespace Scrummable
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Bug> bugList = new List<Bug>();

        BugDatabaseInterface connection = null;
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void ConnectBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.connection != null)
            {
                this.connection.Disconnect();
                this.connection = null;
                ConnectionStatusLbl.Content = "not connected.";
                ConnectionStatusLbl.Foreground = new SolidColorBrush(Colors.Red);
                ConnectBtn.Content = "Connect";
            }
            else
            {
                ConnectionStatusLbl.Content = "Connecting...";
                //this.connection = new DummyDataConnection("data.txt");
                this.connection = new ProductStudioConnection(ProductNameTB.Text, "redmond.corp.microsoft.com");
                if (this.connection.Connect())
                {
                    ConnectionStatusLbl.Foreground = new SolidColorBrush(Colors.Green);
                    ConnectionStatusLbl.Content = "Connected!";
                    ConnectBtn.Content = "Disconnect";
                }
                else
                {
                    ConnectionStatusLbl.Foreground = new SolidColorBrush(Colors.Red);
                    ConnectionStatusLbl.Content = "Connection failed :(";
                }
                Application.Current.Properties["Bug List"] = new List<Bug>();
                BugListView.ItemsSource = null;
                BugListView.ItemsSource = (List<Bug>)Application.Current.Properties["Bug List"];// this.bugList; //This is a hack. Should be using an observable collection...
            }
        }

        private void AddDevBtn_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow popup = new AddUserWindow();
            popup.ShowDialog();
            if (popup.NewUserName != "")
            {
                ((List<Bug>)Application.Current.Properties["Bug List"]).AddRange(this.connection.ImportBugsAssignedTo(popup.NewUserName)); //doesn't properly handle dupes
                this.UpdateBugCount();
            }
        }
        private void UpdateBugCount()
        {
            BugCountLbl.Content = "Total: "+ ((List<Bug>)Application.Current.Properties["Bug List"]).Count + " bugs";
            BugListView.ItemsSource = null;
            BugListView.ItemsSource = (List<Bug>)Application.Current.Properties["Bug List"]; //this.bugList; //This is a hack. Should be using an observable collection...
        }

        private void ImportBugBtn_Click(object sender, RoutedEventArgs e)
        {
            AddBugWindow popup = new AddBugWindow();
            popup.ShowDialog();
            if (popup.BugId != "")
            {
                String[] BugIds = popup.BugId.Split(';');
                ((List<Bug>)Application.Current.Properties["Bug List"]).AddRange(this.connection.ImportBugById(BugIds)); //doesn't properly handle dupes
                this.UpdateBugCount();
            }
        }

        private void AddSprintBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Not yet implemented.");
        }

        private void SaveChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Not yet implemented.");
        }
    }
}
