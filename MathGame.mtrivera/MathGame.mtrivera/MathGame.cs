//enum Difficulty
//{
//	Novice = 4,
//	Intermediate = 6,
//	Advanced = 8,
//	Expert = 12
//};

class MathGame
{

	private List<string> _gameHistory = new List<string>();
	private int _problemRemainingCount = 4;

	public void GameLoop()
	{
		//DisplayMainMenu();
		string? userMenuChoice = null;

		//do
		//{
		//	try
		//	{
		//		userMenuChoice = GetUserMenuSelection();
		//	}
		//	catch (ArgumentOutOfRangeException ex)
		//	{
		//		Console.WriteLine(ex.Message);
		//		Console.WriteLine("Error occurred. Please try again.");
		//	}
		//} while (userMenuChoice == null);

		//switch (userMenuChoice)
		//{
		//	case "V":
		//		ViewGameHistory(gameHistory);
		//		break;
		//	case "A":
		//		Addition(GetRandomPair(), gameHistory, roundCount);
		//		break;
		//	case "S":
		//		Subtraction(GetRandomPair(), gameHistory, roundCount);
		//		break;
		//	case "M":
		//		Multiplication(GetRandomPair(), gameHistory, roundCount);
		//		break;
		//	case "D":
		//		Division(GetRandomPair(), gameHistory, roundCount);
		//		break;
		//	case "Q":
		//		Quit();
		//		break;
		//}
	}

	public void Quit()
	{
		Console.WriteLine("Thanks for playing!");
		Environment.Exit(0);
	}
}
