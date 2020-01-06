using System.Collections.Generic;

namespace pcmonitor
{
    interface ISystemInformation
    {
        List<string[]> ReadData();
        void Save();
    }
}
