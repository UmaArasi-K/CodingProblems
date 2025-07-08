namespace ProjectEuler.Problems;

[AttributeUsage(AttributeTargets.Class)]
public class ProblemIdAttribute : Attribute
{
	#region Properties
	public int Id { get; }
	#endregion

	#region Constructors
	public ProblemIdAttribute(int id)
	{
		this.Id = id;
	}
	#endregion
}