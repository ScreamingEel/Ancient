global using ECS.Experimental.Components;
global using ECS.Experimental.Systems;
using ECS.Experimental;
using System.Diagnostics;

bool nextRound = true;

do
{
    Console.WriteLine("-------------------------");
    Console.WriteLine("How many runs?");
    long runs = Convert.ToInt32(Console.ReadLine());
    //ListBased(runs);
    TypedContext(runs);

    Console.WriteLine("Stop here (y)?");
    
    if (Console.ReadLine() == "y")
        nextRound = false;
}
while (nextRound);

void TypedContext(long runs)
{
    Console.WriteLine("Type based Context");
    Stopwatch stopwatch = Stopwatch.StartNew();
    TypeBasedContext context = new();
    for (long i = 0; i < runs; i++)
    {
        if (i % 2 == 0)
            context.AddComponent(new MoneyComponent());
        //else
        //    context.AddComponent(new FruitComponent());
    }
    stopwatch.Stop();
    TakenTime(stopwatch.ElapsedMilliseconds, runs);
    context.Dispose();
}

void ListBased(long runs)
{
    Console.WriteLine("List based Context");
    Stopwatch stopwatch = Stopwatch.StartNew();
    BankSystem bankSystem = new();
    FruitSystem fruitSystem = new();
    MoneyFruitSystem moneyFruitSystem = new();
    ListBasedContainer<MoneyComponent> moneyContainer = new ListBasedContainer<MoneyComponent>(
        new() { bankSystem, moneyFruitSystem });
    ListBasedContainer<FruitComponent> fruitContainer = new ListBasedContainer<FruitComponent>(
        new() { fruitSystem, moneyFruitSystem });
    for (long i = 0; i < runs; i++)
    {
        if (i % 2 == 0)
            moneyContainer.AddComponent(new MoneyComponent());
        else
            fruitContainer.AddComponent(new FruitComponent());
    }
    stopwatch.Stop();
    TakenTime(stopwatch.ElapsedMilliseconds, runs);
}

void TakenTime(long milliseconds, long runs)
{
    Console.WriteLine($"{runs} runs take {milliseconds} Milliseconds");
    Console.WriteLine($"{runs} runs take {milliseconds / 1000} Seconds");
    Console.WriteLine($"{runs} runs take {milliseconds / 1000 / 60} Minutes");
}