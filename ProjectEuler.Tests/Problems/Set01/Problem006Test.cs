using ProjectEuler.Problems;

namespace ProjectEuler.Tests;

[TestClass]
public class Problem006Test
{
	#region Tests
	[TestMethod]
	public void Test_Solve_ReturnsCorrectSum_ForDefaultLimit()
	{
		//Arrange
		Problem006 problem = new Problem006();
		//Act
		object result = problem.Solve();
		//Assert
		Assert.AreEqual((long) 2640, result);
	}
	[TestMethod]
	public void Test_Solve_ReturnsCorrectSum_ForGivenLimit()
	{
		//Arrange
		Problem006 problem = new Problem006();
		//Act
		object result = problem.Solve([5,10]);
		//Assert
		Assert.AreEqual((long) 1670, result);
	}
	#endregion
}