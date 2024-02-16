﻿using System;
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
        public static readonly RoutedUICommand DetallesIncidencia = new RoutedUICommand("DetallesIncidencia", "DetallesIncidencia", typeof(Comandos), new InputGestureCollection()
        {
                new KeyGesture(Key.D,ModifierKeys.Alt)
        });
        public static readonly RoutedUICommand ResolverIncidencia = new RoutedUICommand("ResolverIncidencia", "ResolverIncidencia", typeof(Comandos), new InputGestureCollection()
        {
                new KeyGesture(Key.R,ModifierKeys.Alt)
        });
        public static readonly RoutedUICommand DesbloquearUsuario = new RoutedUICommand("DesbloquearUsuario", "DesbloquearUsuario", typeof(Comandos), new InputGestureCollection()
        {
                new KeyGesture(Key.D,ModifierKeys.Alt)
        });
        public static readonly RoutedUICommand BloquearUsuario = new RoutedUICommand("BloquearUsuario", "BloquearUsuario", typeof(Comandos), new InputGestureCollection()
        {
                new KeyGesture(Key.B,ModifierKeys.Alt)
        });
        public static readonly RoutedUICommand AplazarPrestamo = new RoutedUICommand("AplazarPrestamo", "AplazarPrestamo", typeof(Comandos), new InputGestureCollection()
        {
                new KeyGesture(Key.A,ModifierKeys.Alt)
        });
        public static readonly RoutedUICommand AgregarImagen = new RoutedUICommand("AgregarImagen", "AgregarImagen", typeof(Comandos), new InputGestureCollection()
        {
                new KeyGesture(Key.I,ModifierKeys.Alt)
        });
        public static readonly RoutedUICommand LimpiarCampos = new RoutedUICommand("LimpiarCampos", "LimpiarCampos", typeof(Comandos), new InputGestureCollection()
        {
                new KeyGesture(Key.L,ModifierKeys.Alt)
        });





    }
}