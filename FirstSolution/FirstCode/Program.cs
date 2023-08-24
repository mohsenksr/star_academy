using System;
using System.Text.Json;
using FirstCode;
using FirstCode.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace FirstCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();

            services.AddSingleton<Main>();
            services.AddSingleton<StudentWorker>();
            services.AddSingleton<ICalculator, Calculator>();   
            services.AddSingleton<IUtils, Utils>();

            var serviceProvider = services.BuildServiceProvider();

            var main = serviceProvider.GetRequiredService<Main>();
            
            main.Execute();
        }
    }
}