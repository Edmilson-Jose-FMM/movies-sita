using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesSita.Domain.Entities
{
    public class Movies
    {
        public int? id { get; set; }
        public string? title { get; set; } 
        public float? vote_average { get; set; }
        public int? vote_count { get; set; }
        public string? status { get; set; }
        public string? release_date { get; set; }
        public int? revenue { get; set; }
        public int? runtime { get; set; }
        public bool?  adult { get; set; }
        public string? backdrop_path { get; set; }
        public int? budget { get; set; }
        public string? homepage { get; set; }
        public string? imdb_id { get; set; }
        public string? original_language { get; set; }
        public string? original_title { get; set; }
        public string? overview { get; set; }
        public float? popularity { get; set; }
        public string? poster_path { get; set; }
        public string? tagline { get; set; }
        public string? genres { get; set; }
        public string? production_companies { get; set; }
        public string? production_countries { get; set; }
        public string? spoken_languages { get; set; }
        public string? keywords { get; set; }
    }
}
