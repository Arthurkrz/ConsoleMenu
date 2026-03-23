using ConsoleMenu.IOC;
using ConsoleMenu.Tests;
using ConsoleMenu.Tests.IOC;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection()
    .InjectServices()
    .InjectHandlers();

services.AddConsoleMenu();

var startup = new Startup(services.BuildServiceProvider());

// startup.ExecuteWithoutHandlers();
// startup.ExecuteWithHandlers();