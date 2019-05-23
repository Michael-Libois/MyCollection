using System;
using System.Collections.Generic;
using System.Text;
using DAL.Converters;
using Common.MTO;
using Common.DataContracts;

namespace DAL.Converters
{
    public interface TypeConverter<TMto, TEf>
    {
        TEf ToEF(TMto TransfertObject);

        TMto ToMTO(TEf Entities);
    }
}
