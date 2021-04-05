using RoutingApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RoutingApi.Domain.Entities
{
    [Table("Todo")]
    public class Todo : Entity, IHasCreationTime, ISoftDelete
    {
        public string TaskName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DueDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsCompleted { get; set; }
    }
}
