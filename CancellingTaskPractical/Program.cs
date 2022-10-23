

/*
 * Simple way to cancel a token using if or exception
 */
static void SimpleExample()
{
    var cts = new CancellationTokenSource();
    var token = cts.Token;

    var task = Task.Factory.StartNew(() =>
    {
        for (int i = 0; i < 20; i++)
        {
            // recommended way
            // token.ThrowIfCancellationRequested();
            
            if (token.IsCancellationRequested)
            {
                break;
            }
            Console.WriteLine($"Time : {i, 2}");
            Thread.Sleep(1000);
        }
    }, token);

    Console.ReadKey();
    cts.Cancel();
    Task.WaitAll(task);
}

static void GetInfromation()
{
    CancellationTokenSource cts = new CancellationTokenSource();
    CancellationToken token = cts.Token;

    token.Register(() =>
    {
        Console.WriteLine("Byee my g");
    }, true);
    
    token.Register(() =>
    {
        Console.WriteLine("Byee my m1");
    }, true);
    
    var task = Task.Factory.StartNew(() =>
    {
        for (int i = 0; i < 20; i++)
        {
            // recommended way
            // token.ThrowIfCancellationRequested();
            
            if (token.IsCancellationRequested)
            {
                break;
            }
            Console.WriteLine($"Time : {i, 2}");
            Thread.Sleep(1000);
        }
    }, token);
    
    var task1 = Task.Factory.StartNew(() =>
    {
        for (int i = 0; i < 20; i++)
        {
            // recommended way
            // token.ThrowIfCancellationRequested();

            token.WaitHandle.WaitOne();
            Console.WriteLine($"Haha : {i, 2}");
            Thread.Sleep(1000);
        }
    }, token);
    
    Console.ReadKey();
    cts.Cancel();
    Task.WaitAll(task, task1);
}

static void MultipleTokenExample()
{
    CancellationTokenSource cts1 = new CancellationTokenSource();
    CancellationTokenSource cts2 = new CancellationTokenSource();
    CancellationTokenSource cts3 = new CancellationTokenSource();
    CancellationTokenSource cts = CancellationTokenSource.CreateLinkedTokenSource(cts1.Token, cts2.Token, cts3.Token);

    CancellationToken token = cts.Token;
    
    var task = Task.Factory.StartNew(() =>
    {
        for (int i = 0; i < 20; i++)
        {
            // recommended way
            // token.ThrowIfCancellationRequested();
            
            if (cts1.Token.IsCancellationRequested)
            {
                break;
            }
            Console.WriteLine($"Time : {i, 2}");
            Thread.Sleep(1000);
        }
    }, cts1.Token);
    
    Console.ReadKey();
    cts.Cancel();
    Task.WaitAll(task, task);
}
MultipleTokenExample();