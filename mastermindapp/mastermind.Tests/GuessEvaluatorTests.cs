namespace mastermind.Tests;

using static mastermind.Colors;
using static mastermind.GuessEvaluator;

[TestFixture]
  public class GuessEvaluatorTests {
  [SetUp]
  public void Setup() {
    
  }

  [Test]
  public void Canary() {
    Assert.Pass();
  }

  [Test]
  public void GuessWhereAllColorsMatch() {
    var selectedColors = new List<Colors> { Red, Blue, Green, Yellow, Purple, Orange };
    var userProvidedColors = selectedColors;
    
    var expectedResult = new Dictionary<Match, int> { {Match.EXACT, 6 }, { Match.POSITION, 0 }, {Match.NONE, 0 } };
    
    var response = Guess(selectedColors, userProvidedColors);

    CollectionAssert.AreEqual(expectedResult, response);
  }

  [Test]
  public void GuessWhereNoColorsMatch() {
    var selectedColors = new List<Colors> { Red, Blue, Green, Yellow, Purple, Orange };
    var userProvidedColors = new List<Colors> { Black, Pink, Black, Pink, Black, Pink };

    var expectedResult = new Dictionary<Match, int> { {Match.EXACT, 0 }, { Match.POSITION, 0 }, {Match.NONE, 6 } };

    var response = Guess(selectedColors, userProvidedColors);

    CollectionAssert.AreEqual(expectedResult, response);
  }

  [Test]
  public void GuessWhereAllColorsMatchButNotInSamePosition() {
    var selectedColors = new List<Colors> { Red, Blue, Green, Yellow, Purple, Orange };
    var userProvidedColors = new List<Colors> { Orange, Purple, Yellow, Green, Blue, Red };

    var expectedResult = new Dictionary<Match, int> { {Match.EXACT, 0 }, { Match.POSITION, 6 }, {Match.NONE, 0 } };

    var response = Guess(selectedColors, userProvidedColors);
    CollectionAssert.AreEqual(expectedResult, response);
  }

  [Test]
  public void GuessWithFirstFourColorsMatchInPosition() {
    var selectedColors = new List<Colors> { Red, Blue, Green, Yellow, Purple, Orange };
    var userProvidedColors = new List<Colors> { Red, Blue, Green, Yellow, Pink, Brown };

    var expectedResult = new Dictionary<Match, int> { {Match.EXACT, 4 }, { Match.POSITION, 0 }, {Match.NONE, 2 } };

    var response = Guess(selectedColors, userProvidedColors);

    CollectionAssert.AreEqual(expectedResult, response);
  }

  [Test]
  public void GuessWithLastFourColorsMatchInPosition() {
    var selectedColors = new List<Colors> { Red, Blue, Green, Yellow, Purple, Orange };
    var userProvidedColors = new List<Colors> { Pink, Brown, Green, Yellow, Purple, Orange };

    var expectedResult = new Dictionary<Match, int> { {Match.EXACT, 4 }, { Match.POSITION, 0 }, {Match.NONE, 2 } };

    var response = Guess(selectedColors, userProvidedColors);

    CollectionAssert.AreEqual(expectedResult, response);
  }

  [Test]
  public void GuessWithFirstThreeColorsMatchInPositionAndLastThreeOutOfPosition() {
    var selectedColors = new List<Colors> { Red, Blue, Green, Yellow, Purple, Orange };
    var userProvidedColors = new List<Colors> { Red, Blue, Green, Orange, Yellow, Purple };

    var expectedResult = new Dictionary<Match, int> { {Match.EXACT, 3 }, { Match.POSITION, 3 }, {Match.NONE, 0 } };

    var response = Guess(selectedColors, userProvidedColors);

    CollectionAssert.AreEqual(expectedResult, response);
  }

  [Test]
  public void GuessWithFirstAndThirdMismatchSecondInPositionOthersOutOfPosition() {
    var selectedColors = new List<Colors> { Red, Blue, Green, Yellow, Purple, Orange };
    var userProvidedColors = new List<Colors> { Pink, Blue, Black, Orange, Yellow, Purple };

    var expectedResult = new Dictionary<Match, int> { {Match.EXACT, 1 }, { Match.POSITION, 3 }, {Match.NONE, 2 } };

    var response = Guess(selectedColors, userProvidedColors);

    CollectionAssert.AreEqual(expectedResult, response);
  }

  [Test]
  public void GuessWithFirstColorInSelectedColorsRepeatedFiveTimes() {
    var selectedColors = new List<Colors> { Red, Blue, Green, Yellow, Purple, Orange };
    var userProvidedColors = new List<Colors> { Red, Red, Red, Red, Red, Red };

    var expectedResult = new Dictionary<Match, int> { {Match.EXACT, 1 }, { Match.POSITION, 0 }, {Match.NONE, 5 } };

    var response = Guess(selectedColors, userProvidedColors);

    CollectionAssert.AreEqual(expectedResult, response);
  }

  [Test]
  public void GuessWithLastColorInSelectedColorsRepeatedFiveTimes() {
    var selectedColors = new List<Colors> { Red, Blue, Green, Yellow, Purple, Orange };
    var userProvidedColors = new List<Colors> { Orange, Orange, Orange, Orange, Orange, Orange };

    var expectedResult = new Dictionary<Match, int> { {Match.EXACT, 1 }, { Match.POSITION, 0 }, {Match.NONE, 5 } };

    var response = Guess(selectedColors, userProvidedColors);

    CollectionAssert.AreEqual(expectedResult, response);
  }

  [Test]
  public void GuessWithFirstColorInSelectedColorsRepeatedFromTwoToSixWithFirstPositionHavingSecondColorInSelection() {
    var selectedColors = new List<Colors> { Red, Blue, Green, Yellow, Purple, Orange };
    var userProvidedColors = new List<Colors> { Blue, Red, Red, Red, Red, Red };

    var expectedResult = new Dictionary<Match, int> { {Match.EXACT, 0 }, { Match.POSITION, 2 }, {Match.NONE, 4 } };

    var response = Guess(selectedColors, userProvidedColors);

    CollectionAssert.AreEqual(expectedResult, response);
  }

  [Test]
  public void GuessWithFirstColorInSelectionRepeatedFromTwoTotSixAndFirstPositionNoMatch() {
    var selectedColors = new List<Colors> { Red, Blue, Green, Yellow, Purple, Orange };
    var userProvidedColors = new List<Colors> { Pink, Red, Red, Red, Red, Red };

    var expectedResult = new Dictionary<Match, int> { {Match.EXACT, 0 }, { Match.POSITION, 1 }, {Match.NONE, 5 } };

    var response = Guess(selectedColors, userProvidedColors);

    CollectionAssert.AreEqual(expectedResult, response);
  }
}
