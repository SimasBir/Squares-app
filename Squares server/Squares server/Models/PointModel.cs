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
        public int xCoord { get; set; }
        public int yCoord { get; set; }
        public List<NamedListPoint> NamedListPoints { get; set; }
    }
}
