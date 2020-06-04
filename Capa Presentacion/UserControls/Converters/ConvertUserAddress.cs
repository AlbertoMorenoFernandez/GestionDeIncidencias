using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
    public class ConvertUserAddress : IValueConverter
    {
     
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) 
        {
            try
            {
                int userId = (int)value;
                Usuario usuarioElegido = Negocio.ObtenerUsuario(userId);
                Sede sede = Negocio.ObtenerSede((int)usuarioElegido.NumOficina);
                String localidad = Negocio.ObtenerLocalidad((int)sede.NumOficina).Nombre;
                return sede.Calle + " CP: " + sede.CodigoPostal + " Planta: " + sede.Planta + " (" + localidad + ")";
            }
            catch (Exception)
            {

              return "No disponible" ;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string strValue = value as string;
            int? rol = 10;
            rol = Negocio.ObtenerRolIdPorNombre(strValue);
            if (rol != 10)
                return rol;
            else
                return DependencyProperty.UnsetValue;
        }
    }
}
