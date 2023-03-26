using System.ComponentModel.DataAnnotations.Schema;

namespace BFF.Core.Data.Entities.BaseImp
{
    [Serializable]
    public class UpdatedOnEntityBase : CreatedOnEntityBase
    {
        [Column("updatedon")]
        public virtual DateTime? UpdatedOn { get; set; }
        [Column("updatedby")]
        public virtual int? UpdatedBy { get; set; }
        public virtual void UpdatedOnAuditing(int updatedBy)
        {
            UpdatedOn = DateTime.Now;
            if (updatedBy.Equals(0)) return;
            UpdatedBy = updatedBy;
        }
    }
}
