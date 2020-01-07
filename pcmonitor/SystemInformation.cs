using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace pcmonitor
{
    class SystemInformation : SystemMonitor, ISystemInformation
    {
        private List<string[]> Collection;
        private readonly string source;
        public SystemInformation(string source) : base(source)
        {
            this.source = source;
        }

        override public List<string[]> ReadData()
        {
            this.Collection = base.ReadData();
            return Collection;
        }

        public void Save()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter($"{this.source}.txt"))
                {
                    foreach (string[] info in this.Collection)
                    {
                        sw.WriteLine($"{info[0]} - {info[1]}");
                    }
                }
                MessageBox.Show("Informations saved in file.", "Saving informations.", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (System.Exception)
            {
                MessageBox.Show("Program encountered problem saving informations.", "Error.", MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }
            
        }
    }
}
