using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Serialization;
using AtomTools_Navisworks.Abstraction;
using AtomTools_Navisworks.Model;
using AtomTools_Navisworks.View;
using Microsoft.Win32;

namespace AtomTools_Navisworks.ViewModel
{
    public class MainWindowViewModel : ModelBase
    {
        public MainWindowViewModel()
        {
            ImportXml();
        }
        private ObservableCollection<PluginData> _pluginCollection;
        public ObservableCollection<PluginData> PluginCollection
        {
            get => _pluginCollection;
            set
            {
                _pluginCollection = value;
                OnPropertyChanged(nameof(PluginCollection));
            }
        }

        //public ICommand OkCommand => new RelayCommandWithoutParameter(ImportXml);

        private void ImportXml()
        {
            string path = @"D:/004_Desktop/PLUGINS";
            XmlStreamer streamer = new XmlStreamer();
            var col = streamer.ImportSettings(path);
            PluginCollection = col;
        }


    }
}
