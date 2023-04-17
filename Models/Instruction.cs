//using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
//using System.ComponentModel;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace Myllah_API.Models
//{
//    public class Instruction
//    {
//        [Key]
//        public string Id { get; set; }
//        [DisplayName("Etape")]
//        public string ToDo { get; set; }

//        [ForeignKey(nameof(RecipeId))]
//        [DisplayName("Recette")]
//        [ValidateNever]
//        public Recipe Recipe { get; set; }
//        public string RecipeId { get; set; }
//    }

//    public class CreateInstruction
//    {
//        public string Id { get; set; } = Guid.NewGuid().ToString();
//        public string ToDo { get; set; }

//        [ForeignKey(nameof(RecipeId))]
//        [DisplayName("Recette")]
//        [ValidateNever]
//        public Recipe Recipe { get; set; }
//        public string RecipeId { get; set; }
//    }

//    public class UpdateInstruction
//    {
//        public string ToDo { get; set; }

//        [ForeignKey(nameof(RecipeId))]
//        [DisplayName("Recette")]
//        [ValidateNever]
//        public Recipe Recipe { get; set; }
//        public string RecipeId { get; set; }
//    }
//}
