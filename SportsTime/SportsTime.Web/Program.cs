using AutoMapper;
using SportsTime.Repositories;
using SportsTime.Services.AutoMapper;
using SportsTime.Web.Extensions;
using SportsTime.Web.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Globalization;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using SportsTime.Repositories.Extensions.Interface;
using SportsTime.Repositories.Extensions.Implementation;
using SportsTime.Data.Entities;
using SportsTime.Resources.Resources;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient(typeof(IUserAccessor), typeof(UserAccessor));

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("SportsTimeContextConnection") ?? throw new InvalidOperationException("Connection string 'SportsTimeContextConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();

builder.Services.AddLocalization(options => { options.ResourcesPath = "Resources"; });

//builder.Services.AddAutoMapper();
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddSingleton<LocalizeService>();
//builder.Services.AddSingleton<ConfigurationService>();

builder.Services.AddMvc(options => options.EnableEndpointRouting = false)
 .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix, options => { options.ResourcesPath = "Resources"; })
 .AddDataAnnotationsLocalization(options =>
 {
     options.DataAnnotationLocalizerProvider = (type, factory) =>
     {
         var assemblyName = new AssemblyName(typeof(Resource).GetTypeInfo().Assembly.FullName);
         return factory.Create("CultureResource", assemblyName.Name);
     };
 });

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new List<CultureInfo> { new CultureInfo("en-US"), new CultureInfo("ar-JO") { NumberFormat = new NumberFormatInfo { NumberDecimalSeparator = "." } }, };
    options.DefaultRequestCulture = new RequestCulture("en-US");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});
builder.Services.Configure<IISServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
});
//builder.Services.AddHttpClient<ReCaptcha>(x =>
//{
//    x.BaseAddress = new Uri("https://www.google.com/recaptcha/api/siteverify");
//});
builder.Services.AddHttpContextAccessor();

builder.Services.AddRepositoryLayer();

builder.Services.AddServicesLayer();

builder.Services.AddSession();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseDefaultFiles();

app.UseSession();

var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(options.Value);

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();






