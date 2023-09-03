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
    [Table("ScreenProfile")]
    public class ScreenProfile
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("ScreenName")]
        [StringLength(150)]
        public string ScreenName { get; set; }

        public virtual ICollection<ScreenRoutes> Routes { get; set; }
        public virtual ICollection<UserProfile> UserProfile { get; set; }
    }
}
