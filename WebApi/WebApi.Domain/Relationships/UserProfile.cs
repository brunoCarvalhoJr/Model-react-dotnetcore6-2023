using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi_Domain.Entities.User;

namespace WebApi_Domain.Relationships
{
    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        public int ProfileId { get; set; }

        public virtual UserEntity User { get; set; }
        public virtual ScreenProfile Profile { get; set; }

    }
}
