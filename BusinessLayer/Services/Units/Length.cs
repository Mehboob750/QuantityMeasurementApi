//-----------------------------------------------------------------------
// <copyright file="Length.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Mehboob Shaikh</author>
//-----------------------------------------------------------------------
[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:FileHeaderFileNameDocumentationMustMatchTypeName", Justification = "Reviewed.")]

namespace BusinessLayer.Services
{
    using System;

    /// <summary>
    /// This Class is Used To Convert Length value from one unit another unit
    /// </summary>
    public class Length
    {
        /// <summary>
        /// This value is used At the Time Of Feet to Inch Conversion
        /// </summary>
        private double feetToInchValue = 12.0;

        /// <summary>
        ///  This value is used At the Time Of Yard to Inch Conversion
        /// </summary>
        private double yardToInchValue = 36.0;

        /// <summary>
        ///  This value is used At the Time Of cm to Inch Conversion
        /// </summary>
        private double centimeterToInchValue = 2.5;

        /// <summary>
        /// Initializes a new instance of the <see cref="Length"/> class.
        /// </summary>
        public Length()
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
            /// It Indicates that Length is in Inch
            /// </summary>
            Inch,

            /// <summary>
            /// It is Used To Convert The Value Of Feet into Inch
            /// </summary>
            FeetToInch,

            /// <summary>
            /// It is Used To Convert The Value Of Yard into Inch
            /// </summary>
            YardToInch,

            /// <summary>
            /// It is Used To Convert The Value Of cm into Inch
            /// </summary>
            CentimeterToInch,
        }

        /// <summary>
        /// This Method is used to Set Unit conversion
        /// </summary>
        /// <param name="conversionType">It contains conversion type</param>
        /// <returns>It returns the Conversion type in unit form</returns>
        public Unit SetUnitAndConvertLength(string conversionType)
        {
            if (conversionType == "FeetToInch")
            {
                return Unit.FeetToInch;
            }
            else if (conversionType == "YardToInch")
            {
                return Unit.YardToInch;
            }
            else if (conversionType == "CentimeterToInch")
            {
                return Unit.CentimeterToInch;
            }
            else if (conversionType == "Inch")
            {
                return Unit.Inch;
            }

            return Unit.Null;
        }

        /// <summary>
        /// This Method Is used to Convert The Length from one to Another
        /// </summary>
        /// <param name="unit">It tells us About the Which Length is to be Convert</param>
        /// <param name="length">It Contains the value Which we convert</param>
        /// <returns>It Returns the Converted Value into Inch Format</returns>
        public double ConvertLength(Unit unit, double length)
        {
            try
            {
                // Check If Unit Is Equal To FeetToInch Then Convert The Feet Value Into Inch
                if (unit.Equals(Unit.FeetToInch))
                {
                    return length * this.feetToInchValue;
                }
                else if (unit.Equals(Unit.YardToInch))
                {
                    return length * this.yardToInchValue;
                }
                else if (unit.Equals(Unit.CentimeterToInch))
                {
                    return length / this.centimeterToInchValue;
                }
                else if (unit.Equals(Unit.Inch))
                {
                    return length;
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