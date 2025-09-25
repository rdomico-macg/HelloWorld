
using HelloWorld;

namespace HelloWorldTest
{
    [TestClass]
    public sealed class WeatherForecastTests
    {
        [TestMethod]
        public void TemperatureF_WhenTemperatureCIsZero_ReturnsThirtyTwo()
        {
            // Arrange
            var weatherForecast = new WeatherForecast { TemperatureC = 0 };

            // Act
            var result = weatherForecast.TemperatureF;

            // Assert
            Assert.AreEqual(32, result);
        }

        [TestMethod]
        public void TemperatureF_WhenTemperatureCIsOneHundred_ReturnsTwoElevenZero()
        {
            // Arrange
            var weatherForecast = new WeatherForecast { TemperatureC = 100 };

            // Act
            var result = weatherForecast.TemperatureF;

            // Assert
            Assert.AreEqual(211, result);
        }

        [TestMethod]
        public void TemperatureF_WhenTemperatureCIsNegativeTwenty_ReturnsNegativeThree()
        {
            // Arrange
            var weatherForecast = new WeatherForecast { TemperatureC = -20 };

            // Act
            var result = weatherForecast.TemperatureF;

            // Assert
            Assert.AreEqual(-3, result);
        }

        [TestMethod]
        public void TemperatureF_WhenTemperatureCIsTwentyFive_ReturnsSeventySix()
        {
            // Arrange
            var weatherForecast = new WeatherForecast { TemperatureC = 25 };

            // Act
            var result = weatherForecast.TemperatureF;

            // Assert
            Assert.AreEqual(76, result);
        }

        [TestMethod]
        public void TemperatureF_WhenTemperatureCIsNegativeForty_ReturnsNegativeThirtyNine()
        {
            // Arrange
            var weatherForecast = new WeatherForecast { TemperatureC = -40 };

            // Act
            var result = weatherForecast.TemperatureF;

            // Assert
            Assert.AreEqual(-39, result);
        }

        [TestMethod]
        [DataRow(0, 32)]
        [DataRow(100, 211)]
        [DataRow(-20, -3)]
        [DataRow(25, 76)]
        [DataRow(-40, -39)]
        [DataRow(50, 121)]
        [DataRow(-10, 15)]
        [DataRow(37, 98)] // Body temperature approximation
        public void TemperatureF_VariousTemperatures_ReturnsExpectedValues(int celsius, int expectedFahrenheit)
        {
            // Arrange
            var weatherForecast = new WeatherForecast { TemperatureC = celsius };

            // Act
            var result = weatherForecast.TemperatureF;

            // Assert
            Assert.AreEqual(expectedFahrenheit, result,
                $"Failed for {celsius}°C. Expected: {expectedFahrenheit}°F, Actual: {result}°F");
        }

        [TestMethod]
        public void TemperatureF_FormulaValidation_UsesCorrectCalculation()
        {
            // Arrange - Test the specific formula: 32 + (int)(TemperatureC / 0.5556)
            var weatherForecast = new WeatherForecast { TemperatureC = 20 };

            // Act
            var result = weatherForecast.TemperatureF;
            var expectedResult = 32 + (int)(20 / 0.5556);

            // Assert
            Assert.AreEqual(expectedResult, result);
            Assert.AreEqual(67, result); // 20°C should give 67°F with this formula
        }
    }
}
