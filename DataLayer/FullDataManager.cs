using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Management;
using System.Threading.Tasks;

namespace DataLayer
{
    public class FullDataManager : DataManager
    {
        public override ComputerSummary GetComputerSummary()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_OperatingSystem");
            foreach (ManagementObject managementObject in mos.Get())
            {
                if (managementObject["Caption"] != null)
                {
                    Console.WriteLine("Operating System Name  :  " + managementObject["Caption"].ToString());   //Display operating system caption
                }
                if (managementObject["OSArchitecture"] != null)
                {
                    Console.WriteLine("Operating System Architecture  :  " + managementObject["OSArchitecture"].ToString());   //Display operating system architecture.
                }
                if (managementObject["CSDVersion"] != null)
                {
                    Console.WriteLine("Operating System Service Pack   :  " + managementObject["CSDVersion"].ToString());     //Display operating system version.
                }
            }
            return null;
        }

 

        public override List<string> GetApplicationList()
        {
            Process[] processes = Process.GetProcesses();
            foreach (var proc in processes)
            {
                if (!string.IsNullOrEmpty(proc.MainWindowTitle))
                    Console.WriteLine(proc.MainWindowTitle);
            }
            return null;
        }

        public override List<string> GetHardwareList()
        {
            var mbs = new ManagementObjectSearcher("Select ProcessorId From Win32_processor");
            ManagementObjectCollection mbsList = mbs.Get();
            string id = "";
            foreach (ManagementObject mo in mbsList)

            {
                id = mo["ProcessorId"].ToString();
                Console.WriteLine($"Processor id- {id} ");
                break;
            }

            ManagementObject dsk = new ManagementObject(@"win32_logicaldisk.deviceid=""c:""");
            dsk.Get();
            string hard = dsk["VolumeSerialNumber"].ToString();
            Console.WriteLine($"Hard disk id- {hard} ");



            return null;
        }
    }
}
