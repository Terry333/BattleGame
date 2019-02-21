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
using System.Diagnostics;
using System.Threading;
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
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            InitializeComponent();

            string locationString = System.IO.Path.GetFullPath(System.IO.Path.Combine(@AppDomain.CurrentDomain.BaseDirectory, @"..\\..\\")) + "GameData\\TestMap.txt";

            Grid grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            Grid leftGrid = new Grid();
            leftGrid.RowDefinitions.Add(new RowDefinition());
            leftGrid.RowDefinitions.Add(new RowDefinition());
            leftGrid.ColumnDefinitions.Add(new ColumnDefinition());

            Grid rightGrid = new Grid();
            rightGrid.RowDefinitions.Add(new RowDefinition());
            rightGrid.RowDefinitions.Add(new RowDefinition());
            rightGrid.ColumnDefinitions.Add(new ColumnDefinition());
            rightGrid.ColumnDefinitions.Add(new ColumnDefinition());

            Grid.SetRow(leftGrid, 0);
            Grid.SetColumn(leftGrid, 0);

            Grid.SetRow(rightGrid, 0);
            Grid.SetColumn(rightGrid, 1);

            grid.Children.Add(rightGrid);
            grid.Children.Add(leftGrid);

            InfoControl info = new InfoControl();

            TabControl tabCtrl = info.TabCtrl;

            Grid.SetRow(tabCtrl, 1);
            Grid.SetColumn(tabCtrl, 1);

            rightGrid.Children.Add(tabCtrl);

            this.output = info.Output;

            //Grid.SetRow(output, 1);
            //Grid.SetColumn(output, 1);

            //rightGrid.Children.Add(output);

            MapFrame map = new MapFrame(locationString, output);
            Grid.SetRow(map, 1);
            Grid.SetColumn(map, 0);

            leftGrid.Children.Add(map);

            this.Content = grid;

            stopWatch.Stop();

            long ts = stopWatch.ElapsedMilliseconds;

            output.postMessage("Application started.");
            output.postMessage(locationString);
            output.postMessage(map.ActualWidth.ToString());
            output.postMessage(map.ActualHeight.ToString());
            output.postMessage("Took " + ts.ToString() + " MS to start.");

            MapControlFrame mapControl = new MapControlFrame(map, output);

            Grid.SetRow(mapControl, 0);
            Grid.SetColumn(mapControl, 0);

            leftGrid.Children.Add(mapControl);
        }
    }
}
