﻿#pragma checksum "..\..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9B20CA1A34D45C3736628B80D4DDF6E9FE8311E0"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Practica2_Alexis_Lopez_Briongos;
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


namespace Practica2_Alexis_Lopez_Briongos {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 84 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textEmail;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textNombre;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textApellido;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textDNI;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datePicker;
        
        #line default
        #line hidden
        
        
        #line 142 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonConfirm;
        
        #line default
        #line hidden
        
        
        #line 155 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cancelButton;
        
        #line default
        #line hidden
        
        
        #line 168 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSalir;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Practica2_Alexis-Lopez-Briongos;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 6 "..\..\..\MainWindow.xaml"
            ((Practica2_Alexis_Lopez_Briongos.MainWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.textEmail = ((System.Windows.Controls.TextBox)(target));
            
            #line 87 "..\..\..\MainWindow.xaml"
            this.textEmail.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.textEmail_MouseDoubleClick);
            
            #line default
            #line hidden
            
            #line 88 "..\..\..\MainWindow.xaml"
            this.textEmail.MouseLeave += new System.Windows.Input.MouseEventHandler(this.textEmail_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 3:
            this.textNombre = ((System.Windows.Controls.TextBox)(target));
            
            #line 93 "..\..\..\MainWindow.xaml"
            this.textNombre.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.textNombre_MouseDoubleClick);
            
            #line default
            #line hidden
            
            #line 94 "..\..\..\MainWindow.xaml"
            this.textNombre.MouseLeave += new System.Windows.Input.MouseEventHandler(this.textNombre_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 4:
            this.textApellido = ((System.Windows.Controls.TextBox)(target));
            
            #line 102 "..\..\..\MainWindow.xaml"
            this.textApellido.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.textApellido_MouseDoubleClick);
            
            #line default
            #line hidden
            
            #line 103 "..\..\..\MainWindow.xaml"
            this.textApellido.MouseLeave += new System.Windows.Input.MouseEventHandler(this.textApellido_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 5:
            this.textDNI = ((System.Windows.Controls.TextBox)(target));
            
            #line 119 "..\..\..\MainWindow.xaml"
            this.textDNI.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.textDNI_MouseDoubleClick);
            
            #line default
            #line hidden
            
            #line 120 "..\..\..\MainWindow.xaml"
            this.textDNI.MouseLeave += new System.Windows.Input.MouseEventHandler(this.textDNI_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 6:
            this.datePicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            this.buttonConfirm = ((System.Windows.Controls.Button)(target));
            
            #line 147 "..\..\..\MainWindow.xaml"
            this.buttonConfirm.Click += new System.Windows.RoutedEventHandler(this.buttonConfirm_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.cancelButton = ((System.Windows.Controls.Button)(target));
            
            #line 157 "..\..\..\MainWindow.xaml"
            this.cancelButton.Click += new System.Windows.RoutedEventHandler(this.cancelButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnSalir = ((System.Windows.Controls.Button)(target));
            
            #line 168 "..\..\..\MainWindow.xaml"
            this.btnSalir.Click += new System.Windows.RoutedEventHandler(this.btnSalir_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

