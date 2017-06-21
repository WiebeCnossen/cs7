namespace Cs7.Fibo {
  using Cs7.Fibo.Util;

  public class Elegant : IFibo {
    public long Nth(int n) => new Fibo(n).ToLong();

    private class Fibo : ILong {
      private readonly ILong fibo;

      public Fibo(int n)
        : this(new Long(n)) {
      }

      private Fibo(ILong n) {
        this.fibo = new If(
          new LessThan(n, new Long(2)),
          () => new Long(1),
          () => new Plus(
                  new Fibo(new Minus(n, new Long(1))),
                  new Fibo(new Minus(n, new Long(2)))));
      }

      public long ToLong() => this.fibo.ToLong();
    }
  }
}