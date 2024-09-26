class Problem
{

	const int MIN_RAND_SEED = 0;
	const int MAX_RAND_SEED = 100;

	private int _operand;
	private string _problemOperator;

	public int Operand
	{
		get
		{
			Random rand = new();
			return rand.Next(MIN_RAND_SEED, MAX_RAND_SEED);
		}
	}

	public void Spawn(int count, (int, int) pairOfNums)
	{
		bool IsValidGuess = false;
		string? userInput = null;
		int userGuess = 0;

		Display(pairOfNums, "Addition", "+");
		userGuess = GetUserGuess(userInput);

		int solution = pairOfNums.Item1 + pairOfNums.Item2;
	}

	public int GetUserGuess(string? userInput)
	{
		int userGuess;
		bool isValidGuess = false;
		do
		{
			userInput = Console.ReadLine();
			isValidGuess = int.TryParse(userInput, out userGuess);

			if (isValidGuess)
			{
				return userGuess;
			}
			else
			{
				Console.WriteLine("Invalid input. Please enter a numerical solution.");
			}
		} while (isValidGuess == false);
		return userGuess;
	}

	//public bool isCorrectGuess()
	//{
	//	VerifyGuess()
	//	if (userGuess == solution)
	//	{ // TODO: Refactor to RecordScore
	//		DateTime localDate = DateTime.Now;
	//		history.Add($"{localDate}\tAddition\t{userGuess}");
	//		Console.WriteLine("Correct. Press any key to continue.");
	//		Addition(GetRandomPair(), history, count - 1);
	//	}
	//	else
	//	{
	//		Console.WriteLine("Incorrect.");
	//		return;
	//	}
	//}

	public void Display((int, int) pairOfNums, string problemType, string problemOperator)
	{
		Console.WriteLine(problemType);
		Console.WriteLine(pairOfNums.Item1.ToString().PadLeft(6));
		Console.WriteLine($"{problemOperator} " + pairOfNums.Item2.ToString().PadLeft(6));
	}
}

//# Problem

//## Fields
//private int operand
//private string operator

//## Methods

//Spawn

//Addition
//Subtraction
//Multiplication
//Division