using Capa_Negocio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Capa_Presentacion.UserControls
{
    /// <summary>
    /// Dado un número identificador de técnico determina su dirección.
    /// <example>
    /// 1-----> Avinguda País Valenciâ nº 30 Planta:2 CP: 080204 (Alcoy)
    /// </example>
    /// </summary>
    [ValueConversion(typeof(int?), typeof(String))]
    public class ConvertTecnicianAddress : IValueConverter
    {
    
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                int userId = (int)value;
                
                return Negocio.ObtenerSedeTecnico(userId);
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
