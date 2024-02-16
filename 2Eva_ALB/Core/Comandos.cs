using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _2Eva_ALB.Core
{
    public static class Comandos
    {
        public static readonly RoutedUICommand Buscar = new RoutedUICommand("Buscar", "Buscar", typeof(Comandos), new InputGestureCollection()
        {
                new KeyGesture(Key.B, ModifierKeys.Control)
        });

        public static readonly RoutedUICommand Guardar = new RoutedUICommand("Guardar", "Guardar", typeof(Comandos), new InputGestureCollection()
        {
                new KeyGesture(Key.G,ModifierKeys.Control)
        });

        public static readonly RoutedUICommand Limpiar = new RoutedUICommand("Limpiar", "Limpiar", typeof(Comandos), new InputGestureCollection()
        {
                new KeyGesture(Key.L,ModifierKeys.Control)
        });
    }
}
