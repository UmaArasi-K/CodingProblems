using ProjectEuler.Problems;

namespace ProjectEuler.Tests;

[TestClass]
public class Problem007Test
{
	#region Tests
	[TestMethod]
	public void Test_Solve_ReturnsCorrectSum_ForDefaultLimit()
	{
		//Arrange
		Problem007 problem = new Problem007();
		//Act
		object result = problem.Solve();
		//Assert
		Assert.AreEqual((long) 13, result);
	}
	[TestMethod]
	public void Test_Solve_ReturnsCorrectSum_ForGivenLimit()
	{
		//Arrange
		Problem007 problem = new Problem007();
		//Act
		object result = problem.Solve(10001);
		//Assert
		Assert.AreEqual((long) 104743, result);
	}
	#endregion
}