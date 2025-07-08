using System.Reflection;

namespace ProjectEuler.Problems;

public class ProblemManagerHelper
{
	#region Internals
	public static Dictionary<int, Type> GetProblemTypes()
	{
		Dictionary<int, Type> dictProblemTypes = typeof(IProblem).Assembly
		                                                         .GetTypes()
		                                                         .Where(t => typeof(IProblem).IsAssignableFrom(t) && t is { IsInterface: false, IsAbstract: false })
		                                                         .Select(t => new
		                                                                      {
			                                                                      Type = t,
			                                                                      t.GetCustomAttribute<ProblemIdAttribute>()?.Id
		                                                                      })
		                                                         .Where(x => x.Id != null)
		                                                         .ToDictionary(x => x.Id!.Value, x => x.Type);

		return dictProblemTypes;
	}
	#endregion
}