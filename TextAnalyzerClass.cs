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
            string sanitized = string.Concat(sentence.Where(c => !char.IsPunctuation(c)));

            return sanitized.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public Tuple<string, int> GetLongWord()
        {

           string sanitized = string.Concat(sentence.Where(c => !char.IsPunctuation(c)));

            string[] words = sanitized.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string longWord = words[0];
            int maxLength = words[0].Length;

            for(int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > maxLength)
                {
                    longWord = words[i];
                    maxLength = words[i].Length;
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
           string sanitized = string.Concat(sentence.Where(c => !char.IsPunctuation(c)));

            string[] words = sanitized.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string shortWord = words[0];
            int minLength = words[0].Length;

            for(int i = 0; i < words.Length; i++)
            {
                if (words[i].Length < minLength)
                {
                    shortWord = words[i];
                    minLength = words[i].Length;
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
            double result = 0d;

           string sanitized = string.Concat(sentence.Where(c => !char.IsPunctuation(c)));

            string[] words = sanitized.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for(int i = 0; i < words.Length; i++)
            {
                result += words[i].Length;
            }

            return result / words.Length;

        }

        public List<string> GetUniqueWordList()
        {
            List<string> uniqueList = new List<string>();

            
            string sanitized = string.Concat(sentence.Where(c => !char.IsPunctuation(c)));

            string[] words = sanitized.Split(' ', StringSplitOptions.RemoveEmptyEntries);


          Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();


            for(int i = 0; i < words.Length; i++)
            {

                if (keyValuePairs.ContainsKey(words[i]))
                {

                    keyValuePairs[words[i]]++;
                }
                else
                {
                    keyValuePairs.Add(words[i], 1);
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
        public List<string> GetListOfDuplicateWords()
        {
            List<string> wordList = new List<string>();

           

            string sanitized = string.Concat(sentence.Where(c => !char.IsPunctuation(c)));

            string[] words = sanitized.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        
           

            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();


            for (int i = 0; i < words.Length; i++)
            {
                if (keyValuePairs.ContainsKey(words[i]))
                {
                    keyValuePairs[words[i]]++;
                }
                else
                {
                    keyValuePairs.Add(words[i], 1);
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

        public Dictionary<string,int> GetWordsFrequency()
        {
            string sanitized = string.Concat(sentence.Where(c => !char.IsPunctuation(c)));

            string[] words = sanitized.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();

            for(int i = 0; i < words.Length; i++)
            {
                if (keyValuePairs.ContainsKey(words[i]))
                {
                    keyValuePairs[words[i]]++;
                }
                else
                {
                    keyValuePairs.Add(words[i], 1);
                }
            }

            return keyValuePairs;
        }


    }
}
