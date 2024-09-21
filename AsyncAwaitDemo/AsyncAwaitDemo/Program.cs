using System;
using System.Threading.Tasks;

namespace AsyncAwaitDemo
{
    // These classes are intentionally empty for the purpose of this example. They are simply marker classes for the purpose of demonstration, contain no properties, and serve no other purpose.
    internal class Bacon { }
    internal class Coffee { }
    internal class Egg { }
    internal class Juice { }
    internal class Toast { }

    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine($"-- begin: {DateTime.Now}");
            //SyncBreakfast();

            //await AsyncBreakfast();
            //await AsyncConcurrent();
            await CompositionWithTask();
            //await WhenAnyTest();

            Console.WriteLine($"-- end: {DateTime.Now}");

        }

        private static async Task WhenAnyTest()
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");

            var eggsTask = FryEggsAsync(2);
            var baconTask = FryBaconAsync(3);
            var toastTask = ToastBreadAsync(2);

            var breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask };
            while (breakfastTasks.Count > 0)
            {
                Task finishedTask = await Task.WhenAny(breakfastTasks);

                if (finishedTask == eggsTask)
                {
                    Console.WriteLine($"eggs are ready. - ManagedThreadId: {Thread.CurrentThread.ManagedThreadId}");
                }
                else if (finishedTask == baconTask)
                {
                    Console.WriteLine($"bacon is ready. - ManagedThreadId: {Thread.CurrentThread.ManagedThreadId}");
                }
                else if (finishedTask == toastTask)
                {
                    Console.WriteLine($"toast is ready. - ManagedThreadId: {Thread.CurrentThread.ManagedThreadId}");
                }

                await finishedTask;
                breakfastTasks.Remove(finishedTask);
            }
        }

        private static async Task CompositionWithTask()
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");

            var eggTask = FryEggsAsync(2);
            var baconTask = FryBaconAsync(3);
            var toastTask = MakeToastWithButterAndJamAsync(2);

            Toast toast = await toastTask;
            Console.WriteLine("toast is ready");

            Egg eggs = await eggTask;
            Console.WriteLine("eggs are ready");

            Bacon bacon = await baconTask;
            Console.WriteLine("bacon is ready");

            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready!");

        }

        private static async Task AsyncConcurrent()
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");

            var toastTask = ToastBreadAsync(2);
            var eggTask = FryEggsAsync(2);
            var baconTask = FryBaconAsync(3);

            Toast toast = await toastTask;
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine($"toast is ready.");
            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");

            Egg eggs = await eggTask;
            Console.WriteLine("eggs are ready");

            Bacon bacon = await baconTask;
            Console.WriteLine("bacon is ready");
            Console.WriteLine("Breakfast is ready!");

        }

        private static async Task AsyncBreakfast()
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");

            Egg eggs = await FryEggsAsync(2);
            Console.WriteLine("eggs are ready");

            Bacon bacon = await FryBaconAsync(3);
            Console.WriteLine("bacon is ready");

            Toast toast = await ToastBreadAsync(2);
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("toast is ready");

            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready!");
        }

        private static void SyncBreakfast()
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");

            Egg eggs = FryEggs(2);
            Console.WriteLine("eggs are ready");

            Bacon bacon = FryBacon(3);
            Console.WriteLine("bacon is ready");

            Toast toast = ToastBread(2);
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("toast is ready");

            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready!");
        }



        private static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
        }

        private static Juice PourOJ()
        {
            Console.WriteLine("Pouring orange juice");
            return new Juice();
        }

        private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Putting jam on the toast");

        private static void ApplyButter(Toast toast) =>
            Console.WriteLine("Putting butter on the toast");

        #region sync methods
        private static Toast ToastBread(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Remove toast from toaster");

            return new Toast();
        }



        private static Bacon FryBacon(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            Task.Delay(3000).Wait();
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second side of bacon...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put bacon on plate");

            return new Bacon();
        }



        private static Egg FryEggs(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            Task.Delay(3000).Wait();
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs ...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put eggs on plate");

            return new Egg();
        }

        #endregion


        #region async methods
        private static async Task<Toast> ToastBreadAsync(int slices)
        {
            Console.WriteLine($"--Begin ToastBreadAsync ManagedThreadId: {Thread.CurrentThread.ManagedThreadId}");

            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            await Task.Delay(3000);
            Console.WriteLine("Remove toast from toaster");

            Console.WriteLine($"--End ToastBreadAsync ManagedThreadId: {Thread.CurrentThread.ManagedThreadId}");

            return new Toast();
        }
        private static async Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"--Begin FryBaconAsync ManagedThreadId: {Thread.CurrentThread.ManagedThreadId}");

            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            await Task.Delay(3000);
            Console.WriteLine($"-- FryBaconAsync flipping ManagedThreadId: {Thread.CurrentThread.ManagedThreadId}");    
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second side of bacon...");
            await Task.Delay(3000);
            Console.WriteLine("Put bacon on plate");

            Console.WriteLine($"--End FryBaconAsync ManagedThreadId: {Thread.CurrentThread.ManagedThreadId}");


            return new Bacon();

        }
        private static async Task<Egg> FryEggsAsync(int howMany)
        {
            Console.WriteLine($"--Begin FryEggsAsync ManagedThreadId: {Thread.CurrentThread.ManagedThreadId}");

            Console.WriteLine("Warming the egg pan...");
            await Task.Delay(3000);
            Console.WriteLine($"-- FryEggsAsync cracking eggs ManagedThreadId: {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs ...");
            await Task.Delay(3000);
            Console.WriteLine("Put eggs on plate");

            Console.WriteLine($"--END FryEggsAsync ManagedThreadId: {Thread.CurrentThread.ManagedThreadId}");

            return new Egg();
        }

        private static async Task<Toast> ToastBreadWithExceptionAsync(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            await Task.Delay(2000);
            Console.WriteLine("Fire! Toast is ruined!");
            throw new InvalidOperationException("The toaster is on fire");
            await Task.Delay(1000);
            Console.WriteLine("Remove toast from toaster");

            return new Toast();
        }


        public static async Task<Toast> MakeToastWithButterAndJamAsync(int number)
        {
            var toast = await ToastBreadAsync(number);
            ApplyButter(toast);
            ApplyJam(toast);

            return toast;
        }
        #endregion

    }
}
