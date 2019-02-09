using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace BattleGame.UI
{
    class MapMouseDetector : Grid
    {
        private MapFrame Map;
        private OutputFrame Output;

        public MapMouseDetector(MapFrame Map, OutputFrame Output)
        {
            this.Map = Map;
            this.Output = Output;

            this.RowDefinitions.Add(new RowDefinition());
            this.RowDefinitions.Add(new RowDefinition());
            this.RowDefinitions.Add(new RowDefinition());
            this.ColumnDefinitions.Add(new ColumnDefinition());
            this.ColumnDefinitions.Add(new ColumnDefinition());
            this.ColumnDefinitions.Add(new ColumnDefinition());

            Rectangle right = new Rectangle();
            right.Height = 500;
            right.Width = 280;
            SolidColorBrush blueBrush = new SolidColorBrush();
            blueBrush.Color = Colors.Blue;
            right.Fill = blueBrush;
            //right.MouseEnter += RightEnter;
            //right.MouseDown += null;
            //right.IsHitTestVisible = false;

            Grid.SetColumn(right, 2);
            Grid.SetRow(right, 1);

            this.Children.Add(right);
        }

        private void RightEnter(object sender, RoutedEventArgs e)
        {
            Output.postMessage("Entered!");
        }
    }
}
