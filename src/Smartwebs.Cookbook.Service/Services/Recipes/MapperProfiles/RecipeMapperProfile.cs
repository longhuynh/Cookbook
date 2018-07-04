using AutoMapper;
using Smartwebs.Cookbook.Domain.Recipes;
using Smartwebs.Cookbook.Services.Recipes.Dtos;

namespace Smartwebs.Cookbook.Services.Recipes.MapperProfiles
{
    public class RecipeMapperProfile : Profile
    {
        public RecipeMapperProfile()
        {
            CreateMap<Recipe, RecipeVersion>();

            CreateMap<Recipe, RecipeDto>();
            CreateMap<CreateRecipeInput, Recipe>();
            CreateMap<UpdateRecipeInput, Recipe>();

            CreateMap<RecipeVersion, RecipeDto>();
            CreateMap<CreateRecipeInput, RecipeVersion>();
            CreateMap<UpdateRecipeInput, RecipeVersion>();
        }
    }
}
