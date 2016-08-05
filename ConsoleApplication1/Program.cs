using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using DataLayer;
using Microsoft.Win32;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {


            var dataManager = new FullDataManager();

            var computername = dataManager.GetMetric("computername");
            Console.WriteLine($"Computer Name: {computername}");

            var cpuUsage = dataManager.GetMetric("cpuusage");
            Console.WriteLine($"Current CPU usage: {cpuUsage}%");

            var ramusage = dataManager.GetMetric("ramusage");
            Console.WriteLine($"Current RAM usage: {ramusage}%");

            var user = dataManager.GetMetric("username");
            Console.WriteLine($"Computer Name: {user}");

            var ram = dataManager.GetMetric("ram");
            Console.WriteLine($"Computer total ram: {ram} mb");

            var video = dataManager.GetMetric("card");
            Console.WriteLine($"Video card: {video}");

            var availablememory = dataManager.GetMetric("availablememory");
            Console.WriteLine($"Total memory: {availablememory} ");

            Console.WriteLine($"IP Address:");
            var ip = dataManager.GetMetric("ip");
            Console.WriteLine($" {ip}");

            var avgDiskWriteQueueLength = dataManager.GetMetric("avgDiskWriteQueueLength");
            Console.WriteLine($"Avg queue lenght: {avgDiskWriteQueueLength}");

            Console.WriteLine($"Computer summary: ");
            var cosumm = dataManager.GetComputerSummary();
            Console.WriteLine($" {cosumm}");

            Console.WriteLine($"Application summary: ");
            var aplication = dataManager.GetApplicationList();
            Console.WriteLine($" {aplication}");

            Console.WriteLine($"Hardware summary: ");
            var hardware = dataManager.GetHardwareList();
            Console.WriteLine($" {hardware}");

            Console.ReadLine();
        }
    }
}
