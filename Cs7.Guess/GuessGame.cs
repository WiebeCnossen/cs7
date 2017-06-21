namespace Cs7.Guess {
  using System;

  using static Ordering;

  public sealed class GuessGame : IGame<Guess> {
    private readonly Guess solution = Guess.Random();

    private GuessState state;

    public GuessGame() {
      this.state = GuessState.Initial();
    }

    public bool Finished => this.state.Finished;

    public string Status => this.state.Status;

    public Result<Guess, string> Parse(string input) {
      return this.Finished
               ? throw new InvalidOperationException("There is no move in a finished game.")
               : Guess.Parse(input);
    }

    public void ApplyMove(Guess move) {
      Ordering ordering;
      switch (move.Value.CompareTo(this.solution.Value)) {
        case var n when n < 0:
          ordering = Less;
          break;
        case var n when n > 0:
          ordering = Greater;
          break;
        default:
          ordering = Equal;
          break;
      }

      this.state = this.state.Next(ordering);
    }
  }
}