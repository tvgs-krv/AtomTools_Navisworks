using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Xml.Serialization;
using Microsoft.Win32;

namespace AtomTools_Navisworks.Model
{
    class XmlStreamer
    {
        public void ExportSettings(ObservableCollection<PluginData> collection)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML files(*.xml)|*.xml|All files(*.*)|*.*";
            saveFileDialog.ShowDialog();
            string path = saveFileDialog.FileName;
            XmlSerializer x1 = new XmlSerializer(collection.GetType());
            if (!String.IsNullOrEmpty(path))
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    x1.Serialize(fs, collection);
                }
                MessageBox.Show("Done!");
                Process.Start("explorer.exe", Path.GetDirectoryName(saveFileDialog.FileName));
            }
        }

        public ObservableCollection<PluginData> ImportSettings()
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "XML files(*.xml)|*.xml|All files(*.*)|*.*";
            op.ShowDialog();
            string path = op.FileName;
            XmlSerializer formatter = new XmlSerializer(typeof(PluginData[]));
            ObservableCollection<PluginData> collection = new ObservableCollection<PluginData>();
            if (!string.IsNullOrEmpty(path))
            {
                //using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                //{
                //    return (ObservableCollection<PluginData>)x.Deserialize(fs);
                //}
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    PluginData[] newpeople = (PluginData[])formatter.Deserialize(fs);

                    foreach (PluginData p in newpeople)
                    {
                        collection.Add(new PluginData { AppDescription = p.AppDescription, AppName = p.AppName, AppPath = p.AppPath, Author = p.Author, AppVersion = p.AppVersion });
                        //Console.WriteLine($"Имя: {p.Name} --- Возраст: {p.Age} --- Компания: {p.Company.Name}");
                    }

                    return collection;
                }
            }
            return null;
        }
        public ObservableCollection<PluginData> ImportSettings(string path)
        {
            string[] allFoundFiles = Directory.GetFiles(path, "AppInfo.xml", SearchOption.AllDirectories);

            XmlSerializer formatter = new XmlSerializer(typeof(PluginData[]));
            ObservableCollection<PluginData> collection = new ObservableCollection<PluginData>();

            for (int i = 0; i < allFoundFiles.Length; i++)
            {
                if (!string.IsNullOrEmpty(allFoundFiles[i]))
                {
                    using (FileStream fs = new FileStream(allFoundFiles[i], FileMode.OpenOrCreate))
                    {
                        PluginData[] newpeople = (PluginData[])formatter.Deserialize(fs);
                        foreach (PluginData p in newpeople)
                        {
                            collection.Add(new PluginData { AppDescription = p.AppDescription, AppName = p.AppName, 
                                AppPath = p.AppPath, Author = p.Author, 
                                AppVersion = p.AppVersion, NavisworksVersion = p.NavisworksVersion});
                        }
                    }
                }
            }
            return collection;
        }

    }
}
