using ConsoleMenu.Contracts;
using ConsoleMenu.Entities;
using ConsoleMenu.Enum;
using ConsoleMenu.IOC;
using ConsoleMenu.Tests.UnitTests.Utilities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace ConsoleMenu.ManualTests.UnitTests
{
    public class DependencyInjectionTests
    {
        [Fact]
        public void DependencyInjection_ShouldInjectHandlersIntoExecutor()
        {
            // Arrange
            var services = new ServiceCollection();

            services.AddConsoleMenu();
            services.AddSingleton<IConsoleMenuHandler, FakeHandler>();

            var provider = services.BuildServiceProvider();
            var executor = provider.GetRequiredService<IConsoleMenuExecutor>();

            var option = ConsoleMenuOption.CreateWithHandler(1, "Test", "test");

            // Act
            var result = executor.Execute(option);

            // Assert
            Assert.Equal(MenuExecutionResult.Continue, result);
        }
    }
}
