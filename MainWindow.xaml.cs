﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TextAnalyzerFinal;
namespace TextAnalyzerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        TextAnalyzerClass analyzerClass;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                string filename = openFileDialog.FileName;
                string text = System.IO.File.ReadAllText(filename);
               
                analyzerClass = new TextAnalyzerClass(text);

                AnalyzerWindow analyzerWindow = new AnalyzerWindow(analyzerClass);

                PunctuationMarkFrequencyWindow punctuationMarkFrequencyWindow = new PunctuationMarkFrequencyWindow(analyzerClass);
                punctuationMarkFrequencyWindow.Show();

                WordFrequencyWindow wordFrequencyWindow = new WordFrequencyWindow(analyzerClass);
                wordFrequencyWindow.Show();

                CharacterFrequencyPerWordWindow characterFrequencyPerWordWindow = new CharacterFrequencyPerWordWindow(analyzerClass);
                characterFrequencyPerWordWindow.Show();



                analyzerWindow.Show();

            }
            
        }

       

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            

            System.Windows.MessageBox.Show("This is a text analyzer application. It will analyze the text you enter and give you the number of words, characters, and lines in the text. It will also give you the average word length and the average line length. You can also save the text to a file and open a text file to analyze it. Enjoy!","About the app",MessageBoxButton.OK,MessageBoxImage.Information);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string text = textBox.Text;

            analyzerClass = new TextAnalyzerClass(text);

            AnalyzerWindow analyzerWindow = new AnalyzerWindow(analyzerClass);
            analyzerWindow.Show();

            WordFrequencyWindow wordFrequencyWindow = new WordFrequencyWindow(analyzerClass);
            wordFrequencyWindow.Show();

            CharacterFrequencyPerWordWindow characterFrequencyPerWordWindow = new CharacterFrequencyPerWordWindow(analyzerClass);
            characterFrequencyPerWordWindow.Show();

            PunctuationMarkFrequencyWindow punctuationMarkFrequencyWindow = new PunctuationMarkFrequencyWindow(analyzerClass);
            punctuationMarkFrequencyWindow.Show();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            textBox.Clear();
        }
    }
}
