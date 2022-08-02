using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class DownloadOperation
    {
        [Key]
        public int DownloadOperationID { get; set; }
        public int ReceiverID { get; set; } //Admin Table Receiver
        public int CategoryID { get; set; }
        public bool DownloadFileStatus { get; set; }
        public DateTime DownloadDate { get; set; }
        public Category Category { get; set; }
    }
}
