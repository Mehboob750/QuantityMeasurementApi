using System;
using System.Collections.Generic;
using BusinessLayer.Interface;
using CommanLayer.Model;
using RepositoryLayer.Interface;

namespace BusinessLayer.Services
{
    public class QuantityMeasurementBusiness : IQuantityMeasurementBusiness
    {
        private IQuantityMeasurementRepository quantityMeasurementRepository;

        public QuantityMeasurementBusiness(IQuantityMeasurementRepository quantityMeasurementRepository)
        {
            this.quantityMeasurementRepository = quantityMeasurementRepository;
        }

        public Quantity ConvertAndAdd(Quantity quantity)
        {
            try
            {
                quantity.Result = UnitConversion(quantity);

                if (quantity.Result > 0)
                {
                    return quantityMeasurementRepository.Add(quantity);
                }
                return quantity;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public IEnumerable<Quantity> GetAllQuantity()
        {
            try
            {
                return quantityMeasurementRepository.GetAllQuantity();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Quantity GetQuantityById(int Id)
        {
            try
            {
                return quantityMeasurementRepository.GetQuantityById(Id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Quantity DeleteQuntityById(int Id)
        {
            try
            {
                return quantityMeasurementRepository.DeleteQuntityById(Id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private double UnitConversion(Quantity quantity)
        {
            try
            {
                string MeasurementType = quantity.MeasurementType;
                string conversionType = quantity.ConversionType;
                double value = quantity.Value;
                return Conversion(MeasurementType, conversionType, value);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private double Conversion(string MeasurementType, string conversionType, double value)
        {
            try
            {
                if (MeasurementType == "length")
                {
                    Length length = new Length();
                    Length.Unit unit = length.SetUnitAndConvertLength(conversionType);

                    if (unit == Length.Unit.FeetToInch || unit == Length.Unit.YardToInch || unit == Length.Unit.CentimeterToInch)
                    {
                        return length.ConvertLength(unit, value);
                    }
                }
                else if (MeasurementType == "weight")
                {
                    Weight weight = new Weight();
                    Weight.Unit unit = weight.SetUnitAndConvertWeights(conversionType);

                    if (unit.Equals(Weight.Unit.GramsToKilogram) || unit.Equals(Weight.Unit.TonneToKilograms))
                    {
                        return weight.ConvertWeigths(unit, value);
                    }
                }
                else if (MeasurementType == "volume")
                {
                    Volume volume = new Volume();
                    Volume.Unit unit = volume.SetUnitAndConvertVolume(conversionType);
                    if (unit.Equals(Volume.Unit.GallonToLitre) || unit.Equals(Volume.Unit.MiliLitreToLitre))
                    {
                        return volume.ConvertValueToLitre(unit, value);
                    }
                }
                else if (MeasurementType == "temperature")
                {
                    Temperature temperature = new Temperature();
                    Temperature.Unit unit = temperature.SetUnitAndConvertTemperature(conversionType);
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
