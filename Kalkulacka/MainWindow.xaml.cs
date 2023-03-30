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
        //private string equation = "";
        private double result = 0;
        string _operatorG;
        int elementsCounter = 0;
        bool resulted = false;
        char[] operators = new char[] { '+', '-', '*', '/' };
        //private bool first = true;

        string[] elements = new string[] { };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonNumberClick(object sender, RoutedEventArgs routedEventArgs)
        {
            Button btnNumber = (Button)sender;
            int number = int.Parse(btnNumber.Content.ToString());
            if (elementsCounter == 1 && resulted)
            {
                elementsCounter--;
                resulted = false;
                TextBox.Clear();
            }

            if (TextBox.Text.Length > 0)
            {
                if (operators.Contains(TextBox.Text[TextBox.Text.Length - 1]) && !resulted)
                {
                    elementsCounter++;
                }
            }
            else
            {
                elementsCounter++;
            }
            
            TextBox.Text += number;
            
        }
        private void ButtonEqualClick(object sender, RoutedEventArgs routedEventArgs)
        {
            
            elements = TextBox.Text.Split(operators);
            if (elements.Length > 1)
            {
                switch (_operatorG)
                {
                    case "+":
                        result = double.Parse(elements[0]) + double.Parse(elements[1]);
                        break;
                    case "-":
                        result = double.Parse(elements[0]) - double.Parse(elements[1]);
                        break;
                    case "*":
                        result = double.Parse(elements[0]) * double.Parse(elements[1]);
                        break;
                    case "/":
                        result = double.Parse(elements[0]) / double.Parse(elements[1]);
                        break;
                    default:
                        break;
                }
                TextBox.Text = result.ToString();
                resulted = true;
                elementsCounter = 1;
            }
            
        }
        private void ButtonOperationClick(object sender, RoutedEventArgs routedEventArgs)
        {
            Button btnOperator = (Button)sender;
            string _operator;

            if (btnOperator.Content.ToString() == "÷") { _operator = "/"; }
            else if (btnOperator.Content.ToString() == "×") { _operator = "*"; }
            else { _operator = btnOperator.Content.ToString(); }

            if (TextBox.Text.Length > 0)
            {
                if (operators.Contains(TextBox.Text[TextBox.Text.Length - 1]))
                {
                    TextBox.Text = TextBox.Text.Remove(TextBox.Text.Length - 1, 1);
                    elementsCounter--;
                }
            }
            
            if (elementsCounter == 3)
            {
                elements = TextBox.Text.Split(operators);
                switch (_operatorG)
                {
                    case "+":
                        result = double.Parse(elements[0]) + double.Parse(elements[1]);
                        break;
                    case "-":
                        result = double.Parse(elements[0]) - double.Parse(elements[1]);
                        break;
                    case "*":
                        result = double.Parse(elements[0]) * double.Parse(elements[1]);
                        break;
                    case "/":
                        result = double.Parse(elements[0]) / double.Parse(elements[1]);
                        break;
                    default:
                        break;

                }
                TextBox.Text = result.ToString();
                elementsCounter = 1;
                resulted = true;
            }

            
            
            if (TextBox.Text.Length > 0)
            {
                _operatorG = _operator;
                TextBox.Text += _operator;
                elementsCounter++;
            }
            

        }
        private void ButtonCClick(object sender, RoutedEventArgs routedEventArgs)
        {
            TextBox.Clear();
            elementsCounter = 0;
        }
        private void ButtonDecimalClick(object sender, RoutedEventArgs routedEventArgs)
        {
            
                string[] veci = TextBox.Text.Split(operators);
                if (veci.Length > 0)
                {
                    if (!veci[veci.Length - 1].Contains(","))
                    {
                        TextBox.Text += ",";
                    }
                }
        }
    }
}
