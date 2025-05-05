var rng = new Random();
var sum = 0;
for (var num = 1; num < 100_000_000; num++)
{
    var x = rng.NextDouble();
    var y = rng.NextDouble();
    if (x * x + y * y < 1.0)
        sum++;
    if ((num % 1000 == 0))
    {
        Console.Write($"\r{num} iterations: {4.0 * sum / num}");
    }
}

//var rng = new Random();
//var sum = 0;
//for (var num = 1; num < 100_000_000; num++)
//{
//    var x = rng.NextDouble();
//    var y = rng.NextDouble();
//    var z = rng.NextDouble();
//    if (x * x + y * y + z * z < 1.0)
//        sum++;
//    if ((num % 1000 == 0))
//    {
//        Console.Write($"\r{num} iterations: {6.0 * sum / num}");
//    }
//}
