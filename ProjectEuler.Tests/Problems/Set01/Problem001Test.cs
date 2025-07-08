using ProjectEuler.Problems;

namespace ProjectEuler.Tests;

[TestClass]
public class Problem001Test
{
	#region Tests
	[TestMethod]
	public void Test_Solve_ReturnsCorrectSum_ForDefaultLimit()
	{
		// Arrange
		Problem001 problem = new();

		// Act
		object result = problem.Solve();

		// Assert
		Assert.AreEqual((long) 233168, result);
	}

	[TestMethod]
	public void Test_Solve_ReturnsCorrectSum_ForGivenLimit()
	{
		// Arrange
		Problem001 problem = new();

		// Act
		object result = problem.Solve(10);

		// Assert
		Assert.AreEqual((long) 23, result);
	}

	[TestMethod]
	[ExpectedException(typeof(ArgumentException))]
	public void Test_Solve_ThrowsException_WhenInvalidArg()
	{
		// Arrange
		Problem001 problem = new();

		// Act
		problem.Solve("not-an-int");

		// Assert - handled by ExpectedException
	}
	#endregion
}