using Capa_Negocio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Capa_Presentacion.UserControls
{
    /// <summary>
    /// Converite el categoriaId en su nombre correspondiente
    /// <example>
    /// 1-----> PC
    /// </example>
    /// </summary>
    [ValueConversion(typeof(int?), typeof(String))]
    public class ConvertIdCategoria : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                int numTipo = (int)value;
                return Negocio.ObtenerNombrePorTipoId(numTipo);
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
                return Negocio.ObtenerTipoIdPorNombre(strValue);
            }
            catch (Exception)
            {
                return 1;
            }

        }
    }
}
