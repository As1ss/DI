﻿#pragma checksum "..\..\..\AdminVentana.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "EFBDA790FB115B3329EB91462C02FCAA19FA033A"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using InicioSesionUsuario_ALB;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace InicioSesionUsuario_ALB {
    
    
    /// <summary>
    /// AdminVentana
    /// </summary>
    public partial class AdminVentana : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\AdminVentana.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnVolver;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\AdminVentana.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrid;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\AdminVentana.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDesbloquear;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\AdminVentana.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBloquear;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/InicioSesionUsuario-ALB;component/adminventana.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\AdminVentana.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.btnVolver = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\..\AdminVentana.xaml"
            this.btnVolver.Click += new System.Windows.RoutedEventHandler(this.btnVolver_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.dataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.btnDesbloquear = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\AdminVentana.xaml"
            this.btnDesbloquear.Click += new System.Windows.RoutedEventHandler(this.btnDesbloquear_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnBloquear = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\AdminVentana.xaml"
            this.btnBloquear.Click += new System.Windows.RoutedEventHandler(this.btnBloquear_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
