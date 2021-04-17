using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Entities
{
    public class Enterprise_MVC_Core_Variant
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int? Age { get; set; }

        public string Commit { get; set; } = string.Empty;
    }
}
