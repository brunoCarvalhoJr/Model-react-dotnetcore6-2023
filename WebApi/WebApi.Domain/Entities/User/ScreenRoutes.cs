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
    [Table("ScreenRoutes")]
    public class ScreenRoutes
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("Route")]
        public string Route { get; set; }

        [Column("ScreenID")]
        public int ScreenId { get; set; }

        public virtual ScreenProfile ScreenProfile { get; set; }
    }
}
