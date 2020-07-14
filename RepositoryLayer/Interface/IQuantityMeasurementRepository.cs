using System;
using System.Collections.Generic;
using System.Text;
using CommanLayer.Model;

namespace RepositoryLayer.Interface
{
    public interface IQuantityMeasurementRepository
    {
        Quantity Add(Quantity quantity);

        IEnumerable<Quantity> GetAllQuantity();

        Quantity GetQuantityById(int Id);

        Quantity DeleteQuntityById(int Id);

        Compare AddComparedValue(Compare compare);
    }
}
