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
        List<Bug> bugList;

        BugDatabaseInterface connection;
        public MainWindow()
        {
            InitializeComponent();
            ConnectionStatusLbl.Content = "Connecting...";
            this.connection = new DummyDataConnection("data.txt");
            if (this.connection.Connect())
            {
                ConnectionStatusLbl.Foreground = new SolidColorBrush(Colors.Green);
                ConnectionStatusLbl.Content = "Connected!";
            }
            else
            {
                ConnectionStatusLbl.Foreground = new SolidColorBrush(Colors.Red);
                ConnectionStatusLbl.Content = "Connection failed :(";
            }
            this.bugList = new List<Bug>();
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            BugListView.ItemsSource = null;
            BugListView.ItemsSource = this.bugList; //This is a hack. Should be using an observable collection...

        }

        private void AddDevBtn_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow popup = new AddUserWindow();
            popup.ShowDialog();
            if (popup.NewUserName != "")
            {
                this.bugList.AddRange(this.connection.ImportBugsAssignedTo(popup.NewUserName)); //doesn't properly handle dupes
                this.UpdateBugCount();
            }
        }
        private void UpdateBugCount()
        {
            BugCountLbl.Content = "Total: "+ this.bugList.Count + " bugs";
            BugListView.ItemsSource = null;
            BugListView.ItemsSource=this.bugList; //This is a hack. Should be using an observable collection...
        }

        private void ImportBugBtn_Click(object sender, RoutedEventArgs e)
        {
            AddBugWindow popup = new AddBugWindow();
            popup.ShowDialog();
            if (popup.BugId != "")
            {
                String[] BugIds = popup.BugId.Split(';');
                this.bugList.AddRange(this.connection.ImportBugById(BugIds)); //doesn't properly handle dupes
                this.UpdateBugCount();
            }
        }
    }
}
