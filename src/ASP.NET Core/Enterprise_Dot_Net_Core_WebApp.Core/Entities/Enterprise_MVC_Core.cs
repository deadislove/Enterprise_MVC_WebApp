using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Entities
{
    [Table("Enterprise_MVC_Core")]
    public class Enterprise_MVC_Core
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public int? Age { get; set; } 
    }
}
