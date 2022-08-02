using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class FileOperation
    {
        [Key]
        public int OperationID { get; set; }
        public int? SenderID { get; set; }
        public int? ReceiverID { get; set; }
        public int CategoryID { get; set; }
        public DateTime Date { get; set; }

        public Category Category { get; set; }
        public Admin SenderUser { get; set; }
        public Admin ReceiverUser { get; set; }
    }
}
