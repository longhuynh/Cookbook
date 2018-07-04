using System.ComponentModel.DataAnnotations;
using Smartwebs.Domain.Entities;

namespace Smartwebs.Cookbook.Domain.Recipes
{
    /// <summary>
    ///  Contains all historical columns
    /// </summary>
    public class RecipeBase : Entity<long>
    {
        public const int MaxDescriptionLength = 250;

        [MaxLength(MaxDescriptionLength)]
        public virtual string Description { get; set; }
    }
}
