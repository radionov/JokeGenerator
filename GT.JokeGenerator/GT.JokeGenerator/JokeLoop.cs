using GT.JokeGenerator.Clients;
using GT.JokeGenerator.Extensions;
using GT.JokeGenerator.Helpers;
using GT.JokeGenerator.Models;
using GT.JokeGenerator.Providers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GT.JokeGenerator
{
    public class JokeLoop
    {
        private IUserInfoClient UserInfoClient { get; }

        private IChuckNorrisClient ChuckNorrisClient { get; }

        private IOutputProvider Output { get; }

        private IInputProvider Input { get; }

        private CancellationTokenSource ChildCancellationTokenSource { get; set; }

        /// <summary>Initializes a new instance of the <see cref="JokeLoop" /> class.</summary>
        public JokeLoop(/* [Dependency Injection]
                        IUserInfoClient userInfoClient,
                        IChuckNorrisClient chuckNorrisClient,
                        IOutputProvider output,
                        IInputProvider Input*/)
        {
            UserInfoClient = new UserInfoClient();
            ChuckNorrisClient = new ChuckNorrisClient();
            Output = new ConsoleOutputProvider();
            Input = new ConsoleInputProvider();
        }

        /// <summary>Starts the loop asynchronous.</summary>
        /// <param name="parentCancellationToken">The parent cancellation token.</param>
        public async Task StartLoopAsync(CancellationToken parentCancellationToken)
        {
            ChildCancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(parentCancellationToken);

            while (!ChildCancellationTokenSource.IsCancellationRequested)
            {
                try
                {
                    Output.Write("Press c to get categories");
                    Output.Write("Press r to get random jokes");

                    var input = Input.ReadKey();

                    switch (input)
                    {
                        case 'c':
                            await ProcessCategoriesAsync();
                            break;

                        case 'r':
                            await ProcessRandomJokesAsync();
                            break;
                        case 'q':
                            ChildCancellationTokenSource.Cancel();
                            break;
                    }
                    
                    await Task.Delay(1000, ChildCancellationTokenSource.Token);
                }
                catch (TaskCanceledException)
                {
                    break;
                }
            }
        }

        private async Task ProcessCategoriesAsync()
        {
            var categoriesTask = ChuckNorrisClient.GetCategoriesAsync();
            await AwaitTasksWithIndicator(categoriesTask);
            PrintResults(string.Empty, (await categoriesTask).ToList());
        }

        private async Task ProcessRandomJokesAsync()
        {
            var useRandomName = Tuple.Create(false, (UserInfo)null);
            var useCategory = Tuple.Create(false, (string)null);

            Output.Write("Want to use a random name? y/n");
            var input = Input.ReadKey();
            if (input == 'y')
            {
                var userNamesTask = UserInfoClient.GetUserInfoAsync();
                await AwaitTasksWithIndicator(userNamesTask);
                useRandomName = Tuple.Create(true, await userNamesTask);
            }

            Output.Write("Want to specify a category? y/n");
            input = Input.ReadKey();
            if (input == 'y')
            {
                var categoriesTask = ChuckNorrisClient.GetCategoriesAsync();
                await AwaitTasksWithIndicator(categoriesTask);

                PrintResults("Enter a category ", (await categoriesTask).ToList());
                var category = Input.ReadString();
                useCategory = Tuple.Create(true, category);
            }

            int inputNumber = 0;
            while (1 > inputNumber || inputNumber > 9)
            {
                Output.Write("How many jokes do you want? (1-9)");
                inputNumber = Input.ReadNumber();

                if (1 > inputNumber || inputNumber > 9)
                {
                    Output.Write("You input is wrong number. Please try again.");
                }
            }

            if (inputNumber > 1)
            {
                Output.Write("Want to process in parallel? y/n");
                input = Input.ReadKey();
            }

            Stopwatch sw = new Stopwatch();
            sw.Start();

            var results = new List<string>();
            var jokeTasks = new Task<Joke>[inputNumber];
            Joke joke = null;

            if (inputNumber > 1 && input == 'y')
            {
                for (int i = 0; i < inputNumber; i++)
                {
                    var jokeTask = useCategory.Item1 ?
                        ChuckNorrisClient.GetJokeByCategoryNameAsync(useCategory.Item2) :
                        ChuckNorrisClient.GetRandonJokeAsync();

                    jokeTasks[i] = jokeTask;
                }

                try
                {
                    await AwaitTasksWithIndicator(jokeTasks);

                    foreach (var jokeTask in jokeTasks)
                    {
                        joke = await jokeTask;

                        if (useRandomName.Item1)
                        {
                            joke = joke.ReplaceWith(useRandomName.Item2);
                        }

                        results.Add(joke.Value);
                    }
                }
                catch (HttpRequestException e)
                {
                    Output.Write(e.Message);
                    Output.Write("Hmm. Why did you do that?");
                }
            }
            else
            {
                try
                {
                    for (int i = 0; i < inputNumber; i++)
                    {
                        var jokeTask = useCategory.Item1 ?
                                ChuckNorrisClient.GetJokeByCategoryNameAsync(useCategory.Item2) :
                                ChuckNorrisClient.GetRandonJokeAsync();

                        await AwaitTasksWithIndicator(jokeTask);
                        joke = await jokeTask;

                        if (useRandomName.Item1)
                        {
                            joke = joke.ReplaceWith(useRandomName.Item2);
                        }

                        results.Add(joke.Value);

                    }
                }
                catch (HttpRequestException e)
                {
                    Output.Write(e.Message);
                    Output.Write("Hmm. Why did you do that?");
                }
            }

            sw.Stop();

            PrintResults(string.Empty, results);
            Output.WriteFormat("Done in {0} milliseconds.", sw.ElapsedMilliseconds);
        }

        private void PrintResults(string text, IList<string> items)
        {
            Output.WriteFormat("{0}[{1}]", text, string.Join(",", items));
        }

        private async Task AwaitTasksWithIndicator(params Task[] tasks)
        {
            var ts = new CancellationTokenSource();
            var waitTask = ConsoleIndicator.WaitAsync(ts.Token);

            try
            {
                await Task.WhenAny(Task.WhenAll(tasks), waitTask);
            }
            catch (HttpRequestException e)
            {
                Output.Write(e.Message);
                Output.Write("Hmm. Why did you do that?");
            }

            ts.Cancel();
            ConsoleIndicator.Clear();
        }
    }
}
