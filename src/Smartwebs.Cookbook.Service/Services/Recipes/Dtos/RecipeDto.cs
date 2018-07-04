using Smartwebs.Domain.Dtos;

namespace Smartwebs.Cookbook.Services.Recipes.Dtos
{
    public class RecipeDto : EntityDto<long>
    {
        public virtual string Description { get; set; }
    }
}
