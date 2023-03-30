namespace FoodPlanner.Domain.Common
{
	public abstract class BaseEntity
	{
		public int Id { get; set; }
		public bool Deleted { get; set; } = false;
	}
}