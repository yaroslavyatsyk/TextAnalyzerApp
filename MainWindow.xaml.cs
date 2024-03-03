using System;
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
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Paragraph = iTextSharp.text.Paragraph;

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
            try
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

                    WordsAndTheirLengthsWindow wordsAndTheirLengthsWindow = new WordsAndTheirLengthsWindow(analyzerClass);
                    wordsAndTheirLengthsWindow.Show();


                    analyzerWindow.Show();

                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("The file you selected is not a text file!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
            try
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

                WordsAndTheirLengthsWindow wordsAndTheirLengthsWindow = new WordsAndTheirLengthsWindow(analyzerClass);
                wordsAndTheirLengthsWindow.Show();
            }
                        catch (Exception ex)
            {
                System.Windows.MessageBox.Show("The textfield can not be empty!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            textBox.Clear();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string filename = saveFileDialog.FileName;
                    string text = textBox.Text;
                    System.IO.File.WriteAllText(filename, text);
                }
            }
            catch { 
            
                System.Windows.MessageBox.Show("Can not save file!","Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if(analyzerClass is not null)
            {
                NewMethod();
            }
            else
            {
                System.Windows.MessageBox.Show("No text to save!","Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void NewMethod()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "PDF file|*.pdf", ValidateNames = true, FileName = "Text Analyzer Report - " + DateTime.Today.ToString("yyyy/MM/dd") })
            {
                if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Document document = new Document();
                    PdfWriter pdfWriter = PdfWriter.GetInstance(document, new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create));
                    pdfWriter.PageEvent = new PdfPageEventHelper();
                    document.Open();
                    document.NewPage();
                    var titleFont = FontFactory.GetFont("Arial", 18, iTextSharp.text.Font.BOLD);

                    Paragraph title = new iTextSharp.text.Paragraph("Text Analyzer Report", titleFont);

                    title.Alignment = Element.ALIGN_CENTER;

                    document.Add(title);

                    Paragraph dateTitle = new Paragraph("Date: " + DateTime.Today.ToString("yyyy/MM/dd"));
                    title.Alignment = Element.ALIGN_RIGHT;

                    document.Add(dateTitle);

                    document.Add(new Paragraph("\n"));

                    Paragraph textTitle = new Paragraph("Text: ");
                   
                    document.Add(textTitle);

                    document.Add(new Paragraph("\n"));

                    Paragraph text = new Paragraph(analyzerClass.GetString);

                    document.Add(text);

                    document.Add(new Paragraph("\n"));

                    var font = FontFactory.GetFont("Arial", 18, iTextSharp.text.Font.NORMAL);

                    Paragraph paragraph = new Paragraph("Text Analysis. Numeric data", font);
                    paragraph.Alignment = Element.ALIGN_CENTER;
                    document.Add(paragraph);

                    document.Add(new Paragraph("\n"));

                    PdfPTable pdfPTable = new PdfPTable(2);

                    pdfPTable.AddCell("Number of words");
                    pdfPTable.AddCell(analyzerClass.CalculateWordAmount().ToString());

                    pdfPTable.AddCell("Number of letters");
                    pdfPTable.AddCell(analyzerClass.CalculateLettersAmount().ToString());


                    pdfPTable.AddCell("Number of digits");
                    pdfPTable.AddCell(analyzerClass.CalculateDigitsAmount().ToString());

                    pdfPTable.AddCell("Longest word");
                    pdfPTable.AddCell(analyzerClass.GetLongWord().Item1);

                    pdfPTable.AddCell("Shortest word");
                    pdfPTable.AddCell(analyzerClass.GetShortWord().Item1);

                    pdfPTable.AddCell("Average word length");
                    pdfPTable.AddCell(analyzerClass.GetAverageWordLength().ToString());


                    pdfPTable.AddCell("Number of spaces");
                    pdfPTable.AddCell(analyzerClass.CalculateSpaceAmount().ToString());


                    pdfPTable.AddCell("Number of conconants");
                    pdfPTable.AddCell(analyzerClass.GetConsonantsAmount().ToString());

                    pdfPTable.AddCell("Number of vowels");
                    pdfPTable.AddCell(analyzerClass.GetVowelsAmount().ToString());

                    pdfPTable.AddCell("Number of punctuation marks");
                    pdfPTable.AddCell(analyzerClass.GetPunctuationMarksAmount().ToString());

                    document.Add(pdfPTable);

                    document.NewPage();

                    var titleFont2 = FontFactory.GetFont("Arial", 18, iTextSharp.text.Font.BOLD);

                    Paragraph title2 = new iTextSharp.text.Paragraph("Word Frequency", titleFont);

                    title2.Alignment = Element.ALIGN_CENTER;

                    document.Add(title2);

                    document.Add(new Paragraph("\n"));


                    PdfPTable pdfPTable2 = new PdfPTable(2);

                    var wordFrequency = analyzerClass.GetWordsFrequency();

                    pdfPTable2.AddCell("Word");
                    pdfPTable2.AddCell("Frequency");

                    foreach (var item in wordFrequency)
                    {
                        pdfPTable2.AddCell(item.Key);
                        pdfPTable2.AddCell(item.Value.ToString());
                    }

                    document.Add(pdfPTable2);
                    document.NewPage();

                    var titleFont3 = FontFactory.GetFont("Arial", 18, iTextSharp.text.Font.BOLD);
                    Paragraph newParagraph = new Paragraph("Character Frequency Per Word", titleFont3);

                    newParagraph.Alignment = Element.ALIGN_CENTER;
                    document.Add(newParagraph);

                    document.Add(new Paragraph("\n"));

                    PdfPTable pdfPTable3 = new PdfPTable(3);

                    var map = analyzerClass.GetCharacterFrequencyPerWord();

                    pdfPTable3.AddCell("Word");
                    pdfPTable3.AddCell("Character");
                    pdfPTable3.AddCell("Frequency");

                    foreach (var item in map)
                    {
                        foreach (var item2 in item.Value)
                        {
                            pdfPTable3.AddCell(item.Key);
                            pdfPTable3.AddCell(item2.Key.ToString());
                            pdfPTable3.AddCell(item2.Value.ToString());
                        }
                    }

                    document.Add(pdfPTable3);
                    document.NewPage();

                    var titleFont4 = FontFactory.GetFont("Arial", 18, iTextSharp.text.Font.BOLD);

                    Paragraph newParagraph2 = new Paragraph("Punctuation Mark Frequency", titleFont4);

                    newParagraph2.Alignment = Element.ALIGN_CENTER;
                    document.Add(newParagraph2);
                    document.Add(new Paragraph("\n"));

                    PdfPTable pdfPTable4 = new PdfPTable(2);

                    var punctuationMarkFrequency = analyzerClass.GetFrequencyOfPunctuationMarks();

                    pdfPTable4.AddCell("Punctuation Mark");
                    pdfPTable4.AddCell("Frequency");

                    foreach (var item in punctuationMarkFrequency)
                    {
                        pdfPTable4.AddCell(item.Key.ToString());
                        pdfPTable4.AddCell(item.Value.ToString());
                    }

                    document.Add(pdfPTable4);

                   

                    document.Close();
                    pdfWriter.Close();

                    System.Windows.MessageBox.Show("Report saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);






                }
            }
        }
    }
}
