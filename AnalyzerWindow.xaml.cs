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
using TextAnalyzerFinal;

namespace TextAnalyzerApp
{
    /// <summary>
    /// Interaction logic for AnalyzerWindow.xaml
    /// </summary>
    public partial class AnalyzerWindow : Window
    {
        TextAnalyzerClass analyzerClass;
        public AnalyzerWindow(TextAnalyzerClass analyzerClass)
        {
            InitializeComponent();
            this.analyzerClass = analyzerClass;

            //Display the text in the text box

            textBox.Text = analyzerClass.GetString;

            textBox1.Text = analyzerClass.GetLongWord().Item1 + " Length: " + analyzerClass.GetLongWord().Item2;

            textBox2.Text = analyzerClass.GetShortWord().Item1 + " Length: " + analyzerClass.GetShortWord().Item2;

            textBox3.Text = analyzerClass.CalculateWordAmount().ToString();

            textBox4.Text = analyzerClass.CalculateSpaceAmount().ToString();

            textBox5.Text = analyzerClass.CalculateDigitsAmount().ToString();

            textBox6.Text = analyzerClass.CalculateLettersAmount().ToString();

            textBox7.Text = analyzerClass.GetVowelsAmount().ToString();

            textBox8.Text = analyzerClass.GetConsonantsAmount().ToString();

            textBox9.Text = analyzerClass.GetAverageWordLength().ToString();

            textBox10.Text = analyzerClass.GetPunctuationMarksAmount().ToString();
        }
    }
}
