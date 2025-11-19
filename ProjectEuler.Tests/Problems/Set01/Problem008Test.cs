using ProjectEuler.Problems;

namespace ProjectEuler.Tests;

[TestClass]
public class Problem008Test
{
	#region Tests
	[TestMethod]
	public void Test_Solve_ReturnsCorrectPrime_ForDefaultValue()
	{
		//Arrange
		Problem008 problem = new Problem008();
		//Act
		object result = problem.Solve();
		//Assert
		Assert.AreEqual((long) 5832, result);
	}
	[TestMethod]
	public void Test_Solve_ReturnsCorrectPrime_ForGivenValue()
	{
		//Arrange
		Problem008 problem = new Problem008();
		//Act
		object result = problem.Solve(13);
		//Assert
		Assert.AreEqual((long) 23514624000, result);
	}
	#endregion
}