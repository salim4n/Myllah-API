//using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
//using System.ComponentModel;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace Myllah_API.Models
//{
//    public class Ingredient
//    {
//        [Key]
//        public int Id { get; set; }
//        public string Name { get; set; }
//        public string Description { get; set; }

//        [ForeignKey(nameof(RecipeId))]
//        [DisplayName("Recette")]
//        [ValidateNever]
//        public Recipe Recipe { get; set; }
//        public string RecipeId { get; set; }
//    }

//    public class CreateIngredient
//    {
//        [Key]
//        public int Id { get; set; }
//        public string Name { get; set; }
//        public string Description { get; set; }

//        [ForeignKey(nameof(RecipeId))]
//        [DisplayName("Recette")]
//        [ValidateNever]
//        public Recipe Recipe { get; set; }
//        public string RecipeId { get; set; }

//    }
//    public class UpdateIngredient
//    {
//        public string Name { get; set; }
//        public string Description { get; set; }

//        [ForeignKey(nameof(RecipeId))]
//        [DisplayName("Recette")]
//        [ValidateNever]
//        public Recipe Recipe { get; set; }
//        public string RecipeId { get; set; }
//    }




//}
