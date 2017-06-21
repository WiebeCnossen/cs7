namespace Cs7.Fibo {
  using System;
  using System.Collections.Generic;
  using System.Linq;

  public class Sequential : IFibo {
    public IEnumerable<long> All => Enumerable.Repeat(0, int.MaxValue).Select(Generator());

    public long Nth(int n) => this.All.ElementAt(n);

    private static (long, long) Next((long, long) state) {
      var (previous, current) = state;
      return (current, previous + current);
    }

    private static Func<int, long> Generator() {
      (long, long) state = (0, 1);

      long Step(int _) {
        state = Next(state);
        var (current, _) = state;
        return current;
      }

      return Step;
    }
  }
}