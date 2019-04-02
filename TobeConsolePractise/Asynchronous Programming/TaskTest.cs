using System;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class TaskTest
    {
        /// <summary>
        /// Starting a tsak with new Task() syntax. Task needs to be started
        /// </summary>
        static Func<string, string> func = str => str;
        static Task<string> strTaskSelf = new Task<string>(() =>
        {
            return "strTaskSelf says hello";
        });

        static Task<string> strTask()
        {
            Func<string> f = () =>
            {
                return "strTask says hello";
            };
            return new Task<string>(f);
        }

        /// <summary>
        /// Starrting a task with Factory syntax. Task is automatically started
        /// </summary>
        Task<string> tskStr(string str)
        {
            return Task.Factory.StartNew(() => str);
        }

        public void GetInfo()
        {
            Task<string> tsk = Task.Factory.StartNew(() =>
            {
                return "Hello";
            });
            var a1 = tsk.Result;
            tsk.ContinueWith(res =>
            {
                string a = res.Result;
                return 1;
            }).ContinueWith(res =>
            {
                Console.WriteLine(res.Result);
            });

            string a2 = tskStr("hello").Result;
            tskStr("hello").ContinueWith(res =>
            {
                string a = res.Result;
                return 2;
            }).ContinueWith(res =>
            {
                Console.WriteLine(res.Result);
            });
        }

        /// <summary>
        /// Using async/await to convert a method block into a task
        /// </summary>
        /// <returns></returns>
        public static async Task<string> asyncTask()
        {
            var str = await new TaskTest().tskStr("hello");
            return str;
        }

        public static Task Run()
        {
            new TaskTest().GetInfo();

            Console.WriteLine(func("hello"));

            strTaskSelf.Start();
            var a = strTaskSelf.Result;

            asyncTask().ContinueWith(res => {
                var b = res.Result;
            });

            strTask().Start();
            return strTaskSelf.ContinueWith(res => {
                Console.WriteLine(res.Result);
            });
        }
    }
}
