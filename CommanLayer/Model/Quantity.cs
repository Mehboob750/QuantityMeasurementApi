using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CommanLayer.Model
{
    public class Quantity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[a-z]*$")]
        public string MeasurementType { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z][a-zA-Z]*$")]
        public string ConversionType { get; set; }
        
        [Required]
        public double Value { get; set; }

        public double Result { get; set; }

        public DateTime DateOfCreation { get; set; } = DateTime.Now;
    }
}
