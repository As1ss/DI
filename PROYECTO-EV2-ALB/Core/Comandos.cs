using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PROYECTO_EV2_ALB.Core
{
    public static class Comandos
    {
        public static readonly RoutedUICommand Salir = new RoutedUICommand("Salir","Salir",typeof(Comandos),new InputGestureCollection()
        {
                new KeyGesture(Key.F4, ModifierKeys.Alt)
        });

        public static readonly RoutedUICommand Aceptar = new RoutedUICommand("Aceptar", "Aceptar", typeof(Comandos), new InputGestureCollection()
        {
                new KeyGesture(Key.Enter)
        });

        public static readonly RoutedUICommand AgregarLibro = new RoutedUICommand("AgregarLibro", "AgregarLibro", typeof(Comandos), new InputGestureCollection()
        {
                new KeyGesture(Key.A,ModifierKeys.Alt)
        });
        public static readonly RoutedUICommand ModificarLibro = new RoutedUICommand("ModificarLibro", "ModificarLibro", typeof(Comandos), new InputGestureCollection()
        {
                new KeyGesture(Key.M,ModifierKeys.Alt)
        });
        public static readonly RoutedUICommand EliminarLibro = new RoutedUICommand("EliminarLibro", "EliminarLibro", typeof(Comandos), new InputGestureCollection()
        {
                new KeyGesture(Key.E,ModifierKeys.Alt)
        });
        public static readonly RoutedUICommand EnviarIncidencia = new RoutedUICommand("EnviarIncidencia", "EnviarIncidencia", typeof(Comandos), new InputGestureCollection()
        {
                new KeyGesture(Key.Enter)
        });

        public static readonly RoutedUICommand PedirLibro = new RoutedUICommand("PedirLibro", "PedirLibro", typeof(Comandos), new InputGestureCollection()
        {
                new KeyGesture(Key.Enter)
        });
        public static readonly RoutedUICommand DevolverLibro = new RoutedUICommand("DevolverLibro", "DevolverLibro", typeof(Comandos), new InputGestureCollection()
        {
                new KeyGesture(Key.Enter)
        });


    }
}
