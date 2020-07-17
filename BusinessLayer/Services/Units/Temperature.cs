//-----------------------------------------------------------------------
// <copyright file="Temperature.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Mehboob Shaikh</author>
//-----------------------------------------------------------------------
[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:FileHeaderFileNameDocumentationMustMatchTypeName", Justification = "Reviewed.")]

namespace BusinessLayer.Services
{
    using System;

    /// <summary>
    /// This Class is Used To Compare two Temperature
    /// </summary>
    public class Temperature
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Temperature"/> class.
        /// </summary>
        public Temperature()
        {
        }

        /// <summary>
        /// Enum is Used To Declare Enumerated Constants
        /// </summary>
        public enum Unit
        {
            /// <summary>
            /// It Shows the Given Temperature is in Fahrenheit
            /// </summary>
            Fahrenheit,

            /// <summary>
            /// It Shows the Given Temperature is in Celsius
            /// </summary>
            Celsius,

            /// <summary>
            /// It is Used to Convert The Fahrenheit Value into Celsius
            /// </summary>
            FahrenheitToCelsius
        }

        /// <summary>
        /// This Method is used to Set Unit conversion
        /// </summary>
        /// <param name="conversionType">It contains conversion type</param>
        /// <returns>It returns the Conversion type in unit form</returns>
        public Unit SetUnitAndConvertTemperature(string conversionType)
        {
            if (conversionType == "FahrenheitToCelsius")
            {
                return Unit.FahrenheitToCelsius;
            }

            return Unit.Celsius;
        }

        /// <summary>
        /// This Method Is used to Convert The Temperature from one to Another
        /// </summary>
        /// <param name="unit">It tells us About the Which temperature is to be Convert</param>
        /// <param name="value">It Contains the value Which we convert</param>
        /// <returns>It Returns the Converted Value into celsius Format</returns>
        public double ConvertTemperature(Unit unit, double value)
        {
            try
            {
                // Check If Unit Is Equal To FahrenheitToCelsius then Convert the Fahrenheit Value Into Celsius
                if (unit.Equals(Unit.FahrenheitToCelsius))
                {
                    return value / 212 * 100;
                }

                return value;
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
