using Dapper.Contrib.Extensions;

namespace Notch.Data.Dapper.Entity
{
    [Table("Product")]
    public class ProductEM
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
    }
}