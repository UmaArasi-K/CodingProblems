using ProjectEuler.Problems;

namespace ProjectEuler.Tests;

[TestClass]
public class Problem004Test
{
	#region Tests
	[TestMethod]
	public void Test_Solve_ReturnsCorrectSum_ForDefaultLimit()
	{
		//Arrange
		Problem004 problem = new Problem004();
		//Act
		object result = problem.Solve();
		//Assert
		Assert.AreEqual((long) 9009, result);
	}
	[TestMethod]
	public void Test_Solve_ReturnsCorrectSum_ForGivenLimit()
	{
		//Arrange
		Problem004 problem = new Problem004();
		//Act
		object result = problem.Solve(3);
		//Assert
		Assert.AreEqual((long) 906609, result);
	}
	#endregion
}