//-----------------------------------------------------------------------
// <copyright file="Volume.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Mehboob Shaikh</author>
//-----------------------------------------------------------------------
[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:FileHeaderFileNameDocumentationMustMatchTypeName", Justification = "Reviewed.")]

namespace BusinessLayer.Services
{
    using System;

    /// <summary>
    /// This Class is Used To Compare two Volumes
    /// </summary>
    public class Volume
    {
        /// <summary>
        /// This value is used At the Time Of Gallon to L Conversion
        /// </summary>
        private double gallonToLitreValue = 3.78;

        /// <summary>
        /// This value is used At the Time Of Ml to L Conversion
        /// </summary>
        private double miliLitreToLitreValue = 1000;

        /// <summary>
        /// Enum is Used To Declare Enumerated Constants
        /// </summary>
        public enum Unit
        {
            /// <summary>
            /// It Indicates Null
            /// </summary>
            Null,

            /// <summary>
            /// It Indicates that Volume is in L
            /// </summary>
            Litre,

            /// <summary>
            /// It Indicates that Convert the Volume From Gallon to L
            /// </summary>
            GallonToLitre,

            /// <summary>
            /// It Indicates that Convert the Volume From Ml to L
            /// </summary>
            MiliLitreToLitre
        }

        /// <summary>
        /// This Method is used to Set Unit conversion
        /// </summary>
        /// <param name="conversionType">It contains conversion type</param>
        /// <returns>It returns the Conversion type in unit form</returns>
        public Unit SetUnitAndConvertVolume(string conversionType)
        {
            if (conversionType == "GallonToLitre")
            {
                return Unit.GallonToLitre;
            }
            else if (conversionType == "MiliLitreToLitre")
            {
                return Unit.MiliLitreToLitre;
            }
            else if (conversionType == "Litre")
            {
                return Unit.Litre;
            }

            return Unit.Null;
        }

        /// <summary>
        /// This Method Is used to Convert The Volume from one to Another
        /// </summary>
        /// <param name="unit">It tells us About the Which Volume is to be Convert</param>
        /// <param name="value">It Contains the value Which we convert</param>
        /// <returns>It Returns the Converted Value into L Format</returns>
        public double ConvertValueToLitre(Unit unit, double value)
        {
            try
            {
                // Check If Unit Is Equal To GallonToLitre Then Convert The Gallon Value Into L
                if (unit.Equals(Unit.GallonToLitre))
                {
                    return value * this.gallonToLitreValue;
                }
                else if (unit.Equals(Unit.MiliLitreToLitre))
                {
                    return value / this.miliLitreToLitreValue;
                }
                else if (unit.Equals(Unit.Litre))
                {
                    return value;
                }

                return 0;
            }
            catch (Exception e)
            {
                throw new QuantityMeasurementException(QuantityMeasurementException.ExceptionType.InvalidValue, e.Message);
            }
        }
    }
}
