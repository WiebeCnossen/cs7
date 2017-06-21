namespace Cs7.Fibo.Util {
  public class LessThan : IBool {
    private readonly ILong left;

    private readonly ILong right;

    public LessThan(ILong left, ILong right) {
      this.left = left;
      this.right = right;
    }

    public bool ToBool() => this.left.ToLong() < this.right.ToLong();
  }
}