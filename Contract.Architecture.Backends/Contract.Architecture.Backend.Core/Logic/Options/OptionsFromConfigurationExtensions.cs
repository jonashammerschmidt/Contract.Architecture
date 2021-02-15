using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Contract.Architecture.Backend.Core.Logic
{
    internal static class OptionsFromConfigurationExtensions
    {
        public static void AddOptionsFromConfiguration<T>(this IServiceCollection services, IConfiguration configuration)
            where T : OptionsFromConfiguration
        {
            T optionsInstance = (T)Activator.CreateInstance(typeof(T));
            string position = optionsInstance.Position;
            services.Configure((Action<T>)(options =>
            {
                IConfigurationSection section = configuration.GetSection(position);
                if (section != null)
                {
                    section.Bind(options);
                }
            }));
        }
    }
}