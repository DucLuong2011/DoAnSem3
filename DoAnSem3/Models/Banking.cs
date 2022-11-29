using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnSem3.Models
{
    [Table("Banking")] // tên bảng được thêm vào database
    public class Banking
    {
        [Key]
        public int bankId { get; set; }


        [DisplayName("Banks")]
        [StringLength(200)]
        [Required(ErrorMessage = "Can't be left blank")]
        public string bankName { get; set; }

        [DisplayName("The Amount")]
        public float rechange { get; set; }

        public bool status { get; set; }
      
        [Display(Name = "  Recharge date")]
        public DateTime? createAt { get; set; } = DateTime.Now;


        //Khoá ngoại


        [Display(Name = "Email account")]
        [ForeignKey("Customer")]
        public int cusId { get; set; }
        public Customer Customer { get; set; }

    }
}
