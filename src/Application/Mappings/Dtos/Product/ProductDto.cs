using FoodPlanner.Application.Mappings.Dtos.Category;

namespace FoodPlanner.Application.Mappings.Dtos.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CategoryDto Category { get; set; }
    }
}