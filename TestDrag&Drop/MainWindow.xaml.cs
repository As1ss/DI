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

namespace TestDrag_Drop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static bool isRedSelected;
        static bool isBlueSelected;
        static Point rPosition;
        static Point bPosition;
        public MainWindow()
        {
            InitializeComponent();
            rPosition = new Point(Canvas.GetLeft(redRectangle), Canvas.GetTop(redRectangle));
            bPosition = new Point(Canvas.GetLeft(blueRectangle),Canvas.GetTop(blueRectangle));
        }

        private void isColliding()
        {
            if (rPosition.X < bPosition.X + blueRectangle.Width &&
                rPosition.X + redRectangle.Width > bPosition.X &&
                rPosition.Y < bPosition.Y + blueRectangle.Height &&
                rPosition.Y + redRectangle.Height > bPosition.Y)
            {
                MessageBox.Show("Colisión");
            }
        }

        private void RedRectangle_MouseMove(object sender, MouseEventArgs e)
        {
            
            if(e.LeftButton== MouseButtonState.Pressed)
            {
                rPosition = e.GetPosition(canvas);
                Canvas.SetTop(redRectangle, rPosition.Y);
                Canvas.SetLeft(redRectangle, rPosition.X);
                isBlueSelected = false;
                isRedSelected = true;
                DragDrop.DoDragDrop(redRectangle,redRectangle, DragDropEffects.Move);
                isColliding();
            }
            
        }

        private void canvas_Drop(object sender, DragEventArgs e)
        {
            if (isRedSelected)
            {
                rPosition = e.GetPosition(canvas);
                Canvas.SetTop(redRectangle, rPosition.Y);
                Canvas.SetLeft(redRectangle, rPosition.X);
            }
            if (isBlueSelected)
            {
                bPosition = e.GetPosition(canvas);
                Canvas.SetTop(blueRectangle, bPosition.Y);
                Canvas.SetLeft(blueRectangle, bPosition.X);
            }
        }

        private void canvas_DragOver(object sender, DragEventArgs e)
        {
            if (isRedSelected)
            {
                rPosition = e.GetPosition(canvas);
                Canvas.SetTop(redRectangle, rPosition.Y);
                Canvas.SetLeft(redRectangle, rPosition.X);
            }
            if (isBlueSelected)
            {
                bPosition = e.GetPosition(canvas);
                Canvas.SetTop(blueRectangle, bPosition.Y);
                Canvas.SetLeft(blueRectangle, bPosition.X);
            }
        }

        private void blueRectangle_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                bPosition = e.GetPosition(canvas);
                Canvas.SetTop(blueRectangle, bPosition.Y);
                Canvas.SetLeft(blueRectangle, bPosition.X);
                isRedSelected = false;
                isBlueSelected = true;
                DragDrop.DoDragDrop(blueRectangle, blueRectangle, DragDropEffects.Move);
                isColliding();
            }
        }
    }
}
