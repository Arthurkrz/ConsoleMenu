using ConsoleMenu.Application;
using ConsoleMenu.Entities;
using ConsoleMenu.Tests.Utilities;

namespace ConsoleMenu.Tests
{
    public class ConsoleMenuSetupTests
    {
        [Fact]
        public async Task Run_ShouldLoopUntilExit()
        {
            // Arrange
            var option = ConsoleMenuOption.Create(1, "Test", () => { });
            var exit = ConsoleMenuOption.CreateExit(2, "Exit");

            var selector = new FakeSelector(new[] { option, option, exit });
            var executor = new FakeExecutor();

            var sut = new ConsoleMenuSetup(selector, executor);
            sut.AddOption(1, "Test", () => { });
            sut.AddExitOption(2, "Exit");

            // Act
            await sut.Run();

            // Assert
            Assert.Equal(3, executor.ExecutionCount);
        }
    }
}
