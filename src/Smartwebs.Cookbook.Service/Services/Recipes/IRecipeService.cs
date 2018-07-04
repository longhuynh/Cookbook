using System.Threading.Tasks;
using Smartwebs.Cookbook.Services.Recipes.Dtos;
using Smartwebs.Domain.Dtos;

namespace Smartwebs.Cookbook.Services.Recipes
{
    public interface IRecipeService
    {
        Task<ListResultDto<RecipeDto>> GetAll();

        Task<ListResultDto<RecipeDto>> GetVersions(long id);

        RecipeDto Get(long id);

        Task<RecipeDto> Create(CreateRecipeInput input);

        Task<RecipeDto> Update(UpdateRecipeInput input);
    }
}
