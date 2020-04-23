using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Autodesk.Navisworks.Api.Plugins;

namespace AtomTools_Navisworks
{
    [Plugin("AtomTools_Navisworks", "ASE", DisplayName = "AtomTools")]
    [RibbonLayout("AtomTools_Navisworks.xaml")]
    [RibbonTab("AtomTools", DisplayName = "AtomTools")]

    [Command("ID_Button_1", CanToggle = true, DisplayName = "MENU", Icon = "CopyParameters_64.png", ToolTip = "Main menu for plugins")]

    public class Command : CommandHandlerPlugin
    {

        public override int ExecuteCommand(string name, params string[] parameters)
        {
            MessageBox.Show("s");
            return 0;
        }
    }
}
