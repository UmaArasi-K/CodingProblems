using ProjectEuler.Problems;

namespace ProjectEuler.Tests;

[TestClass]
public class Problem003Test
{
	#region Tests
	[TestMethod]
	public void Test_Solve_ReturnsCorrectSum_ForDefaultLimit()
	{
		//Arrange
		Problem003 problem = new Problem003();
		//Act
		object result = problem.Solve();
		//Assert
		Assert.AreEqual((long) 5, result);
	}
	[TestMethod]
	public void Test_Solve_ReturnsCorrectSum_ForGivenLimit()
	{
		//Arrange
		Problem003 problem = new Problem003(); 
		//Act
		object result = problem.Solve(600851475143);
		//Assert
		Assert.AreEqual((long) 6857, result);
	}
	#endregion
}