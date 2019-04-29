using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class IMDBMovieResult
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string imdbID { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }

        public string Genre { get; set; }
        public string Director { get; set; }
    }
    public class JsonRetourIMDB
    {
        public IMDBMovieResult[] Search { get; set; }
        public string TotalResults { get; set; }
        public bool Response { get; set; }

    
    }
}
