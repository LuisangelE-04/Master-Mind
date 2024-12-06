namespace mastermind;

public class MasterMind {
  public static Match MatchForPosition(int positionIndex, IEnumerable<Colors> selectedColors, IEnumerable<Colors> userProvidedColors) {
    var candidateColor = userProvidedColors.ElementAt(positionIndex);

    if (candidateColor == selectedColors.ElementAt(positionIndex)) {
      return Match.EXACT;
    }

    if (userProvidedColors.Take(positionIndex).Contains(candidateColor)) {
      return Match.NONE;
    }

    int index = selectedColors.ToList().IndexOf(candidateColor);

    if (index > -1 && selectedColors.ElementAt(index) != userProvidedColors.ElementAt(index)) {
      return Match.POSITION;
    }

    return Match.NONE;
  }

  public static Dictionary<Match, int> Guess(List<Colors> selectedColors, List<Colors> userProvidedColors) {
    int MAX_COLORS = 6;

    var matches = Enumerable.Range(0, MAX_COLORS).Select(positionIndex => MatchForPosition(positionIndex, selectedColors, userProvidedColors));
    
    var results = matches.GroupBy(match => match).ToDictionary(group => group.Key, group => group.Count());

    foreach (Match match in Enum.GetValues(typeof(Match))) {
      if (!results.ContainsKey(match)) {
        results[match] = 0;
      }
    }

    return results;
  }

}