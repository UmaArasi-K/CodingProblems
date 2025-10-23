namespace ProjectEuler.Problems
{
	[ProblemId(5)]

	public class Problem005 : IProblem
	{
		#region Publics
		public string GetQuestion()
		{
			return @"2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
					 What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20 ?";
		}

		public object Solve(params object[] args)
		{
			List<long> values = ParseInput(args);
			List<long> arrfactors = GetValues(values[0], values[1]);
			return ResultOfMultiplication(arrfactors);
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
			foreach(var item in strInput.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
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

		private List<long> GetValues(long lowerLimit, long upperlimit)
		{
			List<long> result = [];
			for(long i = lowerLimit; i <= upperlimit; i++)
			{
				var temp = i;
				foreach(var divident in result)
				{
					if(temp % divident == 0)
					{
						temp=temp/divident;
					}
				}

				if(temp != 1)
				{
					result.Add(temp);
				}
			}

			return result;
		}
		private long ResultOfMultiplication(List<long> factors)
		{
			long result = 1;
			foreach(var factor in factors)
			{
				result *= factor;
			}
			return result;
		}

		
		#endregion
	}
}