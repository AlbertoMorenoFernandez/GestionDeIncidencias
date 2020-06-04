using Capa_Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Presentacion.Utils
{

    /// <summary>
    /// Provee de métodos para:
    /// a) Importar desde un CSV
    /// b) Exportar a un CSV
    /// c) Codificar una cadena.
    /// </summary>
    public static class Utilidad
    {

        /// <summary>
        /// Genera un archivo .csv de la entidad especificada en tipo y con los valores recibido en listado.
        /// </summary>
        /// <param name="listado"> listado con los objetos que deseamos incluir en el csv</param>
        /// <param name="tipo">Tipo de entidad que tiene nuestro listado.</param>
        public static void ExportarCsv(List<Object> listado, string tipo)
        {
            try
            {
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.FileName = "listado_"; // Default file name
                dlg.DefaultExt = ".csv"; // Default file extension
                dlg.Filter = "Csv documents (.csv)|*.csv"; // Filter files by extension
                                                           // Show save file dialog box
                Nullable<bool> result = dlg.ShowDialog();

                // Process save file dialog box results
                if (result == true)
                {
                    // Save document
                    string filename = dlg.FileName;
                    StreamWriter sw = new StreamWriter(filename);

                    if (tipo.Equals("usuario"))
                    {
                        foreach (Usuario u in listado)
                        {
                            sw.WriteLine(u.UsuarioId + ";" + u.Password + ";" + u.Nombre + ";" + u.Apellidos + ";" + u.Extension + ";" + u.Mail + ";" + u.NumOficina + ";" + u.RolUsuario);
                        }
                    }

                    if (tipo.Equals("sede"))
                    {
                        foreach (Sede sede in listado)
                        {
                            sw.WriteLine(sede.NumOficina + ";" + sede.Calle + ";" + sede.Planta + ";" + sede.CodigoPostal + ";" + sede.Localidad);
                        }
                    }

                    if (tipo.Equals("localidad"))
                    {
                        foreach (Localidad local in listado)
                        {
                            sw.WriteLine(local.Id + ";" + local.Nombre);
                        }
                    }
                    if (tipo.Equals("categoria"))
                    {
                        foreach (Tipo tip in listado)
                        {
                            sw.WriteLine(tip.Id + ";" + tip.Nombre);
                        }
                    }
                    if (tipo.Equals("equipo"))
                    {
                        foreach (Equipo e in listado)
                        {
                            sw.WriteLine(e.ServiceTag + ";" + e.Marca + ";" + e.Modelo + ";" + e.FinGarantia + ";" + e.Idtipo + ";" + e.NumOficina + ";" + e.NumSerie);
                        }
                    }
                    sw.Close();
                }
            }
            catch (Exception)
            {
                throw new FormatException("Error al generar CSV");
            }

        }

        /// <summary>
        /// Muestra un cuadro de dialogo que permite seleccionar un archivo CSV,  dependiendo de la entidad pasada como parámetro
        /// genera una lista del tipo que hayamos pasado siempre y cuando el archivo cumpla con el formato correcto y coincidente, en caso contrario
        /// muestra un mensaje de error. Una vez generada la lista, la muestra mediante una ventana modal usando <see cref="impUserModal"/>
        /// </summary>
        /// <param name="tipo"></param>
        public static void ImportarCSv(string tipo)
        {
            try
            {
                // listaUsuarios = negocio.ObtenerUsuarios();
                // Configure open file dialog box
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.FileName = "Document"; // Default file name
                dlg.DefaultExt = ".csv"; // Default file extension
                dlg.Filter = "Csv documents (.csv)|*.csv"; // Filter files by extension

                // Show open file dialog box
                Nullable<bool> result = dlg.ShowDialog();

                // Process open file dialog box results
                if (result == true)
                {
                    // Open document
                    string filename = dlg.FileName;

                    String[] lines = File.ReadAllLines(dlg.FileName);
                    if (lines.Length >= 0)
                    {
                        List<Object> lista = new List<Object>();
                        if (tipo.Equals("usuario"))
                        {
                            
                            List<Usuario> listaUsuarios = new List<Usuario>();
                            for (int i = 0; i < lines.Length; i++)
                            {
                                if (!lines[i].Equals(""))
                                {
                                    string[] campos = lines[i].Split(';');

                                    Usuario nuevoUsuario = new Usuario(int.Parse(campos[0]), campos[1], campos[2], campos[3], int.Parse(campos[4]), campos[5], int.Parse(campos[6]), int.Parse(campos[7]));
                                    listaUsuarios.Add(nuevoUsuario);
                                }

                            }
                            lista.Clear();
                            foreach (Usuario u in listaUsuarios)
                            {
                                lista.Add(u);
                            }
                        }
                        else if (tipo.Equals("sede"))
                        {
                            List<Sede> listaSedes = new List<Sede>();
                            for (int i = 0; i < lines.Length; i++)
                            {
                                if (!lines[i].Equals(""))
                                {
                                    string[] campos = lines[i].Split(';');
                                    Sede nuevaSede = new Sede(int.Parse(campos[0]), campos[1], campos[2],  int.Parse(campos[3]),  int.Parse(campos[4]));
                                    listaSedes.Add(nuevaSede);
                                }

                            }
                            lista.Clear();
                            foreach (Sede u in listaSedes)
                            {
                                lista.Add(u);
                            }
                        }
                        else if (tipo.Equals("localidad"))
                        {
                            List<Localidad> listaLocalidades = new List<Localidad>();
                            for (int i = 0; i < lines.Length; i++)
                            {
                                if (!lines[i].Equals(""))
                                {
                                    string[] campos = lines[i].Split(';');

                                    Localidad nuevaLocalidad = new Localidad(int.Parse(campos[0]), campos[1]);
                                    listaLocalidades.Add(nuevaLocalidad);
                                }
                            }
                            lista.Clear();
                            foreach (Localidad u in listaLocalidades)
                            {
                                lista.Add(u);
                            }
                        }
                        else if (tipo.Equals("categoria"))
                        {
                            List<Tipo> listaTipos = new List<Tipo>();
                            for (int i = 0; i < lines.Length; i++)
                            {
                                if (!lines[i].Equals(""))
                                {
                                    string[] campos = lines[i].Split(';');
                                    Tipo nuevoTipo = new Tipo(int.Parse(campos[0]), campos[1]);
                                    listaTipos.Add(nuevoTipo);
                                }
                            }
                            lista.Clear();
                            foreach (Tipo u in listaTipos)
                            {
                                lista.Add(u);
                            }
                        }
                        else if (tipo.Equals("equipo"))
                        {
                            List<Equipo> listaEquipos = new List<Equipo>();
                            for (int i = 0; i < lines.Length; i++)
                            {
                                if (!lines[i].Equals(""))
                                {
                                    string[] campos = lines[i].Split(';');
                                    Equipo nuevoEquipo = new Equipo(campos[0], campos[1],campos[2],DateTime.Parse(campos[3]),int.Parse(campos[4]),int.Parse(campos[5]),campos[6]);
                                    listaEquipos.Add(nuevoEquipo);
                                }
                            }
                            lista.Clear();
                            foreach (Equipo u in listaEquipos)
                            {
                                lista.Add(u);
                            }
                        }
                        impUserModal modal = new impUserModal(lista, tipo);
                        modal.ShowDialog();
                    }
                }
            }
            catch (IOException )
            {
                VentanaInformacion modal = new VentanaInformacion("Error de lectura de fichero", "advertencia");
                modal.ShowDialog();
            }
            catch (Exception )
            {
                VentanaInformacion modal = new VentanaInformacion("El archivo escogido no es un csv de usuarios", "advertencia");
                modal.ShowDialog();
            }



        }

        /// <summary>
        //  Codifica en MD5 una cadena de texto
        /// </summary>
        /// <param name="input"> Cadena a codificar</param>
        /// <returns> La cadena pasada como parámetro codificada</returns>
        public static string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
