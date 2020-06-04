using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Capa_Negocio;


namespace Capa_Presentacion.UserControls
{
    /// <summary>
    /// Convierte un localidadID en su nombre de localidad
    /// <exammple>
    /// 1-----> Alicante
    /// </exammple>
    /// </summary>
    [ValueConversion(typeof(int?), typeof(String))]
    public class ConvertLocalidad
    {
      
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                int localidad = (int)value;
                return Negocio.ObtenerNombreLocalidad(localidad);
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
                return Negocio.ObtenerLocalidadIdPorNombre(strValue);
            }
            catch (Exception)
            {
                return 1;
            }

        }
    }
}
