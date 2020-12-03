using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Enterprise_MVC_WebApplication.Core
{
    public class Enterprise_MVC_Core
    {
        public int ID { get; set; } = 0;

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        public int Age { get; set; } = 0;
    }
}
