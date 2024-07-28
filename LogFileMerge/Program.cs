using LogFileMerge.Repositories.LogFileMergeRepository;
using Microsoft.Extensions.DependencyInjection;

namespace LogFileMerge
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Seting up Dependency Injection
            var services = new ServiceCollection();

            services.AddTransient<Form1>();
            services.AddScoped<ILogsMergeRepository, LogsMergeRepository>();                  

            using ServiceProvider service = services.BuildServiceProvider(); 
            var form1 = service.GetRequiredService<Form1>();
                                    
            Application.Run(form1);
        }        
    }
}