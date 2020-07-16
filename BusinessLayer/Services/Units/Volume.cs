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
            Null,
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
