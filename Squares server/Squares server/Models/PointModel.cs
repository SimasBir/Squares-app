using System.Collections.Generic;


namespace Squares_server.Models
{
    public class PointModel : Entity
    {
        public int xCoord { get; set; }
        public int yCoord { get; set; }
        public List<NamedListPoint> NamedListPoints { get; set; }
    }
}
