using System.ComponentModel.DataAnnotations;

namespace Sockerbagare2.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string IngredientName { get; set; }
    }
}