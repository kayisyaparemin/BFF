using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BFF.Core.Data.Entities.BaseImp
{
    public class DeletedOnEntityBase : UpdatedOnEntityBase, ISoftDelete
    {
        [Required, Column("isdeleted"), DefaultValue(false)]
        public virtual bool IsDeleted { get; set; }
        public virtual void DeleionAuditing()
        {
            IsDeleted = true;
        }
    }
    public interface ISoftDelete
    {
        bool IsDeleted { get; }
    }
}
