using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace corepractice.Models
{
    public class Group
    {
        [Key]
        [Required]
        public int GroupId { get; set; }
        [StringLength(50)]
        [Required]
        public string GroupName { get; set; }
        [StringLength(256)]
        public string Description { get; set; }
    }
}
