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
using System.IO;
using BattleGame.UI;
using BattleGame.Classes;

namespace BattleGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private OutputFrame output;
        public MainWindow()
        {
            InitializeComponent();

            string locationString = System.IO.Path.GetFullPath(System.IO.Path.Combine(@AppDomain.CurrentDomain.BaseDirectory, @"..\\..\\")) + "GameData\\TestMap.txt";


            Grid grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            Grid rightGrid = new Grid();
            rightGrid.RowDefinitions.Add(new RowDefinition());
            rightGrid.RowDefinitions.Add(new RowDefinition());
            rightGrid.ColumnDefinitions.Add(new ColumnDefinition());
            rightGrid.ColumnDefinitions.Add(new ColumnDefinition());

            Grid.SetRow(rightGrid, 0);
            Grid.SetColumn(rightGrid, 1);

            grid.Children.Add(rightGrid);

            this.output = new OutputFrame();

            Grid.SetRow(output, 1);
            Grid.SetColumn(output, 1);


            rightGrid.Children.Add(output);

            MapFrame map = new MapFrame(locationString, output);
            //MapFrame map = new MapFrame(10,10);

            Grid.SetRow(map, 0);
            Grid.SetColumn(map, 0);
            

            grid.Children.Add(map);

            this.Content = grid;

            output.postMessage("Application started.");
            output.postMessage(locationString);
            
        }

        
    }
}
