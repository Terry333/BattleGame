using System;
using System.Collections.Generic;
using System.Linq;
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
using BattleGame.Classes;
using BattleGame.Classes.TerrainTypes;

namespace BattleGame.UI
{
    class MapControlFrame : Grid
    {
        private MapFrame Map;
        private ScrollBar MapZoom;

        public MapControlFrame(MapFrame Map)
        {
            this.Map = Map;

            this.RowDefinitions.Add(new RowDefinition());
            this.ColumnDefinitions.Add(new ColumnDefinition());

            MapZoom = new ScrollBar();
            MapZoom.Minimum = 0.1;
            MapZoom.Maximum = 1;
            MapZoom.Scroll += ScrollEvent;

            

            Grid.SetRow(MapZoom, 0);
            Grid.SetColumn(MapZoom, 0);

            this.Children.Add(MapZoom);
        }

        private void ScrollEvent(object sender, RoutedEventArgs e)
        {
            Map.UpdateZoom(MapZoom.Value, false, null);
        }
    }
}
