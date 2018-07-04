using System.ComponentModel.DataAnnotations;
using Smartwebs.Cookbook.Domain.Recipes;

namespace Smartwebs.Cookbook.Services.Recipes.Dtos
{
    public class CreateRecipeInput
    {
        [StringLength(RecipeBase.MaxDescriptionLength)]
        [Required]
        public string Description { get; set; }
    }
}