using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Smartwebs.Cookbook.Domain.Recipes;
using Smartwebs.Cookbook.Services.Recipes;
using Smartwebs.Cookbook.Services.Recipes.Dtos;

namespace Smartwebs.Cookbook.Api.Controllers
{
    [Route("[controller]")]
    public class RecipesController : Controller
    {
        private readonly IRecipeService _recipeService;

        public RecipesController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var recipes = await _recipeService.GetAll();
            return Ok(recipes);
        }

        [HttpGet("{id}/versions")]
        public async Task<IActionResult> Get(int id)
        {
            var recipes = await _recipeService.GetVersions(id);

            return Ok(recipes);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SaveRecipeRequest input)
        {
            var createRecipeInput = new CreateRecipeInput
            {
                Description = input.Description
            };

            await _recipeService.Create(createRecipeInput);

            return Accepted();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SaveRecipeRequest input)
        {
            var updateRecipeInput = new UpdateRecipeInput
            {
                Id = id,
                Description = input.Description
            };

            var recipe = await _recipeService.Update(updateRecipeInput);

            return Ok(recipe);
        }
    }

    public class SaveRecipeRequest
    {
        public string Description { get; set; }
    }
}