using Common.DTO.IMDBProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{

    public class JsonRetourIMDB
    {
        public IMDBMovieSummary[] Search { get; set; }
        public string TotalResults { get; set; }
        public bool Response { get; set; }

    
    }
}
