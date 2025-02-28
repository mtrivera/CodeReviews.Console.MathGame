namespace MathGame.mtrivera
{
	public record Difficulty(int Level, string Name)
	{
		public static Difficulty Novice { get; } = new(4, "Novice");
		public static Difficulty Intermediate { get; } = new(6, "Intermediate");	
		public static Difficulty Advanced { get; } = new(8, "Advanced");
		public static Difficulty Expert { get; } = new(12, "Expert");
		public override string ToString() => Name;
	}
}