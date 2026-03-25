using ConsoleMenu.Contracts;
using ConsoleMenu.Entities;
using ConsoleMenu.Enum;
using ConsoleMenu.IOC;
using ConsoleMenu.Tests.Utilities;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleMenu.Tests
{
    public class DependencyInjectionTests
    {
        [Fact]
        public void DependencyInjection_ShouldInjectHandlersIntoExecutor()
        {
            // Arrange
            var services = new ServiceCollection();

            services.AddConsoleMenu();
            services.AddSingleton<IConsoleWrapper, FakeWrapper>();
            services.AddSingleton<IConsoleMenuHandler>(new FakeHandler("test"));

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
