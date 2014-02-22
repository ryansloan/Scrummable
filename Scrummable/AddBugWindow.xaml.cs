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

namespace Scrummable
{
    /// <summary>
    /// Interaction logic for AddBugWindow.xaml
    /// </summary>
    public partial class AddBugWindow : Window
    {
        public String BugId = "";
        public AddBugWindow()
        {
            InitializeComponent();
        }

        private void AddUserNameBtn_Click(object sender, RoutedEventArgs e)
        {
            this.BugId = BugIdTB.Text;
            this.Close();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
