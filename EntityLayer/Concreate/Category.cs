using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string FileName { get; set; }
        public string FileURL { get; set; }
        public int AdminID { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }
        public Admin Admin { get; set; }
        public List<FileOperation> FileOperations { get; set; }
        public List<DownloadOperation> DownloadOperations{ get; set; }
    }
}
