using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squares_server.Models
{
    public class PointModel : Entity
    {
        [Range(-5000, 5000)]
        public int xCoord { get; set; }
        [Range(-5000, 5000)]
        public int yCoord { get; set; }
        public List<NamedListPoint> NamedListPoints { get; set; }
    }
}
