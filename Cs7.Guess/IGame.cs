namespace Cs7.Guess {
  public interface IGame<TMove> {
    bool Finished { get; }

    string Status { get; }

    Result<TMove, string> Parse(string input);

    void ApplyMove(TMove move);
  }
}