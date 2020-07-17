//-----------------------------------------------------------------------
// <copyright file="QuantityMeasurementBusiness.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Mehboob Shaikh</author>
//-----------------------------------------------------------------------
[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:FileHeaderFileNameDocumentationMustMatchTypeName", Justification = "Reviewed.")]

namespace BusinessLayer.Services
{
    using System;
    using System.Collections.Generic;
    using BusinessLayer.Interface;
    using CommanLayer.Model;
    using RepositoryLayer.Interface;

    /// <summary>
    /// This Class is used to implement the methods of interface
    /// </summary>
    public class QuantityMeasurementBusiness : IQuantityMeasurementBusiness
    {
        /// <summary>
        /// Created the Reference of IQuantityMeasurementRepository
        /// </summary>
        private IQuantityMeasurementRepository quantityMeasurementRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuantityMeasurementBusiness"/> class.
        /// </summary>
        /// <param name="quantityMeasurementRepository">It contains the object IQuantityMeasurementRepository</param>
        public QuantityMeasurementBusiness(IQuantityMeasurementRepository quantityMeasurementRepository)
        {
            this.quantityMeasurementRepository = quantityMeasurementRepository;
        }

        /// <summary>
        /// This Method is used to Convert and add new Record
        /// </summary>
        /// <param name="quantity">It contains the Object of Quantity Model</param>
        /// <returns>It returns Added Record</returns>
        public Quantity ConvertAndAdd(Quantity quantity)
        {
            try
            {
                quantity.Result = this.UnitConversion(quantity);

                // Check if result greater than 0
                if (quantity.Result > 0)
                {
                    return this.quantityMeasurementRepository.Add(quantity);
                }

                return quantity;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// This Method is used to Read All Records
        /// </summary>
        /// <returns>It returns All Records</returns>
        public IEnumerable<Quantity> GetAllQuantity()
        {
            try
            {
                return this.quantityMeasurementRepository.GetAllQuantity();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// This Method is used to Get Quantity Record By Id
        /// </summary>
        /// <param name="id">It contains Id</param>
        /// <returns>It returns record of given Id</returns>
        public Quantity GetQuantityById(int id)
        {
            try
            {
                return this.quantityMeasurementRepository.GetQuantityById(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// This Method is used to Delete Quantity Record By Id
        /// </summary>
        /// <param name="id">It contains Id</param>
        /// <returns>It returns the Deleted Record</returns>
        public Quantity DeleteQuntityById(int id)
        {
            try
            {
                return this.quantityMeasurementRepository.DeleteQuntityById(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// This Method is used to Compare and Add
        /// </summary>
        /// <param name="compare">It contains the Object of Compare Model</param>
        /// <returns>It returns Added Record</returns>
        public Compare CompareAndAdd(Compare compare)
        {
            try
            {
                compare.Result = this.UnitComparision(compare);
                if (compare.Result != null)
                {
                    return this.quantityMeasurementRepository.AddComparedValue(compare);
                }

                return compare;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// This Method is used to Read All Records Of Comparisons
        /// </summary>
        /// <returns>It returns All Records</returns>
        public IEnumerable<Compare> GetAllComparison()
        {
            try
            {
                return this.quantityMeasurementRepository.GetAllComparison();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// This Method is used to Get Comparison Record By Id
        /// </summary>
        /// <param name="id">It contains Id</param>
        /// <returns>It returns record of given Id</returns>
        public Compare GetComparisonById(int id)
        {
            try
            {
                return this.quantityMeasurementRepository.GetComparisonById(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// This Method is used to Delete Comparison Record By Id
        /// </summary>
        /// <param name="id">It contains Id</param>
        /// <returns>It returns the Deleted Record</returns>
        public Compare DeleteComparisonById(int id)
        {
            try
            {
                return this.quantityMeasurementRepository.DeleteComparisonById(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// This Method is Used To Compare the two values of different Unit
        /// </summary>
        /// <param name="compare">It contains the information about Compare</param>
        /// <returns>It Returns the comparison result</returns>
        private string UnitComparision(Compare compare)
        {
            try
            {
                // String Variable contains the Measurement Type
                string measurmentType = compare.MeasurementType;

                // String Variable contains the Unit of First Value
                string firstValueUnit = compare.FirstValueUnit;

                // It contains the first Value
                double firstValue = compare.FirstValue;

                // String Variable contains the Unit of Second Value
                string secondValueUnit = compare.SecondValueUnit;

                // It contains the Second Value
                double secondValue = compare.SecondValue;

                // It Contains the Conversion Result of first Value
                double firstResult = this.Conversion(measurmentType, firstValueUnit, firstValue);

                // It Contains the Conversion Result of Second Value
                double secondResult = this.Conversion(measurmentType, secondValueUnit, secondValue);

                // Comapre First Result is Equal to Second or Not
                if (firstResult == secondResult)
                {
                    return "Both values are equal";
                }
                else if (firstResult > secondResult)
                {
                    return firstValueUnit + " " + firstValue + " is greater than " + secondValueUnit + " " + secondValue;
                }
                else if (firstResult < secondResult)
                {
                    return firstValueUnit + " " + firstValue + " is less than " + secondValueUnit + " " + secondValue;
                }

                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// This Method is used to convert unit values one to other
        /// </summary>
        /// <param name="quantity">It contains the information about conversion unit</param>
        /// <returns>It Returns the converted unit result</returns>
        private double UnitConversion(Quantity quantity)
        {
            try
            {
                // String Variable contains the Measurement Type
                string measurementType = quantity.MeasurementType;

                // String Variable contains the Conversion Type
                string conversionType = quantity.ConversionType;

                // It contains the value to be convert
                double value = quantity.Value;

                // It returns the converted unit result
                return this.Conversion(measurementType, conversionType, value);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// This is the Generic Method for length, weight, volume and temperature unit conversion 
        /// </summary>
        /// <param name="measurementType">It contains the Measurement Type</param>
        /// <param name="conversionType">It contains the Conversion Type</param>
        /// <param name="value">It contains the value to be convert</param>
        /// <returns>It returns the converted unit result</returns>
        private double Conversion(string measurementType, string conversionType, double value)
        {
            try
            {
                // Check if Measurement type is length
                if (measurementType == "length")
                {
                    Length length = new Length();
                    Length.Unit unit = length.SetUnitAndConvertLength(conversionType);

                    // Check enum units and conversion Type 
                    if (unit == Length.Unit.FeetToInch || unit == Length.Unit.YardToInch || unit == Length.Unit.CentimeterToInch || unit == Length.Unit.Inch)
                    {
                        return length.ConvertLength(unit, value);
                    }
                }
                else if (measurementType == "weight")
                {
                    Weight weight = new Weight();
                    Weight.Unit unit = weight.SetUnitAndConvertWeights(conversionType);

                    // Check enum units and conversion Type 
                    if (unit.Equals(Weight.Unit.GramsToKilogram) || unit.Equals(Weight.Unit.TonneToKilograms) || unit.Equals(Weight.Unit.kilogram))
                    {
                        return weight.ConvertWeigths(unit, value);
                    }
                }
                else if (measurementType == "volume")
                {
                    Volume volume = new Volume();
                    Volume.Unit unit = volume.SetUnitAndConvertVolume(conversionType);

                    // Check enum units and conversion Type 
                    if (unit.Equals(Volume.Unit.GallonToLitre) || unit.Equals(Volume.Unit.MiliLitreToLitre) || unit.Equals(Volume.Unit.Litre))
                    {
                        return volume.ConvertValueToLitre(unit, value);
                    }
                }
                else if (measurementType == "temperature")
                {
                    Temperature temperature = new Temperature();
                    Temperature.Unit unit = temperature.SetUnitAndConvertTemperature(conversionType);

                    // Check enum units and conversion Type 
                    if (unit.Equals(Temperature.Unit.FahrenheitToCelsius))
                    {
                        return temperature.ConvertTemperature(unit, value);
                    }
                }

                return 0;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
