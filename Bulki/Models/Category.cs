using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Bulki.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "НАЗОВИ ЕГО БЛ!")]
        [MaxLength(40)]
        [DisplayName("Category Name")]
        public string Name { get; set; }

        [DisplayName("Display order")]
        [Range(1,100,ErrorMessage ="Shoud be 1-100")]
        public int DisplayOrder { get; set; }

    }
}
