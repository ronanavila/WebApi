using FastTech.Aplication.Services.ProductHandlers;
using FastTech.Core.MediatR;
using FastTech.Domain.Interfaces.Repositories;
using FastTech.Infrastructure.Context;
using FastTech.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDBContext>(options => 
                                   options.UseSqlServer(builder.Configuration.GetConnectionString("FastTechConnection")));

builder.Services.AddMediatR(typeof(Program));
builder.Services.AddScoped<IMediatrHandler, MediatrHandler>();
builder.Services.AddScoped<IRequestHandler<RegisterProductCommand, bool>,ProductCommandHandler>();

builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

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
