using System;

namespace Smartwebs.Cookbook.Domain.Recipes
{
    /// <summary>
    /// Store all origional and historical recipes
    /// </summary>
    public class RecipeVersion : RecipeBase
    {
        public long? RecipeId { get; set; }

        public DateTime ModifiedDate { get; set; } = DateTime.Now;
    }
}