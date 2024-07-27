Console.WriteLine("What game would you like to play today?");
Console.WriteLine("Choose from the options below");

Console.WriteLine("V - View Game History");
Console.WriteLine("S - Subtraction");
Console.WriteLine("A - Addition");
Console.WriteLine("D - Division");
Console.WriteLine("M - Multiplication");
Console.WriteLine("Q - Quit Game");

bool validInput = false;
string? userInput;

do
{
	userInput = Console.ReadLine();
	if (userInput != null)
	{
		if (IsValidMenuChoice(userInput))
		{
			userInput = userInput.Trim().ToUpper();
			validInput = true;
		}
		else
		{
			Console.WriteLine("Invalid Input. Please type a valid menu option.");
			userInput = null;
		}
	}
} while (userInput == null && validInput == false);



switch (userInput)
{
	case "V":
		ViewGameHistory();
		break;
	case "A":
		Addition();
		break;
	case "S":
		Subtraction();
		break;
	case "M":
		Multiplication();
		break;
	case "D":
		Division();
		break;
	case "Q":
		QuitGame();
		break;
}

void ViewGameHistory()
{
	Console.WriteLine("COMING SOON-View game history");
	Console.WriteLine("Please press any key to continue");
	Console.Read();
}

void Addition()
{
	Console.WriteLine("COMING SOON-Addition problem");
	Console.WriteLine("Press any key to continue");
	Console.ReadLine();
}

void Subtraction()
{
	Console.WriteLine("COMING SOON-Subtraction problem");
	Console.WriteLine("Press any key to continue");
	Console.ReadLine();
}

void Multiplication()
{
	Console.WriteLine("COMING SOON-Multiplication problem");
	Console.WriteLine("Press any key to continue");
	Console.ReadLine();
}

void Division()
{
	Console.WriteLine("COMING SOON-Division problem");
	Console.WriteLine("Press any key to continue");
	Console.ReadLine();
}

void QuitGame()
{
	Console.WriteLine("COMING SOON-Quit the game");
	Console.WriteLine("Press any key to continue");
	Console.ReadLine();
}

bool IsValidMenuChoice(string input)
{
	string[] choices = { "V", "A", "Q", "D", "M", "S" };
	return Array.IndexOf(choices, input.ToUpper()) != -1;
}