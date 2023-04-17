using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Myllah_API.Data;
using Myllah_API.Models;
using Myllah_API.Services;

namespace Myllah_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Recipe>>> GetRecipes()
        {
            var recipes = await _recipeService.GetAllRecipes();

            if (recipes.Count > 0)
            {
                return Ok(recipes);
            }
            else
                return NotFound();

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Recipe>> GetRecipeById(int id)
        {
            var recipe = await _recipeService.GetRecipe(id);
            if (recipe == null)
                return NotFound();
            else
                return Ok(recipe);
        }

        [HttpPost]
        public async Task<ActionResult<Recipe>> CreateRecipe([FromForm] CreateRecipe createRecipe)
        {
            if (ModelState.IsValid)
            {
                var recipe = await _recipeService.CreateRecipe(createRecipe, createRecipe.file);
                if (recipe != null)
                {
                    return Ok(recipe);
                }
                else
                    return BadRequest("model is not look good");
            }
            else
                return BadRequest(createRecipe);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Recipe>> UpdateRecipe(int id, [FromForm] UpdateRecipe updateRecipe)
        {
            if (ModelState.IsValid)
            {
                
                var recipe = await _recipeService.UpdateRecipe(updateRecipe, id);
                if (recipe != null)
                    return Ok(recipe);
                else
                    return BadRequest(updateRecipe);       
            }
            else
                return BadRequest(ModelState);

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Recipe>> DeleteRecipe(int id)
        {
            var isOk = await _recipeService.DeleteRecipe(id);
            if (isOk)
            {
                return Ok(isOk);
            }
            else
                return BadRequest();
        }
    }
}
