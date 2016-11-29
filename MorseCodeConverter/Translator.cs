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
		public Dictionary<char, string> AlphaToMorse = new Dictionary<char, string>();
		public Dictionary<string, char> MorseToAlpha = new Dictionary<string, char>();
		string fileName = "MorseCode.txt";

		public Translator()
		{
			if (File.Exists(fileName))
			{
				// Load the Morse Code dictionaries from a csv file 
				using (var codeFile = new StreamReader(fileName))
				{

					while (codeFile.Peek() > 0)        // while there is something in the file
					{
						var line = codeFile.ReadLine().Split(',');
						var letter = Convert.ToChar(line[0]);
						AlphaToMorse[letter] = line[1];
						MorseToAlpha[line[1]] = letter;
					}
				}
				//Console.WriteLine($"the code for c is{AlphaToMorse['C']}");
				//Console.ReadLine();
			}
			else
			{
				Console.WriteLine("MorseCode.txt is missing so dictionary could not be built");
				Console.ReadLine();
			}

		}
	}
}
