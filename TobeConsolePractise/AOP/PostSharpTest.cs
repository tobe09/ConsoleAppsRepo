using PostSharp.Aspects;
using System;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    public class PostSharpTest
    {
        public static void Run()
        {
            var postSharp = new PostSharpClass();
            var valid = postSharp.Test(9);
            Console.WriteLine(valid.Model.Value);
            var invalid = postSharp.Test(11);
            Console.WriteLine(invalid.Error);
            int value = postSharp.TestAsync(21).Result;
            Console.WriteLine(value);
        }
    }

    class PostSharpClass
    {
        [MethodInterceptor]
        public Result<MyResponse> Test(int value)
        {
            Console.WriteLine("Sync Value: " + value);
            return Result<MyResponse>.Create(new MyResponse { Value = value });
        }

        [MethodInterceptor]
        public Task<int> TestAsync(int value)
        {
            Console.WriteLine("Async Value: " + value);
            return Task.FromResult(value);
        }
    }

    class Result<T>
    {
        public string Error { get; set; }
        public T Model { get; set; }

        internal static Result<T> Create(T model)
        {
            return new Result<T> { Model = model };
        }
    }

    class MyResponse : BaseResponse
    {
        public int Value { get; set; }
    }
    abstract class BaseResponse { }

    [Serializable]
    class MethodInterceptor : MethodInterceptionAspect      //Instance Level Aspect Only Avaliable In Paid Version Of PostSharp
    {
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            foreach (object arg in args.Arguments)
            {
                if (arg is int && (int)arg > 10)
                {
                    var type = ((dynamic)args.Method).ReturnType as Type;
                    dynamic result = Activator.CreateInstance(type);
                    result.Error = "Chaye";
                    args.ReturnValue = result;
                    return;
                }
            }

            args.Proceed();
        }

        public async override Task OnInvokeAsync(MethodInterceptionArgs args)
        {
            args.ReturnValue = await args.InvokeAsync(args.Arguments);
        }
    }
}
