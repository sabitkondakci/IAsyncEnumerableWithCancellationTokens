using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace IAsyncEnumerable
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await ReadLineByLineAsync();
        }

        public static async Task ReadLineByLineAsync()
        {
            var path = Path.Combine(Environment.CurrentDirectory,"sample.txt");

            var perLine = GetLineAsync(path);
            await foreach (var item in perLine)
            {
                Console.WriteLine(item);
            }
        }

        static async IAsyncEnumerable<string> GetLineAsync(string filePath)
        {
            string line = string.Empty;
            using var reader = new StreamReader(filePath);

            while (line != null)
            {
                line = await reader.ReadLineAsync();// ConfigureAwait(false); .Net Legacy Code
                await Task.Delay(1000);
                yield return line;
            }
        }
    }
}
