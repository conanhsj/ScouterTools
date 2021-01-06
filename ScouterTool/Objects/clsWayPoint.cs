using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScouterTool.Objects
{
    public class clsWayPoint
    {
        string strDateTime;
        string strPointName;

        public string DateTime { get => strDateTime; set => strDateTime = value; }
        public string PointName { get => strPointName; set => strPointName = value; }
    }
}
