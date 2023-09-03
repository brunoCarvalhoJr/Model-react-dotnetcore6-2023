using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi_Domain.Entities.User
{
    [Table("EntityType")]
    public class EntityTypesEntity
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Name")]
        [MaxLength(100)]
        public string Name { get; set; }
        [Column("Type")]
        public int Type { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }
        public virtual UserEntity User { get; set; }
    }
}
