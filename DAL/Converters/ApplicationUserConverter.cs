
using Common.MTO;
using Common.DTO.IMDBProxy;
using DAL.Entities;
using DAL.Entities.Messages;
using System;
using System.Collections.Generic;
using System.Text;


namespace DAL.Converters
{
    public class ApplicationUserConverter : TypeConverter<ApplicationUserEF, ApplicationUserEF>
    {
        public ApplicationUserEF ToEF(ApplicationUserEF Message)
            => Message;

        public ApplicationUserEF ToMTO(ApplicationUserEF messageEF)
            => messageEF;
    }
}
