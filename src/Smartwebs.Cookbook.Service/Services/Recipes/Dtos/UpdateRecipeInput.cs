using System.ComponentModel.DataAnnotations;
using Smartwebs.Cookbook.Domain.Recipes;
using Smartwebs.Domain.Entities;

namespace Smartwebs.Cookbook.Services.Recipes.Dtos
{
    public class UpdateRecipeInput : Entity<long>
    {
        [StringLength(RecipeBase.MaxDescriptionLength)]
        public string Description { get; set; }
    }
}