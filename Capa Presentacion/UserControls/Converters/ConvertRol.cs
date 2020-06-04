using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using Capa_Negocio;
using Capa_Entidades;

namespace Capa_Presentacion.UserControls
{
    /// <summary>
    /// Convierte el RolId en su nombre correspondiente
    /// <example>
    /// 2----> cliente
    /// 3----> tecnico
    /// </example>
    /// </summary>
    [ValueConversion(typeof(int?), typeof(String))]
    public class ConvertRol : IValueConverter
    {
     
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                int rol = (int)value;
                Rol rolElegido = Negocio.ObtenerRol(rol);
                return rolElegido.Nombre;
            }
            catch (Exception)
            {

                return "No disponible";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string strValue = value as string;
            int? rol = 10;
            rol = Negocio.ObtenerRolIdPorNombre(strValue);
            if (rol!=null && rol != 10)
                return rol;
            else
                return DependencyProperty.UnsetValue;
        }
    }
}
