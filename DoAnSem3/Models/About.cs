using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnSem3.Models
{
    [Table("About")] // tên bảng được sinh ra trong database

    public class About
    {
        [Key]
        public int Id{ get; set; }

        [DisplayName("Name")]
        [StringLength(200)]
        [Required(ErrorMessage = "Can't be left blank")]
        public string title { get; set; }
        public string image{ get; set; }

        [StringLength(1000)]
        [Required(ErrorMessage = "Can't be left blank")]
        public string content { get; set; }

        public DateTime? craateAt{ get; set; } = DateTime.Now;

    }
}
