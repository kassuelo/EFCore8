using Curso.API.DbContexts;
using Curso.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Context>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ConnectionStrings:EFCoreConsole"))
);

//using (var context = new Context())
//{
//    context.Database.EnsureCreated();
//}

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.AllowTrailingCommas = true;
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/diretores", (Context context) =>
{
    return context.Diretores.Include(d => d.Filmes).ToList();
})
.WithOpenApi();

app.MapPost("/diretores", (Context context, Diretor diretor) =>
{
    //garante vinculo explícito
    if(diretor.Filmes is not null)
    {
        foreach(var filme in diretor.Filmes)
        {
            filme.Diretor = diretor;
        }
    }
    context.Diretores.Add(diretor);
    context.SaveChanges();
    return Results.Created($"/diretor/{diretor.Id}", diretor);
})
.WithOpenApi();

app.MapPut("/diretores/{diretorId}", (Context context, int diretorId, Diretor input) =>
{
    var diretor = context.Diretores.Include(diretor => diretor.Filmes).FirstOrDefault(d => d.Id == diretorId);
    if(diretor is null)
    {
        return Results.NotFound();
    }

    diretor.Nome = input.Nome;
    context.Diretores.Update(diretor);

    var filmesInput = input.Filmes ?? new List<Filme>();

    //remove filmes que não vieram no input
    var filmesParaRemover = diretor.Filmes.Where(f => !filmesInput.Any(i => i.Id == f.Id)).ToList();
    foreach(var filme in filmesParaRemover)
    {
        context.Filmes.Remove(filme);
    }

    //adiciona ou atualiza
    foreach(var filmeInput in filmesInput)
    {
        var filmeExistente = diretor.Filmes.FirstOrDefault(f => f.Id == filmeInput.Id);

        if(filmeExistente is null)
        {
            //novo 
            var novoFilme = new Filme
            {
                Titulo = filmeInput.Titulo,
                Ano = filmeInput.Ano,
                Diretor = diretor
            };
            context.Filmes.Add(novoFilme);
        }
        else
        {
            //atualiza
            filmeExistente.Titulo = filmeInput.Titulo;
            filmeExistente.Ano = filmeInput.Ano;
            filmeExistente.Diretor = diretor;

            context.Filmes.Update(filmeExistente);
        }
    }
    context.SaveChanges();
    return Results.Ok();
})
.WithOpenApi();

app.MapDelete("/diretores/{diretorId}", (Context context, int diretorId) =>
{
    var diretor = context.Diretores.FirstOrDefault(d => d.Id == diretorId);
    if(diretor is null)
    {
        return Results.NotFound();
    }
    context.Diretores.Remove(diretor);
    context.SaveChanges();
    return Results.NoContent();

})
.WithOpenApi();

app.Run();
