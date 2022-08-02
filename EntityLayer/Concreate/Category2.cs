using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class Category2
    {
        public int CategoryID { get; set; }
        public string FileName { get; set; }
        public IFormFile FileURL { get; set; }
        public int AdminID { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }
    }
}
