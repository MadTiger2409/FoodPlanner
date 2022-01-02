namespace FoodPlanner.WebApi.ActionParameters.Ingredient
{
    public record CreateIngredient
    {
        public int ProductId { get; set; }
        public int UnitId { get; set; }
        public float Amount { get; set; }

        public Domain.Entities.Ingredient GetIngredient()
        {
            return new()
            {
                ProductId = ProductId,
                UnitId = UnitId,
                Amount = Amount
            };
        }
    }
}