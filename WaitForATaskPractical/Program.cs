
Console.WriteLine("Simple Wait Task-------------------");
 Task simpleWaitTask = Task.Factory.StartNew(() =>
    {

        SpinWait.SpinUntil(() => false, 2000);
        Console.WriteLine($"Simple Wait : {2000}");

    });
simpleWaitTask.Wait();

Console.WriteLine(" Wait Task ALl/ Any-------------------");
Task t1 = Task.Factory.StartNew(() =>
{
    for (int i = 0; i < 11; i++)
    {
        Thread.Sleep(1000);
    }
});


Task t2 = Task.Factory.StartNew(() =>
{
    
    for (int i = 0; i < 11; i++)
    {
        Thread.Sleep(1000);


    }
});

// waits for any task to finish and vice versa for all
Task.WaitAny(new []{t1, t2}, TimeSpan.FromSeconds(10));

