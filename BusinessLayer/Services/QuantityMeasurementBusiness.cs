using System;
using System.Collections.Generic;
using System.Text;
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

        public Quantity Convert(Quantity quantity)
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
            Length length = new Length();
           
            if (MeasurementType == "length")
            {
                Length.Unit unit = length.SetUnitAndConvertLength(conversionType);

                if (unit == Length.Unit.FeetToInch || unit == Length.Unit.YardToInch || unit == Length.Unit.CentimeterToInch)
                {
                    return length.ConvertLength(unit, value);
                }
            }

            return value;
        }

    }
}
