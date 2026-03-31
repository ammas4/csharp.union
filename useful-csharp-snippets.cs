using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml;

namespace A
{
    class B
    {
        public event Action<string> MessageSended; //простое текстосодержащее событие 

        public event MessageSendedFunc MessageSendedV2; //сложное событие с кастомным делегатом для выполнения
        public delegate void MessageSendedFunc(object sender);
    }
    class B2
    {
        //Реализация интерфейса INotifyPropertyChanged, об уведомлениии при изменении значения property:
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(info));
        }
    }

    class B3
    {
        B3()
        {
            string _ = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.ffff");
            _ = 10.ToString("X"); //hex
            _ = 123000.ToString("N0"); // 123 000
            _ = 1.2252.ToString("F2"); // 1.23
        }
    }

    class B4
    {
        B4() //В конструкторе для демонстрации!
        {
            //v1 Стартуем процесс в системе, с перенаправлением ввода-вывода
            ProcessStartInfo psi = new ProcessStartInfo("cmd.exe")
            {
                RedirectStandardError = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false
            };
            Process p = Process.Start(psi);
            StreamWriter sw = p.StandardInput;
            StreamReader sr = p.StandardOutput;
            sw.WriteLine("Hello world!");
            sr.Close();
            p.WaitForExit();

            //v2 Стартуем процесс в системе, выполняющий my_batch_file.batch
            var args = string.Format("/c {0}: && cd \"{1}\" && my_batch_file", Path.GetPathRoot(@"d:\"), (@"full_path"));
            Process proc = Process.Start(@"C:\Windows\System32\cmd.exe", args);
            proc.WaitForExit();
        }
    }

    class B5
    {
        //межпроцессный mutex для синхронизации потоков в разных приложениях
        private const string MutexName = "FAA9569-7DFE-4D6D-874D-19123FB16CBC-8739827-[SystemSpecicString]";
        private static Mutex _globalMutex = new Mutex(false, MutexName);
        B5()
        {
            if (_globalMutex.WaitOne(100)) { Thread.Sleep(1000); _globalMutex.ReleaseMutex(); } else { }
            _globalMutex.Dispose();
        }
    }

    class B6
    {
        //вызвать функцию из C++ библиотеки
        const string DllName = "cppDll.cpp";

        public static void CppFunc1(double[] tArray, int tArrayLength, int rosetteSize,
out double xc, out double yc, out double h2, out double omega, out double angle1, out double angle2, out double angle3)
        {
            unsafe
            {
                fixed (double* p0 = &tArray[0])
                fixed (double* pxc = &xc)
                fixed (double* pyc = &yc)
                fixed (double* ph2 = &h2)
                fixed (double* pomega = &omega)
                fixed (double* pangle1 = &angle1)
                fixed (double* pangle2 = &angle2)
                fixed (double* pangle3 = &angle3)
                {
                    cpp_func_1(p0, tArrayLength, rosetteSize, pxc, pyc, ph2, pomega, pangle1, pangle2, pangle3);
                }
            }
        }

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        unsafe static extern void cpp_func_1(double* tArray, int tArrayLength, int rosetteSize, double* xc, double* yc, double* h2, double* omega, double* angle1, double* angle2, double* angle3);


    }

    class B7
    {
        //Быстро серилизовать любой тип данных
        private static readonly System.Text.Json.JsonSerializerOptions _options = new System.Text.Json.JsonSerializerOptions
        {
            WriteIndented = true
        };

        B7()
        {
            object obj = new { A = 1 };
            string json = System.Text.Json.JsonSerializer.Serialize(obj, _options); 
        }
    }
}
