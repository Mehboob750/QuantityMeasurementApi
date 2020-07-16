using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class Length
    {
        const double FeetToInchValue = 12.0;
        const double YardToInchValue = 36.0;
        const double CentimeterToInchValue = 2.5;

        public Length()
        {
        }

        public enum Unit
        {
            Null,
            Inch,
            FeetToInch,
            YardToInch,
            CentimeterToInch,
        }

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

        public double ConvertLength(Unit unit, double length)
        {
            try
            {
                if (unit.Equals(Unit.FeetToInch))
                {
                    return length * FeetToInchValue;
                }

                else if (unit.Equals(Unit.YardToInch))
                {
                    return length * YardToInchValue;
                }

                else if (unit.Equals(Unit.CentimeterToInch))
                {
                    return length / CentimeterToInchValue;
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

        public double CalculateLength(double firstValue, double secondValue)
        {
            try
            {
                return firstValue + secondValue;
            }
            catch (QuantityMeasurementException e)
            {
                throw new QuantityMeasurementException(QuantityMeasurementException.ExceptionType.InvalidData, e.Message);
            }
        }
    }
}

