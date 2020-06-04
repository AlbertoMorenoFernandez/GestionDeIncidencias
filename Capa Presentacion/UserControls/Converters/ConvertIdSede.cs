using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using Capa_Entidades;
using Capa_Negocio;

namespace Capa_Presentacion.UserControls
{

    /// <summary>
    /// Realiza la conversión de un "numOficina" a la dirección completa
    /// <example>
    /// 1 ------------> Avenida Oscar Esplá 58 CP: 03006 Plana: 2 (Alicante)
    /// </example>
    /// </summary>
    [ValueConversion(typeof(int?), typeof(String))]
    public class ConvertIdSede : IValueConverter
    {
  
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                int numSede = (int)value;
                return Negocio.ObtenerDireccionSede(numSede);
            }
            catch (Exception)
            {
                return "No disponible";
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                string strValue = value as string;
                return Negocio.obtenerSedeIdPorNombre(strValue);
            }
            catch (Exception)
            {
                return 1;                
            }
                
        }
    }
}