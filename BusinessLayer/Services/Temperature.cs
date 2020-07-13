using System;

namespace BusinessLayer.Services
{
    public class Temperature
    {
        public Temperature()
        {
        }

        public enum Unit
        {
            
            Fahrenheit,
            Celsius,
            FahrenheitToCelsius
        }

        public Unit SetUnitAndConvertTemperature(string conversionType)
        {
            if (conversionType == "FahrenheitToCelsius")
            {
                return Unit.FahrenheitToCelsius;
            }

            return Unit.Fahrenheit;
        }

        public double ConvertTemperature(Unit unit, double value)
        {
            try
            {
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
