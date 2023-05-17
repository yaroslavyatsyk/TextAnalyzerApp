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
    /// Interaction logic for WordFrequencyWindow.xaml
    /// </summary>
    public partial class WordFrequencyWindow : Window
    {
        TextAnalyzerClass analyzerClass;
        public WordFrequencyWindow(TextAnalyzerClass textAnalyzerClass)
        {
            InitializeComponent();
            analyzerClass = textAnalyzerClass;

            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("Word");
            dataTable.Columns.Add("Frequency");

            
            foreach (var item in analyzerClass.GetWordsFrequency())
            {
                dataTable.Rows.Add(item.Key, item.Value);
            }

            FrequencyWordDataGrid.ItemsSource = dataTable.DefaultView;

           
        }
    }
}
