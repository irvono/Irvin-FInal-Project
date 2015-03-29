using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnoWeb.Models
{
    public class Video
    {
        public int VideoID { get; set; }
        public string Title { get; set; }
        public int GenreID { get; set; }
        public int OnerID { get; set; }
    }
}
