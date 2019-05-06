using Common.BTO;
using Common.DTO.IMDBProxy;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.TypeExtentions
{
    public static class AdressEFExtentions
    {
        public static AdressEF ToEF(this AdressBTO adressBTO)
            => new AdressEF
            {
                Id = adressBTO.Id,
                UserID = adressBTO.UserID,
                Street = adressBTO.Street,
                Number = adressBTO.Number,
                PostalCode = adressBTO.PostalCode,
                City = adressBTO.City
            };

        public static AdressBTO ToBTO(this AdressEF adressEF)
            => new AdressBTO
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
