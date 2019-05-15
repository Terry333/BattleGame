using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Media;
using System.Diagnostics;
using BattleGame.Classes;
using BattleGame.Enums;


namespace BattleGame.UI
{
    class MapFrame : ScrollViewer
    {
        private int xLength;
        private int yLength;
        public MapSpace[,] MapSpaceGrid;
        private OutputFrame output;
        public Button[,] ButtonGrid;
        private Canvas canvas;

        public MapFrame(string locationFile, OutputFrame output)
        {
            string mapInputData = System.IO.File.ReadAllText(@locationFile);

            string[] mapSections = mapInputData.Split('-');

            string[] mapDimensions = mapSections[0].Split(';');

            int X = int.Parse(mapDimensions[0]);
            int Y = int.Parse(mapDimensions[1]);

            xLength = X;
            yLength = Y;

            this.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;

            canvas = new Canvas();

            canvas.Width = 2700;
            canvas.Height = canvas.Width / X / 0.9 * Y;

            this.Content = canvas;

            this.output = output;
            MapSpaceGrid = new MapSpace[X,Y];
            ButtonGrid = new Button[X, Y];

            this.KeyDown += MapKeyDown;

            UpdateZoom(1, true, mapSections);        
        }

        private void MapKeyDown(object sender, KeyEventArgs e)
        {
            switch(e.Key)
            {
                case Key.W:
                    ScrollToVerticalOffset(this.VerticalOffset - 30);
                    break;
                case Key.S:
                    ScrollToVerticalOffset(this.VerticalOffset + 30);
                    break;
                case Key.D:
                    ScrollToHorizontalOffset(this.HorizontalOffset + 30);
                    break;
                case Key.A:
                    ScrollToHorizontalOffset(this.HorizontalOffset - 30);
                    break;
                default: break;
            }
        }

        public void UpdateZoom(double percent, Boolean create, string[] mapSections)
        {
            canvas.Width = 2700 * percent;
            canvas.Height = canvas.Width / yLength / 0.9 * xLength;

            string[] townY = { };
            string[] infraY = { };
            string[] forestY = { };
            TerrainTypes[,] terrainMap = { };

            if(create)
            {
                terrainMap = new TerrainTypes[xLength, yLength];

                string[] terrainY = mapSections[1].Split('{');

                for (int i = 0; i < yLength; i++)
                {
                    string[] terrainX = terrainY[i].Split(';');

                    for (int o = 0; o < xLength; o++)
                    {
                        int Value = Convert.ToInt16(terrainX[o]);
                        terrainMap[i, o] = (TerrainTypes) Value;
                    }
                }

                townY = mapSections[2].Split('{');

                infraY = mapSections[3].Split('{');

                forestY = mapSections[4].Split('{');
            }

            Boolean isOdd = true;
            double height = canvas.Height / yLength;
            double width = canvas.Width / xLength;
            double xMod = 0;
            double yMod = 0;

            for (int y = 0; y < yLength; y++)
            {
                isOdd = !isOdd;

                yMod = y * (0.75 * height);

                string[] townX = { };
                string[] infraX = { };
                string[] forestX = { };

                if (create)
                {

                    townX = townY[y].Split(';');

                    infraX = infraY[y].Split(';');

                    forestX = forestY[y].Split(';');
                }

                for (int x = 0; x < xLength; x++)
                {
                    xMod = width * x;
                    if (isOdd)
                    {
                        xMod = xMod + width / 2;
                    }

                    if(create)
                    {
                        MapSpaceGrid[x, y] = new MapSpace(x, y);
                        MapSpaceGrid[x, y].GetButton().Name = "Button" + x.ToString() + y.ToString();
                        ButtonGrid[x, y] = MapSpaceGrid[x, y].GetButton();
                        canvas.Children.Add(ButtonGrid[x, y]);

                        ButtonGrid[x, y].Click += MapSpaceClick;

                        MapSpaceGrid[x, y].TownLevel = Convert.ToInt32(townX[x]);

                        MapSpaceGrid[x, y].SetInfrastructureLevel(Convert.ToInt32(infraX[x]));
                    }
                    

                    ButtonGrid[x, y].Width = width;
                    ButtonGrid[x, y].Height = height;
                    Canvas.SetTop(ButtonGrid[x, y], yMod);
                    Canvas.SetLeft(ButtonGrid[x, y], xMod);
                }
            }
        }

        private MapSpace GetAssociatedMapSpaceFromButton(Button button)
        {
            for(int i = 0; i < xLength; i++)
            {
                for (int o = 0; o < yLength; o++)
                {
                    if(button == ButtonGrid[i,o])
                    {
                        return MapSpaceGrid[i, o];
                    }
                }
            }
            return null;
        }

        public Button[,] GetButtons()
        {
            Button[,] returnArray = new Button[xLength, yLength];
            Canvas canvas = (Canvas)VisualTreeHelper.GetChild(VisualTreeHelper.GetChild(GetVisualChild(0), 1), 0);
            for (int x = 0; x < xLength; x++)
            {
                for (int y = 0; y < yLength; y++)
                {
                    if(x != 0 && y != 0)
                    {
                        returnArray[x, y] = (Button)VisualTreeHelper.GetChild(canvas, x * y);
                    }
                    else
                    {
                        returnArray[x, y] = (Button)VisualTreeHelper.GetChild(canvas, y);
                    }
                    
                }
            }
            return returnArray;
        }

        public TextBlock[,] GetMapTextBlocks()
        {
            TextBlock[,] returnArray = new TextBlock[xLength, yLength];
            Canvas canvas = (Canvas)VisualTreeHelper.GetChild(VisualTreeHelper.GetChild(GetVisualChild(0), 1), 0);
            for (int x = 0; x < xLength; x++)
            {
                for (int y = 0; y < yLength; y++)
                {
                    if (x != 0 && y != 0)
                    {
                        Button button = (Button)VisualTreeHelper.GetChild(canvas, x * y);
                        Grid grid = (Grid) VisualTreeHelper.GetChild(ButtonGrid[y, x], 0);
                        returnArray[x, y] = (TextBlock)VisualTreeHelper.GetChild(grid, 1);
                    }
                    else
                    {
                        Button button = (Button)VisualTreeHelper.GetChild(canvas, y);
                        DependencyObject obj = VisualTreeHelper.GetChild(ButtonGrid[y, x], 0);
                        Grid grid = (Grid)obj;
                        returnArray[x, y] = (TextBlock)VisualTreeHelper.GetChild(grid, 1);
                    }
                }
            }
            return returnArray;
        }

        public void MapSpaceClick(object sender, RoutedEventArgs e)
        {
            MapSpace space = GetAssociatedMapSpaceFromButton((Button) sender);
            output.postMessage(space.X.ToString() + ", " + space.Y.ToString());
            output.postMessage(Enum.GetName(typeof(TerrainTypes), space.TerrainType));
        }
    }
}