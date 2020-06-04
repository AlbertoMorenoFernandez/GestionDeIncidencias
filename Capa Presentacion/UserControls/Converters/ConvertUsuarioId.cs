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
    /// Realiza la conversión de un identificador de usuario al nombre y apellidos
    /// <example>
    /// 1-----> Alberto Moreno Fernández
    /// </example>
    /// </summary>
    [ValueConversion(typeof(int?), typeof(String))]
    public class ConvertUsuarioId : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                int user = (int)value;
                Usuario usuarioElegido = Negocio.ObtenerUsuario(user);
                return usuarioElegido.Nombre + " " + usuarioElegido.Apellidos;
            }
            catch (Exception)
            {

                return "No disponible";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
                return DependencyProperty.UnsetValue;
        }
    }
}