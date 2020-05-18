using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AtomTools_Navisworks.View;
using AtomTools_Navisworks.ViewModel;
using Autodesk.Navisworks.Api.Plugins;
using Autodesk.Windows;

namespace AtomTools_Navisworks
{
    [Plugin("AtomTools_Navisworks", "ASE", DisplayName = "AtomTools")]
    [RibbonLayout("AtomTools_Navisworks.xaml")]
    [RibbonTab("AtomTools", DisplayName = "AtomTools")]
    [Command("ID_Button_1", CanToggle = true, DisplayName = "MAIN MENU", Icon = "Logo.png", LargeIcon = "Logo_large.png", ToolTip = "Main menu for plugins")]

    public class Command : CommandHandlerPlugin
    {
        public static MainWindow MainWindow { get; private set; }

        public override int ExecuteCommand(string name, params string[] parameters)
        {
            try
            {
                if (MainWindow == null)
                {
                    MainWindowViewModel mvvm = new MainWindowViewModel();
                    MainWindow = new MainWindow { DataContext = mvvm };
                    MainWindow.Closed += (sender, args) => MainWindow = null;
                    MainWindow.ShowDialog();
                }
                else
                {
                    MainWindow.Activate();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Navisworks error");
            }
            return 0;
        }
    }
}

