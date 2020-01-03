using System.Management;
using System.Windows;

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

        void GetProcessorInfo()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_Processor");
           // HardwareMonitor monitor = new HardwareMonitor("Win32_Processor");
            //monitor.GetInfo("Name");
            foreach (ManagementObject processorInfo in searcher.Get())
            {
                processorName.Text += ($"{processorInfo["Name"]}");
                processorCores.Text += ($"{processorInfo["NumberOfCores"]}");
            }
            
            
        }
        private void Info_Loaded(object sender, RoutedEventArgs e)
        {
            GetProcessorInfo();
        }
    }
}
