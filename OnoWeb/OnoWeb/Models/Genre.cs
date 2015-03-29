using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnoWeb.Models
{
    public class Genre
    {
        public int GenreID { get; set; }
        public string GenreName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Video> Videos { get; set; }
    }
}
