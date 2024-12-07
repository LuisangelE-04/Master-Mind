namespace mastermind;

using static mastermind.GuessEvaluator;

public class MasterMind {
  public static (Dictionary<Match, int> guess, int attempts,  GameStatus status) Play(IEnumerable<Colors> gameSelectedColors, IEnumerable<Colors> userProvidedColors, int attempts) {
    int MAX_ATTEMTPS = 20, MAX_COLORS = 6;
    int currentAttempt = attempts + 1;

    if (currentAttempt > MAX_ATTEMTPS) {
      throw new InvalidOperationException("You Lost");
    }

    var guessResult = Guess(gameSelectedColors, userProvidedColors);

    if (guessResult[Match.EXACT] == MAX_COLORS) {
      return (guessResult, currentAttempt, GameStatus.WON);
    }

    if (currentAttempt == MAX_ATTEMTPS) {
      return (guessResult, currentAttempt, GameStatus.LOST);
    }

    return (guessResult, currentAttempt, GameStatus.IN_PROGRESS);
  }

}
