using System;
using System.Collections.Generic;

namespace enums_and_interfaces
{
	interface ISavableToDatabase {
		void SaveToDatabase();
	}

	class Animal {
		public void Speak() {
			Console.WriteLine("muuuu");
		}
	}

	class IceCream : ISavableToDatabase {
		public void SaveToDatabase() {
			Console.WriteLine("The Ice Cream was saved to the database.");
		}
	}

	class Elk : Animal, ISavableToDatabase {
		public void SaveToDatabase() {
			Console.WriteLine("The Elk was saved to the database.");
		}
	}
	class Wolf : Animal, ISavableToDatabase {
		public void SaveToDatabase() {
			Console.WriteLine("The Wolf was saved to the database.");
		}
	}

	class Fox : Animal {}

	enum SelectableOptions { CreateAElk = 10, CreateAWolf, CreateAFox }

    class Program
    {
		static SelectableOptions GetChoiceFromUser() {
			// TODO: This should be a Console.ReadLine
			Console.Write("Ange ditt val: ");
			string input = Console.ReadLine();
			int inputAsInt = Convert.ToInt32(input);
			SelectableOptions option = (SelectableOptions)inputAsInt;
			bool exists = Enum.IsDefined(typeof(SelectableOptions), option);

			return option;
		}
		
        static void Main(string[] args)
        {
			List<ISavableToDatabase> listOfThingsToCreate = new List<ISavableToDatabase>();
			Animal theAnimalToCreate;

			Console.WriteLine("Make a choice to create: [" + Convert.ToInt32(SelectableOptions.CreateAFox) + "] for Fox [" + Convert.ToInt32(SelectableOptions.CreateAElk) + "] for Elk and ["+ Convert.ToInt32(SelectableOptions.CreateAWolf) +"] for Wolf");
			SelectableOptions choice = GetChoiceFromUser();

			switch (choice) {
				case SelectableOptions.CreateAElk: 
					Console.WriteLine("You selected to create an Elk");
					theAnimalToCreate = new Elk();
					break;
				case SelectableOptions.CreateAWolf:
					Console.WriteLine("You selected Wolf");
					theAnimalToCreate = new Wolf();
					break;
				case SelectableOptions.CreateAFox: 
					Console.WriteLine("You selected Fox");
					theAnimalToCreate = new Fox();
					break;
				default:
					Console.WriteLine("No selection, you get an Elk!");
					break;
			}

			// NOTE: Commented out code for clarity
			// if (theAnimalToCreate is ISavableToDatabase) {
			// 	listOfThingsToCreate.Add(theAnimalToCreate as ISavableToDatabase);
			// }

			// foreach(ISavableToDatabase creatableThing in listOfThingsToCreate) {
			// 	creatableThing.SaveToDatabase();
			// }

			Console.WriteLine("End of selection program");
        }
    }
}