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

		private long GetResult(long lowerLimit, long upperlimit)
		{
			if(lowerLimit == 1)
			{
				List<long> arrfactors = FactorMethod(lowerLimit, upperlimit);
				return ResultOfMultiplication(arrfactors);
			}

			return LCM(lowerLimit, upperlimit);
		}

		private List<long> FactorMethod(long lowerLimit, long upperlimit)
		{
			List<long> result = [];
			for(long i = lowerLimit; i <= upperlimit; i++)
			{
				long temp = i;
				foreach(long divident in result)
				{
					if(temp % divident == 0)
					{
						temp = temp / divident;
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
			foreach(long factor in factors)
			{
				result *= factor;
			}

			return result;
		}

		private long LCM(long lowerLimit, long upperlimit)
		{
			long LCM = 1;
			for(long i = lowerLimit; i <= upperlimit; i++)
			{
				LCM = (LCM * i) / GCD(LCM, i);
			}

			return LCM;
		}

		private long GCD(long a, long b)
		{
			while(b != 0)
			{
				long temp = b;
				b = a % b;
				a = temp;
			}

			return a;
		}
		#endregion
	}
}