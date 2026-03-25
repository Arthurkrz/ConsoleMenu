using ConsoleMenu.Application;
using ConsoleMenu.Contracts;
using ConsoleMenu.Entities;
using ConsoleMenu.Enum;
using ConsoleMenu.Tests.Utilities;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleMenu.Tests
{
    public class ConsoleMenuExecutorTests
    {
        private ConsoleMenuExecutor _sut = new(Array.Empty<IConsoleMenuHandler>(), new FakeWrapper());

        [Fact]
        public void Execute_ShouldRunAction()
        {
            // Arrange
            var called = false;
            var option = ConsoleMenuOption.Create(1, "Test", () => called = true);

            // Act
            var result = _sut.Execute(option);

            // Assert
            Assert.True(called);
            Assert.Equal(MenuExecutionResult.Continue, result);
        }

        [Fact]
        public void Execute_ShouldRunHandler()
        {
            // Arrange
            var handler = new FakeHandler("test");
            _sut = new ConsoleMenuExecutor(new[] { handler }, new FakeWrapper());

            var option = ConsoleMenuOption.CreateWithHandler(1, "Test", "test");

            // Act
            var result = _sut.Execute(option);

            // Assert
            Assert.True(handler.IsExecuted);
            Assert.Equal(MenuExecutionResult.Continue, result);
        }

        [Fact]
        public void Execute_ShouldExit()
        {
            // Arrange
            var option = ConsoleMenuOption.CreateExit(1, "Exit");

            // Act
            var result = _sut.Execute(option);

            // Assert
            Assert.Equal(MenuExecutionResult.Exit, result);
        }

        [Fact]
        public void Execute_ShouldThrowException_WhenDuplicateHandlers()
        {
            // Arrange
            var handlers = new[]
            {
                new FakeHandler("duplicate"),
                new FakeHandler("duplicate")
            };

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() =>
                new ConsoleMenuExecutor(handlers, new FakeWrapper()));
        }

        [Fact]
        public void Execute_ShouldThrowException_WhenDIInjectsDuplicateHandlers()
        {
            // Arrange
            var services = new ServiceCollection();

            services.AddSingleton<IConsoleMenuHandler>(new FakeHandler("key"));
            services.AddSingleton<IConsoleMenuHandler>(new FakeHandler("key"));

            services.AddSingleton<IConsoleWrapper, FakeWrapper>();

            var provider = services.BuildServiceProvider();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() =>
                provider.GetRequiredService<IConsoleMenuExecutor>());
        }

        [Fact]
        public void Execute_ShouldThrowException_WhenHandlerNotFound()
        {
            // Arrange
            var option = ConsoleMenuOption.CreateWithHandler(1, "Test", "missing");

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => _sut.Execute(option));
        }
    }
}
