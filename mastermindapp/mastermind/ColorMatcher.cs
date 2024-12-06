namespace mastermind;

public static class ColorMatcher {
  public static Match MatchForPosition(int positionIndex, IEnumerable<Colors> selectedColors, IEnumerable<Colors> userProvidedColors) {
    var candidateColor = userProvidedColors.ElementAt(positionIndex);

    if (candidateColor == selectedColors.ElementAt(positionIndex)) {
      return Match.EXACT;
    }

    if (userProvidedColors.Take(positionIndex).Contains(candidateColor)) {
      return Match.NONE;
    }

    var index = selectedColors.ToList().IndexOf(candidateColor);

    if (index > -1 && selectedColors.ElementAt(index) != userProvidedColors.ElementAt(index)) {
      return Match.POSITION;
    }

    return Match.NONE;
  }
}
