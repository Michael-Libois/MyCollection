using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO.DataContext
{
    public class AdressDTO
    {
        public int Id { get; set; }
        public string UserID { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
    }
}
