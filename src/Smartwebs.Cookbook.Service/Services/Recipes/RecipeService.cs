using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Smartwebs.Cookbook.Domain.Recipes;
using Smartwebs.Cookbook.Ef;
using Smartwebs.Cookbook.Services.Recipes.Dtos;
using Smartwebs.Domain.Dtos;
using Smartwebs.Domain.Repositories;

namespace Smartwebs.Cookbook.Services.Recipes
{
    public class RecipeService : IRecipeService
    {
        private readonly IRepository<Recipe, long> _recipeRepository;
        private readonly IRepository<RecipeVersion, long> _recipeVersionRepository;

        public RecipeService(
            IRepository<Recipe, long> recipeRepository,
            IRepository<RecipeVersion, long> recipeVersionRepository
            )
        {
            _recipeRepository = recipeRepository;
            _recipeVersionRepository = recipeVersionRepository;
        }
        
        public Task<ListResultDto<RecipeDto>> GetAll()
        {
            var results = _recipeRepository.GetAllList();

            return Task.FromResult(new ListResultDto<RecipeDto>(
                Mapper.Map<List<RecipeDto>>(results)
            ));
        }

        public Task<ListResultDto<RecipeDto>> GetVersions(long id)
        {
            var results = _recipeVersionRepository.GetAll()
                .Where(x => x.RecipeId == id)
                .ToList();

            return Task.FromResult(new ListResultDto<RecipeDto>(
                Mapper.Map<List<RecipeDto>>(results)
            ));
        }

        public RecipeDto Get(int id)
        {
            var result = _recipeRepository.FirstOrDefault(x => x.Id == id);

            return Mapper.Map<RecipeDto>(result);
        }


        public async Task<RecipeDto> Update(UpdateRecipeInput input)
        {
            var recipe = _recipeRepository.FirstOrDefault(x => x.Id == input.Id);

            if(recipe != null)
            {
                await MakeVersion(recipe, recipe.Id);

                recipe = Mapper.Map<Recipe>(input);
                await _recipeRepository.UpdateAsync(recipe);
                await _recipeRepository.SaveChangeAsync();
            }

            return Mapper.Map<RecipeDto>(recipe);
        }

        public async Task<RecipeDto> Create(CreateRecipeInput input)
        {
            var recipe = Mapper.Map<Recipe>(input);
            recipe = await _recipeRepository.InsertAsync(recipe);
            await _recipeRepository.SaveChangeAsync();

            await MakeVersion(recipe, null);

            return Mapper.Map<RecipeDto>(recipe);
        }   
        
        private async Task MakeVersion(Recipe recipe, long? recipeId)
        {
            var recipeVersion = Mapper.Map<RecipeVersion>(recipe);
            recipeVersion.RecipeId = recipeId;

            await _recipeVersionRepository.InsertAsync(recipeVersion);
            await _recipeVersionRepository.SaveChangeAsync();
        }
    }
}
