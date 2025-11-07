using ProjectEuler.Problems;

namespace ProjectEuler.Tests;

[TestClass]
public class Problem005Test
{
	#region Tests
	[TestMethod]
	public void Test_Solve_ReturnsCorrectSum_ForDefaultLimit()
	{
		//Arrange
		Problem005 problem = new Problem005();
		//Act
		object result = problem.Solve();
		//Assert
		Assert.AreEqual((long) 2520, result);
	}
	[TestMethod]
	public void Test_Solve_ReturnsCorrectSum_ForGivenLimit()
	{
		//Arrange
		Problem005 problem = new Problem005();
		//Act
		object result = problem.Solve([5,10]);
		//Assert
		Assert.AreEqual((long) 2520, result);
	}
	#endregion
}