namespace Cs7.Fibo.Util {
  public class Long : ILong {
    private readonly long value;

    public Long(long value) => this.value = value;

    public long ToLong() => this.value;
  }
}