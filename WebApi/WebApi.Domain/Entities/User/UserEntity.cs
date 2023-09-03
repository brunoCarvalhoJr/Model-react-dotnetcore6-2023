using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi_Domain.Relationships;

namespace WebApi_Domain.Entities.User
{
    [Table("User")]
    public class UserEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("email")]
        [MaxLength(100)]
        public string Email { get; set; }
        [Required]
        [Column("name")]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [Column("lastname")]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required]
        [Column("password")]
        [MaxLength(100)]
        public string Password { get; set; }
        public virtual ICollection<EntityTypesEntity> EntityTypes { get; set; }
        public virtual ICollection<UserProfile> UserProfile { get; set; }
    }
}
