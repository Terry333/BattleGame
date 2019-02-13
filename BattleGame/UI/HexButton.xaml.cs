using System.Windows.Controls;

namespace BattleGame.UI
{
    /// <summary>
    /// Interaction logic for HexButton.xaml
    /// </summary>
    public partial class HexButton : Page
    {

        public HexButton()
        {
            InitializeComponent();
        }

        public Button GetButton()
        {
            this.RemoveLogicalChild(this.Button);
            return (Button)this.Button;
        }
    }
}
