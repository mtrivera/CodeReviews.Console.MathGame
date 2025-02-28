namespace MathGame.mtrivera
{
	class MathGame
	{
		Problem problem = new();
		public List<string> GameHistory { get; set; } = new List<string>();
		public int ProblemRemainingCount { get; set; } = Difficulty.Novice.Level;
		
		public void Play()
		{
			problem.GameLoop(GameHistory, ProblemRemainingCount);
		}

		//public void GameLoop()
		//{

		//	DisplayMainMenu();
		//	string? userMenuChoice = null;

		//	do
		//	{
		//		try
		//		{
		//			userMenuChoice = GetUserMenuSelection();
		//		}
		//		catch (ArgumentOutOfRangeException ex)
		//		{
		//			Console.WriteLine(ex.Message);
		//			Console.WriteLine("Error occurred. Please try again.");
		//		}
		//	} while (userMenuChoice == null);

		//	switch (userMenuChoice)
		//	{
		//		//case "V":
		//		//	ViewGameHistory(_gameHistory);
		//		//	break;
		//		case "A":
		//			problem.Spawn(problem.Addition, GameHistory, ProblemRemainingCount);
		//			break;
		//		//case "S":
		//		//	problem.Spawn(problem.Subtraction, _gameHistory, _problemRemainingCount);
		//		//	break;
		//		//case "M":
		//		//	problem.Spawn(problem.Multiplication, _gameHistory, _problemRemainingCount);
		//		//	break;
		//		//case "D":
		//		//	problem.Spawn(problem.Division, _gameHistory, _problemRemainingCount);
		//		//	break;
		//		//case "Q":
		//		//	Quit();
		//		//	break;
		//	}
		//}

		//public string GetUserMenuSelection()
		//{
		//	string? userInput;

		//	userInput = Console.ReadLine();

		//	if (userInput != null)
		//	{
		//		userInput = userInput.Trim().ToUpper();

		//		if (!IsValidMenuChoice(userInput))
		//		{
		//			throw new ArgumentOutOfRangeException("Invalid Input. Please type a valid menu option.");
		//		}
		//	}
		//	return userInput!;
		//}

		//void ViewGameHistory(List<string> scores)
		//{
		//	if (scores.Count > 0)
		//	{
		//		scores.ForEach(Print);
		//	}
		//	else
		//	{
		//		Console.WriteLine("Empty history. Please play a game.");
		//	}
		//	GameLoop();
		//}

		bool IsValidMenuChoice(string input)
		{
			Dictionary<string, string> mathGameCommands = new Dictionary<string, string>
			{
				{"A", "Addition"},
				{"D", "Division"},
				{"M", "Multiplication"},
				{"S", "Subtraction"},
				{"V", "View History"},
				{"Q", "Quit Game"}
			};

			return mathGameCommands.ContainsKey(input.ToUpper());
		}

		//public void Quit()
		//{
		//	Console.WriteLine("Thanks for playing!");
		//	Environment.Exit(0);
		//}
	}
}