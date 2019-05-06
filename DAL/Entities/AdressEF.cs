using Common.DataContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{

    [Table("Adress")]
    public class AdressEF : IGenericEntities
    {

        public int Id { get; set; }
        public string UserID { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }

    }
}
