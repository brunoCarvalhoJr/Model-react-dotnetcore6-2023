using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi_Domain.Entities.Audit
{
    [Table("Log")]
    public class LogEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Required]
        [Column("log_time")]
        public DateTime LogTime { get; set; }
        [Required]
        [Column("type_name")]
        [MaxLength(100)]
        public string TypeName { get; set; }
        [Column("type")]
        public int Type { get; set; }
        [Column("username")]
        [MaxLength(100)]
        public string UserName { get; set; }

    }
}
