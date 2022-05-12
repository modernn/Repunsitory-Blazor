using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repunsitory.Shared.Models
{
    public class Pun
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public string Catagory { get; set; }
        public int Rating { get; set; }
    }
}
