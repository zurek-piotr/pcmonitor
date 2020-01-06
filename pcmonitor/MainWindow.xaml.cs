using System.Collections.Generic;
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

        private void LoadData(string source, ListView view) {
            SystemInformation informations = new SystemInformation(source);
            List<string[]> data = informations.ReadData();
            foreach (string[] info in data)
            {
                view.Items.Add(new ViewListItem { Name = info[0], Property = info[1] });
            }
        }

        private void Processor_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData("Win32_Processor", processorInfo);
        }
        private void Disks_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData("Win32_DiskDrive", disksInfo);
        }

        private void ProcessorSaveButton_Click(object sender, RoutedEventArgs e)
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
