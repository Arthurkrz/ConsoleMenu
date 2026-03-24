using ConsoleMenu.Contracts;
using ConsoleMenu.Entities;
using ConsoleMenu.Enum;
using ConsoleMenu.IOC;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace ConsoleMenu.Tests.UnitTests
{
    public class DependencyInjectionTests
    {
        [Fact]
        public void DependencyInjection_ShouldInjectHandlersIntoExecutor()
        {
            // Arrange
            var services = new ServiceCollection();

            services.AddConsoleMenu();
            services.AddSingleton<IConsoleMenuHandler, TestHandler>();

            var provider = services.BuildServiceProvider();
            var executor = provider.GetService<IConsoleMenuExecutor>();

            var option = ConsoleMenuOption.CreateWithHandler(1, "Test", "test");

            // Act
            var result = executor.Execute(option);

            // Assert
            Assert.Equal(MenuExecutionResult.Continue, result);
        }
    }
}
