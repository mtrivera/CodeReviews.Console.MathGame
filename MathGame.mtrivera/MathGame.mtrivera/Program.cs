﻿DisplayMainMenu();

int roundCount = 3;
string userMenuChoice = null;
List<string> gameHistory = new List<string>();

do
{
    try
    {
        userMenuChoice = GetUserMenuSelection();
    }
    catch (ArgumentOutOfRangeException ex)
    {
        Console.WriteLine(ex.Message);
        Console.WriteLine("Error occurred. Please try again.");
    }
} while (userMenuChoice == null);

string GetUserMenuSelection()
{
    string? userInput;

    userInput = Console.ReadLine();

    if (userInput != null)
    {
		userInput = userInput.Trim().ToUpper();

		if (!IsValidMenuChoice(userInput))
        {
            throw new ArgumentOutOfRangeException("Invalid Input. Please type a valid menu option.");
        }
    }
    return userInput;
}

int GetRandomNum()
{
    Random rand = new Random();
    return rand.Next(0, 100);
}

(int, int) GetRandomPair()
{
    return (GetRandomNum(), GetRandomNum());
}

switch (userMenuChoice)
{
    case "V":
        ViewGameHistory();
        break;
    case "A":
        Addition(GetRandomPair(), gameHistory, roundCount);
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

void Addition((int, int)pairOfNums, List<string> history, int count)
{
 if (count == 0)
 {
        return;
 }

  bool IsValidGuess = false;
  string? userInput;
  int userGuess = 0;
  int solution = pairOfNums.Item1 + pairOfNums.Item2;
  Console.WriteLine("Addition");
  Console.WriteLine(pairOfNums.Item1.ToString().PadLeft(6));
  // TODO: Fix padding
  Console.WriteLine("+ " + pairOfNums.Item2.ToString().PadLeft(6));
  
  // TODO
  // Move to seperate method: GetUserGuess
  do
  {
        userInput = Console.ReadLine();
        if (userInput != null && userInput != "")
        {
            IsValidGuess = int.TryParse(userInput, out userGuess);
            if (IsValidGuess)
            {
				if (userGuess == solution)
				{
					DateTime localDate = DateTime.Now;
					history.Add($"{localDate}\tAddition\t{userGuess}");
					Console.WriteLine("Correct. Press any key to continue.");
					Addition(GetRandomPair(), gameHistory, count - 1);
				}
				else
				{
					Console.WriteLine("Incorrect.");
					return;
				}
			}
            else
            {
                Console.WriteLine("Invalid input. Please enter a numerical solution.");
            }
        }
  } while(IsValidGuess == false);
}

void DisplayMainMenu()
{
	Console.WriteLine("What game would you like to play today?");
	Console.WriteLine("Choose from the options below");

	Console.WriteLine("V - View Game History");
	Console.WriteLine("S - Subtraction");
	Console.WriteLine("A - Addition");
	Console.WriteLine("D - Division");
	Console.WriteLine("M - Multiplication");
	Console.WriteLine("Q - Quit Game");
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