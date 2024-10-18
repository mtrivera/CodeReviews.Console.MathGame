
namespace MathGame.mtrivera
{
	class Problem
	{
		public const int MIN_RAND_SEED = 0;
		public const int MAX_RAND_SEED = 101;

		public record MathProblem(string ProblemType, string ProblemOperator);

		public int Roll(int minSeed = MIN_RAND_SEED, int maxSeed = MAX_RAND_SEED)
		{
			Random rand = new Random();
			return rand.Next(minSeed, maxSeed);
		}

		public int[] GetRandomNums(int count)
		{
			int[] nums = new int[count];

			for (int i = 0; i < count; i++)
			{
				nums[i] = Roll();
			}

			return nums;
		}


		public int Addition()
		{
			MathProblem addition = new("Addition", "+");
			int[] operands = GetRandomNums(2);
			DisplayContent(operands, addition.ProblemOperator, addition.ProblemType);
			return operands[0] + operands[1];
		}

		public int Division()
		{
			MathProblem division = new("Division", "÷");
			int[] operands = GetRandomNums(2);

			// Ensure that division results in whole number
			while (operands[0] % operands[1] != 0)
			{
				operands = GetRandomNums(2);
			}

			DisplayContent(operands, division.ProblemOperator, division.ProblemType);

			return operands[0] / operands[1];
		}

		public int Multiplication()
		{
			MathProblem multiplication = new("Multiplication", "x");
			int[] operands = GetRandomNums(2);
			DisplayContent(operands, multiplication.ProblemOperator, multiplication.ProblemType);
			return operands[0] * operands[1];
		}

		public int Subtraction()
		{
			MathProblem subtraction = new("Subtraction", "-");
			int[] operands = GetRandomNums(2);
			DisplayContent(operands, subtraction.ProblemOperator, subtraction.ProblemType);
			return operands[0] - operands[1];
		}

		public void Spawn(Func<int> mathOperation, List<string> history, string mathProblemType, int count)
		{
			if (count == 0) 
			{
				this.GameLoop(history, count);
			}

			bool IsValidGuess = false;
			string? userInput = null;
			int userGuess = 0;
			
			int solution = mathOperation();
			userGuess = GetUserGuess(userInput);

			if (userGuess == solution)
			{
				RecordScore(userGuess, mathProblemType, history);
				this.Spawn(mathOperation, history, mathProblemType, count - 1);
			}

		}

		void RecordScore(int userGuess, string problemType, List<string> history)
		{
			DateTime localDate = DateTime.Now;
			history.Add($"{localDate}\t{problemType}\t{userGuess}");
			Console.WriteLine("Correct. Press any key to continue.");
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

		public void DisplayContent(int[] operands, string problemOperator, string problemType)
		{
			Console.WriteLine(problemType);
			Console.WriteLine(operands[0].ToString().PadLeft(6));
			Console.WriteLine($"{problemOperator} " + operands[1].ToString().PadLeft(6));
		}

		public void GameLoop(List<string> history, int problemCount)
		{
			// Reset problem count when finished
			if (problemCount == 0)
			{
				problemCount = 4;
			}

			DisplayMainMenu();
			string? userMenuChoice = null;

			do
			{
				try
				{
					userMenuChoice = this.GetUserMenuSelection();
				}
				catch (ArgumentOutOfRangeException ex)
				{
					Console.WriteLine(ex.Message);
					Console.WriteLine("Error occurred. Please try again.");
				}
			} while (userMenuChoice == null);

			switch (userMenuChoice)
			{
				case "V":
					ViewGameHistory(history, problemCount);
					break;
				case "A":
					this.Spawn(this.Addition, history, "Addition", problemCount);
					break;
				case "S":
					this.Spawn(this.Subtraction, history, "Subtraction", problemCount);
					break;
				case "M":
					this.Spawn(this.Multiplication, history, "Multiplication", problemCount);
					break;
				case "D":
					this.Spawn(this.Division, history, "Division", problemCount);
					break;
				case "Q":
					this.Quit();
					break;
			}
		}

		void Print(string s)
		{
			Console.WriteLine(s);
		}

		void ViewGameHistory(List<string> scores, int problemCount)
		{
			if (scores.Count > 0)
			{
				scores.ForEach(Print);
			}
			else
			{
				Console.WriteLine("Empty history. Please play a game.");
			}
			this.GameLoop(scores, problemCount);
		}

		public void DisplayMainMenu()
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

		public string GetUserMenuSelection()
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
			return userInput!;
		}

		public void Quit()
		{
			Console.WriteLine("Thanks for playing!");
			Environment.Exit(0);
		}

		//public struct Operand
		//{ 
		//	public int Value
		//	{
		//		get
		//		{
		//			Random rand = new Random();
		//			return rand.Next(MIN_RAND_SEED, MAX_RAND_SEED);
		//		}
		//	}
		//}
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