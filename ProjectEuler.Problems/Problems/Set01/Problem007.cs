namespace ProjectEuler.Problems
{
	[ProblemId(7)]
	public class Problem007 : IProblem
	{
		#region Publics
		public string GetQuestion()
		{
			return @"By listing the first six prime numbers: 
					2,3,4,5,7,11 and 13, 
					we can see that the 6th prime is 13.
					What is the 10001st prime number";
		}

		public object Solve(params object[] args)
		{
			long Input = ParseInput(args);
			return GetResult(Input);
		}
		#endregion

		#region Privates
		private static long ParseInput(params object[] args)
		{
			long input = 6;
			if(args.Length <= 0) return input;
			input = args[0] switch
			{
				int l => l,
				long i => i,
				string => throw (new ArgumentException("Input should be a number"))
			};
			return input;
		}

		private long GetResult(long Input)
		{
			List<long> Primes = new List<long>
			                    {
				                    2
			                    };
			long currentElement = 3;
			while(Primes.Count != Input)
			{
				if(IsPrime(currentElement, Primes))
				{
					Primes.Add(currentElement);
				}

				currentElement += 2;
			}

			return Primes[^1];
		}

		private bool IsPrime(long Element, List<long> Primes)
		{
			long limit = (long) Math.Sqrt(Element);
			foreach(long num in Primes)
			{
				if(num > limit) break;
				if(Element % num == 0)
				{
					return false;
				}
			}
			return true;
		}
		#endregion
	}
}