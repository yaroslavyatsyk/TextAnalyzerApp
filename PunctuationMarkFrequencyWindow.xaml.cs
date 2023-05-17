using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for PunctuationMarkFrequencyWindow.xaml
    /// </summary>
    public partial class PunctuationMarkFrequencyWindow : Window
    {

        TextAnalyzerClass analyzerClass;
        public PunctuationMarkFrequencyWindow(TextAnalyzerClass analyzerClass)
        {
            InitializeComponent();
            this.analyzerClass = analyzerClass;

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Punctuation Mark");
            dataTable.Columns.Add("Frequency");

            foreach (var item in analyzerClass.GetFrequencyOfPunctuationMarks())
            {
                dataTable.Rows.Add(item.Key, item.Value);
            }

            dataGrid.ItemsSource = dataTable.DefaultView;
        }
    }
}
