namespace mastermind;

using static mastermind.ColorMatcher;

public class MasterMind {
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
