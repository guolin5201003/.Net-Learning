

using System.Text.RegularExpressions;

namespace AsyncScenarios
{
    class Button
    {
        public Func<object, object, Task>? Clicked
        {
            get;
            internal set;
        }
    }

    class DamageResult
    {
        public int Damage
        {
            get { return 0; }
        }
    }

    class User
    {
        public bool isEnabled
        {
            get;
            set;
        }

        public int id
        {
            get;
            set;
        }
    }

    internal class Program
    {
        private static readonly HttpClient s_httpClient = new();

        private static readonly IEnumerable<string> s_urlList = new string[]
        {
            "https://learn.microsoft.com",
            "https://learn.microsoft.com/aspnet/core",
            "https://learn.microsoft.com/azure",
            "https://learn.microsoft.com/azure/devops",
            "https://learn.microsoft.com/dotnet",
            "https://learn.microsoft.com/dotnet/desktop/wpf/get-started/create-app-visual-studio",
            "https://learn.microsoft.com/education",
            "https://learn.microsoft.com/shows/net-core-101/what-is-net",
            "https://learn.microsoft.com/enterprise-mobility-security",
            "https://learn.microsoft.com/gaming",
            "https://learn.microsoft.com/graph",
            "https://learn.microsoft.com/microsoft-365",
            "https://learn.microsoft.com/office",
            "https://learn.microsoft.com/powershell",
            "https://learn.microsoft.com/sql",
            "https://learn.microsoft.com/surface",
            "https://dotnetfoundation.org",
            "https://learn.microsoft.com/windows",
        };



        static async Task Main(string[] args)
        {
            Console.WriteLine("Application started.");

            //Scenario 1:
            Console.WriteLine("Counting '.NET' phrase in websites...");
            //Way 1:
            int total = 0;
            foreach (var url in s_urlList)
            {
                var result = await CountDotNet(url);
                Console.WriteLine($"{url}: {result}");
                total += result;
            }
            Console.WriteLine("Total: " + total);

            ////Way 2: Using Task.WhenAll
            //int total = 0;
            //var countTasks = new List<Task<int>>();
            //foreach (var url in s_urlList)
            //{
            //    countTasks.Add(CountDotNet(url));
            //}
            //var tttasks = await Task.WhenAll(countTasks);
            //total = tttasks.Sum();
            //Console.WriteLine("Total: " + total);


            //Scenario 2:
            Console.WriteLine("Retrieving User objects with list of IDs...");
            IEnumerable<int> ids = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            var users = await GetUserAsyncByLinq(ids);
            foreach (var user in users)
            {
                Console.WriteLine($"User {user.id} is enabled: {user.isEnabled}");
            }

        }

        private static async Task<int> CountDotNet(string url)
        {
            Console.WriteLine($"url: {url}");
            var html = await s_httpClient.GetStringAsync(url);
            var count = Regex.Matches(html, "dotnet").Count;
            Console.WriteLine($"Counted {count} occurrences of '.NET' in {url}");
            return count;
        }

        // <GetUsersForDataset>
        private static async Task<User> GetUserAsync(int userId)
        {
            // Code omitted:
            //
            // Given a user Id {userId}, retrieves a User object corresponding
            // to the entry in the database with {userId} as its Id.
            Console.WriteLine($"Retrieving user {userId}...");
            return await Task.FromResult(new User() { id = userId });
        }

        private static async Task<IEnumerable<User>> GetUserAsync(IEnumerable<int> userIds)
        {
            //var users = new List<User>();
            //foreach (var userId in userIds)
            //{
            //    users.Add(await GetUserAsync(userId));
            //}
            //return users;

            var getUserTasks = new List<Task<User>>();
            foreach (var userId in userIds)
            {
                getUserTasks.Add(GetUserAsync(userId));
            }
            return await Task.WhenAll(getUserTasks);
        }

        public static async Task<IEnumerable<User>> GetUserAsyncByLinq(IEnumerable<int> userIds)
        {
            //ToArray is nessary here.
            //Because LINQ uses deferred (lazy) execution, which means that the query is not executed until the data is actually needed.
            //So, ToArray() or ToList() is necessary to force the query to execute and return the results immediately.
            var getUserTasks = userIds.Select(id=> GetUserAsync(id)).ToArray();
            return await Task.WhenAll(getUserTasks);
        }

    }
}
