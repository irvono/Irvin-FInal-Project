using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnoWeb.Models
{
    public class Album
    {
        public int AlbumID { get; set; }
        public string Title { get; set; }

        // Every album has many photos and a particular photo can only belong to one album
        public virtual ICollection<Photo> Photos { get; set; }
    }
}
