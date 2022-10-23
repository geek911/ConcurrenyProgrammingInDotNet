

var t1 = Task.Factory.StartNew(() => throw new Exception("This is from task1"));


var t2 = Task.Factory.StartNew(() => throw new FormatException("This is from task2"));


try
{
    Task.WaitAll(t1, t2);
}
catch (AggregateException e)
{

    foreach (var s in e.InnerExceptions)
    {
        Console.WriteLine(s.Message);
    }
    e.Handle(exception =>
    {
        if (exception is FormatException)
        {
            // if you handled the exception
            return true;
        }
        // if you did not
        return false;
    });
}

