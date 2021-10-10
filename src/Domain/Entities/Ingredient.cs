using FoodPlanner.Domain.Common;

namespace FoodPlanner.Domain.Entities
{
    public class Ingredient : BaseEntity
    {
        public float Amount { get; set; }
        public int ProductId { get; set; }
        public int UnitId { get; set; }
        public Product Product { get; set; }
        public Unit Unit { get; set; }
    }
}