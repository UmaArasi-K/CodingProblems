namespace ProjectEuler.Problems;

public interface IProblem
{
	/// <summary>
	/// Returns the question or prompt to be displayed before solving.
	/// </summary>
	string GetQuestion();

	/// <summary>
	/// Solves the problem with optional arguments.
	/// </summary>
	object Solve(params object[] args);
}