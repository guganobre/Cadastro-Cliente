using GestaoCliente.Infra.IoC;
using GestaoCliente.Presentation.Web.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var configuration = builder.Configuration;
var services = builder.Services;

services.AddRepository(configuration);
services.AddService();
services.AddAutoMapper();

services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;  // Garante que o cookie n�o seja acessado via JS
    options.Cookie.IsEssential = true; // Torna o cookie essencial para a aplica��o
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Tempo de expira��o da sess�o
});

builder.AddConfiguration();