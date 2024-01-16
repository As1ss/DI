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

       
    }
}
