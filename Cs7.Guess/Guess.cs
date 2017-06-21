namespace Cs7.Guess {
  using System;
  using System.Globalization;

  using static Result<Guess, string>;

  public class Guess {
    public const int Lower = 0;

    public const int Upper = 50;

    private Guess(int value) {
      this.Value = value;
    }

    public int Value { get; }

    public static bool TryParse(string input, out Guess guess, out string errorInfo) {
      if (!int.TryParse(input, NumberStyles.None, CultureInfo.InvariantCulture, out var value)) {
        guess = null;
        errorInfo = "Not a valid number.";
        return false;
      }

      if (value < Lower) {
        guess = null;
        errorInfo = $"Number should be at least {Lower}.";
        return false;
      }

      if (value >= Upper) {
        guess = null;
        errorInfo = $"Number should be less than {Upper}.";
        return false;
      }

      guess = new Guess(value);
      errorInfo = null;
      return true;
    }

    public static Result<Guess, string> Parse(string input) {
      return !int.TryParse(input, NumberStyles.None, CultureInfo.InvariantCulture, out var move)
               ? new Error("Not a valid number.")
               : move < Lower
                 ? new Error($"Number should be at least {Lower}.")
                 : move >= Upper
                   ? new Error($"Number should be less than {Upper}.")
                   : (Result<Guess, string>)new Ok(new Guess(move));
    }

    public static Guess Random() => new Guess(Lower + new Random().Next(Upper - Lower));

    public static implicit operator int(Guess guess) => guess.Value;
  }
}