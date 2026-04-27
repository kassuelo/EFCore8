using Curso.API.DbContexts;
using Curso.API.Entities;
using Curso.API.Models;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Context>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("EFCoreConsole"))
            .LogTo(Console.WriteLine, LogLevel.Information)
);

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

app.MapGet("/diretores/agregacao/{nome}", (string nome, Context context) =>
{
    return context.Diretores
        .Include(diretor => diretor.Filmes)
        //.Select(diretor => diretor.Nome)
        //.OrderByDescending()
        .FirstOrDefault(diretor => diretor.Nome.Contains(nome)) ?? new Diretor { Id = 9999, Nome = "Maria" };
})
.WithOpenApi();

app.MapGet("/diretores/where/{id}", (int id, Context context) =>
{
    return context.Diretores
        .Include(d => d.Filmes)
        .Where(diretor => diretor.Id == id)
        .ToList();
})
.WithOpenApi();

app.MapGet("/filmes", (Context context) =>
{
    return context.Filmes
        .Include(filme => filme.Diretor)
        .OrderByDescending(filme => filme.Ano)
        .ThenBy(filme => filme.Titulo)
        .ToList();
})
.WithOpenApi();


app.MapGet("/filmes/{id}", (int id, Context context) =>
{
    return context.Filmes
        .Where(filme => filme.Id == id)
        .Include(filme => filme.Diretor).ToList();
})
.WithOpenApi();

app.MapGet("/filmesEFFunction/byName/{titulo}", (string titulo, Context context) =>
{
    return context.Filmes
        .Where(filme =>
            EF.Functions.Like(filme.Titulo, $"%{titulo}%")
        )
        .Include(filme => filme.Diretor).ToList();
})
.WithOpenApi();

app.MapGet("/filmesLinQ/byName/{titulo}", (string titulo, Context context) =>
{
    return context.Filmes
        .Where(filme => filme.Titulo.Contains(titulo))
        .Include(filme => filme.Diretor).ToList();
})
.WithOpenApi();

app.MapPost("/diretores", (Context context, Diretor diretor) =>
{
    //garante vinculo explícito
    if (diretor.Filmes is not null)
    {
        foreach (var filme in diretor.Filmes)
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
    if (diretor is null)
    {
        return Results.NotFound();
    }

    diretor.Nome = input.Nome;
    context.Diretores.Update(diretor);

    var filmesInput = input.Filmes ?? new List<Filme>();

    //remove filmes que não vieram no input
    var filmesParaRemover = diretor.Filmes.Where(f => !filmesInput.Any(i => i.Id == f.Id)).ToList();
    foreach (var filme in filmesParaRemover)
    {
        context.Filmes.Remove(filme);
    }

    //adiciona ou atualiza
    foreach (var filmeInput in filmesInput)
    {
        var filmeExistente = diretor.Filmes.FirstOrDefault(f => f.Id == filmeInput.Id);

        if (filmeExistente is null)
        {
            //novo 
            var novoFilme = new Filme
            {
                Titulo = filmeInput.Titulo,
                Ano = filmeInput.Ano,
                DiretorId = diretor.Id
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

app.MapDelete("/filmes/{filmeId}", (Context context, int filmeId) =>
{
    context.Filmes.Where(filme => filme.Id == filmeId).ExecuteDelete<Filme>();
})
.WithOpenApi();

app.MapPatch("/filmesUpdate", (Context context, FilmeUpdate filmeUpdate) =>
{
    var filme = context.Filmes.Find(filmeUpdate.Id);
    if(filme == null)
    {
        return Results.NotFound("Filme não encontrado");
    }

    filme.Titulo = filmeUpdate.Titulo;
    filme.Ano = filmeUpdate.Ano;

    context.Filmes.Update(filme);
    context.SaveChanges();
    return Results.Ok("Filme atualizado com sucesso");
})
.WithOpenApi();


app.MapPatch("/filmesExecuteUpdate", (Context context, FilmeUpdate filmeUpdate) =>
{
    var linhasAfetadas = context.Filmes.Where(filme => filme.Id == filmeUpdate.Id)
        .ExecuteUpdate<Filme>(setter => setter
            .SetProperty(f => f.Titulo, filmeUpdate.Titulo)
            .SetProperty(f => f.Ano, filmeUpdate.Ano));

    if(linhasAfetadas > 0)
    {
        return Results.Ok($"Você teve um total de {linhasAfetadas} linhas afetadas");
    }
    else
    {
        return Results.NoContent();
    }
})
.WithOpenApi();

app.MapDelete("/diretores/{diretorId}", (Context context, int diretorId) =>
{
    var diretor = context.Diretores.FirstOrDefault(d => d.Id == diretorId);
    if (diretor is null)
    {
        return Results.NotFound();
    }
    context.Diretores.Remove(diretor);
    context.SaveChanges();
    return Results.NoContent();

})
.WithOpenApi();

app.Run();
