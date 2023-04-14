using System.ComponentModel.DataAnnotations.Schema;

namespace BFF.API.Models.DTOs.Product
{
    public class ProductInsertDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public long Stock { get; set; }
        public int CategegoryId { get; set; }
    }
}
