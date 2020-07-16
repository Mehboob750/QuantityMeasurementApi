using System;

namespace BusinessLayer.Services
{
    public class Weight
    {
        const double ConvertWeightValue = 1000;
        public Weight()
        {
        }

        public enum Unit
        {
            Null,
            kilogram,
            GramsToKilogram,
            TonneToKilograms
        }

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
       
        public double ConvertWeigths(Unit unit, double weight)
        {
            try
            {
                if (unit.Equals(Unit.GramsToKilogram))
                {
                    return weight / ConvertWeightValue;
                }
                else if (unit.Equals(Unit.TonneToKilograms))
                {
                    return weight * ConvertWeightValue;
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
