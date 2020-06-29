using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class Observables
    {
        static int value = 1;

        public static void Run()
        {
            var observer = Observer.Create((IEnumerable<int> values) => Console.WriteLine("Observer: " + string.Join(", ", values)));

            var observable = GetObservable();
            observable.Subscribe(observer);
            observable.Subscribe(val => Console.WriteLine("Action 1: " + string.Join(", ", val)));
            Console.WriteLine();


            //IScheduler scheduler = Scheduler.Default;

            //var subject = Subject.Create<IEnumerable<int>>(observer, observable);
            //subject.NotifyOn(scheduler);

            //subject.Subscribe(val => Console.WriteLine("Action 2: " + string.Join(", ", val)));

            //subject.Subscribe(val => Console.WriteLine("Action 3: " + string.Join(", ", val)));

            //subject.OnNext(new List<int> { ++value, ++value, ++value });


            //var behaviourSubject replaySubject= new BehaviorSubject<IEnumerable<int>>(new List<int> { ++value, ++value, ++value });
            var replaySubject = new ReplaySubject<IEnumerable<int>>(2);
            replaySubject.Subscribe(val => Console.WriteLine("Action 4: " + string.Join(", ", val)));
            replaySubject.Subscribe(val => Console.WriteLine("Action 5: " + string.Join(", ", val)));
            Console.WriteLine();
            replaySubject.OnNext(new List<int> { ++value, ++value, ++value });
            replaySubject.Subscribe(val => Console.WriteLine("Action 6: " + string.Join(", ", val)));
            Console.WriteLine();
            replaySubject.OnNext(new List<int> { ++value, ++value, ++value });
            replaySubject.Subscribe(val => Console.WriteLine("Action 7: " + string.Join(", ", val)));
            Console.WriteLine();
            replaySubject.OnNext(new List<int> { ++value, ++value, ++value });
            replaySubject.Subscribe(val => Console.WriteLine("Action 8: " + string.Join(", ", val)));
        }

        public static IObservable<IEnumerable<int>> GetObservable()
        {
            return Observable.Create<List<int>>(observer =>
            {
                return Task.Run(() =>
                {
                    observer.OnNext(new List<int> { ++value, ++value, ++value });
                    observer.OnNext(new List<int> { ++value, ++value, ++value });
                });
            });
        }
    }
}