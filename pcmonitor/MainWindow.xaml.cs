using System.Collections.Generic;
using System.Management;
using System.Windows;
using System.Windows.Controls;

namespace pcmonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Procesor_Loaded(object sender, RoutedEventArgs e)
        {
            SystemInformation processor = new SystemInformation("Win32_Processor");
            List<string[]> data = processor.ReadData();
            foreach (string[] info in data)
            {
                processorInfo.Items.Add(new ViewListItem { Name = info[0], Property = info[1] });
            }
        }
        private void Disks_Loaded(object sender, RoutedEventArgs e)
        {
            SystemInformation disks = new SystemInformation("Win32_DiskDrive");
            List<string[]> data = disks.ReadData();
            foreach (string[] info in data)
            {
                disksInfo.Items.Add(new ViewListItem { Name = info[0], Property = info[1] });
            }
        }

        private void processorSaveButton_Click(object sender, RoutedEventArgs e)
        {
            SystemInformation processor = new SystemInformation("Win32_Processor");
            processor.Save();
        }

        private void DisksSaveButton_Click(object sender, RoutedEventArgs e)
        {
            SystemInformation disks = new SystemInformation("Win32_DiskDrive");
            disks.Save();
        }
    }

    internal class ViewListItem
    {
        public string Name { get; set; }
        public string Property { get; set; }
    }
}
