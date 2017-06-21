namespace Cs7.Fibo {
  public class Recursive : IFibo {
    public long Nth(int n) => n < 2 ? 1L : this.Nth(n - 2) + this.Nth(n - 1);
  }
}