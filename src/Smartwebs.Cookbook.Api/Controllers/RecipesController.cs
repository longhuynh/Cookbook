using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Smartwebs.Cookbook.Services.Recipes;
using Smartwebs.Cookbook.Services.Recipes.Dtos;

namespace Smartwebs.Cookbook.Controllers
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
        public async Task<IActionResult> Post([FromBody]CreateRecipeInput input)
        {
            await _recipeService.Create(input);

            return Accepted();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]UpdateRecipeInput input)
        {
            var recipe = await _recipeService.Update(input);

            return Ok(recipe);
        }
    }
}
