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


        private string GetSanitizedString()
        {
            return string.Concat(sentence.Where(c => !char.IsPunctuation(c)));
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
            string sanitized = GetSanitizedString();

            return sanitized.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public Tuple<string, int> GetLongWord()
        {

           string sanitized = GetSanitizedString();

            string[] words = sanitized.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var wordToLengthMap = GetLengthForEachWord();


            string longWord = string.Empty;
            int maxLength = 0;

            for (int i = 0; i < words.Length; i++)
            {
                if (wordToLengthMap[words[i]] > maxLength)
                {
                    maxLength = wordToLengthMap[words[i]];
                    longWord = words[i];
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
           string sanitized = GetSanitizedString();

            string[] words = sanitized.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var wordToLengthMap = GetLengthForEachWord();

            int shortestLength = int.MaxValue;
            string shortWord = string.Empty;


            for (int i = 0; i < words.Length; i++)
            {
                if (wordToLengthMap[words[i]] < shortestLength)
                {
                    shortestLength = wordToLengthMap[words[i]];
                    shortWord = words[i];
                }
            }
            return Tuple.Create(shortWord, shortestLength);


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

           string sanitized = GetSanitizedString();

            string[] words = sanitized.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for(int i = 0; i < words.Length; i++)
            {
                result += words[i].Length;
            }

            return Math.Round(result / words.Length,1);

        }

    

        public Dictionary<string,int> GetWordsFrequency()
        {
            string sanitized = GetSanitizedString();

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

            string vowels = "aeiouAEIOU";

          

            for(int i = 0; i < sentence.Length; i++)
            {

                if (vowels.Contains(sentence[i]))
                {
                    result++;
                }
            }
            return result;
        }

        public int GetConsonantsAmount()
        {
            int result = 0;
            string consonants = "bcdfghjklmnpqrstvwxyz" + "bcdfghjklmnpqrstvwxyz".ToUpper();
         
            for (int i = 0; i < sentence.Length; i++)
            {
                if (consonants.Contains(sentence[i]))
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

            string sanitized = GetSanitizedString();

            string[] words = sanitized.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; i++)
            {


                Dictionary<char, int> charFrequency = new Dictionary<char, int>();
                for (int j = 0; j < words[i].Length; j++)
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

        public Dictionary<string, int> GetLengthForEachWord() {

            Dictionary<string, int> WordToLength = new Dictionary<string, int>();
            string sanitized = GetSanitizedString();

            string[] words = sanitized.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; i++)
            {
                if (!WordToLength.ContainsKey(words[i]))
                {
                    WordToLength.Add(words[i], words[i].Length);
                }
            }

            return WordToLength;



        }
        public List<char> GetUniqueLetters()
        {

            
            Dictionary<char, int> frequency = new Dictionary<char, int>();
            var sanitized = string.Concat(sentence.Where(c => !char.IsPunctuation(c))).ToLower();
            foreach (char symbol in sanitized)
            {
                if (char.IsLetter(symbol))
                {
                   if(frequency.ContainsKey(symbol))
                    {
                        frequency[symbol]++;
                    }
                    else
                    {
                        frequency.Add(symbol, 1);
                    }
                }
            }

            return frequency.Keys.Where(c => frequency[c] == 1).ToList();


        }
        public List<string> GetUniqueWords()
        {
            
            Dictionary<string, int> frequency = new Dictionary<string, int>();
            string sanitized = string.Concat(sentence.Where(c => !char.IsPunctuation(c))).ToLower();
            string[] words = sanitized.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                if (frequency.ContainsKey(word))
                {
                    frequency[word]++;
                }
                else
                {
                    frequency.Add(word, 1);
                }
            }
            return frequency.Keys.Where(c => frequency[c] == 1).ToList();

        }


    }
}
