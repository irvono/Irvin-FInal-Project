using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnoWeb.Models
{
    public class PhotoViewModel
    {
        public string Name { get; set; }
        public OnerViewModel Oner { get; set; }
    }
    public class OnerViewModel
    {
        public string FirstName { get; set; }
    }
}
