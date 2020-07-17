//-----------------------------------------------------------------------
// <copyright file="Quantity.cs" company="BridgeLabz Solution">
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
    /// This is Model class of Quantity
    /// </summary>
    public class Quantity
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
        /// Gets or sets the ConversionType
        /// </summary>
        [Required]
        [RegularExpression(@"^[A-Z][a-zA-Z]*$")]
        public string ConversionType { get; set; }

        /// <summary>
        /// Gets or sets the Value
        /// </summary>
        [Required]
        public double Value { get; set; }

        /// <summary>
        /// Gets or sets the Result
        /// </summary>
        public double Result { get; set; }

        /// <summary>
        /// Gets or sets the DateOfCreation
        /// </summary>
        public DateTime DateOfCreation { get; set; } = DateTime.Now;
    }
}
