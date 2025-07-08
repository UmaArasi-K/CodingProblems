using ProjectEuler.Problems;

namespace ProjectEuler.Tests;

[TestClass]
public class ProblemManagerHelperTest
{
	#region Tests
	[TestMethod]
	public void GetProblemTypes_ReturnsAllDecoratedProblems()
	{
		// Act
		Dictionary<int, Type> problemTypes = ProblemManagerHelper.GetProblemTypes();

		// Assert
		Assert.IsTrue(problemTypes.Count > 0, "No problems found.");
		Assert.IsTrue(problemTypes.ContainsKey(1), "Problem 001 not found.");
		Assert.AreEqual(typeof(Problem001), problemTypes[1], "Problem 001 type mismatch.");
	}

	[TestMethod]
	public void GetProblemTypes_OnlyReturnsIProblemImplementations()
	{
		// Act
		Dictionary<int, Type> problemTypes = ProblemManagerHelper.GetProblemTypes();

		// Assert
		foreach(Type type in problemTypes.Values)
		{
			Assert.IsTrue(typeof(IProblem).IsAssignableFrom(type), $"{type.Name} does not implement IProblem.");
		}
	}

	[TestMethod]
	public void GetProblemTypes_HasUniqueIds()
	{
		// Act
		Dictionary<int, Type> problemTypes = ProblemManagerHelper.GetProblemTypes();

		// Assert
		List<int> duplicateIds =
		[
			.. problemTypes
			   .GroupBy(p => p.Key)
			   .Where(g => g.Count() > 1)
			   .Select(g => g.Key)
		];

		Assert.AreEqual(0, duplicateIds.Count, $"Duplicate ProblemIds found: {string.Join(", ", duplicateIds)}");
	}

	[TestMethod]
	public void AllProblemClasses_HaveProblemIdAttribute()
	{
		// Arrange
		IEnumerable<Type> allProblemClasses = typeof(IProblem).Assembly
		                                                      .GetTypes()
		                                                      .Where(t => typeof(IProblem).IsAssignableFrom(t) && t is { IsAbstract: false, IsInterface: false });

		// Act & Assert
		foreach(Type type in allProblemClasses)
		{
			object? attr = type.GetCustomAttributes(typeof(ProblemIdAttribute), false).FirstOrDefault();
			Assert.IsNotNull(attr, $"Missing [ProblemId] attribute on {type.Name}");
		}
	}
	#endregion
}