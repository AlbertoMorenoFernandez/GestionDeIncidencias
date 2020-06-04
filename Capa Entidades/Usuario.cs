using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{
    public class Usuario : INotifyPropertyChanged
    {

        private int? _usuarioId;
        private string _password;
        private string _nombre;
        private string _apellidos;
        private int? _extension;
        private string _mail;
        private int? _numOficina;
        private int? _rolUsuario;

        public Usuario()
        {
            _usuarioId = 0;
            _password = null;
            _nombre = null;
            _apellidos = null;
            _extension = 0;
            _mail = null;
            _numOficina = 0;
            _rolUsuario = 0;
        }

        public Usuario(Usuario previo)
        {
            UsuarioId = previo.UsuarioId;
            Password = previo.Password;
            Nombre = previo.Nombre;
            Apellidos = previo.Apellidos;
            Extension = previo.Extension;
            Mail = previo.Mail;
            NumOficina = previo.NumOficina;
            RolUsuario = previo.RolUsuario;
        }
        public Usuario(int? usuarioId, string password, string nombre, string apellidos, int? extension, string mail, int? numOficina, int? rolUsuario)
        {
            UsuarioId = usuarioId;
            Password = password;
            Nombre = nombre;
            Apellidos = apellidos;
            Extension = extension;
            Mail = mail;
            NumOficina = numOficina;
            RolUsuario = rolUsuario;
        }

        public int? UsuarioId {
            get
            {
                return _usuarioId;
            }

            set
            {
                _usuarioId = value;
                OnPropertyChanged("UsuarioId");
            
            }
        }
        public string Password {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
             }
        }
        public string Nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
                OnPropertyChanged("Nombre");
            }
        }
        public string Apellidos {
            get
            {
                return _apellidos;
            }
            set
            {
                _apellidos = value;
                OnPropertyChanged("Apellidos");
            }
        }
        public int? Extension {
            get {
                return _extension;
            }
            set {
                _extension = value;
                OnPropertyChanged("Extension");
            }
        }
        public string Mail {
            get
            {
                return _mail;
            }
            set
            {
                _mail = value;
                OnPropertyChanged("Mail");
            }
        }
        public int? NumOficina {
            get
            {
                return _numOficina;
            }
            set
            {
                _numOficina = value;
                OnPropertyChanged("NumOficina");
            }
        }
        public int? RolUsuario {
            get
            {
                return _rolUsuario;
            }
            set
            {
                _rolUsuario = value;
                OnPropertyChanged("RolUsuario");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
      

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
