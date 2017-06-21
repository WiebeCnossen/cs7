namespace Cs7.Guess {
  public class Result<TValue, TError> {
    public class Ok : Result<TValue, TError> {
      public Ok(TValue value) {
        this.Value = value;
      }

      private TValue Value { get; }

      public static implicit operator TValue(Ok ok) {
        return ok.Value;
      }

      public void Deconstruct(out TValue value) {
        value = this.Value;
      }
    }

    public class Error : Result<TValue, TError> {
      public Error(TError info) {
        this.Info = info;
      }

      private TError Info { get; }

      public static implicit operator TError(Error error) {
        return error.Info;
      }

      public void Deconstruct(out TError message) {
        message = this.Info;
      }
    }
  }
}