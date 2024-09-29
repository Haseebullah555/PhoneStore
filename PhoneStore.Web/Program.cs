using Microsoft.AspNetCore.Localization;
using PhoneStore.Web.Resources;
using System.Globalization;
using System.Reflection;
using PhoneStore.Persistence;
using PhoneStore.Application;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<LocService>();
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.Configure<RequestLocalizationOptions>(
             options =>
             {
                 var supportedCultures = new List<CultureInfo>
                     {
                         new CultureInfo("ps-AF"),
                         new CultureInfo("fa"),
                         new CultureInfo("en")
                     };
                 options.DefaultRequestCulture = new RequestCulture("ps-AF");
                 options.SupportedCultures = supportedCultures;
                 options.SupportedUICultures = supportedCultures;
                 options.RequestCultureProviders.Insert(0, new QueryStringRequestCultureProvider());
             });

builder.Services.AddMvc()
            .AddViewLocalization()
            .AddDataAnnotationsLocalization(options =>
            {
                options.DataAnnotationLocalizerProvider = (type, factory) =>
                {
                    var assemblyName = new AssemblyName(typeof(SharedResource).GetTypeInfo().Assembly.FullName);
                    return factory.Create("SharedResource", assemblyName.Name);
                };
            });
builder.Services.ConfigureApplicationServices();
builder.Services.ConfigurePersistenceServices(builder.Configuration);
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build(); 
app.UseRequestLocalization(
app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
