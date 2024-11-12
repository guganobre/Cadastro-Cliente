using AutoMapper;
using GestaoCliente.Core.Application.Helpers;
using GestaoCliente.Presentation.Web.Helpers;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace GestaoCliente.Presentation.Web.Configurations
{
    public static class AppConfiguration
    {
        public static WebApplicationBuilder? AddConfiguration(this WebApplicationBuilder builder)
        {
            var defaultCulture = new CultureInfo("pt-BR");
            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(defaultCulture),
                SupportedCultures = new List<CultureInfo> { defaultCulture },
                SupportedUICultures = new List<CultureInfo> { defaultCulture }
            };

            // config app
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseRequestLocalization(localizationOptions);

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();

            return builder;
        }

        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddSingleton(new MapperConfiguration(config =>
                                                            config.ConfigurationApplicationMap()
                                                                    .ConfigurationServiceMap()
                                                        ).CreateMapper());

            return services;
        }
    }
}