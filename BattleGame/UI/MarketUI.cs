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
using BattleGame.Enums;
using BattleGame.Classes;

namespace BattleGame.UI
{
    public class MarketUI : Window
    {
        private Grid Grid;
        public Market Market;
        public Label LRAS, AD, SRAS, PL, RGDP;
        public ItemTypes Type;

        public MarketUI(Market market, ItemTypes type)
        {
            Market = market;
            Market.Ui = this;
            Title = Market.Name;
            Type = type;
            Width = 600;
            Height = 400;

            Grid = new Grid();
            AddChild(Grid);
            Grid.ColumnDefinitions.Add(new ColumnDefinition());
            Grid.ColumnDefinitions.Add(new ColumnDefinition());
            Grid.ColumnDefinitions.Add(new ColumnDefinition());
            Grid.ColumnDefinitions.Add(new ColumnDefinition());
            Grid.ColumnDefinitions.Add(new ColumnDefinition());
            Grid.RowDefinitions.Add(new RowDefinition());
            Grid.RowDefinitions.Add(new RowDefinition());

            LRAS = new Label();
            Label LRASLabel = new Label();
            LRASLabel.Content = "LRAS";
            Grid.SetColumn(LRASLabel, 0);
            Grid.SetRow(LRASLabel, 0);
            Grid.SetColumn(LRAS, 0);
            Grid.SetRow(LRAS, 1);

            SRAS = new Label();
            Label SRASLabel = new Label();
            SRASLabel.Content = "SRAS";
            Grid.SetColumn(SRASLabel, 1);
            Grid.SetRow(SRASLabel, 0);
            Grid.SetColumn(SRAS, 1);
            Grid.SetRow(SRAS, 1);

            AD = new Label();
            Label ADLabel = new Label();
            ADLabel.Content = "AD";
            Grid.SetColumn(ADLabel, 2);
            Grid.SetRow(ADLabel, 0);
            Grid.SetColumn(AD, 2);
            Grid.SetRow(AD, 1);

            PL = new Label();
            Label PLLabel = new Label();
            PLLabel.Content = "PL";
            Grid.SetColumn(PLLabel, 3);
            Grid.SetRow(PLLabel, 0);
            Grid.SetColumn(PL, 3);
            Grid.SetRow(PL, 1);

            RGDP = new Label();
            Label RGDPLabel = new Label();
            RGDPLabel.Content = "RGDP";
            Grid.SetColumn(RGDPLabel, 4);
            Grid.SetRow(RGDPLabel, 0);
            Grid.SetColumn(RGDP, 4);
            Grid.SetRow(RGDP, 1);

            Grid.Children.Add(LRAS);
            Grid.Children.Add(SRAS);
            Grid.Children.Add(AD);
            Grid.Children.Add(PL);
            Grid.Children.Add(RGDP);
            Grid.Children.Add(LRASLabel);
            Grid.Children.Add(SRASLabel);
            Grid.Children.Add(ADLabel);
            Grid.Children.Add(PLLabel);
            Grid.Children.Add(RGDPLabel);
        }

        public void AddItem(MarketItem item)
        {
            
        }

        public void UpdateUI()
        {
            PL.Content = Market.PriceLevel;
        }


    }
}
