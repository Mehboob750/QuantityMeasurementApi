using System;
using System.Collections.Generic;
using System.Text;
using CommanLayer.Model;

namespace RepositoryLayer.Interface
{
    public interface IQuantityMeasurementRepository
    {
        Quantity Add(Quantity quantity);
    }
}
