using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopMVC.DTO
{
    public class UserViewModel
    {
        public long ID { get; set; }

        [Display(Name = "User Name")]
        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(32)]
        public string PassWord { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        public DateTime? CreatedDate { get; set; }

        public long CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public long ModifiedBy { get; set; }

        public bool Status { get; set; }
    }
}
