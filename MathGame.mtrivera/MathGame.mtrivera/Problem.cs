using System.Diagnostics;

namespace MathGame.mtrivera
{
	class Problem
	{
		public const int MIN_RAND_SEED = 0;
		public const int MAX_RAND_SEED = 101;
		public bool isRandomMode = false;
		public bool isTimeTrial = false;

		Stopwatch stopwatch = new Stopwatch();

		public record MathProblem(string ProblemType, string ProblemOperator);

		public int Roll(int minSeed = MIN_RAND_SEED, int maxSeed = MAX_RAND_SEED)
		{
			Random rand = new Random();
			return rand.Next(minSeed, maxSeed);
		}

		public void DisplayDifficultyMenu(int problemCount)
		{
			Dictionary<int, string> difficultyTitle = new Dictionary<int, string>
			{
				{4, "Novice"},
				{6, "Intermediate"},
				{8, "Advanced"},
				{12, "Expert"}
			};

			Console.WriteLine($"Current difficulty: {difficultyTitle[problemCount]}");
			Console.WriteLine();
			Console.WriteLine("Please select a new difficulty:");
			Console.WriteLine("N - Novice (Least difficult)");
			Console.WriteLine("I - Intermediate");
			Console.WriteLine("A - Advanced");
			Console.WriteLine("E - Expert (Most difficult)");
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
				if (isTimeTrial)
				{
					stopwatch.Stop();
				}

				Console.WriteLine(stopwatch.Elapsed);
				this.GameLoop(history, count);
			}

			bool IsValidGuess = false;
			string? userInput = null;
			int userGuess = 0;
			
			int solution = mathOperation();
			userGuess = GetUserGuess(userInput);

			if (isTimeTrial)
			{
				stopwatch.Start();
			}
		
			if (userGuess == solution)
			{
				RecordScore(userGuess, mathProblemType, history);
				
				if (isRandomMode)
				{
					RandomMode(history, count - 1);
				}
				
				this.Spawn(mathOperation, history, mathProblemType, count - 1);
			}

		}

		void RecordScore(int userGuess, string problemType, List<string> history)
		{
			DateTime localDate = DateTime.Now;
			history.Add($"{localDate}\t{problemType}\t{userGuess}\t{stopwatch.Elapsed}");
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
				case "C":
					DisplayDifficultyMenu(problemCount);
					problemCount = GetDifficultySelectionFromUser();
					this.GameLoop(history, problemCount);
					break;
				case "T":
					isTimeTrial = true;
					this.GameLoop(history, problemCount);
					break;
				case "R":
					isRandomMode = true;
					RandomMode(history, problemCount);
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

		public void RandomMode(List<string> history, int problemCount)
		{
			Random rand = new Random();
			int problemIndex = rand.Next(0, 4);

			List<Func<int>> problems = new List<Func<int>>()
			{
				Addition,
				Subtraction,
				Multiplication,
				Division,
			};

			Dictionary<Func<int>, string> operationNames = new Dictionary<Func<int>, string>
			{
				{Addition, "Addition"},
				{Subtraction, "Subtraction"},
				{Multiplication, "Multiplication"},
				{Division, "Division"}
			};

			Spawn(problems[problemIndex], history, operationNames[problems[problemIndex]], problemCount);
		}

		public void DisplayMainMenu()
		{
			Console.WriteLine("What game would you like to play today?");
			Console.WriteLine("Choose from the options below");

			Console.WriteLine("V - View Game History");
			Console.WriteLine("T - Time Trial");
			Console.WriteLine("R - Random Mode (Random math problems)");
			Console.WriteLine("C - Change Difficulty");
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
				{"T", "Time Trial"},
				{"C", "Change Difficulty"},
				{"R", "Random Mode"},
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

		bool IsValidDifficultyChoice(string input)
		{
			Dictionary<string, Difficulty> difficultyLevels = new Dictionary<string, Difficulty>
			{
				{"N", Difficulty.Novice},
				{"I", Difficulty.Intermediate},
				{"A", Difficulty.Advanced},
				{"E", Difficulty.Expert}
			};

			return difficultyLevels.ContainsKey(input.ToUpper());
		}

		public int GetDifficultySelectionFromUser()
		{
			Dictionary<string, int> difficultyLevels = new Dictionary<string, int>
			{
				{"N", Difficulty.Novice.Level},
				{"I", Difficulty.Intermediate.Level},
				{"A", Difficulty.Advanced.Level},
				{"E", Difficulty.Expert.Level}
			};

			bool isValidDifficulty = false;
			string? userInput = null;

			do
			{
				userInput = Console.ReadLine();

				if (userInput != null)
				{
					userInput = userInput.Trim().ToUpper();

					if (IsValidDifficultyChoice(userInput))
					{
						isValidDifficulty = true;
					}
					else
					{
						Console.WriteLine("Invalid Input. Please type a valid menu option.");
					}
				}
			} while (isValidDifficulty == false);

			return difficultyLevels[userInput!];
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