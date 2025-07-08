using System.Collections;

namespace ProjectEuler.Problems;

public static class ResponseParserExtensions
{
	#region Internals
	public static string Parse(this object? oValue)
	{
		if(oValue is null)
		{
			return "null";
		}

		return oValue switch
		{
			string s => s,
			int i => i.ToString(),
			long l => l.ToString(),
			double d => d.ToString("G"),
			bool b => b.ToString(),
			IEnumerable enumerable and not string => ParseEnumerable(enumerable),
			_ => oValue.ToString() ?? "null"
		};
	}
	#endregion

	#region Privates
	private static string ParseEnumerable(IEnumerable values)
	{
		IEnumerable<string> items = values.Cast<object?>().Select(Parse);

		return string.Join(", ", items);
	}
	#endregion
}