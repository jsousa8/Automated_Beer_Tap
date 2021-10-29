using System;
using System.Diagnostics;
using System.IO;
using BeerService.Interface;

namespace BeerService
{
    public class Beer : IBeverage
    {
        public string Ounces { get; set; }
        public bool Status { get; set; }

        public Beer()
        {
            this.Ounces = "12";
            this.Status = false;
        }

        public void TriggerEvent(){
            Console.WriteLine("IM HERE");
            Console.WriteLine($"Ounces: {this.Ounces}");
            Console.WriteLine($"Status: {this.Status}");
            String path = "/app/Controllers/talkToArduino.sh";
            /*
            String currentDirectory = Directory.GetCurrentDirectory();
            Console.WriteLine($"Current Directory: {currentDirectory}");
            String testPath = "/app/BeerService/";
            String[] filesInDirectory = Directory.GetDirectories(currentDirectory);
            Console.WriteLine($"Subdirectories in directory: ");
            foreach (string a in filesInDirectory)
            {
                Console.WriteLine(a);
            }
            */

            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo() { FileName = "/bin/bash", Arguments = path, };
                Process proc = new Process() { StartInfo = startInfo, };
                proc.Start();
            }
            catch(Exception e)
            {
                Console.WriteLine("Could not start process!");
                Console.WriteLine(e.Message);
            }




        }
    }
}
                
