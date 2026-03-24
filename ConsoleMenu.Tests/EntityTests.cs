using ConsoleMenu.Entities;
using Xunit;

namespace ConsoleMenu.ManualTests.UnitTests
{
    public class EntityTests
    {
        [Fact]
        public void Create_ShouldThrowException_WhenInvalidId()
        {
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                ConsoleMenuOption.Create(0, "Invalid", () => { }));
        }

        [Fact]
        public void CreateWithHandler_ShouldThrowException_WhenEmptyKey()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
                ConsoleMenuOption.CreateWithHandler(1, "Test", ""));
        }
    }
}
