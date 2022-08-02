using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime DateTime { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [Compare("Password", ErrorMessage = "Please,enter your password correctly")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public List<Category> Categories { get; set; }

        public virtual ICollection<FileOperation> AdminSender { get; set; }
        public virtual ICollection<FileOperation> AdminReceiver { get; set; }
    }
}
