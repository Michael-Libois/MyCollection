﻿namespace Common.MTO
{
    public class MovieSummary
    {
        public int Id { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string imdbID { get; set; }
        public string Poster { get; set; }

        public string Genre { get; set; }
        public string Director { get; set; }
    }
}
