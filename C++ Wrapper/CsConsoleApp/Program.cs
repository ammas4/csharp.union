using CppCliLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var alg = new CppCliAlgorithm();
            bool initOk = alg.InitAlgorithm(null);
            Console.WriteLine("InitAlgorithm: " + initOk);

            byte[] buffer = new byte[10];
            for (int i = 0; i < buffer.Length; i++)
                buffer[i] = (byte)(i + 1);

            RunAlgInfoManaged info = new RunAlgInfoManaged
            {
                t1 = 0,
                t2 = 0
            };

            for (int k = 0; k < 3; k++)
            {
                bool ok = alg.Run(buffer, ref info);
                Console.WriteLine($"Run {k}: ok={ok}, t1={info.t1}, t2={info.t2}");
            }

            Console.ReadLine();
        }
    }
}
