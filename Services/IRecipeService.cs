using Myllah_API.Models;

namespace Myllah_API.Services
{
    public interface IRecipeService
    {
        public  Task<List<Recipe>> GetAllRecipes();
        public  Task<Recipe> GetRecipe(int id);
        public  Task<Recipe> CreateRecipe(CreateRecipe createRecipe, IFormFile file);
        public  Task<Recipe> UpdateRecipe(UpdateRecipe updateRecipe, int id);
        public  Task<bool> DeleteRecipe(int id);
    }
}
