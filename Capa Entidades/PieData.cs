using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{

    /// <summary>
    /// CLASE AUXILIAR QUE PERMITE CREAR UNA ESTRUCTURA CON EL NOMBRE DE UN TIPO DE ARTÍCULO Y CUANTOS ARTÍCULOS HAY DE ESE TIPO.
    /// </summary>
    public class PieData
    {
        string _name;
        int _count;

        public PieData(string name, int count)
        {
            this.Name = name;
            this.Count = count;
        }

        public string Name { get => _name; set => _name = value; }
        public int Count { get => _count; set => _count = value; }
    }
}
