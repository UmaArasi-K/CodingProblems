namespace ProjectEuler.Problems
{
	[ProblemId(6)]
	public class Problem006 : IProblem
	{
		#region Publics
		public string GetQuestion()
		{
			return @"The sum of the squares of the first ten natural numbers is, 1^2+2^2+....+10^2 = 385.

			The square of the sum of the first ten natural numbers is, (1+2+....+10)^2=3025

			Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 
			3025-385 = 2640.

			Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.";
		}

		public object Solve(params object[] args)
		{
			List<long> values = ParseInput(args);
			return GetResult(values[0], values[1]);
		}
		#endregion

		#region Privates
		private static List<long> ParseInput(params object[] args)
		{
			long upperLimit = 10;
			long lowerLimit = 1;

			if(args.Length <= 0) return [lowerLimit, upperLimit];
			string strInput = args.Parse();
			List<long> longInput = new List<long>();
			foreach(string item in strInput.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
			{
				if(long.TryParse(item, out long val))
				{
					longInput.Add(val);
				}
			}

			lowerLimit = longInput[0];
			upperLimit = longInput[1];
			return [lowerLimit, upperLimit];
		}

		private long GetResult(long Lower, long Upper)
		{
			long SqSum = 0;
			long SumSq = 0;
			for(long i = Lower; i <= Upper; i++)
			{
				SqSum += Square(i);
				SumSq += i;
			}
			return (SumSq*SumSq-SqSum);
		}

		private long Square(long i)
		{
			return (i*i);
		}
		#endregion
	}
}