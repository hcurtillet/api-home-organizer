using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using HomeOrganizer.API.Extensions;
using HomeOrganizer.API.Filters;
using HomeOrganizer.Application;
using HomeOrganizer.Application.Common.Interfaces;
using HomeOrganizer.Application.Extensions;
using HomeOrganizer.Infrastructure;
using HomeOrganizer.Infrastructure.Authentication;
using HomeOrganizer.Infrastructure.Extensions;
using Org.BouncyCastle.Crypto.Utilities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICurrentUser, CurrentUser>();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacModule());
});

var configuration = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<MappingProfile>();
});

builder.Services.AddSingleton<IMapper>(sp => new Mapper(configuration, sp.GetRequiredService));
builder.Services.AddApplication();
// Add services to the container.

builder.Services.AddControllers(o =>
{
    o.Filters.Add<FirebaseAuthenticationFilter>();
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();