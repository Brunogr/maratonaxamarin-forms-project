using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaratonaXamarinsProject.Model
{
    public class FacebookMovieModel
    {
        public Datum[] data { get; set; }
        public Paging paging { get; set; }
    }

    public class Paging
    {
        public Cursors cursors { get; set; }
        public string next { get; set; }
    }

    public class Cursors
    {
        public string before { get; set; }
        public string after { get; set; }
    }

    public class Datum
    {
        public DataMovie data { get; set; }
        public string id { get; set; }
    }

    public class DataMovie
    {
        public Movie movie { get; set; }
    }

    public class Movie
    {
        public string id { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public string image { get; set; }
    }
}
