// <copyright file="Compare.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Mehboob Shaikh</author>
//-----------------------------------------------------------------------
[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:FileHeaderFileNameDocumentationMustMatchTypeName", Justification = "Reviewed.")]

namespace CommanLayer.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// This is Model class of Compare
    /// </summary>
    public class Compare
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the MeasurementType
        /// </summary>
        [Required]
        [RegularExpression(@"^[a-z]*$")]
        public string MeasurementType { get; set; }

        /// <summary>
        /// Gets or sets the FirstValueUnit
        /// </summary>
        [Required]
        [RegularExpression(@"^[A-Z][a-zA-Z]*$")]
        public string FirstValueUnit { get; set; }

        /// <summary>
        /// Gets or sets the FirstValue
        /// </summary>
        [Required]
        public double FirstValue { get; set; }

        /// <summary>
        /// Gets or sets the SecondValueUnit
        /// </summary>
        [Required]
        [RegularExpression(@"^[A-Z][a-zA-Z]*$")]
        public string SecondValueUnit { get; set; }

        /// <summary>
        /// Gets or sets the SecondValue
        /// </summary>
        [Required]
        public double SecondValue { get; set; }

        /// <summary>
        /// Gets or sets the Result
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// Gets or sets the CreatedDate
        /// </summary>
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
