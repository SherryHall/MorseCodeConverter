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
			bool keepGoing = true;
			Translator currTranslate = new Translator();

			
			while(keepGoing)
			{
				Console.Write("Do you want to translate a message to morse code (Y/N)?  ");
				char answer = Console.ReadKey().KeyChar;
				if (answer.Equals('Y') | answer.Equals('y'))
				{
					Console.WriteLine("\nEnter the message to encode: (Alphanumberic characters only!)");
					var message = Console.ReadLine();
					var codeString = currTranslate.EncodeIt(message);
					Console.WriteLine($"The morse code is {codeString}");
					currTranslate.SaveTranslation(message, codeString);
				}
				else
				{
					keepGoing = false;
				}
			}
		}
	}
}
