using Common.BTO;
using Common.DTO.DataContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.TypeExtentions
{
    public static class AdressExtentions
    {

        public static AdressBTO ToBTO(this AdressDTO adressDTO)
            => new AdressBTO
            {
                Id = adressDTO.Id,
                UserID = adressDTO.UserID,
                Street = adressDTO.Street,
                Number = adressDTO.Number,
                PostalCode = adressDTO.PostalCode,
                City = adressDTO.City
                
            };

        public static AdressDTO ToDTO(this AdressBTO adressBTO)
            => new AdressDTO
            {
                Id = adressBTO.Id,
                UserID = adressBTO.UserID,
                Street = adressBTO.Street,
                Number = adressBTO.Number,
                PostalCode = adressBTO.PostalCode,
                City = adressBTO.City

            };

    }
}
