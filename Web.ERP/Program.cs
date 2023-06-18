
using Infrastructure.BL.Data;
using Microsoft.EntityFrameworkCore;
using DominCore.Entity;
using Microsoft.AspNetCore.Identity;
using Infrastructure.BL.Seeds;
using System.Reflection;
using Web.ERP.AutoMapperMaping;
using DominCore.IServices;
using Web.ERP.Services;
using Microsoft.AspNetCore.Mvc.Razor;
using Web.ERP.Languages;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddDbContext<ApplicationDBContext>
builder.Services.AddDbContext<ApplicationDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString ("DefaultConnection")));


builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    //mmkn n3mlo btre2a tanya 
    options.SignIn.RequireConfirmedPhoneNumber = true;//m7tag al8y email confirmed 8er lma ana a3mlo confirmation 
    options.Password.RequireDigit = false;//lazm password ygy rakm 
    options.Password.RequireUppercase= false;//mch lazm ykon yper or lower or number
    options.Password.RequireLowercase= false;
    options.Password.RequiredLength= 5;
    options.Password.RequireNonAlphanumeric= false;//mch lazm tkon 7rof bs 
    options.Password.RequiredUniqueChars= 0;
}).AddEntityFrameworkStores<ApplicationDBContext>();



//Language
builder.Services.AddSingleton<ResourceWebServices>();//AddSingleton is a generic service collection 
builder.Services.AddLocalization(options => options.ResourcesPath="Resources");
builder.Services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization(options =>
    {
        options.DataAnnotationLocalizerProvider = (type, factory) =>
        {
            var assemblyName = new AssemblyName(typeof(ResourceWeb).GetTypeInfo().Assembly.FullName!);
            return factory.Create("ResourceWeb",assemblyName.Name!);
            
        };
    });




//builder.Services.Configure<IdentityOptions>(options =>
//{
//    options.SignIn.RequireConfirmedPhoneNumber = true;//m7tag al8y email confirmed 8er lma ana a3mlo confirmation 
//    options.Password.RequireDigit = false;//lazm password ygy rakm 
//    options.Password.RequireUppercase = false;//mch lazm ykon yper or lower or number
//    options.Password.RequireLowercase = false;
//    options.Password.RequiredLength = 5;
//    options.Password.RequireNonAlphanumeric = false;//mch lazm tkon 7rof bs 
//    options.Password.RequiredUniqueChars = 0;
//});




//inject auto mapper
builder.Services.AddSession();
builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));

builder.Services.AddScoped<IServices<RoleModel>, ServicesRoles>();

var app = builder.Build();



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
app.UseSession();

app.UseAuthorization();

//Language 
var SupportedCulter = new[] { "ar", "en" };
app.UseRequestLocalization(new RequestLocalizationOptions()
    .SetDefaultCulture(SupportedCulter[0])
    .AddSupportedCultures(SupportedCulter)
    .AddSupportedUICultures(SupportedCulter)
    );
    



//Add Default Data of company and branch 
using var ScopeServices = app.Services.CreateScope();// creating scope to add deafult data 
var services = ScopeServices.ServiceProvider;
var context = services.GetRequiredService<ApplicationDBContext> ();// get service of data base 
DefaultData.SeedCompany(context);
DefaultData.SeedBranch(context);

///////
///

///Add Roles And Users 
///

var ScopeFactory = app.Services.GetRequiredService<IServiceScopeFactory> ();
using var scope =ScopeFactory.CreateScope();
var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

await DefaultRoles.SeedsRolesAsync(roleManager);
//users 
await DefaultUsers.SeedFullOwnerAsync(userManager,context);
await DefaultUsers.SeedOwnerCompanyAsync(userManager, context);
await DefaultUsers.SeedBranchManagerAsync(userManager, context);





app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
