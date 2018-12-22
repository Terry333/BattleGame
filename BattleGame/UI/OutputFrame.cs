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

namespace BattleGame.UI
{
    class OutputFrame : ScrollViewer
    {
        private StackPanel stackPanel;

        public OutputFrame()
        {
            this.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;

            stackPanel = new StackPanel();
            stackPanel.HorizontalAlignment = HorizontalAlignment.Left;
            stackPanel.VerticalAlignment = VerticalAlignment.Top;

            this.Content = stackPanel;
        }

        public void postMessage(String message)
        {
            TextBlock block = new TextBlock();
            block.Width = stackPanel.Width;
            block.Height = 25;
            block.Text = message;
            stackPanel.Children.Add(block);
        }

    }
}
