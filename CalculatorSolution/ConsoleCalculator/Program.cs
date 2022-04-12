namespace ConsoleCalculator;
class Program
{
    static void Main()
    {
        //Synchronous();
        //Asynchronous();
        Nice();
        Console.WriteLine("End..");
        Console.ReadLine();
    }

    private static async void Nice()
    {
        Task<int> t1 = new Task<int>(() =>
        {
            int result = LongAdd(7, 2);
            return result;
        });

        t1.Start();

        int result = await t1;
        Console.WriteLine(result);

        result = await Task.Run(() => LongAdd(3, 8));
        Console.WriteLine(result);

        result = await LongAddAsync(9, 6);
        Console.WriteLine(result);
    }

    private static void Asynchronous()
    {
        int a = 4;
        Task<int> t1 = new Task<int>(()=>
        {
            int result = LongAdd(a, 2);
            return result;
        });

        Task.Run(() => LongAdd(3, 8))
            .ContinueWith((pt) => {
                Console.WriteLine(pt.Result);
            }).
            ContinueWith(t => Console.WriteLine("Parallel"));

        //t1.Start();
       
    }

    static void DoCalc()
    {
        Synchronous();
    }
    private static void Synchronous()
    {
        int result = LongAdd(1, 2);
        Console.WriteLine(result);
    }

    static int LongAdd(int a, int b)
    {
        Task.Delay(10000).Wait();
        return a + b;
    }
    static Task<int> LongAddAsync(int a, int b)
    {
        return Task.Run(() => LongAdd(a, b));
    }
}
