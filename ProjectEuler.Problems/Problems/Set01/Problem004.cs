
namespace ProjectEuler.Problems
{
	[ProblemId(4)]
	#region Publics
	public class Problem004 : IProblem
	{
		public string GetQuestion()
		{
			return @"A palindromic number reads the same both ways. 
			The largest palindrome made from the product of two 2-digit numbers is 9009 = 91*99.
			Find the largest palindrome made from the product of two 3-digit numbers.";
		}
		public object Solve(params object[] args)
		{
			long input=ParseInput(args);
			int inital = 10;
			long value = inital;
			for(int i = 1; i < input; i++)
			{
				value = value * inital;
			}
			long resultPalindrome=Calculate(value-1,value-1);
			return resultPalindrome;
		}
	#endregion

	#region Privates
	private static long ParseInput(params object[] args)
		{
			long input = 2;
			if(args.Length <= 0) return input;
			input = args[0] switch
			{
				int i => i,
				long l => l,
				_ => throw new ArgumentException("Expected an integer as the first argument")
			};
			return input;
		}
		private static long Calculate(long first, long second)
		{
			long currentmax = 0;
			do
			{
				long product = first * second;
				second--;
				if(IsPalindrome(product))
				{
					currentmax=Math.Max(currentmax,product);
				}
				if(second*first<currentmax)
				{
					first--;
					second = first;
				}
			}
			while(first > 0 && second > 0);
			return currentmax;
		}
		private static bool IsPalindrome(long number)
		{
			string strNumber = number.ToString();
			int length = strNumber.Length;
			for(int i = 0; i < length / 2; i++)
			{
				if(strNumber[i] != strNumber[length - 1 - i])
				{
					return false;
				}
			}
			return true;
		}
		#endregion
	}
}
