namespace Cs7.Guess {
  using System;

  public enum Ordering {
    Less,

    Equal,

    Greater
  }

  public abstract class GuessState {
    public abstract string Status { get; }

    public abstract bool Finished { get; }

    public static GuessState Initial() {
      return new Start();
    }

    public abstract GuessState Next(Ordering ordering);

    private sealed class Start : GuessState {
      public override bool Finished => false;

      public override string Status => $"Start: find the number between {Guess.Lower} and {Guess.Upper - 1} inclusive.";

      public override GuessState Next(Ordering ordering) {
        return ordering == Ordering.Equal ? new Success() : (GuessState)new Wrong(ordering, 2);
      }
    }

    private sealed class Wrong : GuessState {
      // The 1 based number of the attempt we are waiting for
      private readonly int attempt;

      private readonly string relation;

      public Wrong(Ordering ordering, int attempt) {
        this.relation = ordering.ToString().ToLowerInvariant();
        this.attempt = attempt;
      }

      public override bool Finished => false;

      public override string Status => $"Wrong, the number you gave was {this.relation} than the solution";

      public override GuessState Next(Ordering ordering) {
        return ordering == Ordering.Equal
                 ? new Success()
                 : this.attempt == 5
                   ? new Fail()
                   : (GuessState)new Wrong(ordering, this.attempt + 1);
      }
    }

    private sealed class Success : GuessState {
      public override bool Finished => true;

      public override string Status => "Correct, you did it!";

      public override GuessState Next(Ordering ordering) {
        throw new InvalidOperationException($"Cannot move beyond {nameof(Success)} state.");
      }
    }

    private sealed class Fail : GuessState {
      public override bool Finished => true;

      public override string Status => "You failed! Better luck next time.";

      public override GuessState Next(Ordering ordering) {
        throw new InvalidOperationException($"Cannot move beyond {nameof(Fail)} state.");
      }
    }
  }
}