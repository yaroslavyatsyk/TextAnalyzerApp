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
      
        public Dictionary<char,int> GetFrequencyOfPunctuationMarks()
        {
            Dictionary<char, int> keyValuePairs = new Dictionary<char, int>();
            for(int i = 0; i < sentence.Length; i++)
            {
                if (!char.IsLetterOrDigit(sentence[i]) && !char.IsWhiteSpace(sentence[i]))
                {
                    if (keyValuePairs.ContainsKey(sentence[i]))
                    {
                        keyValuePairs[sentence[i]]++;
                    }
                    else
                    {
                        keyValuePairs.Add(sentence[i], 1);
                    }
                }
            }
            return keyValuePairs;
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

            return Math.Round(result / words.Length,1);

        }

    

        public Dictionary<string,int> GetWordsFrequency()
        {
            string sanitized = string.Concat(sentence.Where(c => !char.IsPunctuation(c))).ToLower();

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
                    keyValuePairs.TryAdd(words[i], 1);
                }
            }

            return keyValuePairs;
        }

        public int GetVowelsAmount()
        {
            int result = 0;

            string vowels = "aeiou";

            string lowerCased = sentence.ToLower();

            for(int i = 0; i < lowerCased.Length; i++)
            {

                if (vowels.Contains(lowerCased[i]))
                {
                    result++;
                }
            }
            return result;
        }

        public int GetConsonantsAmount()
        {
            int result = 0;
            string consonants = "bcdfghjklmnpqrstvwxyz";
            string lowerCased = sentence.ToLower();
            for (int i = 0; i < lowerCased.Length; i++)
            {
                if (consonants.Contains(lowerCased[i]))
                {
                    result++;
                }
            }
            return result;
        }


        public int GetPunctuationMarksAmount()
        {
            int result = 0;
            
            foreach(char symbol in sentence)
            {
                if(!char.IsLetterOrDigit(symbol) && !char.IsWhiteSpace(symbol))
                {
                    result++;
                }
            }
            return result;
        }

        public List<KeyValuePair<string,Dictionary<char,int>>> GetCharacterFrequencyPerWord()
        {

            List<KeyValuePair<string, Dictionary<char,int>>> keyValuePairs = new List<KeyValuePair<string, Dictionary<char, int>>>();

            string sanitized = string.Concat(sentence.Where(c => !char.IsPunctuation(c))).ToLower();

            string[] words = sanitized.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for(int i = 0; i < words.Length; i++)
            {
               

                Dictionary<char, int> charFrequency = new Dictionary<char, int>();
                for(int j = 0; j < words[i].Length; j++)
                {
                    if (charFrequency.ContainsKey(words[i][j]))
                    {
                        charFrequency[words[i][j]]++;
                    }
                    else
                    {
                        charFrequency.TryAdd(words[i][j], 1);
                    }
                }
                keyValuePairs.Add(new KeyValuePair<string, Dictionary<char, int>>(words[i], charFrequency));
            }


            return keyValuePairs;

        }



    }
}
