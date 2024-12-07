namespace mastermind.Tests;

using static mastermind.Colors;
using static mastermind.MasterMind;

[TestFixture]
public class MasterMindTests {
  [SetUp]
  public void SetUp() {

  }

  [Test]
  public void PlayFirstAttemptAllMatches() {
    var selectedColors = new List<Colors> { Red, Blue, Green, Yellow, Purple, Orange };
    var userProvidedColors = selectedColors;
    var numberOfAttempts = 0;

    var expectedResult = (new Dictionary<Match, int> { { Match.EXACT, 6 }, { Match.POSITION, 0 }, { Match.NONE, 0 } }, 1, GameStatus.WON);

    var response = Play(selectedColors, userProvidedColors, numberOfAttempts);

    Assert.AreEqual(expectedResult, response);
  }

  [Test]
  public void PlayFirstAttemptNoMatches() {
    var selectedColors = new List<Colors> { Red, Blue, Green, Yellow, Purple, Orange };
    var userProvidedColors = new List<Colors> { Black, Pink, Black, Pink, Black, Pink };
    var numberOfAttempts = 0;

    var expectedResult = (new Dictionary<Match, int> { {Match.EXACT, 0 }, { Match.POSITION, 0 }, { Match.NONE, 6 } }, 1, GameStatus.IN_PROGRESS);

    var response = Play(selectedColors, userProvidedColors, numberOfAttempts);

    Assert.AreEqual(expectedResult, response);
  }

  [Test]
  public void PlayFirstAttemptSomeExactAndSomeNonExactMatches() {
    var selectedColors = new List<Colors> { Red, Blue, Green, Yellow, Purple, Orange };
    var userProvidedColors = new List<Colors> { Red, Blue, Pink, Yellow, Black, Purple };
    var numberOfAttempts = 0;

    var expectedResult = (new Dictionary<Match, int> { { Match.EXACT, 3 }, { Match.POSITION, 1 }, { Match.NONE, 2 } }, 1, GameStatus.IN_PROGRESS);

    var response = Play(selectedColors, userProvidedColors, numberOfAttempts);

    Assert.AreEqual(expectedResult, response);
  }
}