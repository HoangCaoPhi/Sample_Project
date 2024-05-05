namespace Sample_UnitTest.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsValidLogFileName_GoodExtensionLowercase_ReturnsTrue()
        {
            // Arrange
            LogAnalyzer analyzer = new();

            // Act
            bool result = analyzer.IsValidLogFileName("filewithgoodextension.txt");

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void IsValidLogFileName_GoodExtensionUppercase_ReturnsTrue()
        {
            // Arrange
            LogAnalyzer analyzer = new();

            // Act
            bool result = analyzer.IsValidLogFileName("filewithgoodextension.TXT");

            // Assert
            Assert.That(result, Is.True);
        }
    }
}