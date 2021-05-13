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

namespace calculator_wpf
{
    public class Calculator
    {
        public List<double> numbers = new List<double>();
        public List<char> signs = new List<char>();
        double result = 0;
        string input;
        private void GetInput()
        {
            double intBuffer = 0;

            foreach (char m in input)
            {
                if (Char.IsDigit(m))
                {
                    intBuffer = intBuffer * 10;
                    intBuffer = intBuffer + (m - '0');
                }
                else
                {
                    numbers.Add(intBuffer);
                    intBuffer = 0;
                    signs.Add(m);
                }               
            }
            numbers.Add(intBuffer);
        }
        private void CalculateResult()
        {
            for(int i = 0; i < signs.Count;)
            {
                if(signs[i] == '/')
                {
                    numbers[i] = numbers[i] / numbers[i + 1];
                    numbers.RemoveAt(i + 1);
                    signs.RemoveAt(i);
                }else if(signs[i] == '*')
                {
                    numbers[i] = numbers[i] * numbers[i + 1];
                    numbers.RemoveAt(i + 1);
                    signs.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
            result += numbers[0];

            for(int i = 1; i < numbers.Count; i++)
            {
                if(signs[i-1] == '+')
                {
                    result += numbers[i];
                }
                if (signs[i-1] == '-')
                {
                    result -= numbers[i];
                }
            }
        }

        public Calculator(string input)
        {
            this.input = input;
            GetInput();
            CalculateResult();
        }

        public double getResult()
        {
            return result;
        }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
           
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Calculator calc = new Calculator(equation.Text);
           
           
            Output.Text = calc.getResult().ToString();

        }
    }
}
