using Microsoft.VisualBasic;

namespace ProjectEuler.Problems
{
	[ProblemId(8)]
	public class Problem008 : IProblem
	{
		#region Publics
		public string GetQuestion()
		{
			return @"The four adjacent digits in the 1000-digit number that have the greatest product are 9*9*8*9=5832.
					Find the thirteen adjacent digits in the 1000-digit number that have the greatest product. What is the value of this product?";
		}

		public object Solve(params object[] args)
		{
			long Input = ParseInput(args);
			string givenInput ="7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801869478851843858615607891129494954595017379583319528532088055111254069874715852386305071569329096329522744304355766896648950445244523161731856403098711121722383113622298934233803081353362766142828064444866452387493035890729629049156044077239071381051585930796086670172427121883998797908792274921901699720888093776657273330010533678812202354218097512545405947522435258490771167055601360483958644670632441572215539753697817977846174064955149290862569321978468622482839722413756570560574902614079729686524145351004748216637048440319989000889524345065854122758866688116427171479924442928230863465674813919123162824586178664583591245665294765456828489128831426076900422421902267105562632111110937054421750694165896040807198403850962455444362981230987879927244284909188845801561660979191338754992005240636899125607176060588611646710940507754100225698315520005593572972571636269561882670428252483600823257530420752963450";
			var digits = givenInput.Select(c => int.Parse(c.ToString())).ToList();
			return GetResult(digits,Input);
		}
		#endregion

		#region Privates
		private static long ParseInput(params object[] args)
		{
			long input = 4;
			if(args.Length <= 0) return input;
			input = args[0] switch
			{
				int l => l,
				long i => i,
				string => throw (new ArgumentException("Input should be a number"))
			};
			return input;
		}

		private long GetResult(List<int> InitialList,long Input)
		{
			int start = 0;
			int ListLength = InitialList.Count;
			long Maximum = 0;
			while(start+Input<=ListLength)
			{
				if(InitialList.Slice(start, Convert.ToInt32(Input)).Contains(0))
				{
					start =start + InitialList.Slice(start, Convert.ToInt32(Input)).FindIndex(x => x == 0)+1;
					continue;
				}
				Maximum = Math.Max(Maximum, MultiplyList(InitialList.Slice(start, Convert.ToInt32(Input))));

				start++;
			}
			return Maximum;
		}

		private long MultiplyList(List<int> List)
		{
			return List.Aggregate(1L, (a, b) => a * b);
		}
		#endregion
	}
}