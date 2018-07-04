using System;

namespace Smartwebs.Cookbook.Domain.Recipes
{
    /// <summary>
    /// Main recipe table
    /// </summary>
    public class Recipe : RecipeBase
    {
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? ModifiedDate { get; set; }
    }
}
