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
    /// Interaction logic for CharacterFrequencyPerWordWindow.xaml
    /// </summary>
    public partial class CharacterFrequencyPerWordWindow : Window
    {

        TextAnalyzerClass analyzerClass;
        public CharacterFrequencyPerWordWindow(TextAnalyzerClass analyzerClass)
        {
            InitializeComponent();
            this.analyzerClass = analyzerClass;

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Word");
            dataTable.Columns.Add("Character");
            dataTable.Columns.Add("Frequency");

            foreach (var item in analyzerClass.GetCharacterFrequencyPerWord())
            {
                foreach (var item2 in item.Value)
                {
                    dataTable.Rows.Add(item.Key, item2.Key, item2.Value);
                }
            }

            dataGrid.ItemsSource = dataTable.DefaultView;
        }
    }
}
