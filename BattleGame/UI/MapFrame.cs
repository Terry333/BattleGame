﻿using System;
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
using System.Diagnostics;
using BattleGame.Classes;
using BattleGame.Classes.TerrainTypes;


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
        private double widthToHeightRatio = 0.9;

        private Boolean WDown = false;
        private Boolean ADown = false;
        private Boolean SDown = false;
        private Boolean DDown = false;

        private System.Threading.Tasks.Task<int> time;

        public MapFrame(string locationFile, OutputFrame output)
        {
            this.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;

            canvas = new Canvas();

            canvas.Height = 3000;
            canvas.Width = 2700;

            this.Content = canvas;

            this.output = output;
            string mapInputData = System.IO.File.ReadAllText(@locationFile);

            string[] mapSections = mapInputData.Split('-');

            string[] mapDimensions = mapSections[0].Split(';');                     

            int X = int.Parse(mapDimensions[0]);
            int Y = int.Parse(mapDimensions[1]);

            xLength = X;
            yLength = Y;

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
            canvas.Height = 3000 * percent;
            canvas.Width = canvas.Height * widthToHeightRatio;

            string[] townY = { };
            string[] infraY = { };
            Terrain[,] terrainMap = { };

            if(create)
            {
                terrainMap = new Terrain[xLength, yLength];

                string[] terrainY = mapSections[1].Split('{');

                for (int i = 0; i < yLength; i++)
                {
                    string[] terrainX = terrainY[i].Split(';');

                    for (int o = 0; o < xLength; o++)
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
