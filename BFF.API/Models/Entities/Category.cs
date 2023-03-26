using BFF.Core.Data.Entities.BaseImp;
using System.ComponentModel.DataAnnotations.Schema;

namespace BFF.Models.Entities
{
    [Table("categories")]
    public class Category : ActiveOnEntityBase
    {
        [Column("name")]
        public string Name { get; set; }
    }
}
