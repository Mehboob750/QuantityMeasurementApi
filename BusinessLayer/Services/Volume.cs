using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class Volume
    {
        private double gallonToLitreValue = 3.78;

        private double miliLitreToLitreValue = 1000;

        public enum Unit
        {
            Gallon,
            Litre,
            GallonToLitre,
            MiliLitreToLitre
        }

        public Unit SetUnitAndConvertVolume(string conversionType)
        {
            if (conversionType == "GallonToLitre")
            {
                return Unit.GallonToLitre;
            }

            if (conversionType == "MiliLitreToLitre")
            {
                return Unit.MiliLitreToLitre;
            }

            return Unit.Litre;
        }

        public double ConvertValueToLitre(Unit unit, double value)
        {
            try
            {
                if (unit.Equals(Unit.GallonToLitre))
                {
                    return value * this.gallonToLitreValue;
                }
                else if (unit.Equals(Unit.MiliLitreToLitre))
                {
                    return value / this.miliLitreToLitreValue;
                }

                return value;
            }
            catch (Exception e)
            {
                throw new QuantityMeasurementException(QuantityMeasurementException.ExceptionType.InvalidValue, e.Message);
            }
        }
    }
}
