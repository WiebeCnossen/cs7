namespace Cs7.Fibo {
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;

  internal class Program {
    private static void Main() {
      void Fibos(IFibo fibo, int from, int to) {
        foreach (var n in Enumerable.Range(from, to - from)) {
          Console.WriteLine($"{n} => {fibo.Nth(n)}");
        }
      }

      Fibos(new Elegant(), 0, 5);
      Fibos(new Recursive(), 5, 10);
      Fibos(new Sequential(), 10, 15);

      Console.WriteLine("Doing benchmarks...");
      var lines = new List<string> {
        Benchmark(new Elegant(), 35),
        Benchmark(new Recursive(), 35),
        Benchmark(new Sequential(), 35)
      };
      Console.WriteLine("I am ready, are you too?");
      Console.ReadKey(true);
      lines.ForEach(Console.WriteLine);
    }

    private static string Benchmark(IFibo fibo, int n) {
      var sum = 0L;
      var sw = Stopwatch.StartNew();
      for (var i = 0; i < 10; i++) {
        sum += fibo.Nth(n);
      }

      sw.Stop();
      return $"{fibo.GetType().Name} : {sw.ElapsedMilliseconds}ms (sum {sum})";
    }
  }
}