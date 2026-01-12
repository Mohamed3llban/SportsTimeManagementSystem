//namespace SportsTime.Data.Entities.Primitives;

//public abstract class Enumeration<TEnum> : IEquatable<Enumeration<TEnum>>
//{
//	protected Enumeration(int id, string name)
//	{
//		Id = id;
//		Name = name;
//	}

//	public int Id { get; protected init; }
//	public string Name { get; protected init; } = string.Empty;

//	public static TEnum? FromId(int id) => default;

//	public static TEnum? FromName(string name) => default;

//	public bool Equals(Enumeration<TEnum>? other) =>
//		other is not null && GetType() == other.GetType() && Id == other.Id;

//	public override bool Equals(object? obj) => obj is Enumeration<TEnum> other && Equals(other);

//	public override int GetHashCode() => Id.GetHashCode();

//	public static IEnumerable<TEnum> GetValues()
//	{
//		// Implement logic to retrieve all instances of the enumeration type
//		// This could involve querying a database or returning a predefined collection
//		// For simplicity, you can return an empty list for now.
//		return new List<TEnum>();
//	}
//}
