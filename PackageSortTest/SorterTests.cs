using PackageSort;

namespace PackageSortTest
{
    using NUnit.Framework;

    [TestFixture]
    public class SorterTests
    {
        [TestCase(0, 10, 10, 10)]
        [TestCase(10, -1, 10, 10)]
        [TestCase(10, 10, 0, 10)]
        [TestCase(10, 10, 10, -5)]
        public void Sort_InvalidInputs_ReturnsRejected(
            double width, double height, double length, double mass)
        {
            //Arrange
            var expected = "REJECTED";

            //Act
            var result = Sorter.sort(width, height, length, mass);

            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Sort_StandardPackage_ReturnsStandard()
        {
            //Arrange
            var expected = "STANDARD";

            //Act
            var result = Sorter.sort(10, 10, 10, 5);

            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Sort_BulkyByDimension_ReturnsSpecial()
        {
            //Arrange
            var expected = "SPECIAL";

            //Act
            var result = Sorter.sort(150, 10, 10, 5);

            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Sort_BulkyByVolume_ReturnsSpecial()
        {
            //Arrange
            var expected = "SPECIAL";

            //Act
            // Volume = 1,000,000 (boundary)
            var result = Sorter.sort(100, 100, 100, 5);

            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Sort_HeavyOnly_ReturnsSpecial()
        {
            //Arrange
            var expected = "SPECIAL";

            //Act
            var result = Sorter.sort(10, 10, 10, 20);

            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Sort_BulkyAndHeavy_ReturnsRejected()
        {
            //Arrange
            var expected = "REJECTED";

            //Act
            var result = Sorter.sort(150, 10, 10, 20);

            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(149.9, 1, 1, 19.9)]
        [TestCase(1, 149.9, 1, 19.9)]
        [TestCase(1, 1, 149.9, 19.9)]
        [TestCase(149, 149, 45, 19.9)]
        public void Sort_JustBelowThresholds_ReturnsStandard(double width, double height, double length, double mass)
        {
            //Arrange
            var expected = "STANDARD";

            //Act
            var result = Sorter.sort(width, height, length, mass);

            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Sort_ExactDimensionAndWeightThreshold_ReturnsRejected()
        {
            //Arrange
            var expected = "REJECTED";

            //Act
            //Exactly at bulky dimension threshold and heavy threshold
            var result = Sorter.sort(150, 10, 10, 20);

            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
