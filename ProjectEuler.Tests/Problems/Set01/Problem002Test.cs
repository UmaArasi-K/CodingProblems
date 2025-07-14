using ProjectEuler.Problems;

namespace ProjectEuler.Tests;

[TestClass]
public class Problem002Test
{
	#region Tests
	[TestMethod]
	public void Test_Solve_ReturnsCorrectSum_ForDefaultLimit()
	{ 
		//Arrange
		Problem002 problem = new Problem002();
		//Act
		object result = problem.Solve();
		//Assert
		Assert.AreEqual((long) 44, result);
	}

	[TestMethod]
	public void Test_Solve_ReturnsCorrectSum_ForGivenLimit()
	{
		//Arrange
		Problem002 problem = new Problem002();
		//Act
		object result = problem.Solve(10);
		//Assert
		Assert.AreEqual((long) 10, result);
	}

	#endregion
}