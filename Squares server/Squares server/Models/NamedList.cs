using System.Collections.Generic;


namespace Squares_server.Models
{
    public class NamedList : Entity
    {
        public string Name { get; set; }
        public List<NamedListPoint> NamedListPoints { get; set; }

    }
}
