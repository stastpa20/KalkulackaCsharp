using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace Kalkulacka
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string equation = "";
        private int result = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonNumberClick(object sender, RoutedEventArgs routedEventArgs)
        {
            Button btnNumber = (Button)sender;
            int number =  int.Parse(btnNumber.Content.ToString());
            TextBox.Text += number;
        }
        private void ButtonEqualClick(object sender, RoutedEventArgs routedEventArgs)
        {

        }
        private void ButtonOperationClick(object sender, RoutedEventArgs routedEventArgs)
        {
            Button btnOperator = (Button)sender;
            string[] operators = new string[] { "+", "-", "*", "/"}; 
            string _operator;
            if (btnOperator.Content.ToString() == "÷"){ _operator = "/";}
            else if (btnOperator.Content.ToString() == "×") {_operator = "*"; }
            else { _operator = btnOperator.Content.ToString(); }

            if (operators.Contains(TextBox.Text[TextBox.Text.Length - 1].ToString()/*.Substring(TextBox.Text.Length - 1, 1)*/))
            {
                TextBox.Text = TextBox.Text.Remove(TextBox.Text.Length - 1,1);
            }  
            TextBox.Text += _operator;

        }
        private void ButtonCClick(object sender, RoutedEventArgs routedEventArgs)
        {
            TextBox.Clear();
        }
        private void ButtonDecimalClick(object sender, RoutedEventArgs routedEventArgs)
        {

        }
    }
}
