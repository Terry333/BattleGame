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
    class MapFrame : Canvas
    {
        int xLength;
        int yLength;
        MapSpace[,] mapSpaceGrid;
        OutputFrame output;
        Button[,] buttonGrid;

        public MapFrame(string locationFile, OutputFrame output)
        {
            this.Height = 1000;
            this.Width = 900;

            this.output = output;
            string mapInputData = System.IO.File.ReadAllText(@locationFile);

            string[] mapSections = mapInputData.Split('-');

            string[] mapDimensions = mapSections[0].Split(';');                     

            int X = int.Parse(mapDimensions[0]);
            int Y = int.Parse(mapDimensions[1]);

            xLength = X;
            yLength = Y;

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
            buttonGrid = new Button[X, Y];

            Boolean isOdd = true;
            double height = this.Height / yLength;
            double width = this.Width / xLength;
            double xMod = 0;
            double yMod = 0;
            Debug.WriteLine("Height " + this.Height.ToString() + ", Width" + this.Width.ToString());

            for (int y = 0; y < Y; y++)
            {
                isOdd = !isOdd;

                yMod = y * (0.75 * height);

                for (int x = 0; x < X; x++)
                {
                    xMod = width * x;
                    if(isOdd)
                    {
                        xMod = xMod + width / 2;
                    }

                    mapSpaceGrid[x, y] = new MapSpace(x,y, terrainMap[x,y]);
                    buttonGrid[x, y] = mapSpaceGrid[x, y].GetButton();

                    
                    mapSpaceGrid[x, y].GetButton().Width = width;
                    mapSpaceGrid[x, y].GetButton().Height = height;

                    Debug.WriteLine(xMod.ToString() + ", " + yMod.ToString());

                    this.Children.Add(mapSpaceGrid[x, y].GetButton());

                    Canvas.SetBottom(buttonGrid[x, y], yMod);
                    Canvas.SetLeft(buttonGrid[x, y], xMod);
                    mapSpaceGrid[x, y].GetButton().Click += MapSpaceClick;
                }
            }
        }

        public MapSpace getMapSpaceFromMapGrid(int x, int y)
        {
            return mapSpaceGrid[y, x];
        }

        private MapSpace GetAssociatedMapSpaceFromButton(Button button)
        {
            for(int i = 0; i < xLength; i++)
            {
                for (int o = 0; o < yLength; o++)
                {
                    if(button == buttonGrid[i,o])
                    {
                        return mapSpaceGrid[i, o];
                    }
                }
            }
            return null;
        }

        public void MapSpaceClick(object sender, RoutedEventArgs e)
        {
            MapSpace space = GetAssociatedMapSpaceFromButton((Button) sender);
            output.postMessage(space.getX().ToString() + ", " + space.getY().ToString());
            output.postMessage(space.getTerrainType().getTerrainName());
        }
    }
}
