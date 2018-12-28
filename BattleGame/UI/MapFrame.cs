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
using System.Diagnostics;
using BattleGame.Classes;
using BattleGame.Classes.TerrainTypes;


namespace BattleGame.UI
{
    class MapFrame : Grid
    {
        MapSpace[,] mapSpaceGrid;
        OutputFrame output;

        public MapFrame(string locationFile, OutputFrame output)
        {
            this.output = output;
            string mapInputData = System.IO.File.ReadAllText(@locationFile);

            string[] mapSections = mapInputData.Split('-');

            string[] mapDimensions = mapSections[0].Split(';');                     

            int X = int.Parse(mapDimensions[0]);
            int Y = int.Parse(mapDimensions[1]);

            Terrain[,] terrainMap = new Terrain[X, Y];

            string[] terrainY = mapSections[1].Split('{');

            for(int i = 0; i < Y; i++)
            {
                string[] terrainX = terrainY[i].Split(';');

                Debug.WriteLine(terrainX.Length.ToString());

                for(int o = 0; o < X; o++)
                {
                    switch (terrainX[o])
                    {
                        case "p":
                            terrainMap[i, o] = new Plains();
                            break;
                        case "h":
                            terrainMap[i, o] = new Hills();
                            break;
                        case "ma":
                            terrainMap[i, o] = new Marsh();
                            break;
                        default:
                            terrainMap[i, o] = new Plains();
                            break;
                    }
                }
            }

            mapSpaceGrid = new MapSpace[X,Y];

            for(int i = 0; i < Y; i++)
            {
                this.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int i = 0; i < X; i++)
            {
                this.RowDefinitions.Add(new RowDefinition());
            }

            for (int y = 0; y < Y; y++)
            {
                for (int x = 0; x < X; x++)
                {
                    
                    mapSpaceGrid[x, y] = new MapSpace(x,y, terrainMap[x,y]);
                    

                    Grid.SetRow(mapSpaceGrid[x,y], x);
                    Grid.SetColumn(mapSpaceGrid[x, y], y);

                    mapSpaceGrid[x, y].Width = this.Width / X;
                    mapSpaceGrid[x, y].Height = this.Height / Y;

                    this.Children.Add(mapSpaceGrid[x, y]);

                    mapSpaceGrid[x, y].Click += MapSpaceClick;
                }
            }
        }

        public MapSpace getMapSpaceFromMapGrid(int x, int y)
        {
            return mapSpaceGrid[y, x];
        }

        public void MapSpaceClick(object sender, RoutedEventArgs e)
        {
            MapSpace actualSender = (MapSpace)sender;
            output.postMessage(actualSender.getX().ToString() + ", " + actualSender.getY().ToString());
            output.postMessage(actualSender.getTerrainType().getTerrainName());
        }
    }
}
