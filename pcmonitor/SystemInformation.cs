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
                    string GroupHeader = "";

                    foreach (string[] info in this.Collection)
                    {

                        if (info[2] != GroupHeader)
                        {
                            sw.WriteLine($"\n### {info[2]} ###\n");
                        }

                        sw.WriteLine($"{info[0]} - {info[1]}");

                        GroupHeader = info[2];

                    }
                }

                MessageBox.Show("Information saved in file.", "Saving information", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (System.Exception)
            {

                MessageBox.Show("Program encountered a problem while saving information.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                throw;

            }

        }
    }
}
