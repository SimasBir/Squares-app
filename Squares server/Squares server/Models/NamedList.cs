using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squares_server.Models
{
    public class NamedList : Entity
    {
        public string Name { get; set; }
        public List<NamedListPoint> NamedListPoints { get; set; }

    }
}
