using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBindings
{
    public class Persona:INotifyPropertyChanged
    {
        private String? nombre;
        private String? apellido;
        private String? nombreCompleto;
        private uint edad;
        

        public Persona() { 

        }

        public string? Nombre { get => nombre; set
            {
                nombre = value;
                OnPropertyChanged("NombreCompleto");
            }
        }
        public uint Edad { get => edad; set => edad = value; }
        public string? Apellido
        {
            get => apellido; set
            {
                apellido = value;
                OnPropertyChanged("ApellidoCompleto");
            }
        }
        public string? NombreCompleto
        {
            get => $"{Nombre} {Apellido}";
            set { }
        }

        public event PropertyChangedEventHandler? PropertyChanged;


        private void OnPropertyChanged(string propertyName)
        {
            
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
