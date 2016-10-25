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
using System.Diagnostics;
using ExtensionMethods;

namespace AnalysisOfAlgs_Project3
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //take input
            int size = Convert.ToInt32(textBox.Text);
            int max = Convert.ToInt32(textBox1.Text);
            int search = Convert.ToInt32(textBox2.Text);

            //initialize random array
            int[] searchInt = new int[size];
            Random rand = new Random();

            textBoxOutput.AppendText(Environment.NewLine);
            textBoxOutput.AppendText("-----------------------------------------------------------");
            textBoxOutput.AppendText(Environment.NewLine);

            textBoxOutput.AppendText("Array values: ");

            for (int i=0; i < size; i++)
            {
                searchInt[i] = rand.Next(1,max);
                textBoxOutput.AppendText(searchInt[i]+",");
            }

            textBoxOutput.AppendText(Environment.NewLine);
            textBoxOutput.AppendText("Found operands: ");
            textBoxOutput.AppendText(Environment.NewLine);

            Stopwatch timer = new Stopwatch();
            timer.Start();

            /*expected time is on order of n+m where in is size of initial array and m is operand number to search for addition operands
             * Process:
             * 1. Create an array that will hold all values smaller than the result we are searching for, initialized to 0 - O(2m)
             * 2. Loop through initial array and compare if value is smaller than the result, if so increment the index in the sub array - O(n+2m)
             * 3. Test if operand pairs have index values > 0, if both so, they must be present - O(m)
             */

            //step 1: - need to initialize to 0 using extension method
            int[] subArray = new int[search];
            subArray.Populate(0);

            //step 2:
            for (int i = 0; i<size; i++)
            {
                if (searchInt[i] < search)
                {
                    subArray[searchInt[i]]++;
                }
            }
            int count = 0;
            //step 3:
            for (int i = 1; i<=Convert.ToInt32(Math.Floor(search/2.0)); i++)
            {
                int operandOne = i;
                int operandTwo = search - i;
                if (subArray.TwoIndexMin(operandOne, operandTwo) > 0)
                {
                    textBoxOutput.AppendText("(" + operandOne + ", " + operandTwo + ") : " + subArray.TwoIndexMin(operandOne, operandTwo));
                    textBoxOutput.AppendText(Environment.NewLine);
                    count++;
                }
            }


            timer.Stop();
            textBoxOutput.AppendText("Total time: "+timer.Elapsed + " for n = "+size+", and m = "+search+" and "+ count +" total unique pairs were found.");
        }
    }
}
