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
    /// Convierte un idTecnico en el nombre y apellidos de dicho técnico
    /// <example>
    /// 1------> Alberto Moreno Fernández
    /// </example>
    /// </summary>
    [ValueConversion(typeof(int?), typeof(String))]
    public class ConvertTecnicoId : IValueConverter
    {
      
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value != null)
                {
                    int tecnico = (int)value;
                    List<Tecnico> listaTecnicos = Negocio.ObtenerTecnicos();
                    Tecnico tecnicoAConvertir = listaTecnicos.Where(X => X.IdTecnico == tecnico).ToList()[0];
                    Usuario usuarioTecnico = Negocio.ObtenerUsuario((int)tecnicoAConvertir.IdUsuario);
                    return usuarioTecnico.Nombre + " " + usuarioTecnico.Apellidos;
                }
                else
                    return "";
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
