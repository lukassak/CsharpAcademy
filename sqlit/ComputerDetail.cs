using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlit
{
    public class ComputerDetail
    {
        public int CpuUsage { get; set; }
        public int RamUsage { get; set; }
        public int AvailableDiskSpaceGb { get; set; }
        public int AverageDiskQueueLength { get; set; }
        public  DateTime? Time { get; set; }
        public int ComputerDetailsId { get; set; }
        public ICollection<UsageData> UsageDataCollection { get; set; }
    }
    
}
