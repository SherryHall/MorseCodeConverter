using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseCodeConverter
{
	class Program
	{
		static void Main(string[] args)
		{
			// Homework week 4 day 2.  Encode enter message into morse code. Decode morse code into message. Display past messages encoded.

			bool keepGoing = true;
			Translator currTranslate = new Translator();


			while (keepGoing)
			{
				// Translate a message into Morse Code
				Console.Write("Do you want to translate a message to morse code (Y/N)?  ");
				char answer1 = Console.ReadKey().KeyChar;
				if (answer1.Equals('Y') | answer1.Equals('y'))
				{
					Console.WriteLine("\nEnter the message to encode: (Alphanumberic characters only!)");
					var message = Console.ReadLine();
					var codeString = currTranslate.EncodeIt(message);
					Console.WriteLine($"The morse code is {codeString}");
					currTranslate.SaveTranslation(message, codeString);
				}
				else
				{
					Console.WriteLine();
					Console.WriteLine();
					keepGoing = false;
				}
			}

			keepGoing = true;
			while (keepGoing)
			{
				// Translate Morse Code into a message 
				Console.Write("Do you want to translate morse code into a message (Y/N)?  ");
				char answer2 = Console.ReadKey().KeyChar;
				if (answer2.Equals('Y') | answer2.Equals('y'))
				{
					Console.WriteLine("\nEnter the message to decode: (Dots and Dashes only! Separate letters with a space and words with /)");
					var morseCode = Console.ReadLine();
					var decodeString = currTranslate.DecodeIt(morseCode);
					Console.WriteLine($"The message is:  {decodeString}");
				}
				else
				{
					Console.WriteLine();
					keepGoing = false;
				}
			}

			// Display past translations
			Console.Write("Do you want to see the past messages encoded (Y/N?  ");
			char answer3 = Console.ReadKey().KeyChar;
			if (answer3.Equals('Y') | answer3.Equals('y'))
			{
				currTranslate.DisplayAllPrior();
				Console.ReadLine();
			}
		}
	}
}
