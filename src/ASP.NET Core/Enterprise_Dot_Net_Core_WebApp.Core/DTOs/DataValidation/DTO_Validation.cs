using Enterprise_Dot_Net_Core_WebApp.SharedKernel.DataValidation;
using System;
using System.ComponentModel.DataAnnotations;

namespace Enterprise_Dot_Net_Core_WebApp.Core.DTOs.DataValidation
{
    public class DTO_Validation
    {
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Name must have value.")]
        public string Name { get; set; }

        [Range(1,99)]
        public int? Age { get; set; }

        [DataValidation]
        public string ValidatedResult { get; set; } = "Stand by.";

        public DateTime StartDate { get; set; } = DateTime.Now;

        [DataValidation("StartDate")]
        public DateTime EndDate { get; set; } = DateTime.Now;
    }
}
