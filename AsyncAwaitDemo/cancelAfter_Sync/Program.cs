namespace cancelAfter_Sync
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var timeout = TimeSpan.FromSeconds(5);

            var task = Task.Run(() => DoWork());
            if (!task.Wait(timeout))
            {
                Console.WriteLine("Task timed out");
            }
            else
            {
                Console.WriteLine("Task completed successfully");
            }
        }

        static void DoWork()
        {
            Console.WriteLine("Starting work");

            Thread.Sleep(10000);

            Console.WriteLine("Finished work");
        }
    }
}
