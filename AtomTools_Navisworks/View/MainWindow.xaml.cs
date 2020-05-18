using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using AtomTools_Navisworks.Abstraction;

namespace AtomTools_Navisworks.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, ICloseable
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        void ShowHideDetails(object sender, RoutedEventArgs e)
        {
            for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
                if (vis is DataGridRow)
                {
                    var row = (DataGridRow)vis;
                    row.DetailsVisibility =
                        row.DetailsVisibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;

                    break;
                }
        }
    }
}
