using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BFF.Core.Data.Entities.BaseImp
{
    public interface IEntity
    {
        int Id { get; set; }
        public  bool IsDeleted { get; set; }
        public virtual void DeletionAuditing()
        {
            IsDeleted = true;
        }
        public  bool IsActive { get; set; }
        public virtual void ActiveAuditing()
        {
            IsActive = true;
        }
        public  DateTime CreatedOn { get; set; }
        public  int? CreatedBy { get; set; }

        public virtual void CreatedOnAuditing(int createdBy)
        {
            CreatedOn = DateTime.UtcNow;
            if (createdBy.Equals(0)) return;
            CreatedBy = createdBy;
        }
        public  DateTime? UpdatedOn { get; set; }
        public  int? UpdatedBy { get; set; }
        public virtual void UpdatedOnAuditing(int updatedBy)
        {
            UpdatedOn = DateTime.UtcNow;
            if (updatedBy.Equals(0)) return;
            UpdatedBy = updatedBy;
        }
    }
}
