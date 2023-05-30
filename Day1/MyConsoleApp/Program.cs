Console.WriteLine("Main NO.1");
_ = StartIt();
Console.WriteLine("Main NO.2");
Console.ReadLine();

async Task StartIt()
{
    for (int i = 0; i < 10000; i++)
    {
        Console.WriteLine("StartIt 1");
    }
    await MethodA();
    Console.WriteLine("StartIt 2");
}

async Task MethodA()
{
    for (int i = 1; i <= 3; i++)
    {
        await Task.Delay(2000);
        Console.WriteLine($"Method A {i}");
    }
}