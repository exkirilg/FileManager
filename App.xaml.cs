using FileManager.FileSystem;
using FileManager.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace FileManager;

public partial class App : Application
{
	public static IHost? AppHost { get; private set; } 

	public App()
	{
		AppHost = Host.CreateDefaultBuilder()
			.ConfigureServices((hostContext, services) =>
			{
				services.AddSingleton<MainWindow>();
				services.AddSingleton<IFileSystemServices, FileSystemServices>();
				services.AddSingleton<AppVM>();
				services.AddDbContext<ApplicationContext>(options =>
				{
					options.UseSqlite("Data Source=FileManager.db");
				});
			})
			.Build();
	}

	protected override async void OnStartup(StartupEventArgs e)
	{
		await AppHost!.StartAsync();

		await AppHost.Services.GetRequiredService<ApplicationContext>().Database.EnsureCreatedAsync();

		var startupForm = AppHost.Services.GetRequiredService<MainWindow>();
		startupForm.Show();

		base.OnStartup(e);
	}

	protected override async void OnExit(ExitEventArgs e)
	{
		await AppHost!.StopAsync();

		base.OnExit(e);
	}
}
