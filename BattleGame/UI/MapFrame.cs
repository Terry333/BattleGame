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


namespace BattleGame.UI
{
    class MapFrame : ScrollViewer
    {
        private int xLength;
        private int yLength;
        private MapSpace[,] mapSpaceGrid;
        private OutputFrame output;
        private Button[,] buttonGrid;
        private Canvas canvas;

        private System.Threading.Tasks.Task<int> time;

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
            mapSpaceGrid = new MapSpace[X,Y];
            buttonGrid = new Button[X, Y];

            this.KeyDown += MapKeyDown;

            UpdateZoom(1, true, mapSections);

            CancellationTokenSource source = new CancellationTokenSource();

            time = Task.Run(async delegate
            {
                await Task.Delay(TimeSpan.FromSeconds(1/30));
                return 42;
            });
            source.Cancel();

            
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
            object[,] terrainMap = { };

            if(create)
            {
                terrainMap = new object[xLength, yLength];

                string[] terrainY = mapSections[1].Split('{');

                for (int i = 0; i < yLength; i++)
                {
                    string[] terrainX = terrainY[i].Split(';');

                    for (int o = 0; o < xLength; o++)
                    {
                        switch (terrainX[o])
                        {
                            case "p":
                                terrainMap[i, o] = Terrain.Plains();
                                break;
                            case "h":
                                terrainMap[i, o] = Terrain.Plains;
                                break;
                            case "ma":
                                terrainMap[i, o] = Terrain.Plains;
                                break;
                            default:
                                terrainMap[i, o] = Terrain.Plains;
                                break;
                        }
                    }
                }

                townY = mapSections[2].Split('{');

                infraY = mapSections[3].Split('{');
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

                if (create)
                {

                    townX = townY[y].Split(';');

                    infraX = infraY[y].Split(';');
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
                        mapSpaceGrid[x, y] = new MapSpace(x, y, terrainMap[x, y]);
                        mapSpaceGrid[x, y].GetButton().Name = "Button" + x.ToString() + y.ToString();
                        buttonGrid[x, y] = mapSpaceGrid[x, y].GetButton();
                        canvas.Children.Add(buttonGrid[x, y]);

                        buttonGrid[x, y].Click += MapSpaceClick;

                        Debug.WriteLine("Town level " + townX[x]);

                        mapSpaceGrid[x, y].SetTownLevel(Convert.ToInt32(townX[x]));

                        mapSpaceGrid[x, y].SetInfrastructureLevel(Convert.ToInt32(infraX[x]));
                    }
                    

                    buttonGrid[x, y].Width = width;
                    buttonGrid[x, y].Height = height;
                    Canvas.SetTop(buttonGrid[x, y], yMod);
                    Canvas.SetLeft(buttonGrid[x, y], xMod);
                }
            }
        }

        public MapSpace GetMapSpaceFromMapGrid(int x, int y)
        {
            return mapSpaceGrid[y, x];
        }

        public Button[,] GetButtonGrid()
        {
            return buttonGrid;
        }

        public MapSpace[,] GetMapGrid()
        {
            return mapSpaceGrid;
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
                        DependencyObject obj = VisualTreeHelper.GetChild(buttonGrid[y, x], 0);
                        Grid grid = (Grid)obj;
                        returnArray[x, y] = (TextBlock)VisualTreeHelper.GetChild(grid, 1);
                    }
                    else
                    {
                        Button button = (Button)VisualTreeHelper.GetChild(canvas, y);
                        DependencyObject obj = VisualTreeHelper.GetChild(buttonGrid[y, x], 0);
                        Grid grid = (Grid)obj;
                        returnArray[x, y] = (TextBlock)VisualTreeHelper.GetChild(grid, 1);
                    }

                }
            }
            return returnArray;
        }

        public void ChangeAllSpaceText(string newText)
        {
            Canvas canvas = (Canvas) VisualTreeHelper.GetChild(VisualTreeHelper.GetChild(GetVisualChild(0), 1), 0);
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(canvas); i++)
            {
                Button button = (Button)VisualTreeHelper.GetChild(canvas, i);
                Grid grid = (Grid)VisualTreeHelper.GetChild(button, 0);
                TextBlock block = (TextBlock)VisualTreeHelper.GetChild(grid, 1);
                block.Text = newText;
            }
        }

        public void MapSpaceClick(object sender, RoutedEventArgs e)
        {
            MapSpace space = GetAssociatedMapSpaceFromButton((Button) sender);
            output.postMessage(space.getX().ToString() + ", " + space.getY().ToString());
            output.postMessage(space.getTerrainType().);
        }
    }
}
