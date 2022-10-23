using System.Threading.Tasks;

//Passing the argument, but the problem is boxing and unboxing
Task.Factory.StartNew(WordPrinterObj, '?');

// Creates and start a task at the same time
Task.Factory.StartNew(() => WordPrinter('O'));

//Creates and start a task separately
Task task = new Task(() => WordPrinter('-'));
task.Start();


// Return values
Task<int> counterTask = Task.Factory.StartNew(() => WordCounter("Moses Chawawa"));

// Result is blocking
Console.WriteLine($"Word Counter : {counterTask.Result}");


static int WordCounter(string word)
{
    return word.Length;
}

static void WordPrinter(char character)
{
    for (int i = 0; i < 1000; i++)
    {
        Console.Write(character);
    }
}

static void WordPrinterObj(object character)
{
    for (int i = 0; i < 1000; i++)
    {
        Console.Write(character);
    }
}