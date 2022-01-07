using System.IO;

namespace FoodPlanner.Infrastructure.Persistence.Common
{
    public record FileResult(Stream Content, string Type, string Name);
}