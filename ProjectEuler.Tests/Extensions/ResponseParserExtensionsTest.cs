using ProjectEuler.Problems;

namespace ProjectEuler.Tests;

[TestClass]
public class ResponseParserExtensionsTest
{
	#region Tests
	[TestMethod]
	public void Parse_Null_ReturnsNullString()
	{
		// Arrange
		object? value = null;

		// Act
		string result = value.Parse();

		// Assert
		Assert.AreEqual("null", result);
	}

	[TestMethod]
	public void Parse_Primitives_ReturnExpectedStrings()
	{
		// Arrange

		// Act

		// Assert
		Assert.AreEqual("42", 42.Parse());
		Assert.AreEqual("3.14", 3.14.Parse());
		Assert.AreEqual("True", true.Parse());
		Assert.AreEqual("hello", "hello".Parse());
	}

	[TestMethod]
	public void Parse_ListOfInts_ReturnsCommaSeparated()
	{
		// Arrange
		List<int> list = [1, 2, 3];
		object value = list;

		// Act
		string result = value.Parse();

		// Assert
		Assert.AreEqual("1, 2, 3", result);
	}

	[TestMethod]
	public void Parse_ArrayOfStrings_ReturnsCommaSeparated()
	{
		// Arrange
		object value = new[] { "a", "b", "c" };

		// Act
		string result = value.Parse();

		// Assert
		Assert.AreEqual("a, b, c", result);
	}

	[TestMethod]
	public void Parse_EmptyList_ReturnsEmptyString()
	{
		// Arrange
		object value = new List<object>();

		// Act
		string result = value.Parse();

		// Assert
		Assert.AreEqual("", result);
	}

	[TestMethod]
	public void Parse_CustomObject_UsesToString()
	{
		// Arrange
		TestClass obj = new() { Name = "Euler" };

		// Act
		string result = obj.Parse();

		// Assert
		Assert.AreEqual("TestClass: Euler", result);
	}
	#endregion

	#region Class TestClass
	private class TestClass
	{
		#region Properties
		public string Name { get; init; } = "";
		#endregion

		#region Publics
		public override string ToString()
		{
			return $"TestClass: {this.Name}";
		}
		#endregion
	}
	#endregion
}