using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace pcmonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal class ViewListItem
        {
            public string Name { get; set; }
            public string Property { get; set; }
            public string GroupHeader { get; set; }
        }

        private SystemInformation processor;
        private SystemInformation disks;
        private SystemInformation memory;
        private SystemInformation network;

        public MainWindow()
        {
            InitializeComponent();
        }

        private SystemInformation LoadData(string source, ListView view)
        {
            try
            {

                SystemInformation informations = new SystemInformation(source);
                List<string[]> data = informations.ReadData();

                try
                {

                    List<ViewListItem> items = new List<ViewListItem>();

                    foreach (string[] info in data)
                    {

                        items.Add(new ViewListItem { Name = info[0], Property = info[1], GroupHeader = info[2] });

                    }

                    view.ItemsSource = items;
                    CollectionView cView = (CollectionView)CollectionViewSource.GetDefaultView(view.ItemsSource);
                    PropertyGroupDescription groupDescription = new PropertyGroupDescription("GroupHeader");
                    cView.GroupDescriptions.Add(groupDescription);

                }
                catch (System.Exception)
                {

                    MessageBox.Show("Program encountered problem while adding information to table.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    throw;

                }

                return informations;

            }
            catch (System.Exception)
            {

                MessageBox.Show("Program encountered problem while retrieving information.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                throw;

            }

        }

        private void Processor_Loaded(object sender, RoutedEventArgs e)
        {
            processor = LoadData("Win32_Processor", processorInfo);
        }
        private void Disks_Loaded(object sender, RoutedEventArgs e)
        {
            disks = LoadData("Win32_DiskDrive", disksInfo);
        }
        private void Memory_Loaded(object sender, RoutedEventArgs e)
        {
            memory = LoadData("Win32_PhysicalMemory", memoryInfo);
        }
        private void Network_Loaded(object sender, RoutedEventArgs e)
        {
            network = LoadData("Win32_NetworkAdapter", networkInfo);
        }

        private void ProcessorSaveButton_Click(object sender, RoutedEventArgs e)
        {
            new Thread(processor.Save).Start();
        }

        private void DisksSaveButton_Click(object sender, RoutedEventArgs e)
        {
            new Thread(disks.Save).Start();
        }

        private void MemorySaveButton_Click(object sender, RoutedEventArgs e)
        {
            new Thread(memory.Save).Start();
        }
        private void NetworkSaveButton_Click(object sender, RoutedEventArgs e)
        {
            new Thread(network.Save).Start();
        }
    }

}
