using System;
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
using BattleGame.Classes;
using BattleGame.Classes.TerrainTypes;


namespace BattleGame.UI
{
    class MapFrame : Grid
    {
        MapSpace[,] mapSpaceGrid;

        public MapFrame(int X, int Y)
        {
            mapSpaceGrid = new MapSpace[Y,X];

            for(int i = 0; i < X; i++)
            {
                this.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int i = 0; i < Y; i++)
            {
                this.RowDefinitions.Add(new RowDefinition());
            }

            for (int x = 0; x < X; x++)
            {
                for (int y = 0; y < Y; y++)
                {
                    mapSpaceGrid[x, y] = new MapSpace(x,y,new Plains());
                    Grid.SetRow(mapSpaceGrid[x,y], y);
                    Grid.SetColumn(mapSpaceGrid[x, y], x);

                    mapSpaceGrid[x, y].Width = this.Width / X;
                    mapSpaceGrid[x, y].Height = this.Height / Y;

                    this.Children.Add(mapSpaceGrid[x, y]);
                }
            }
        }

        public MapSpace getMapSpaceFromMapGrid(int x, int y)
        {
            return mapSpaceGrid[x, y];
        }
    }
}
