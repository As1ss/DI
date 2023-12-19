using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TestCommandBindings
{
    public static class WPFComandos
    {
        public static readonly RoutedUICommand Salir =
             new RoutedUICommand(
                 "Salir",
                 "Salir",
                 typeof(WPFComandos),
                 new InputGestureCollection { new KeyGesture(Key.F4, ModifierKeys.Control) }
             );


        public static readonly RoutedUICommand MostrarNotificacion =
            new RoutedUICommand(
                "MostarNotificacion", "MostrarNotificacion", typeof(WPFComandos), new InputGestureCollection { new KeyGesture(Key.T, ModifierKeys.Control) });
    }
}
