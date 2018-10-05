using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardSample.Server.Models
{
    public abstract class EntityBase
    {
        [Key]
        [Index("IX_Id", 1, IsUnique = true)]
        public string Id { get; set; }
        
        public DateTime? CreationTime { get; set; }
        public DateTime? ModificationTime { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DeletionTime { get; set; }

        public string CratedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string DeletedBy { get; set; }
    }
}