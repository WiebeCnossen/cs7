namespace Cs7.Fibo.Util {
  public class Minus : ILong {
    private readonly ILong left;

    private readonly ILong right;

    public Minus(ILong left, ILong right) {
      this.left = left;
      this.right = right;
    }

    public long ToLong() => this.left.ToLong() - this.right.ToLong();
  }
}