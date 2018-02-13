using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace TobeConsolePractise
{
    class InputOutput
    {
        public static void run()
        {
            //    string t = Path.GetFullPath("info.txt");
            //    TextReader ts = new StreamReader(@"C:\Users\NeptuneDev1\Documents\Visual Studio 2013\Projects\HospitalManager\HospitalManager\App_Data\Info.txt");
            //    string s = ts.ReadToEnd();
            //    string constr = s.Remove(s.Length - 16);
            //    string key = s.Remove(0, 13);
            //    Console.Write(s+"\n"+constr+"\n"+key);
            string ss = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            StreamWriter tw = File.AppendText(@"c:\temp\info.txt");
            StringBuilder sb = new StringBuilder();
            TextWriter tw2 = new StringWriter(sb);
            string s = "Hello";
            tw.WriteLine(s + ", Hi");
            tw.WriteLine("\r\nwell\nwell"); tw.Flush();
            //tw.Dispose(); //or //tw.Close();
            //Console.ReadKey();
        }
    }
}
