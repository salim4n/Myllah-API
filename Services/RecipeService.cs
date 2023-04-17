using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Myllah_API.Data;
using Myllah_API.Models;
using System.Reflection.Metadata;

namespace Myllah_API.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly Context _db;
        private readonly IBlobService _blob;
        private readonly ILogger<RecipeService> _logger;

        public RecipeService(Context db, IBlobService blob, ILogger<RecipeService> logger)
        {
            _db = db;
            _blob = blob;
            _logger = logger;
        }

        public async Task<Recipe> CreateRecipe(CreateRecipe createRecipe, IFormFile file)
        {

            Recipe recipe = new Recipe()
                {
                    Name = createRecipe.Name,
                    Description = createRecipe.Description,
                    //Ingredients = createRecipe.Ingredients,
                    //Instructions = createRecipe.Instructions,
                };

                if(file != null)
                {
                var fileName = PopulateFile(file);
                recipe.ImageUri = await _blob.UploadBlob(fileName, file);
                }

                _db.Recipes.Add(recipe);
                _db.SaveChanges();

                return recipe; 
        }

        public async Task<bool> DeleteRecipe(int id)
        {
            
            var recipe = await _db.Recipes.FindAsync(id);
            if (recipe != null)
            {
                var isOk = await _blob.DeleteBlob(recipe.ImageUri.Split("/").Last());
                if (isOk)
                {
                    _db.Recipes.Remove(recipe);
                    _db.SaveChanges();
                    return true;
                }
                else
                {
                    _logger.LogWarning($"Blob {recipe.ImageUri.Split("/").Last()} is not deleted");
                    _db.Recipes.Remove(recipe);
                    _db.SaveChanges();
                    return true;
                }

            }
            else
                return false;
            
        }

        public async Task<List<Recipe>> GetAllRecipes()
        {
            List<Recipe> recipes = await _db.Recipes
                //.Include(r => r.Instructions)
                //.Include(r => r.Ingredients)
                .ToListAsync();
            if(recipes.Count == 0)
            {
                return new List<Recipe>();
            }

            return recipes;
        }

        public async Task<Recipe> GetRecipe(int id)
        {
            var recipe = await _db.Recipes.FindAsync(id);
            if(recipe == null)
            {
                throw new Exception($"recipe with id : {id} not found ");
            }
            return recipe;
        }

        public async Task<Recipe> UpdateRecipe(UpdateRecipe updateRecipe, int id)
        {
            var recipe = await _db.Recipes.FindAsync(id);
            if (recipe is not null)
            {

                if(updateRecipe.file != null)
                {
                    var fileName = PopulateFile(updateRecipe.file);
                    var isOk = await _blob.DeleteBlob(recipe.ImageUri.Split("/").Last());
                    recipe.ImageUri = await _blob.UploadBlob(fileName, updateRecipe.file);
                    if (!isOk)
                    {
                        _logger.LogWarning($"Blob {recipe.ImageUri.Split("/").Last()} is not deleted");   
                    }
                }


                recipe.Name = updateRecipe.Name;
                recipe.Description = updateRecipe.Description;
                //recipe.Ingredients = updateRecipe.Ingredients;
                //recipe.Instructions = updateRecipe.Instructions;
                
                _db.Recipes.Update(recipe);
                _db.SaveChanges();
            }
            else
                throw new Exception("Recipe cannot be updated, this recipe doesn't exist.");


            return recipe;
        }

        private string PopulateFile(IFormFile file)
        {
            var fileName = Path.GetFileNameWithoutExtension(file.Name) + "_" + Guid.NewGuid() + Path.GetExtension(file.FileName);
            return fileName;
        }
    }
}
