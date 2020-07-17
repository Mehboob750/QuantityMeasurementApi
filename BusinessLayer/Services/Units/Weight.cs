//-----------------------------------------------------------------------
// <copyright file="Weight.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Mehboob Shaikh</author>
//-----------------------------------------------------------------------
[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:FileHeaderFileNameDocumentationMustMatchTypeName", Justification = "Reviewed.")]

namespace BusinessLayer.Services
{
    using System;

    /// <summary>
    /// This Class is Used To Compare two Weight
    /// </summary>
    public class Weight
    {
        /// <summary>
        /// This value is used to convert into Kilogram
        /// </summary>
        private double convertWeightValue = 1000;

        /// <summary>
        /// Initializes a new instance of the <see cref="Weight"/> class.
        /// </summary>
        public Weight()
        {
        }

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
            /// It Indicates that Weight is in kilogram
            /// </summary>
            kilogram,

            /// <summary>
            /// It is Used To Convert The Value Of gram into kilogram
            /// </summary>
            GramsToKilogram,

            /// <summary>
            /// It is Used To Convert The Value Of T into kilogram
            /// </summary>
            TonneToKilograms
        }

        /// <summary>
        /// This Method is used to Set Unit conversion
        /// </summary>
        /// <param name="conversionType">It contains conversion type</param>
        /// <returns>It returns the Conversion type in unit form</returns>
        public Unit SetUnitAndConvertWeights(string conversionType)
        {
            if (conversionType == "GramsToKilogram")
            {
                return Unit.GramsToKilogram;
            }
            else if (conversionType == "TonneToKilograms")
            {
                return Unit.TonneToKilograms;
            }
            else if (conversionType == "kilogram")
            {
                return Unit.kilogram;
            }

            return Unit.Null;
        }

        /// <summary>
        /// This Method Is used to Convert The Weight from one to Another
        /// </summary>
        /// <param name="unit">It tells us About the Which weight is to be Convert</param>
        /// <param name="weight">It Contains the value Which we convert</param>
        /// <returns>It Returns the Converted Value into kilogram Format</returns>
        public double ConvertWeigths(Unit unit, double weight)
        {
            try
            {
                // Check If Unit Is Equal To GramsToKiloGrams Then Convert The gram Value Into kilogram
                if (unit.Equals(Unit.GramsToKilogram))
                {
                    return weight / this.convertWeightValue;
                }
                else if (unit.Equals(Unit.TonneToKilograms))
                {
                    return weight * this.convertWeightValue;
                }
                else if (unit.Equals(Unit.kilogram))
                {
                    return weight;
                }

                return 0;
            }
            catch (QuantityMeasurementException e)
            {
                throw new QuantityMeasurementException(QuantityMeasurementException.ExceptionType.InvalidData, e.Message);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
