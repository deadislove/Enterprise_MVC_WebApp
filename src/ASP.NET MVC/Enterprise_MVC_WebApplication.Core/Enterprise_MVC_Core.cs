using Enterprise_MVC_WebApplication.Core.Interceptor;
using System;
using System.ComponentModel.DataAnnotations;

namespace Enterprise_MVC_WebApplication.Core
{
    [InterceptorOfCore]
    public class Enterprise_MVC_Core : ContextBoundObject
    {
        public int ID { get; set; } = 0;

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        public int Age { get; set; } = 0;
    }
}
