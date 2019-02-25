﻿using System;
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

namespace BattleGame.UI
{
    class MapControlFrame : Grid
    {
        private MapFrame Map;
        private ScrollBar MapZoom;
        private Button ShowInfrastructure;
        private Boolean InfraShowing = false;
        private Button[,] MapButtonGrid;
        private MapSpace[,] MapGrid;
        private OutputFrame Output;
        private readonly string TextureFolderLocation = System.IO.Path.GetFullPath(System.IO.Path.Combine(@AppDomain.CurrentDomain.BaseDirectory, @"..\\..\\")) + "GameData\\Textures";

        public MapControlFrame(MapFrame Map, OutputFrame Output)
        {
            this.Map = Map;
            this.Output = Output;
            MapGrid = Map.MapSpaceGrid;
            MapButtonGrid = Map.ButtonGrid;

            // Setting columns and rows in the grid.

            this.ColumnDefinitions.Add(new ColumnDefinition());
            this.ColumnDefinitions.Add(new ColumnDefinition());
            this.ColumnDefinitions.Add(new ColumnDefinition());
            this.ColumnDefinitions.Add(new ColumnDefinition());
            this.RowDefinitions.Add(new RowDefinition());
            this.RowDefinitions.Add(new RowDefinition());
            this.RowDefinitions.Add(new RowDefinition());
            //this.RowDefinitions.Add(new RowDefinition());
            //this.RowDefinitions.Add(new RowDefinition());
            this.ColumnDefinitions.Add(new ColumnDefinition());
            this.RowDefinitions.Add(new RowDefinition());
            
            // Creating the map zoom scroll bar.

            MapZoom = new ScrollBar();
            MapZoom.Minimum = 0.1;
            MapZoom.Maximum = 1;
            MapZoom.Scroll += ScrollEvent;
            MapZoom.Orientation = Orientation.Horizontal;
            MapZoom.Value = 1;
            

            // Creating the show infrastructure button.

            ShowInfrastructure = new Button();
            ShowInfrastructure.Click += InfraClick;

            // Setting the positions of the UI elements.

            Grid.SetRow(MapZoom, 0);
            Grid.SetColumn(MapZoom, 0);

            Grid.SetRow(ShowInfrastructure, 1);
            Grid.SetColumn(ShowInfrastructure, 0);
            
            // Adding the UI elements to the grid.

            this.Children.Add(MapZoom);
            this.Children.Add(ShowInfrastructure);

            Button button = (Button)VisualTreeHelper.GetChild(this, 1);
            SetButtonImage(1, TextureFolderLocation + "\\InfrastructureIcon.png");
        }

        private void ScrollEvent(object sender, RoutedEventArgs e)
        {
            Map.UpdateZoom(MapZoom.Value, false, null);
        }

        private void SetButtonImage(int index, string imagePath)
        {
            Button button = (Button)GetVisualChild(index);
            Debug.WriteLine(VisualTreeHelper.GetChildrenCount(button).ToString());
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(button); i++)
            {
                Debug.WriteLine(i.ToString() + ";    " + VisualTreeHelper.GetChild(button, i));
            }

            Image img = new Image();
            img.Loaded += ImageLoaded;

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.DecodePixelWidth = 200;
            bitmap.DecodePixelHeight = 200;
            bitmap.UriSource = new Uri(TextureFolderLocation + "\\InfrastructureIcon.png");
            bitmap.EndInit();

            img.Source = bitmap;
            button.Content = img;
        }

        private void ImageLoaded(object sender, RoutedEventArgs e)
        {

        }

        private void InfraClick(object sender, RoutedEventArgs e)
        {
            TextBlock[,] textGrid = Map.GetMapTextBlocks();
            switch (InfraShowing)
            {
                case (false):
                    InfraShowing = true;
                    
                    for(int y = 0; y < textGrid.GetLength(0); y++)
                    {
                        for(int x = 0; x < textGrid.GetLength(1); x++)
                        {
                            textGrid[y, x].Text = MapGrid[y, x].FunctioningInfrastructure.ToString() + "/" + MapGrid[y, x].InfrastructureLevel.ToString();
                        }
                    } 
                    break;
                default:

                    for (int y = 0; y < textGrid.GetLength(0); y++)
                    {
                        for (int x = 0; x < textGrid.GetLength(1); x++)
                        {
                            textGrid[y, x].Text = "";
                        }
                    }
                    InfraShowing = false;
                    break;
            }
        }
    }
}
