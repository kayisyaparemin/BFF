using System.ComponentModel.DataAnnotations.Schema;

namespace BFF.Core.Data.Entities.BaseImp
{
    public class ActiveOnEntityBase : DeletedOnEntityBase
    {
        [Column("isactive")]
        public virtual bool IsActive { get; set; }
        public virtual void ActiveAuditing()
        {
            IsActive = true;
        }
    }
}
