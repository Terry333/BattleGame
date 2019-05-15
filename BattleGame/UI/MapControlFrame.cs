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
using BattleGame.Enums;

namespace BattleGame.UI
{
    class MapControlFrame : Grid
    {
        private MapFrame Map;
        private ScrollBar MapZoom;
        private Button ShowInfrastructure, ShowAgencies, ShowGov, ShowCoords;
        private Boolean InfraShowing = false;
        private Button[,] MapButtonGrid;
        private MapSpace[,] MapGrid;
        private OutputFrame Output;
        private readonly string TextureFolderLocation = System.IO.Path.GetFullPath(System.IO.Path.Combine(@AppDomain.CurrentDomain.BaseDirectory, @"..\\..\\")) + "GameData\\Textures";
        private GovtScreen GovernmentScreen;
        private ComboBox MarketSelector;
        public List<Market> Markets;
        private List<MarketUI> MarketFrames;

        public MapControlFrame(MapFrame Map, OutputFrame Output)
        {
            this.Map = Map;
            this.Output = Output;
            MapGrid = Map.MapSpaceGrid;
            MapButtonGrid = Map.ButtonGrid;

            Markets = new List<Market>();
            MarketFrames = new List<MarketUI>();

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
            

            // Creating the buttons.

            ShowInfrastructure = new Button();
            ShowInfrastructure.Click += InfraClick;

            ShowAgencies = new Button();
            ShowAgencies.Click += AgencyClick;

            ShowCoords = new Button();
            ShowCoords.Click += CoordClick;
            ShowCoords.Content = "Coords";

            ShowGov = new Button();
            ShowGov.Click += GovClick;
            GovernmentScreen = new GovtScreen();

            // Creating the Markets.

            MarketSelector = new ComboBox();

            for(int i = 0; i < Enum.GetNames(typeof(ItemTypes)).Length; i++)
            {
                MarketSelector.Items.Add(((ItemTypes) i).ToString());
                Debug.WriteLine(((ItemTypes)i).ToString());
                Market market = new Market((ItemTypes)i, CurrencyTypes.USD, ((ItemTypes)i).ToString() + " USA");
                ItemTypes type = (ItemTypes)i;
                MarketFrames.Add(new MarketUI(market, (ItemTypes)i));
                Markets.Add(market);
                MarketFrames[i].Hide();
            }

            MarketSelector.SelectionChanged += ItemMarketEvent;

            // Adding items for testing

            MarketUser user = new MarketUser("Campbell Soup");
            Classes.MarketItems.CannedFood cannedFood = new Classes.MarketItems.CannedFood();
            cannedFood.User = user;

            GetProperMarket(ItemTypes.Consumable).ListItem(user, cannedFood);

            // Setting the positions of the UI elements.

            Grid.SetRow(MapZoom, 0);
            Grid.SetColumn(MapZoom, 0);

            Grid.SetRow(ShowInfrastructure, 1);
            Grid.SetColumn(ShowInfrastructure, 0);

            Grid.SetRow(ShowAgencies, 1);
            Grid.SetColumn(ShowAgencies, 1);

            Grid.SetRow(ShowGov, 1);
            Grid.SetColumn(ShowGov, 2);

            Grid.SetRow(ShowCoords, 1);
            Grid.SetColumn(ShowCoords, 3);

            Grid.SetRow(MarketSelector, 1);
            Grid.SetColumn(MarketSelector, 4);

            // Adding the UI elements to the grid.

            this.Children.Add(MapZoom);
            this.Children.Add(ShowInfrastructure);
            this.Children.Add(ShowAgencies);
            this.Children.Add(ShowGov);
            this.Children.Add(MarketSelector);
            this.Children.Add(ShowCoords);

            Button button = (Button)VisualTreeHelper.GetChild(this, 1);
            SetButtonImage(1, TextureFolderLocation + "\\InfrastructureIcon.png");

            button = (Button)VisualTreeHelper.GetChild(this, 2);
            SetButtonImage(2, TextureFolderLocation + "\\EmptyClipboard.png");

            button = (Button)VisualTreeHelper.GetChild(this, 3);
            SetButtonImage(3, TextureFolderLocation + "\\govt.png");

        }

        public Market GetProperMarket(ItemTypes type)
        {
            for (int i = 0; i < Markets.Count; i++)
            {
                Debug.WriteLine(Markets[i].ItemType.ToString());
                Debug.WriteLine(Markets[i].ItemType == type);
                if(Markets[i].ItemType == type)
                {
                    return Markets[i];
                }
            }

            return null;
        }

        private void ScrollEvent(object sender, RoutedEventArgs e)
        {
            Map.UpdateZoom(MapZoom.Value, false, null);
        }

        private void CoordClick(object sender, RoutedEventArgs e)
        {
            TextBlock[,] textGrid = Map.GetMapTextBlocks();
            switch (InfraShowing)
            {
                case (false):
                    InfraShowing = true;

                    for (int y = 0; y < textGrid.GetLength(0); y++)
                    {
                        for (int x = 0; x < textGrid.GetLength(1); x++)
                        {
                            textGrid[y, x].Text = x.ToString() + "," + y.ToString();
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

        private void ItemMarketEvent(object sender, RoutedEventArgs e)
        {
            ItemTypes type = (ItemTypes) Enum.Parse(typeof(ItemTypes), (string) ((ComboBox) sender).SelectedValue, true);
            MarketFrames[(int)type].Show();
        }

        private void SetButtonImage(int index, string imagePath)
        {
            Button button = (Button)GetVisualChild(index);
            Debug.WriteLine(VisualTreeHelper.GetChildrenCount(button).ToString());
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(button); i++)
            {
                Debug.WriteLine(i.ToString() + ";    " + VisualTreeHelper.GetChild(this, i));
            }

            Image img = new Image();

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(imagePath);
            bitmap.EndInit();
            bitmap.DecodePixelWidth = bitmap.PixelWidth;
            bitmap.DecodePixelHeight = bitmap.PixelHeight;

            img.Source = bitmap;
            button.Content = img;
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

        private void AgencyClick(object sender, RoutedEventArgs e)
        {

        }

        private void GovClick(object sender, RoutedEventArgs e)
        {
            if(GovernmentScreen.IsVisible == true)
            {
                GovernmentScreen.Hide();
            }
            else
            {
                GovernmentScreen.Show();
            }
        }
    }
}
