using System.Collections.Generic;
using System.Management;

namespace pcmonitor
{
    class SystemMonitor
    {
        private readonly ManagementObjectSearcher searcher;

        public SystemMonitor(string source)
        {
            searcher = new ManagementObjectSearcher($"select * from {source}");
        }

        virtual public List<string[]> ReadData()
        {
            List<string[]> CollectionData = new List<string[]>();
            string[] values = new string[2];
            foreach (ManagementObject info in this.searcher.Get())
            {
                foreach (PropertyData data in info.Properties)
                {
                    if (data.Value != null && data.Value.ToString() != "")
                    {
                        values = new string[] { $"{data.Name}", $"{data.Value}"};
                        CollectionData.Add(values);
                    }
                    continue;

                }
            }

            return CollectionData;
        }
    }
}
