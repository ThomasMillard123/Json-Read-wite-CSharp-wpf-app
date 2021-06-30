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

namespace Json_Wirter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
           
        }


        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            
        }


        //mode change
        private void AddModeActivate(object sender, RoutedEventArgs e)
        {
            Input.Content = new Page1();
        }

        private void RemoveModeActivate(object sender, RoutedEventArgs e)
        {
            Input.Content = new Page2();
        }
        private void FindModeActivate(object sender, RoutedEventArgs e)
        {
            Input.Content = new Page3();
        }
        private void UpdateModeActivate(object sender, RoutedEventArgs e)
        {
            Input.Content = new Page4();
        }
        private void DisplayModeActivate(object sender, RoutedEventArgs e)
        {
            Input.Content = new Page5();
        }
    }
}
