using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BFF.Core.Data.Entities.BaseImp
{
    [Serializable]
    public class CreatedOnEntityBase : BaseEntity
    {
        [Required, Column("createdon")]
        public virtual DateTime CreatedOn { get; set; }
        [Required, Column("createdby")]
        public virtual int? CreatedBy { get; set; }

        public virtual void CreatedOnAuditing(int createdBy)
        {
            CreatedOn = DateTime.Now;
            if (createdBy.Equals(0)) return;
            CreatedBy = createdBy;
        }
    }
}
