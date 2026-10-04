using System.ComponentModel.DataAnnotations.Schema;

namespace LearningApi.Models
{
    // ---------- MODEL LAYER ----------
    // Just holds data. No logic here.
    // [Column] maps each property to the actual column name in the existing "Products" table.
    [Table("Products")]
    public class Product
    {
        [Column("productID")]
        public int Id { get; set; }

        [Column("productName")]
        public string Name { get; set; } = string.Empty;

        [Column("productPrice")]
        public decimal Price { get; set; }
    }
}
