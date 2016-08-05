using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{

    public abstract class DataManager
    {
        public virtual string GetMetric(string type)
        {
            var value = "";
            switch (type.ToLower())
            {
                   



                case "cpuusage":
                    var searcher = new ManagementObjectSearcher("select * from Win32_PerfFormattedData_PerfOS_Processor");
                    foreach (var obj in searcher.Get().Cast<ManagementObject>())
                    {
                        value = obj["PercentProcessorTime"].ToString();
                        break;
                    }
                    break;

                case "ram":
                    var searcher2 = new ManagementObjectSearcher("select * from Win32_PerfFormattedData_PerfOS_Memory");
                    foreach (var obj in searcher2.Get().Cast<ManagementObject>())
                    {
                        value = obj["AvailableMBytes"].ToString();
                        break;
                    }
                    break;

                case "card":
                    var searcher3 = new ManagementObjectSearcher("select * from Win32_VideoController");
                    foreach (var obj in searcher3.Get().Cast<ManagementObject>())
                    {
                        value = obj["name"].ToString();
                        break;
                    }
                    break;

                case "ip":
                    var searcher4 = new ManagementObjectSearcher("select * from Win32_NetworkAdapterConfiguration WHERE IPEnabled = 'TRUE'");
                    List<string> allIPs = new List<string>();
                    foreach (var obj in searcher4.Get().Cast<ManagementObject>())
                   
                        {
                            if (obj["IPAddress"] != null)
                            {
                                if (obj["IPAddress"] is Array)
                                {
                                    string[] addresses = (string[])obj["IPAddress"];
                                    allIPs.AddRange(addresses);
                                }
                                else
                                {
                                    allIPs.Add(obj["IPAddress"].ToString());
                                }
                            }
                        string dogCsv = string.Join(",", allIPs.ToArray());
                        Console.WriteLine(dogCsv);
                    }
                  
                    break;

                case "ramusage":
                    var searcher5 = new ManagementObjectSearcher("select * from Win32_PerfFormattedData_PerfOS_Memory");
                    foreach (var obj in searcher5.Get().Cast<ManagementObject>())
                    {
                        value = obj["PercentCommittedBytesInUse"].ToString();
                        break;
                    }
                    break;

                case "availablememory":
                    var searcher6 = new ManagementObjectSearcher("select * from Win32_LogicalDisk");
                    foreach (var obj in searcher6.Get().Cast<ManagementObject>())
                    {
                        value = obj["size"].ToString();
                        break;
                    }
                    break;


                case "AvgDiskWriteQueueLength":
                    var searcher7 = new ManagementObjectSearcher("select * from Win32_PerfFormattedData_PerfDisk_PhysicalDisk");
                    foreach (var obj in searcher7.Get().Cast<ManagementObject>())
                    {
                        value = obj["AvgDiskWriteQueueLength"].ToString();
                        break;
                    }
                    break;

                case "computername":
                    value = Environment.MachineName;
                    break;
                default:
                    value = "";
                    break;


                case "username":
                    value = Environment.UserName;
                    break;
                

            }

            return value;
        }

        public abstract ComputerSummary GetComputerSummary();
        public abstract List<string> GetApplicationList();
        public abstract List<string> GetHardwareList();
    }
}
