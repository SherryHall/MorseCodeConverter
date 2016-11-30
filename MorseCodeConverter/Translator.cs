using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseCodeConverter
{
	class Translator
	{
		public Dictionary<char, string> AlphaToCode = new Dictionary<char, string>();
		public Dictionary<string, char> CodeToAlpha = new Dictionary<string, char>();
		string keyFile = "MorseCode.csv";


		public Translator()
		{
			if (File.Exists(keyFile))
			{
				// Load the Morse Code dictionaries from a csv file 
				using (var codeFile = new StreamReader(keyFile))
				{
					// while there are lines remaining in the file, read the line, split into Char and morse code, add to dictionaries
					while (codeFile.Peek() > 0)        
					{
						var line = codeFile.ReadLine().Split(',');
						var letter = Convert.ToChar(line[0]);
						AlphaToCode[letter] = line[1];
						CodeToAlpha[line[1]] = letter;
					}
				}
			}
			else
			{
				Console.WriteLine("MorseCode.txt is missing so dictionary could not be built");
				Console.ReadLine();
			}
		}

		public string EncodeIt(string message)
		{
			// Translate message into morse code with a space between each letter and / between words
			string codeString = String.Empty;
			string value;
			var words = message.Split(' ');
			foreach (string word in words)
			{
				for (int i = 0; i < word.Length; i++)
				{
					//codeString += AlphaTCode[char.ToUpper( word[i])] + " ";
					if (AlphaToCode.TryGetValue(char.ToUpper(word[i]), out value))
					{
						codeString += value + " ";
					}
				}
				// Remove last space at end of string and Add end of word separator
				codeString = codeString.TrimEnd() + '/';
			}
			return codeString;
		}

		public void SaveTranslation (string message, string codeString)
		{
			string transFile = "Translations.csv";
			//using (var translations = new StreamWriter(transFile))
			using (var translations = File.AppendText(transFile))
			{
				translations.WriteLine($"{message},{codeString}");
			}
		}
	}
}
