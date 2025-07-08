using System.Reflection;
using ProjectEuler.Problems;

namespace ProjectEuler.Tests;

[TestClass]
public class ProblemIdAttributeTest
{
	#region Tests
	[TestMethod]
	public void Attribute_IsDefinedOnProblem001()
	{
		// Arrange
		Type type = typeof(Problem001);

		// Act
		bool hasAttribute = type.GetCustomAttributes(typeof(ProblemIdAttribute), false).Any();

		// Assert
		Assert.IsTrue(hasAttribute, "ProblemIdAttribute is not defined on Problem001.");
	}

	[TestMethod]
	public void Attribute_HasCorrectIdValue()
	{
		// Arrange
		Type type = typeof(Problem001);

		// Act
		ProblemIdAttribute? attribute = type.GetCustomAttribute<ProblemIdAttribute>();

		// Assert
		Assert.IsNotNull(attribute, "ProblemIdAttribute was not found.");
		Assert.AreEqual(1, attribute.Id, "ProblemIdAttribute does not return correct ID.");
	}

	[TestMethod]
	public void All_IProblem_Implementations_Have_Unique_ProblemIds()
	{
		// Arrange
		IEnumerable<Type> allProblemTypes = typeof(IProblem).Assembly
		                                                    .GetTypes()
		                                                    .Where(t => typeof(IProblem).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

		List<int?> problemIds = allProblemTypes
		                        .Select(t => t.GetCustomAttribute<ProblemIdAttribute>()?.Id)
		                        .Where(id => id != null)
		                        .ToList();

		List<int?> duplicates = problemIds
		                        .GroupBy(id => id)
		                        .Where(g => g.Count() > 1)
		                        .Select(g => g.Key)
		                        .ToList();

		// Assert
		Assert.AreEqual(0, duplicates.Count, $"Duplicate ProblemIds found: {string.Join(", ", duplicates)}");
	}
	#endregion
}