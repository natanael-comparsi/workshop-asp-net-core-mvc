using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SalesWebMvc.Data;
using System.Configuration;
using SalesWebMvc.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuração do provider do MySQL a partir da definição do DbContext
builder.Services.AddDbContext<SalesWebMvcContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("SalesWebMvcContext"),
                     new MySqlServerVersion(new Version(8, 0, 42)), // Deve ser inserida a versão do MySQL utilizada
                     mysqlOptions => mysqlOptions.MigrationsAssembly("SalesWebMvc")));

// Registra o serviço 'SeedingService' no sistema de injeção de dependencia da aplicação
builder.Services.AddScoped<SeedingService>();

// Registra o serviço 'SellerService' no sistema de injeção de dependencia da aplicação
builder.Services.AddScoped<SellerService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Chama o método para popular o banco de dados caso a base de dados não esteja populada ainda
app.Services.CreateScope().ServiceProvider.GetRequiredService<SeedingService>().Seed();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

// Definição de padrão(pattern) do controlador da rota
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
