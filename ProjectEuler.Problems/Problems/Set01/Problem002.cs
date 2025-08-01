﻿namespace ProjectEuler.Problems;

[ProblemId(2)]
public class Problem002 : IProblem
{
	#region Publics
	public string GetQuestion()
	{
		return @"Each new term in the Fibonacci sequence is generated by adding the previous two terms. By starting with 1 and 2, the first 10 terms will be:
				1, 2, 3, 5, 8, 13, 21, 34, 55, 89...
				By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.";
	}

	public object Solve(params object[] args)
	{
		long lUpperLimit = ParseInput(args);
		long lSum = Calculate(lUpperLimit);
		// long lSum = SolveByLogic(lUpperLimit);

		return lSum;
	}
	#endregion

	#region Private
	private static long ParseInput(params object[] args)
	{
		long lUpperLimit = 100;

		if(args.Length <= 0) return lUpperLimit;

		lUpperLimit = args[0] switch
		{
			int i => i,
			long l => l,
			_ => throw new ArgumentException("Expected an integer as the first argument.")
		};

		return lUpperLimit;
	}
	private static long Calculate(long val)
	{
		long i = 1;
		long k = 2, sum = 0;
		while(k <= val)
		{
			if(k % 2 == 0)
			{
				sum += k;
			}
			long temp = k;
			k = k + i;
			i = temp;
		}
		return sum;
	}
	#endregion
}