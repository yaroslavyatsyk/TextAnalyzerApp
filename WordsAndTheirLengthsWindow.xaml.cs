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
    /// Interaction logic for WordsAndTheirLengthsWindow.xaml
    /// </summary>
    public partial class WordsAndTheirLengthsWindow : Window
    {
        TextAnalyzerClass analyzerClass;
        
        public WordsAndTheirLengthsWindow(TextAnalyzerClass textAnalyzerClass)
        {
            InitializeComponent();
            this.analyzerClass = textAnalyzerClass;

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Word");
            dataTable.Columns.Add("Length");

            foreach (var item in analyzerClass.GetLengthForEachWord())
            {
                dataTable.Rows.Add(item.Key, item.Value);
            }
            dataGrid.ItemsSource = dataTable.DefaultView;

            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
