﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Proyecto_1EVA_ALB
{
    /// <summary>
    /// Lógica de interacción para ModoDios.xaml
    /// </summary>
    public partial class ModoDios : Page
    {
        MainWindow window;
        public ModoDios(MainWindow window)
        {
            InitializeComponent();
            this.window = window;
        }
    }
}
