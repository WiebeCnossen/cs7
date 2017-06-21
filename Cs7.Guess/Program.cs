namespace Cs7.Guess {
  using System;

  using static Result<Guess, string>;

  public class Program {
    private static void Main() {
      IGame<Guess> game = new GuessGame();
      Console.WriteLine(game.Status);

      while (!game.Finished) {
        var move = ReadMoveUntilValid(game);
        game.ApplyMove(move);
        Console.WriteLine(game.Status);
      }
    }

    private static Guess ReadMoveUntilValid(IGame<Guess> game) {
      Console.Write("> ");
      switch (game.Parse(Console.ReadLine())) {
        case Ok move:
          return move;
        case Error message:
          Console.WriteLine(message);
          return ReadMoveUntilValid(game);
        default:
          throw new InvalidOperationException($"Result should be either {nameof(Ok)} or {nameof(Error)}");
      }
    }
  }
}