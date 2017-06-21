namespace Cs7.Fibo.Util {
  using System;

  public class If : ILong {
    private readonly IBool guard;

    private readonly Func<ILong> negative;

    private readonly Func<ILong> positive;

    public If(IBool guard, Func<ILong> positive, Func<ILong> negative) {
      this.guard = guard ?? throw new ArgumentNullException(nameof(guard));
      this.positive = positive ?? throw new ArgumentNullException(nameof(positive));
      this.negative = negative ?? throw new ArgumentNullException(nameof(negative));
    }

    public long ToLong() => this.guard.ToBool() ? this.positive().ToLong() : this.negative().ToLong();
  }
}