using System.ComponentModel.DataAnnotations.Schema;

namespace BFF.Core.Data.Entities.BaseImp
{
    public class ActiveOnEntityBase : DeletedOnEntityBase,IEntity
    {
        [Column("isactive")]
        public virtual bool IsActive { get; set; }
        public virtual void ActiveAuditing()
        {
            IsActive = true;
        }
    }
}
