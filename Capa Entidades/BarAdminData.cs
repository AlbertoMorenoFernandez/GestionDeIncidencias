using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{
    public class BarAdminData
    {
        string _day;
        double _count;

        public BarAdminData(string day, double count)
        {
            Day = day;
            Count = count;
        }

        public string Day { get => _day; set => _day = value; }
        public double Count { get => _count; set => _count = value; }
    }
}
