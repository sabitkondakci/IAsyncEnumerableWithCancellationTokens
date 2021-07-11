using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace TaskCancel__Asnyc
{
    class Program
    {
        static async Task Main(string[] args)
        {
           await GetNumbersWithTimeOutAsync(GetNumbersAsync(),TimeSpan.FromSeconds(10));
        }


        public static async IAsyncEnumerable<int> GetNumbersAsync(
            [EnumeratorCancellation] CancellationToken token = default)
        {
           for (int i = 0; i < 100; i++)
           {
               await Task.Delay(100,token);
               yield return i;
           }
        }

        static async Task StartGettingNumbersAsync(TimeSpan afterSecondsCancel)
        {
            try
            {
                int index = 0;
                using CancellationTokenSource canTokenSource = new CancellationTokenSource(afterSecondsCancel);
                await foreach (var item in GetNumbersAsync(canTokenSource.Token).ConfigureAwait(false))
                {
                    System.Console.WriteLine($"item[{index}] : {item}");
                    index++;
                }
            }
            catch (System.OperationCanceledException)
            {
                System.Console.WriteLine("Operation has been canceled");
            }
        }

        static async Task GetNumbersWithTimeOutAsync(IAsyncEnumerable<int> items,TimeSpan timeout)
        {
           try
           {
               int index = 0;
               using CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(timeout);
               await foreach (var item in items.WithCancellation(cancellationTokenSource.Token).ConfigureAwait(false))
               {
                   System.Console.WriteLine($"item[{index}] : {item}");
                   index++;
               }
           }
           catch (System.OperationCanceledException)
           {
               System.Console.WriteLine("Request timed out, please check your network connection");
           }
        }

    }
   
}
