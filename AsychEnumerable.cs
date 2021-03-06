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
            await foreach (var item in perLine.ConfigureAwait(false))
            {
                Console.WriteLine(item);
            }

            //same 
            /*

            await using IAsyncEnumerator<string> enumerator = perLine.GetAsyncEnumerator();
            while (await enumerator.MoveNextAsync())
            {
                var item = enumerator.Current;
                Console.WriteLine(item);
            }

            */
        }

        static async IAsyncEnumerable<string> GetLineAsync(string filePath)
        {
            string line = string.Empty;
            using var reader = new StreamReader(filePath);

            while (line != null)
            {
                line = await reader.ReadLineAsync().ConfigureAwait(false); // IO Stream may block UI thread, this shouldn'b be avoided.
                await Task.Delay(1000);
                yield return line;
            }
        }
    }
}
