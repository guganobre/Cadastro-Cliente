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

builder.AddConfiguration();