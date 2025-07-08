using System.Diagnostics;
using ProjectEuler.Problems;

namespace ProjectEuler.Runner;

public class Program
{
	#region Properties
	private static Dictionary<int, Type> PROBLEMS => ProblemManagerHelper.GetProblemTypes();
	#endregion

	#region Privates
	private static void Main()
	{
		try
		{
			while(true)
			{
				Console.Write("Enter problem number to run (or 'q' to quit): ");

				string? strInput = Console.ReadLine()?.Trim();

				if(string.IsNullOrEmpty(strInput))
				{
					WriteColoredOutput("\nInput cannot be empty.\n", ConsoleColor.Yellow);
					continue;
				}

				if(string.Equals(strInput, "Q", StringComparison.OrdinalIgnoreCase)) break;

				if(!int.TryParse(strInput, out int nId))
				{
					WriteColoredOutput("\nInvalid input. Please enter a number.\n", ConsoleColor.Red);
					continue;
				}

				StartProblem(nId);
			}
		}
		catch(OperationCanceledException)
		{
			WriteColoredOutput("\nOperation cancelled.", ConsoleColor.Yellow);
		}
		catch(Exception exception)
		{
			WriteColoredOutput($"\nUnexpected error: {exception.Message}.", ConsoleColor.Red);
		}
	}

	private static void StartProblem(int nId)
	{
		if(PROBLEMS.TryGetValue(nId, out Type? problemType))
		{
			if(Activator.CreateInstance(problemType) is not IProblem problem)
			{
				WriteColoredOutput("Failed to create problem instance.", ConsoleColor.Red);
				return;
			}

			WriteColoredOutput($"\nProblem {nId}:", ConsoleColor.Cyan);
			Console.WriteLine(problem.GetQuestion());

			Console.Write("\nEnter problem arguments (comma separated): ");
			string? strUserInput = Console.ReadLine();
			object[] args = ParseUserInput(strUserInput);

			Stopwatch stopwatch = Stopwatch.StartNew();

			string result = problem.Solve(args).Parse();
			
			stopwatch.Stop();

			WriteColoredOutput($"\nResult: {result}", ConsoleColor.Green);
			WriteColoredOutput($"Time taken: {stopwatch.ElapsedMilliseconds} ms\n", ConsoleColor.DarkGray);
		}
		else
		{
			WriteColoredOutput("\nProblem not found.\n", ConsoleColor.Red);
		}
	}

	private static object[] ParseUserInput(string? strInput)
	{
		return string.IsNullOrWhiteSpace(strInput) ? [] : [.. strInput.Split(',').Select(arg => ParseArgument(arg.Trim()))];
	}

	private static object ParseArgument(string arg)
	{
		if(int.TryParse(arg, out int i)) return i;
		if(long.TryParse(arg, out long l)) return l;
		if(double.TryParse(arg, out double d)) return d;
		if(bool.TryParse(arg, out bool b)) return b;

		return arg;
	}

	private static void WriteColoredOutput(string strText, ConsoleColor color)
	{
		ConsoleColor colorPrevious = Console.ForegroundColor;

		Console.ForegroundColor = color;
		Console.WriteLine(strText);
		Console.ForegroundColor = colorPrevious;
	}
	#endregion
}