using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GraphApp.Model
{
    internal class ConsoleHelper
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool AllocConsole();
        
        public static void OpenConsole()
        {
            // Allocate a console for this WPF process
            var _ = AllocConsole();

            // Redirect Console.Out to the new console
            var stdHandle = Console.OpenStandardOutput();
            var writer = new StreamWriter(stdHandle, Encoding.UTF8) { AutoFlush = true };
            Console.SetOut(writer);
            Console.SetError(writer);
        }
    }
}
