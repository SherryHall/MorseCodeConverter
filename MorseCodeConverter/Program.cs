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
				Console.WriteLine("Do you want to translate a message to morse code (Y/N)?");
				char answer = Console.ReadKey().KeyChar;
				if (answer.Equals('Y') | answer.Equals('y'))
				{

				}
			}
			
			Console.ReadLine();

		}
	}
}
