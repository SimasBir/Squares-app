using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squares_server.Models
{
    public class NamedListPoint
    {
        public int NamedListId { get; set; }
        public int PointModelId { get; set; }
        public NamedList NamedList { get; set; }
        public PointModel PointModel { get; set; }
    }
}
