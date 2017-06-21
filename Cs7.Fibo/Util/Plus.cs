namespace Cs7.Fibo.Util {
  public class Plus : ILong {
    private readonly ILong left;

    private readonly ILong right;

    public Plus(ILong left, ILong right) {
      this.left = left;
      this.right = right;
    }

    public long ToLong() => this.left.ToLong() + this.right.ToLong();
  }
}