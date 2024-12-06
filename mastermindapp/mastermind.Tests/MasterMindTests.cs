namespace mastermind.Tests;

using static mastermind.Colors;
using static mastermind.MasterMind;

[TestFixture]
  public class Test {
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
}
