using ConsoleMenu.Application;
using ConsoleMenu.Entities;
using ConsoleMenu.Tests.UnitTests.Utilities;
using Xunit;

namespace ConsoleMenu.ManualTests.UnitTests
{
    public class ConsoleMenuSelectorTests
    {
        private readonly FakeWrapper _console = new();
        private readonly ConsoleMenuSelector _sut = new(new FakeWrapper());

        [Fact]
        public void ObtainOption_ShouldReturnCorrectOption()
        {
            // Arrange
            _console.EnqueueKey('2');

            var options = new[]
            {
                ConsoleMenuOption.Create(1, "Option 1", () => { }),
                ConsoleMenuOption.Create(2, "Option 2", () => { })
            };

            // Act
            var result = _sut.ObtainOption(options);

            // Assert
            Assert.Equal(2, result.Id);
        }

        [Fact]
        public void ObtainOption_ShouldAllowRetry()
        {
            // Arrange
            _console.EnqueueKey('9');
            _console.EnqueueKey('1');

            var options = new[]
                { ConsoleMenuOption.Create(1, "Option 1", () => { }) };

            // Act
            var result = _sut.ObtainOption(options);

            // Assert
            Assert.Equal(1, result.Id);
            Assert.Contains(_console.ColoredLines, x => x.Color == ConsoleColor.Red);
        }

        [Fact]
        public void ObtainOption_ShouldThrowException_WhenNoOptionsProvided()
        {
            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => 
                _sut.ObtainOption(Array.Empty<ConsoleMenuOption>()));
        }

        [Fact]
        public void ObtainOption_ShouldThrowException_WhenDuplicateIds()
        {
            // Arrange
            var options = new[]
            {
                ConsoleMenuOption.Create(1, "Option 1", () => { }),
                ConsoleMenuOption.Create(1, "Option 2", () => { })
            };

            // Act & Assert
            Assert.Throws<InvalidOperationException>(
                () => _sut.ObtainOption(options));
        }
    }
}
