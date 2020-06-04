using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Capa_Entidades;
namespace Capa_Presentacion
{
    /// <summary>
    /// Lógica de interacción para VentanaGerente.xaml
    /// </summary>
    public partial class VentanaGerente : Window
    {
        public VentanaGerente(Usuario user)
        {
            InitializeComponent();
        }
    }
}
