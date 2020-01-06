using System.Collections.Generic;
using System.IO;

namespace pcmonitor
{
    class SystemInformation : SystemMonitor
    {
        private List<string[]> Collection;
        private readonly string source;
        public SystemInformation(string source) : base(source)
        {
            this.source = source;
        }

        override public List<string[]> ReadData() {
            Collection = base.ReadData();
            return Collection;
        }

        public void Save()
        {
            this.ReadData();
            using (StreamWriter sw = new StreamWriter($"{this.source}.txt"))
            {
                foreach (string[] info in this.Collection)
                {
                    sw.WriteLine($"{info[0]} - {info[1]}");
                }
            }
        }
    }
}
