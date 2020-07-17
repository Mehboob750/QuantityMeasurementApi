//-----------------------------------------------------------------------
// <copyright file="QuantityMeasurementException.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Mehboob Shaikh</author>
//-----------------------------------------------------------------------
[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:FileHeaderFileNameDocumentationMustMatchTypeName", Justification = "Reviewed.")]

namespace BusinessLayer.Services
{
    using System;

    /// <summary>
    /// This Class used to Define Custom Exceptions
    /// </summary>
    public class QuantityMeasurementException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuantityMeasurementException"/> class.
        /// </summary>
        public QuantityMeasurementException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuantityMeasurementException"/> class.
        /// </summary>
        /// <param name="type">It contains the type of Exception</param>
        public QuantityMeasurementException(ExceptionType type, string message) : base(message)
        {
            this.Type = type;
        }

        /// <summary>
        /// Enum is Used to define Enumerated Data types
        /// </summary>
        public enum ExceptionType
        {
            InvalidData,
            InvalidValue
        }

        /// <summary>
        /// It creates the Reference of Exception Type
        /// </summary>
        public ExceptionType Type { get; set; }
    }
}
