using Common.MTO;
using Common.DTO.IMDBProxy;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Converters
{
    public  class AdressConverter : TypeConverter<Adress, AdressEF>
    {
        public  AdressEF ToEF( Adress Adress)
            => new AdressEF
            {
                Id = Adress.Id,
                UserID = Adress.UserID,
                Street = Adress.Street,
                Number = Adress.Number,
                PostalCode = Adress.PostalCode,
                City = Adress.City
            };

        public  Adress ToMTO( AdressEF adressEF)
            => new Adress
            {
                Id = adressEF.Id,
                UserID = adressEF.UserID,
                Street = adressEF.Street,
                Number = adressEF.Number,
                PostalCode = adressEF.PostalCode,
                City = adressEF.City
            };
    }
}
