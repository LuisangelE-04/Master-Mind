namespace mastermind.Tests;

using System.Runtime.CompilerServices;
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

  [Test]
  public void PlaySecondAttemptExactMatch() {
    var selectedColors = new List<Colors> { Red, Blue, Green, Yellow, Purple, Orange };
    var userProvidedColors = selectedColors;
    var numberOfAttempts = 1;

    var expectedResult = (new Dictionary<Match, int> { { Match.EXACT, 6 }, { Match.POSITION, 0 }, { Match.NONE, 0 } }, 2, GameStatus.WON);

    var response = Play(selectedColors, userProvidedColors, numberOfAttempts);

    Assert.AreEqual(expectedResult, response);
  }

  [Test]
  public void PlaySecondAttemptNoMatches() {
    var selectedColors = new List<Colors> { Red, Blue, Green, Yellow, Purple, Orange };
    var userProvidedColors = new List<Colors> { Black, Pink, Black, Pink, Black, Pink };
    var numberOfAttempts = 1;

    var expectedResult = (new Dictionary<Match, int> { { Match.EXACT, 0 }, { Match.POSITION, 0 }, { Match.NONE, 6 } }, 2, GameStatus.IN_PROGRESS);

    var response = Play(selectedColors, userProvidedColors, numberOfAttempts);

    Assert.AreEqual(expectedResult, response);
  }

  [Test]
  public void PlayTwentiethAttemptExactMatch() {
    var selectedColors = new List<Colors> { Red, Blue, Green, Yellow, Purple, Orange };
    var userProvidedColors = selectedColors;
    var numberOfAttempts = 19;

    var expectedResult = (new Dictionary<Match, int> { { Match.EXACT, 6 }, { Match.POSITION, 0 }, { Match.NONE, 0 } }, 20, GameStatus.WON);

    var response = Play(selectedColors, userProvidedColors, numberOfAttempts);

    Assert.AreEqual(expectedResult, response);
  }

  [Test]
  public void PlayTwentiethAttemptNoMatches() {
    var selectedColors = new List<Colors> { Red, Blue, Green, Yellow, Purple, Orange };
    var userProvidedColors = new List<Colors> { Black, Pink, Black, Pink, Black, Pink };
    var numberOfAttempts = 19;

    var expectedResult = (new Dictionary<Match, int> { { Match.EXACT, 0 }, { Match.POSITION, 0 }, { Match.NONE, 6 } }, 20, GameStatus.LOST);

    var response = Play(selectedColors, userProvidedColors, numberOfAttempts);

    Assert.AreEqual(expectedResult, response);
  }

  [Test]
  public void PlayTwentiethAttemptSomeExactAndSomeNonExactMatches() {
    var selectedColors = new List<Colors> { Red, Blue, Green, Yellow, Purple, Orange };
    var userProvidedColors = new List<Colors> { Red, Blue, Pink, Yellow, Black, Purple };
    var numberOfAttempts = 19;

    var expectedResult = (new Dictionary<Match, int> { { Match.EXACT, 3 }, { Match.POSITION, 1 }, { Match.NONE, 2 } }, 20, GameStatus.LOST);

    var response = Play(selectedColors, userProvidedColors, numberOfAttempts);

    Assert.AreEqual(expectedResult, response);
  }
}