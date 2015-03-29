using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnoWeb.Models
{
    public class Photo
    {
        public int PhotoID { get; set; }
        public string Name { get; set; }
        public string PhotoFile { get; set; }
        public int AlbumID { get; set; }
        public int OnerID { get; set; }
    }
}
