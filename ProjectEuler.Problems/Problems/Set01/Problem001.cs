namespace ProjectEuler.Problems;

[ProblemId(1)]
public class Problem001 : IProblem
{
	#region Publics
	public string GetQuestion()
	{
		return "If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.\n" +
		       "Find the sum of all the multiples of 3 or 5 below 1000.";
	}

	public object Solve(params object[] args)
	{
		long lUpperLimit = ParseInput(args);
		long lSum = SolveByMath(lUpperLimit);
		// long lSum = SolveByLogic(lUpperLimit);

		return lSum;
	}
	#endregion

	#region Privates
	private static long ParseInput(params object[] args)
	{
		long lUpperLimit = 1000;

		if(args.Length <= 0) return lUpperLimit;

		lUpperLimit = args[0] switch
		{
			int i => i,
			long l => l,
			_ => throw new ArgumentException("Expected an integer as the first argument.")
		};

		return lUpperLimit;
	}

	private static long SolveByMath(long lUpperLimit)
	{
		return SumDivisibleBy(3, lUpperLimit) + SumDivisibleBy(5, lUpperLimit) - SumDivisibleBy(15, lUpperLimit);
	}

	private static long SumDivisibleBy(long lDivisible, long lUpperLimit)
	{
		long lPossibles = (lUpperLimit - 1) / lDivisible;

		return lDivisible * lPossibles * (lPossibles + 1) / 2;
	}

	private static long SolveByLogic(long lUpperLimit)
	{
		long lSum = 0;

		for(long i = 3; i <= lUpperLimit; i += 3)
		{
			lSum += i;
		}

		for(long i = 5; i <= lUpperLimit; i += 5)
		{
			if(i % 15 == 0) continue;

			lSum += i;
		}

		return lSum;
	}
	#endregion
}