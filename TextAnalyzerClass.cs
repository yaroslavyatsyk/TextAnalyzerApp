using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalyzerFinal
{
    public class TextAnalyzerClass
    {
        private readonly string sentence;

        public TextAnalyzerClass(string text)
        {
            text = text.Replace(Environment.NewLine, " ");
            sentence = text;
        }

        public string GetString { get { return sentence; } }
        public int CalculateSpaceAmount()
        {
            int spaceAmount = 0;
            for(int i = 0; i < sentence.Length; i++)
            {
                if(sentence[i] == ' ')
                {
                    spaceAmount++;
                }
            }
            return spaceAmount;
        }
        public int CalculateWordAmount()
        {
            return sentence.Trim(new char[] { '!', '.', ',', '(', ')', '&', '@'}).Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public Tuple<string, int> GetLongWord()
        {

           string[] words = sentence.Trim(new char[] { '!', '.', ',', '(', ')', '&', '@' }).Split(' ');
          

            string longWord = words[0].Trim(new char[] { '!', '.', ',', '(', ')', '&', '@' });
            int maxLength = words[0].Trim(new char[] { '!', '.', ',', '(', ')', '&', '@' }).Length;

            for(int i = 0; i < words.Length; i++)
            {
                if(words[i].Trim(new char[] { '!', '.', ',', '(', ')', '&', '@' }).Length > maxLength)
                {
                    longWord = words[i].Trim(new char[] { '!', '.', ',', '(', ')', '&', '@' });
                    maxLength = words[i].Trim(new char[] { '!', '.', ',', '(', ')', '&', '@' }).Length;
                }
            }

            
            return Tuple.Create(longWord, maxLength);
        }
        public int CalculateDigitsAmount()
        {
            int digitsAmount = 0;
            foreach(char symbol in sentence)
            {
                if(char.IsDigit(symbol))
                {
                    digitsAmount++;
                }
            }
            return digitsAmount;
        }
        public int CalculateLettersAmount()
        {
            int lettersAmount = 0;

            foreach (char symbol in sentence)
            {
                if(char.IsLetter(symbol))
                {
                    lettersAmount++;
                }
            }
            return lettersAmount;
        }
        public Tuple<string, int> GetShortWord()

        {
            string[] words = sentence.Trim(new char[] { '!', '.', ',', '(', ')', '&', '@' }).Split(' ', StringSplitOptions.RemoveEmptyEntries);


            string shortWord = words[0].Trim(new char[] { '!', '.', ',', '(', ')', '&', '@' });
            int minLength = words[0].Trim(new char[] { '!', '.', ',', '(', ')', '&', '@' }).Length;

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Trim(new char[] { '!', '.', ',', '(', ')', '&', '@' }).Length < minLength)
                {
                    shortWord = words[i].Trim(new char[] { '!', '.', ',', '(', ')', '&', '@' });
                    minLength = words[i].Trim(new char[] { '!', '.', ',', '(', ')', '&', '@' }).Length;
                }
            }
            return Tuple.Create(shortWord, minLength);
        }
        private Dictionary<char, int> GetSpecialCharactersOccurance()
        {
            Dictionary<char, int> result = new Dictionary<char, int>();

            foreach(char symbol in sentence)
            {
               if(result.ContainsKey(symbol))
                {
                    result[symbol]++;
                }
               else
                {
                    result.Add(symbol, 1);
                }
            }
            return result;
        }
        public List<KeyValuePair<char, int>> GetSpecialList()
        {
           Dictionary<char, int> keyValuePairs = GetSpecialCharactersOccurance();

            List<KeyValuePair<char, int>> result = new List<KeyValuePair<char, int>>();

            foreach(KeyValuePair<char,int> item in keyValuePairs)
            {
                if(!char.IsLetterOrDigit(item.Key) && !char.IsWhiteSpace(item.Key))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public int CalculateUpperCaseLettersAmount()
        {
            int result = 0;

            foreach(char symbol in sentence)
            {
                if(char.IsUpper(symbol))
                {
                    result++;
                }
            }
            return result;
        }

        public int CalculateLowerCaseLettersAmount()
        {
            int result = 0;

            foreach (char symbol in sentence)
            {
                if (char.IsLower(symbol))
                {
                    result++;
                }
            }
            return result;
        }

        public double GetAverageWordLength()
        {
            double result = 0;

            string[] words = sentence.Trim(new char[] { '!', '.', ',', '(', ')', '&', '@' }).Split(' ');

            for(int i = 0; i < words.Length; i++)
            {
                result += words[i].Length;
            }

            return result / words.Length;

        }

        public List<string> GetUniqueWordList()
        {
            List<string> uniqueList = new List<string>();

            string[] words = sentence.Trim(new char[] { '!', '.', ',', '(', ')', '&', '@' }).Split(' ', StringSplitOptions.RemoveEmptyEntries);


            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (keyValuePairs.ContainsKey(word.Trim(new char[] { '!', '.', ',', '(', ')', '&', '@' })))
                {
                    keyValuePairs[word.Trim(new char[] { '!', '.', ',', '(', ')', '&', '@' })]++;
            }
            else
                {
                keyValuePairs.Add(word.Trim(new char[] { '!', '.', ',', '(', ')', '&', '@' }), 1);
            }
            }

            foreach (KeyValuePair<string, int> item in keyValuePairs)
            {
                if (item.Value == 1)
                {
                    uniqueList.Add(item.Key);
                }
            }
            return uniqueList;


        }
        public List<string> GetRepeatWordList()
        {
            List<string> wordList = new List<string>();

            string[] words = sentence.Trim(new char[] { '!', '.', ',', '(', ')', '&', '@' }).Split(' ', StringSplitOptions.RemoveEmptyEntries);

        
            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();


            for(int i = 0; i < words.Length; i++)
            {
                if (keyValuePairs.ContainsKey(words[i].Trim(new char[] { '!', '.', ',', '(', ')', '&', '@' })))
                {
                    keyValuePairs[words[i].Trim(new char[] { '!', '.', ',', '(', ')', '&', '@' })]++;
                }
                else
                {
                    keyValuePairs.Add(words[i].Trim(new char[] { '!', '.', ',', '(', ')', '&', '@' }), 1);
                }
            }

            foreach(KeyValuePair<string, int> item in keyValuePairs)
            {
                if(item.Value > 1)
                {
                    wordList.Add(item.Key);
                }
            }
            return wordList;

           
        }


    }
}
