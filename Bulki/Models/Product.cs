using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bulki.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }

        [Required]
        [MaxLength(30,ErrorMessage ="Слишком длинное ФИО")]
        public string Author { get; set; }

        [Required]
        [DisplayName("Price")]
        [Range(1,10000,ErrorMessage ="Не верно указана Цена")]
        public double Price { get; set; }

        public int CategoryId { get; set; }
        
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }


    }
}
