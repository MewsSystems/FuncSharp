using System;

namespace FuncSharp.Performance
{
    class Program
    {
        static void Main(string[] args)
        {
            var cube = new DataCube3<int, int, int, int>();
            var iterations = 100;

            for (var i = 0; i < iterations; i++)
            {
                Console.WriteLine($"Iteration {i}/{iterations}");

                for (var j = 0; j < 100; j++)
                {
                    for (var k = 0; k < 100; k++)
                    {
                        var value = i + j + k;

                        cube.Set(i, j, k, value);
                        if (cube.Get(i, j, k).Get() != value)
                        {
                            throw new InvalidOperationException();
                        }
                    }
                }
            }
        }
    }
}
