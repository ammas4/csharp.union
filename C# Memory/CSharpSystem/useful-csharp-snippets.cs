using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Xml;

namespace A
{
    class B
    {
        public event Action<string> MessageSended; //простое текстосодержащее событие 

        public event MessageSendedFunc MessageSendedV2; //сложное событие с кастомным делегатом для выполнения
        public delegate void MessageSendedFunc(object sender);

        readonly Random _random = new Random();
        public void DoAny() => MessageSended?.Invoke("Message from B " + _random.GetHexString(10));
    }

    class B2 : INotifyPropertyChanged
    {
        //Реализация интерфейса INotifyPropertyChanged, об уведомлениии при изменении значения property:
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(info));
        }

        int _prop;
        public int Prop { get => _prop; set { _prop = value; NotifyPropertyChanged(nameof(Prop)); } }
    }

    class B3
    {
        B3(bool toPrint)
        {
            string _ = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.ffff");
            if (toPrint) Console.WriteLine(_);
            _ = 10.ToString("X"); 
            if (toPrint) Console.WriteLine(_); //hex
            _ = 123000.ToString("N0"); 
            if (toPrint) Console.WriteLine(_); // 123 000
            _ = 1.2252.ToString("F2"); 
            if (toPrint) Console.WriteLine(_); // 1.23
            //File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), $"{DateTime.Now.ToString("_H_mm_ss_fff.txt")}") , text);
        }
    }

    class B4
    {
        B4() //В конструкторе для демонстрации!
        {
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
            }

            {
                //v2 Стартуем процесс в системе, выполняющий my_batch_file.batch
                var args = string.Format("/c {0}: && cd \"{1}\" && my_batch_file", Path.GetPathRoot(@"d:\"), (@"full_path"));
                Process proc = Process.Start(@"C:\Windows\System32\cmd.exe", args);
                proc.WaitForExit();
            }

            {//v3 Открываем блокнот с содержимым файла
                string filePath = @"C:\Temp\myfile.txt";
                var psi = new ProcessStartInfo
                {
                    FileName = "notepad.exe",
                    Arguments = $"\"{filePath}\"",
                    UseShellExecute = false
                };

                Process p = Process.Start(psi);
            }
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

    class B8
    {
        B8()
        {
            string answer =
                @"Test 123 completed successfully\n" +
                @"Test 124 completed successfully\n" +
                @"Test 125 failed\n";

            string patternSuccess = @"Test\s+(.+?)\s+completed\s+successfully";
            string patternFailed = @"Test\s+(.+?)\s+failed";
            //Поиск удачных тестов
            MatchCollection matchesSuccess = Regex.Matches(answer, patternSuccess);
            foreach (Match match in matchesSuccess)
            {
                Console.WriteLine(match.Value);
            }
        }

        /*
		class CancellationTest
{
	~CancellationTest()
	{
		_cts1?.Dispose();
		_ctsTheSecond?.Dispose();
		_ctsTheThird?.Dispose();
	}

	CancellationTokenSource _cts1;
	CancellationTokenSource _ctsTheSecond;
	CancellationTokenSource _ctsTheThird;

	public async Task<int> TestCts()
	{
		if(_cts1 != null) _cts1.Dispose(); //!1
		if(_ctsTheSecond) _ctsTheSecond.Dispose();
		if(_ctsTheThird != null) _ctsTheThird.Dispose();
		_cts1 = new CancellationTokenSource();
		_ctsTheSecond = new CancellationTokenSource();
		_ctsTheThird = CancellationTokenSource.CreateLinkedTokenSource(_cts1.Token, _ctsTheSecond.Token);

		Task t_ = Task.Run(async () => { _cts1.Cancel(); //!2
		});

		try
		{
			await Task.Run(async () => { await Task.Delay(1000); 
			_cts1.Token.ThrowIfCancellationRequested(); //!2.2
			}, _cts1.Token);
		}
		catch (OperationCanceledException) { } //!3
		
		if (_ctsTheThird.IsCancellationRequested && _cts1.IsCancellationRequested && !_ctsTheSecond.IsCancellationRequested) //!4
		{  "Family My".ToString(); }

		return 0;
	}

//methods, 1
void FindFileByExtension(DirectoryInfo dir, string extension, ref FileInfo result)
{
	DirectoryInfo().GetFiles("*.csproj", SearchOption.AllDirectories);
	return;
}

//methods, 2, StringBuilderExtensions
public static bool EndContains(this StringBuilder sb, string text, int lenSpectr)
{
	if (sb.Length < text.Length)
		return false;

	var sbLength = sb.Length;
	if (lenSpectr > sbLength)
		lenSpectr = sbLength;

	var textLength = text.Length;
	if (lenSpectr < textLength)
		lenSpectr = textLength;

	for (int i = 0; i <= lenSpectr - textLength; i++)
	{
		bool v = false;
		for (int j = 0; j < textLength; j++)
		{
			if (text[j] != sb[sbLength - lenSpectr + i + j])
			{
				v = true;
				break;
			}
		}
		if (v)
			continue;
		return true;
	}
	return false;
}
		*/
    }
}