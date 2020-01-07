using System.Collections.Generic;
using System.IO;

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
        }
    }
}
