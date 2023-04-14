using BFF.API.Core.Service;
using BFF.Core.Data;
using BFF.Core.Data.Entities.BaseImp;
using Microsoft.AspNetCore.OData.Query;
using System.ComponentModel.DataAnnotations.Schema;

namespace BFF.Models.Entities
{
    [Table("products")]
    public class Product : ActiveOnEntityBase
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("image")]
        public byte[] Image { get; set; }

        [Column("size")]
        public string Size { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("stock")]
        public long Stock { get; set; }

        [Column("categoryId")]
        public int CategegoryId { get; set; }
    }
}
