using Microsoft.Extensions.DependencyInjection;
using System;
using System.Runtime.CompilerServices;
using TranscriptManagement.Commands;
using TranscriptManagement.RepositoryInterfaces;
using TranscriptManagement.TranscriptManager;
using TranscriptManagement.UserInterfaces;
using TranscriptManagerClient;
using TranscriptManagerPersistence.Paths;
using TranscriptManagerPersistence.Repositories;

namespace TranscriptManagerApp
{
    class Program
    {
        static void Main(string[] args)
        {

            IServiceCollection services = new ServiceCollection();
            Configure(services);
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            var service = serviceProvider.GetService<ITranscriptServices>();
            service.Run();


        }

        private static void Configure(IServiceCollection services)
        {
            services.AddTransient<IFilePaths, FilePaths>();
            services.AddTransient<IUserInterface, ConsoleUserInterface>();
            services.AddTransient<ITranscriptServices, TranscriptServices>();
            services.AddTransient<ITranscriptDesigner, TranscriptDesigner>();
            services.AddTransient<ITranscriptCalculator, TranscriptCalculator>();
            services.AddTransient<Func<string, TranscriptCommand>>(TranscriptCommand.GetTranscriptCommand);

            services.AddSingleton<IModelCOntext, ModelContext>();
            
        }
    }
}
