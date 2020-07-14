using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CommanLayer.Model
{
    public class Compare
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[a-z]*$")]
        public string MeasurementType { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z][a-zA-Z]*$")]
        public string FirstValueUnit { get; set; }

        [Required]
        public double FirstValue { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z][a-zA-Z]*$")]
        public string SecondValueUnit { get; set; }

        [Required]
        public double SecondValue { get; set; }

        public string Result { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}

